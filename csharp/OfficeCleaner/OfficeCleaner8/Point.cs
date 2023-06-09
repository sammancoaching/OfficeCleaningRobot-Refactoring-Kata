using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner8
{
    public class Point : IPoint
    {
        private int x;
        private int y;

        public Point()
        {
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
         
        public int X
        {
            get { return x; }
            set
            {
                if (value < -100000 || value > 100000)
                    throw new InvalidCoordinatesException();
                this.x = value;
            }
        }

        public int Y
        {
            get { return y; }
            set
            {
                if (value < -100000 || value > 100000)
                    throw new InvalidCoordinatesException();
                this.y = value;
            }
        }

        public override bool Equals(Object pointToCompare)
        {
            bool result = false;

            if (pointToCompare is IPoint)
            {
                if (((IPoint)pointToCompare).X == X && ((IPoint)pointToCompare).Y == Y)
                    result = true;
            }

            return result;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}
