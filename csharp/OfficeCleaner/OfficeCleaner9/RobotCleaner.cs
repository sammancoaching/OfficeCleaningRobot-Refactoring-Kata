
using System.Collections.Generic;
namespace OfficeCleaner9
{

    public class RobotCleaner
    {
        /// <summary>
        /// Directions NEWS = North, East, West, South
        /// </summary>
        const string DIRECTIONS = "NEWS";
        /// <summary>
        /// Maximum number of steps
        /// </summary>
        const int MAX_STEPS = 100000;
        /// <summary>
        /// Upper bounadry width of the room.
        /// from problem x(-100,000 <= x <= 100,000).
        /// </summary>
        private const int FLOOR_UPPER_WIDTH = 100000;
        /// <summary>
        /// Lower bounadry width of the room.
        /// from problem x(-100,000 <= x <= 100,000).
        /// </summary>
        private const int FLOOR_LOWER_WIDTH = -100000;
        /// <summary>
        /// Upper bounadry length of the room.
        /// from problem y(-100,000 <= y <= 100,000).
        /// </summary>
        private const int FLOOR_UPPER_LENGTH = 100000;
        /// <summary>
        /// Lower bounadry length of the room.
        /// from problem y(-100,000 <= y <= 100,000).
        /// </summary>
        private const int FLOOR_LOWER_LENGTH = -100000;
        /// <summary>
        /// Current Location X.
        /// </summary>
        private static int CURRENT_X;
        /// <summary>
        /// Current Location Y.
        /// </summary>
        private static int CURRENT_Y;

        /// <summary>
        /// Holds the x y coordiantes on floor.
        /// </summary>
        public struct Coordinates
        {
            public int X;
            public int Y;
            public Coordinates(int x, int y)
            {
                this.X = x;
                this.Y = y;
            }

            public override string ToString()
            {
                return "[" + this.X + ", " + this.Y + ", Visit]";
            }
        }
        /// <summary>
        /// Sorted List(for fast searching) of visited spaces(coordinates) on floor.
        /// </summary>
        public  SortedList<string, Coordinates> visitedPlaces = new SortedList<string, Coordinates>();

        /// <summary>
        /// Constructor with no parameter
        /// </summary>
        public RobotCleaner() { }

        /// <summary>
        /// Starts the robot at given location and Visit it 
        /// </summary>
        /// <param name="X">X coordinate</param>
        /// <param name="Y">Y coordiante</param>
        public void StartAt(int X, int Y)
        {
            CURRENT_X = X; // x(-100,000 <= x <= 100,000)
            CURRENT_Y = Y; //y(-100,000 <= y <= 100,000)
            //Visited start position,  (Key  = CURRENT_X + CURRENT_Y) for searching
            visitedPlaces.Add(string.Format("{0} {1}",CURRENT_X, CURRENT_Y), new Coordinates(CURRENT_X, CURRENT_Y));
        }

        /// <summary>
        /// Visits the floor 
        /// in direction
        /// with number of steps
        /// </summary>
        /// <param name="direction">Direction {'E', 'W', 'N', 'S'}</param>
        /// <param name="steps"></param>
        public void CleanFloor(char direction, int steps)
        {
            // if the correct direction is no given it exits
            if (!DIRECTIONS.Contains(direction.ToString()))
                return;
            //if steps is less than 0 or greater than MAX_STEPS it exits
            if (steps < 0 || steps > MAX_STEPS)
                return;
            switch (direction)
            {
                case 'N':
                    for (int i = 0; i < steps; i++)
                    {
                        //if robot is at the boundary of the floor it just stops there and wait for next direction 
                        if (CURRENT_Y + 1 > FLOOR_UPPER_LENGTH)
                        {
                            CURRENT_Y = FLOOR_UPPER_LENGTH;
                            break;
                        }
                        else
                        {
                            //if place is not visited
                            if (!visitedPlaces.ContainsKey(string.Format("{0} {1}", CURRENT_X, CURRENT_Y + 1)))
                            {
                                //Visit it and add to the visited places
                                visitedPlaces.Add(string.Format("{0} {1}", CURRENT_X, CURRENT_Y + 1), new Coordinates(CURRENT_X, ++CURRENT_Y));
                            }
                            else
                            {
                                //otherwise moves to the next location
                                ++CURRENT_Y;
                            }
                        }
                    }
                    break;
                case 'S':
                    for (int i = 0; i < steps; i++)
                    {
                        //if robot is at the boundary of the floor it just stops there and wait for next direction 
                        if (CURRENT_Y - 1 < FLOOR_LOWER_LENGTH)
                        {
                            CURRENT_Y = FLOOR_LOWER_LENGTH;
                            break;
                        }
                        else
                        {
                            //if place is not visited
                            if (!visitedPlaces.ContainsKey(string.Format("{0} {1}", CURRENT_X, CURRENT_Y - 1)))
                            {
                                //Visit it and add to the visited places
                                visitedPlaces.Add(string.Format("{0} {1}", CURRENT_X, CURRENT_Y - 1), new Coordinates(CURRENT_X, --CURRENT_Y));
                            }
                            else
                            {
                                //otherwise moves to the next location
                                --CURRENT_Y;
                            }
                        }
                    }
                    break;
                case 'E':
                    for (int i = 0; i < steps; i++)
                    {
                        //if robot is at the boundary of the floor it just stops there and wait for next direction 
                        if (CURRENT_X - 1 < FLOOR_LOWER_WIDTH)
                        {
                            CURRENT_X = FLOOR_LOWER_WIDTH;
                            break;
                        }
                        else
                        {
                            //if place is not visited
                            if (!visitedPlaces.ContainsKey(string.Format("{0} {1}", CURRENT_X - 1, CURRENT_Y)))
                            {
                                //Visit it and add to the visited places
                                visitedPlaces.Add(string.Format("{0} {1}", CURRENT_X - 1, CURRENT_Y), new Coordinates(--CURRENT_X, CURRENT_Y));
                            }
                            else
                            {
                                //otherwise moves to the next location
                                --CURRENT_X;
                            }
                        }
                    }
                    break;
                case 'W':
                    for (int i = 0; i < steps; i++)
                    {
                        //if robot is at the boundary of the floor it just stops there and wait for next direction 
                        if (CURRENT_X + 1 > FLOOR_UPPER_WIDTH)
                        {
                            CURRENT_X = FLOOR_UPPER_WIDTH;
                            break;
                        }
                        else
                        {
                            //if place is not visited
                            if (!visitedPlaces.ContainsKey(string.Format("{0} {1}", CURRENT_X + 1, CURRENT_Y)))
                            {
                                //Visit it and add to the visited places
                                visitedPlaces.Add(string.Format("{0} {1}", CURRENT_X + 1, CURRENT_Y), new Coordinates(++CURRENT_X, CURRENT_Y));
                            }
                            else
                            {
                                //otherwise moves to the next location
                                ++CURRENT_X;
                            }
                        }
                    }
                    break;
            }
        }

        public void PrintVisitedPlaces()
        {
            
                var result = "";
                foreach (var spot in visitedPlaces)
                {
                    result += spot.Value.ToString();
                    result += "\n";
                }
                //Console.Out.Write(result);
            
        }
    }
}
