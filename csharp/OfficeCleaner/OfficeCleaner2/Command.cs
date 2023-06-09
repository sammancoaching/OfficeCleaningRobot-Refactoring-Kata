using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner2
{
    /// <summary>
    /// Models a robot command
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Command() { }

        /// <summary>
        /// Initializes direction and a number of steps
        /// </summary>
        /// <param name="dir">Direction</param>
        /// <param name="steps">Number of steps to move in the said direction</param>
        public Command(Direction dir, int steps)
        {
            direction = dir;
            numOfSteps = steps;
        }

        private Direction direction;

        /// <summary>
        /// Direction
        /// </summary>
        public Direction Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        private int numOfSteps;

        /// <summary>
        /// Number of steps to move in the indicated direction
        /// </summary>
        public int NumOfSteps
        {
            get { return numOfSteps; }
            set { numOfSteps = value; }
        }
    }
}
