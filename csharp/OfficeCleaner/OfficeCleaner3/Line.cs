using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner3
{
    class Line
    {
        private LineDirection direction;
        private int cc;
        private int pc1;
        private int pc2;

        public Line(LineDirection parallelWithAxis, int crossAxisCoord, int parallelAxisCoord1, int parallelAxisCoord2)
        {
            this.direction = parallelWithAxis;
            this.cc = crossAxisCoord;
            this.pc1 = parallelAxisCoord1;
            this.pc2 = parallelAxisCoord2;
        }

        public LineDirection Direction { get { return direction; } }
        public int CrossCoordinate { get { return cc; } }
        public int ParallelCoordinate1 { get { return pc1; } }
        public int ParallelCoordinate2 { get { return pc2; } }
    }
}
