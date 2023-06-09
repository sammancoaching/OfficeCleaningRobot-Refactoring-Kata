using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace OfficeCleaner2
{
    /// <summary>
    /// Models a visiting robot
    /// </summary>
    public class RobotCleaner
    {
        private List<ISegment> segments = new List<ISegment>();   //a list containing paths already taken by a robot
        private long uniqiePlacesVisited=0;
        private ISegment currentSegment;
        private int startingX;
        private int startingY;

        /// <summary>
        /// Starting Y coordinate for a robot.
        /// </summary>
        public int StartingY
        {
            get { return startingY; }
            set { startingY = value; }
        }
        
        /// <summary>
        /// Starting X coordinate for a robot.
        /// </summary>
        public int StartingX
        {
            get { return startingX; }
            set { startingX = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RobotCleaner() 
        {
            InitializeRobot(0, 0);
        }

        /// <summary>
        /// Sets initial coordinates for the robot
        /// </summary>
        /// <param name="coord">Coordinates</param>
        public RobotCleaner(int x, int y)
        {
            InitializeRobot(x, y);
        }

        private void InitializeRobot(int x, int y)
        {
            startingX = x;
            startingY = y;
        }

        /// <summary>
        /// Visits the plateau area based on a command queue
        /// </summary>
        /// <param name="commands">Command queue</param>
        public void VisitOffice(Queue<Command> commands)
        {
            int numOfCommands = commands.Count;
            for (int i = 0; i < numOfCommands; i++)
            {
                Command cmd = commands.Dequeue();
                if (cmd.Direction == Direction.West)
                    GoWest(cmd.NumOfSteps);
                else
                    if (cmd.Direction == Direction.South)
                        GoSouth(cmd.NumOfSteps);
                    else
                        if (cmd.Direction == Direction.North)
                            GoNorth(cmd.NumOfSteps);
                        else
                            if (cmd.Direction == Direction.East)
                                GoEast(cmd.NumOfSteps);
            }
        }

        /// <summary>
        /// Gets a number of unique plateau places (vertices) Visited
        /// </summary>
        /// <returns></returns>
        public long GetNumberOfUniquePlacesVisited()
        {
            return uniqiePlacesVisited;
        }

        /// <summary>
        /// Sets up a new segment for a robot to walk.
        /// </summary>
        /// <param name="dir">Command direction</param>
        /// <param name="numOfSteps">Number of steps to move in the said direction.</param>
        private void BuildNewSegment(Direction dir, int numOfSteps)
        {
            Coordinate startingCoords = new Coordinate();
            if (segments.Count != 0)    //other segments have been added previously 
            {
                //set starting coordinates of a new segment to ending coordinates of a previous segment
                startingCoords = currentSegment.GetEndingCoord();
            }
            else
                //for the first segment set starting coordinates to default starting coord for a robot
                startingCoords = new Coordinate(startingX,startingY);   //the very first segment

            //instantiate a correct instance of a segment based on a direction
            if (dir == Direction.North ||
                dir == Direction.South)
            {
                currentSegment = new VerticalSegment();
            }
            else if (dir == Direction.East ||
                dir == Direction.West)
            {
                currentSegment = new HorizontalSegment();
            }

            //set up the new segment
            currentSegment.SetCoordinates(startingCoords, dir, numOfSteps);
        }

        /// <summary>
        /// Returns a number of vertices in the current segment that have already been visited by previous segments.
        /// </summary>
        private int GetOverlappingVertices()
        {
            int numOfOverlappingVertices = 0;
            for (int i = 0; i < segments.Count; i++)
            {
                ISegment otherSegment = segments[i];
                int increment = currentSegment.GetOverlappingVerticesWith(otherSegment);
                if (increment == currentSegment.GetNumberOfAllVertices())
                {
                    //all vertices on currentSegment are overlapping
                    //no need to process the other segments in the list
                    numOfOverlappingVertices = increment;
                    break;
                }
                numOfOverlappingVertices +=increment;
            }
            currentSegment.ClearOverlappingVerticesCache();
            return numOfOverlappingVertices;
        }

        /// <summary>
        /// Moves the robot a number of steps in the northern direction
        /// </summary>
        /// <param name="numOfSteps">Number of steps to move towards North</param>
        private void GoNorth(int numOfSteps)
        {
            BuildNewSegment(Direction.North, numOfSteps);
            uniqiePlacesVisited += (numOfSteps + 1 - GetOverlappingVertices());
            //add current segment to a list of processed segments
            segments.Add(currentSegment);
        }

        /// <summary>
        /// Moves the robot a number of steps in the southern direction
        /// </summary>
        /// <param name="numOfSteps">Number of steps to move towards South</param>
        private void GoSouth(int numOfSteps)
        {
            BuildNewSegment(Direction.South, numOfSteps);
            uniqiePlacesVisited += (numOfSteps + 1 - GetOverlappingVertices());
            //add current segment to a list of processed segments
            segments.Add(currentSegment);
        }

        /// <summary>
        /// Moves the robot a number of steps in the western direction
        /// </summary>
        /// <param name="numOfSteps">Number of steps to move towards West</param>
        private void GoWest(int numOfSteps)
        {
            BuildNewSegment(Direction.West, numOfSteps);
            uniqiePlacesVisited+=(numOfSteps+1-GetOverlappingVertices());
            //add current segment to a list of processed segments
            segments.Add(currentSegment);
        }

        /// <summary>
        /// Moves the robot a number of steps in the eastern direction
        /// </summary>
        /// <param name="numOfSteps">Number of steps to move towards East</param>
        private void GoEast(int numOfSteps)
        {
            BuildNewSegment(Direction.East, numOfSteps);
            uniqiePlacesVisited+=(numOfSteps+1-GetOverlappingVertices());
            //add current segment to a list of processed segments
            segments.Add(currentSegment);
        }
    }
}
