using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner8
{
    public class RobotCleaner : IRobot
    {
        /// <summary> 
        /// This method implements visiting functionality. The visiting starts at 
        /// start place and continues according to each command in commands.
        /// </summary>
        /// <param name="start">Starting point from which the visiting begins.</param>
        /// <param name="commands">List of commands that define direction and number of steps for each command.</param>
        /// <returns>List of unique places that were Visited represented as points with x and y coordinates.</returns>
        public int move(IPoint start, IList<ICommand> commands)
        {
            if (start == null || commands == null)
            {
                throw new InvalidNullInputException();
            }

            if (commands != null && commands.Count > 10000)
            {
                throw new InvalidNumberOfCommandsException();
            }

            IList<IPoint> uniqueVisitedPlaces = new List<IPoint>();
            uniqueVisitedPlaces.Add(start);
            IList<IPoint> VisitedPlaces = null;
            IPoint startingPlace = start;

            foreach (ICommand command in commands)
            {
                VisitedPlaces = command.Execute(startingPlace);
                if (VisitedPlaces.Count > 0)
                {
                    startingPlace = VisitedPlaces[VisitedPlaces.Count - 1];
                    
                }

                foreach (IPoint VisitedPlace in VisitedPlaces)
                {
                    if (!uniqueVisitedPlaces.Contains(VisitedPlace))
                    {
                        uniqueVisitedPlaces.Add(VisitedPlace);
                    }
                }
            }

            return uniqueVisitedPlaces.Count;
        }
    }
}
