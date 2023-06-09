using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner3
{
    public class RobotCleaner
    {
        long counter;
        int lastX;
        int lastY;
        Dictionary<LineDirection, SortedDictionary<int, List<Line>>> lines;

        public RobotCleaner(int startX, int startY)
        {
            this.lastX = startX;
            this.lastY = startY;
            //Minimum possible counter value.
            counter = 1;
            //Initializing lines
            lines = new Dictionary<LineDirection, SortedDictionary<int, List<Line>>>();
            lines.Add(LineDirection.H, new SortedDictionary<int, List<Line>>());
            lines.Add(LineDirection.V, new SortedDictionary<int, List<Line>>());
        }

        public void Move(Direction dir, int steps)
        {
            int currentX = lastX;
            int currentY = lastY;
            int incX = 0;
            int incY = 0;
            LineDirection lineDir;
            DefineIncrementsAndLineDirection(dir, ref incX, ref incY, out lineDir);
            for (int i = 0; i < steps; i++)
            {
                currentX += incX;
                currentY += incY;
                if (PointFree(currentX, currentY))
                {
                    counter++;
                }
            }
            //Did not have time to check for existance of same, included, including, overlapped lines.
            AddLineToStorage(lastX, lastY, currentX, currentY, lineDir);
            lastX = currentX;
            lastY = currentY;
        }

        private void AddLineToStorage(int x1, int y1, int x2, int y2, LineDirection lineDir)
        {
            int crossCoord;
            int parallelCoord1;
            int parallelCoord2;
            if (lineDir == LineDirection.H)
            {
                crossCoord = y1;
                parallelCoord1 = x1;
                parallelCoord2 = x2;
            }
            else if (lineDir == LineDirection.V)
            {
                crossCoord = x1;
                parallelCoord1 = y1;
                parallelCoord2 = y2;
            }
            else
            {
                throw new Exception("Unsupported line direction");
            }
            SortCoords(ref parallelCoord1, ref parallelCoord2);
            Line line = new Line(lineDir, crossCoord, parallelCoord1, parallelCoord2);

            if (!lines[lineDir].ContainsKey(crossCoord))
            {
                lines[lineDir].Add(crossCoord, new List<Line>());
            }
            lines[lineDir][crossCoord].Add(line);
        }

        private void SortCoords(ref int parallelCoord1, ref int parallelCoord2)
        {
            if (parallelCoord1 > parallelCoord2)
            {
                int temp = parallelCoord1;
                parallelCoord1 = parallelCoord2;
                parallelCoord2 = temp;
            }
        }

        private void DefineIncrementsAndLineDirection(Direction dir, ref int incX, ref int incY, out LineDirection lineDir)
        {
            if (dir == Direction.E)
            {
                incX = 1;
                lineDir = LineDirection.H;
            }
            else if (dir == Direction.W)
            {
                incX = -1;
                lineDir = LineDirection.H;
            }
            else if (dir == Direction.N)
            {
                incY = 1;
                lineDir = LineDirection.V;
            }
            else if (dir == Direction.S)
            {
                incY = -1;
                lineDir = LineDirection.V;
            }
            else
            {
                throw new Exception("Unsupported step Direction");
            }
        }

        private bool PointFree(int currentX, int currentY)
        {
            if (LinesSetCrossesDot(lines[LineDirection.H], currentY, currentX))
            {
                return false;
            }
            if (LinesSetCrossesDot(lines[LineDirection.V], currentX, currentY))
            {
                return false;
            }
            return true;
        }

        bool LinesSetCrossesDot(SortedDictionary<int, List<Line>> linesSet, int crossCoord, int parallelCoord)
        {
            if (linesSet.ContainsKey(crossCoord))
            {
                foreach (Line currLine in linesSet[crossCoord])
                {
                    if (parallelCoord >= currLine.ParallelCoordinate1 && parallelCoord <= currLine.ParallelCoordinate2)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public long Counter { get { return counter; } }
    }
}
