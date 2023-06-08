using System.Collections.Generic;

namespace MarsRover5
{
    public class Rover
    {
        private int coordinateX;
        private int coordinateY;
        private readonly RoverTracker tracker;

        public Rover(int[] startCoordinates)
        {
            coordinateX = startCoordinates[0];
            coordinateY = startCoordinates[1];
            tracker = new RoverTracker();
            tracker.AddPosition(GetCurrentPosition());
        }

        public void Move(List<MoveDirection> moveDirections)
        {
            foreach ( MoveDirection moveDirection in moveDirections )
            {
                for (int i = 0; i < moveDirection.MoveSteps; i++)
                {
                    switch (moveDirection.CompassDirection)
                    {
                        case "N":
                            coordinateY++;
                            break;
                        case "S":
                            coordinateY--;
                            break;
                        case "W":
                            coordinateX--;
                            break;
                        case "E":
                            coordinateX++;
                            break;
                    }
                    tracker.AddPosition(GetCurrentPosition());
                }
            }
        }

        public int[] GetCurrentPosition()
        {
            return new int[] {coordinateX, coordinateY};
        }

        public int Report()
        {
            return tracker.GetUniquePositions();
        }
    }
}
