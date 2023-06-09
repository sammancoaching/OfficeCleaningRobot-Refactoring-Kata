using System.Collections.Generic;

namespace OfficeCleaner5
{
    public class RobotCleaner
    {
        private int coordinateX;
        private int coordinateY;
        private readonly RobotTracker tracker;

        public RobotCleaner(int[] startCoordinates)
        {
            coordinateX = startCoordinates[0];
            coordinateY = startCoordinates[1];
            tracker = new RobotTracker();
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
