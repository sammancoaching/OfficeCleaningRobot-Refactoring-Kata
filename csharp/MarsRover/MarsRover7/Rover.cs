using System.Drawing;
using System.Collections.Generic;
namespace MarsRover7
{
    /// <summary>
    /// This is the class implementing the robot
    /// </summary>
    public class Rover
    {
        #region Private members
        
        private Point currentPosition;
        private List<Point> cleanedPlaces;
        
        #endregion

        #region Public Properties
        
        public Point CurrentPosition
        {
            get { return currentPosition; }
            set 
            {
                currentPosition = value;
                //Every time the current position is set it means that the robot is at that position
                //so that position will be cleaned.
                //The following code tries to add this position to the already cleaned positions list.
                AddPlaceToCleaned(value);
            }
        }
        public int VisitedPlacesCount
        {
            get { return cleanedPlaces.Count; }
        }

        #endregion

        #region Ctor

        public Rover()
        {
            cleanedPlaces = new List<Point>();
            currentPosition = new Point();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// This method executes the given command.Depending on the direction and 
        /// the number of the steps, robot's current position changes which reflects in this place
        /// getting cleaned.
        /// </summary>
        /// <param name="command">Command to execute</param>
        public void ExecuteCommand(CommandDescription command)
        {
            for (int i = 0; i < command.Steps; i++)
            {
                switch (command.Direction)
                {
                    case CommandDirections.East:
                        CurrentPosition = new Point(currentPosition.X + 1, currentPosition.Y);
                        break;
                    case CommandDirections.West:
                        CurrentPosition = new Point(currentPosition.X - 1, currentPosition.Y);
                        break;
                    case CommandDirections.North:
                        CurrentPosition = new Point(currentPosition.X, currentPosition.Y + 1);
                        break;
                    case CommandDirections.South:
                        CurrentPosition = new Point(currentPosition.X, currentPosition.Y - 1);
                        break;
                    case CommandDirections.NoDirection:
                        //Robot stays on his place.
                        break;
                    default:
                        break;
                }
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Checks whether given place already exists in cleaned places collection
        /// </summary>
        /// <param name="placeToSearchFor">Place to search</param>
        /// <returns>True if robot has already been added to the cleaned places collection </returns>
        private bool IsPlaceAlreadyCleaned(Point placeToSearchFor)
        {
            foreach (Point point in cleanedPlaces)
            {
                if ((point.X == placeToSearchFor.X) && (point.Y == placeToSearchFor.Y))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Adds the place to the cleaned places collection
        /// </summary>
        /// <param name="place"></param>
        private void AddPlaceToCleaned(Point place)
        {
            if (!IsPlaceAlreadyCleaned(place))
            {
                cleanedPlaces.Add(place);
            }
        }

        #endregion

    }
}
