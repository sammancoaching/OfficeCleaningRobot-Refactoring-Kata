using System;

namespace MarsRover12
{
    public class Rover
    {
        private readonly IPlateau _plateau;
        private PointOfCompass _currentPosition;

        public Rover(int startingPositionX, int startingPositionY)
            : this (startingPositionX, startingPositionY, new Plateau())
        {
        }

        public Rover(int startingPositionX, int startingPositionY, IPlateau plateau)
        {
            _plateau = plateau;
            _currentPosition = new PointOfCompass(startingPositionX, startingPositionY);
            _plateau.SetPlaceVisited(_currentPosition);
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
            get { return _plateau.VisitedPlacesCount; }
        }


        public void Move(PointOfCompass direction, int steps)
        {

            PointOfCompass moveDirection = direction * Math.Sign(steps);
            int distance = Math.Abs(steps);

            for (int visitOperation = 1; visitOperation <= distance; ++visitOperation)
            {
                _currentPosition = _currentPosition + moveDirection;
                _plateau.SetPlaceVisited(_currentPosition);
            }            
        }
    }
}