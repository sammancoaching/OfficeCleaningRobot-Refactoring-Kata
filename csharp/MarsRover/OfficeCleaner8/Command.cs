using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner8
{
    public class Command : ICommand
    {
        public enum Compass
        {
            north = 0,
            south = 1,
            west = 2,
            east = 3
        }

        private Compass direction;
        private int numberOfSteps;

        public Command() 
        {
        }

        public Command(Compass direction, int numberOfSteps)
        {
            Direction = direction;
            NumberOfSteps = numberOfSteps;
        }

        public Compass Direction
        {
            get { return this.direction; }
            set { direction = value; }
        }

        public int NumberOfSteps
        {
            get { return this.numberOfSteps; }
            set
            {
                if (value < 0 || value > 100000)
                    throw new InvalidNumberOfStepsException();
                numberOfSteps = value;
            }
        } 

        /// <summary>
        /// This methods executes a command, it starts to Visit at start
        /// and returns the list of all places that were Visited. The list
        /// might contain the same place more than once.
        /// </summary>
        /// <param name="start">Place from which the visiting starts.</param>
        /// <returns>All places that were Visited (non-unique).</returns>
        public IList<IPoint> Execute(IPoint start)
        {
            IList<IPoint> result = new List<IPoint>();
            IPoint newPoint = null;

            for (int i = 0; i < numberOfSteps; i++)
            {
                newPoint = new Point();
                switch(direction)       
                  {         
                     case Command.Compass.north:         
                        newPoint.X = start.X;
                        newPoint.Y = start.Y + 1;
                        break;
                     case Command.Compass.south:   
                        newPoint.X = start.X;
                        newPoint.Y = start.Y - 1;
                        break;                  
                     case Command.Compass.west:            
                        newPoint.X = start.X - 1;
                        newPoint.Y = start.Y;
                        break;
                     case Command.Compass.east:
                         newPoint.X = start.X + 1;
                         newPoint.Y = start.Y;
                         break;
                     default:            
                        break;      
                   }
                   start = newPoint;
                   result.Add(newPoint);
            }

            return result;
        }

    }
}
