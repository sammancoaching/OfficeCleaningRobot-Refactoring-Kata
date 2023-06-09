using System;

namespace OfficeCleaner11
{
    public class RobotCleaner
    {
        private readonly IOffice _office;
        private Point _currentPosition;

        public RobotCleaner(int startingPositionX, int startingPositionY)
            : this (startingPositionX, startingPositionY, new Office())
        {
        }

        public RobotCleaner(int startingPositionX, int startingPositionY, IOffice office)
        {
            _office = office;
            _currentPosition = new Point(startingPositionX, startingPositionY);
            _office.SetPlaceVisited(_currentPosition);
        }

        public int CurrentPositionX
        {
            get { return _currentPosition.X; }
        }


        public int CurrentPositionY
        {
            get { return _currentPosition.Y; }
        }

        public long VisitedPlacesCount
        {
            get { return _office.VisitedPlacesCount; }
        }


        public void MoveForward(MoveForwardCommand moveCommand)
        {

            Point moveDirection = (Point)moveCommand.Direction * Math.Sign(moveCommand.Steps);
            int distance = Math.Abs(moveCommand.Steps);

            for (int visitOperation = 1; visitOperation <= distance; ++visitOperation)
            {
                _currentPosition = _currentPosition + moveDirection;
                _office.SetPlaceVisited(_currentPosition);
            }            
        }
    }
}