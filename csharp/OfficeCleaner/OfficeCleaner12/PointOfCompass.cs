namespace OfficeCleaner12
{
    public struct  PointOfCompass
    {
		public static PointOfCompass East = new PointOfCompass(1, 0);
		public static PointOfCompass West = new PointOfCompass(-1, 0);
		public static PointOfCompass South = new PointOfCompass(0, -1);
		public static PointOfCompass North = new PointOfCompass(0, 1);

		private readonly int _x;
        private readonly int _y;

        public PointOfCompass(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
        }

        public int Y
        {
            get { return _y; }
        }


        public override bool Equals(object obj)
        {
            if ((obj is PointOfCompass) == false)
            {
                return false;
            }

            PointOfCompass point = (PointOfCompass)obj;
            return _x == point._x && _y == point._y;
        }

        public override int GetHashCode()
        {
            return _x ^ _y;
        }

        public static PointOfCompass operator *(PointOfCompass a, int b)
        {
            PointOfCompass result = new PointOfCompass(a.X * b, a.Y * b);
            return result;
        }

        public static PointOfCompass operator + (PointOfCompass a, PointOfCompass b)
        {
            PointOfCompass result = new PointOfCompass(a.X + b.X, a.Y + b.Y);
            return result;
        }
    }

}
