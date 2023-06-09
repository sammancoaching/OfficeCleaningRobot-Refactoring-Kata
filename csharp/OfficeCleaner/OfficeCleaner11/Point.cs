using System;
using System.Collections.Generic;

namespace OfficeCleaner11
{
    public struct  Point
    {
        private int _x;
        private int _y;

        private static readonly Dictionary<PointOfCompass, Point> MapPointOfCompassToPoint;
        static Point()
        {
            MapPointOfCompassToPoint = new Dictionary<PointOfCompass, Point>();

            MapPointOfCompassToPoint[PointOfCompass.East] = new Point(1, 0);
            MapPointOfCompassToPoint[PointOfCompass.West] = new Point(-1, 0);
            MapPointOfCompassToPoint[PointOfCompass.North] = new Point(0, 1);
            MapPointOfCompassToPoint[PointOfCompass.South] = new Point(0, -1);
        }

        public Point(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }


        public override bool Equals(object obj)
        {
            if ((obj is Point) == false)
            {
                return false;
            }

            Point point = (Point)obj;
            return _x == point._x && _y == point._y;
        }

        public override int GetHashCode()
        {
            return _x ^ _y;
        }

        public static explicit operator Point(PointOfCompass source)
        {
            try
            {
                return MapPointOfCompassToPoint[source];
            }
            catch(KeyNotFoundException)
            {
                throw new InvalidCastException();
            }
        }

        public static Point operator *(Point a, int b)
        {
            Point result = new Point(a.X * b, a.Y * b);
            return result;
        }

        public static Point operator + (Point a, Point b)
        {
            Point result = new Point(a.X + b.X, a.Y + b.Y);
            return result;
        }
    }

}
