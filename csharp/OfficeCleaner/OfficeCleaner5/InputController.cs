using System;
using System.Collections.Generic;

namespace OfficeCleaner5
{
    public class InputController : IInputController
    {
        private int coordinateX;
        private int coordinateY;
        public int[] InitialCoordinates
        {
            get { return new int[] {coordinateX, coordinateY}; }
        }

        private readonly List<MoveDirection> moveDirections = new List<MoveDirection>();
        public List<MoveDirection> MoveDirections
        {
            get { return moveDirections; }
        }

        public void ReadInputParameters()
        {
            char[] split = new char[] { Convert.ToChar(" ") };
            int numberOfCommands = Convert.ToInt32(System.Console.ReadLine());
            string inputString = System.Console.ReadLine();
            string[] inputParameters = inputString.Split(split, 2);
            try
            {
                coordinateX = Utility.ValidateCoordinateRange(Convert.ToInt32(inputParameters[0]));
                coordinateY = Utility.ValidateCoordinateRange(Convert.ToInt32(inputParameters[1]));
            }
            catch(OverflowException)
            {
                throw new OutOfCoordinateBoundsException();
            }
            catch(OutOfCoordinateBoundsException)
            {
                //handle logic
                System.Console.WriteLine("Coordinate out of range");
            }
            for ( int i = 0; i < numberOfCommands; i++ )
            {
                inputString = System.Console.ReadLine();
                try
                {
                    inputParameters = inputString.Split(split, 2);
                    MoveDirection md = new MoveDirection();
                    md.CompassDirection = Utility.ValidateCompassDirection(inputParameters[0]);
                    md.MoveSteps = Utility.ValidateStepRange(Convert.ToInt32(inputParameters[1]));
                    moveDirections.Add(md);
                }
                catch ( OverflowException )
                {
                    throw new OutOfRangeException();
                }
                catch ( OutOfRangeException )
                {
                    //handle logic
                    System.Console.WriteLine("Step out of valid range");
                }
                catch ( InvalidCompassDirectionException )
                {
                    //handle logic
                    System.Console.WriteLine("Not allowed compass symbol");
                }
            }
        }
    }
}
