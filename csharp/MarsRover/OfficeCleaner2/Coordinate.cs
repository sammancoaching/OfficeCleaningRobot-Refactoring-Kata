using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner2
{
    /// <summary>
    /// Represents a single point on a coordinate plane
    /// </summary>
    public struct Coordinate
    {
        private int x;
        private int y;

        /// <summary>
        /// X coordinate - movement along East/West direction
        /// </summary>
        public int X
        {
            get { return x; }
            set { 
                x = value;
            }
        }

        /// <summary>
        /// Y coordinate - movement along North/South direction
        /// </summary>
        public int Y
        {
            get { return y; }
            set { 
                y = value;
            }
        }

        /// <summary>
        /// Supply initial coordinates (x,y)
        /// </summary>
        /// <param name="_x">x coordinate</param>
        /// <param name="_y">y coordinate</param>
        public Coordinate(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }
}
