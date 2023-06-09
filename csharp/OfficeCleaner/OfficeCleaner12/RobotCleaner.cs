using System;

namespace OfficeCleaner12
{
    public class RobotCleaner
    {
        private readonly IOffice _office;
        private PointOfCompass _currentPosition;

        public RobotCleaner(int startingPositionX, int startingPositionY)
            : this (startingPositionX, startingPositionY, new Office())
        {
        }

        public RobotCleaner(int startingPositionX, int startingPositionY, IOffice office)
        {
            _office = office;
            _currentPosition = new PointOfCompass(startingPositionX, startingPositionY);
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

        public long visitedPlacesCount
        {
            get { return _office.VisitedPlacesCount; }
        }


        public void Move(PointOfCompass direction, int steps)
        {

            PointOfCompass moveDirection = direction * Math.Sign(steps);
            int distance = Math.Abs(steps);

            for (int visitOperation = 1; visitOperation <= distance; ++visitOperation)
            {
                _currentPosition = _currentPosition + moveDirection;
                _office.SetPlaceVisited(_currentPosition);
            }            
        }
    }
}