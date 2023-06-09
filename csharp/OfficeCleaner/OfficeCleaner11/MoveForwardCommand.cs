namespace OfficeCleaner11
{
    public struct MoveForwardCommand
    {
        private PointOfCompass _direction;
        private int _steps;


        public MoveForwardCommand(PointOfCompass direction, int steps)
        {
            _direction = direction;
            _steps = steps;
        }

        public PointOfCompass Direction
        {
            get { return _direction; }
            set { _direction = value; }
        }

        public int Steps
        {
            get { return _steps; }
            set { _steps = value; }
        }
    }
}
