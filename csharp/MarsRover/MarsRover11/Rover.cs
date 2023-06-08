using System;

namespace MarsRover11
{
    public class Rover
    {
        private readonly IPlateau _plateau;
        private Point _currentPosition;

        public Rover(int startingPositionX, int startingPositionY)
            : this (startingPositionX, startingPositionY, new Plateau())
        {
        }

        public Rover(int startingPositionX, int startingPositionY, IPlateau plateau)
        {
            _plateau = plateau;
            _currentPosition = new Point(startingPositionX, startingPositionY);
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

        public long VisitedPlacesCount
        {
            get { return _plateau.VisitedPlacesCount; }
        }


        public void MoveForward(MoveForwardCommand moveCommand)
        {

            Point moveDirection = (Point)moveCommand.Direction * Math.Sign(moveCommand.Steps);
            int distance = Math.Abs(moveCommand.Steps);

            for (int visitOperation = 1; visitOperation <= distance; ++visitOperation)
            {
                _currentPosition = _currentPosition + moveDirection;
                _plateau.SetPlaceVisited(_currentPosition);
            }            
        }
    }
}