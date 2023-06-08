using System.Collections.Generic;

namespace MarsRover5
{
    public class RoverTracker : ITracker
    {
        private readonly List<int[]> positions;
        
        public RoverTracker()
        {
            positions = new List<int[]>();
        }
        
        public void AddPosition(int[] coordinates)
        {
            positions.Add(coordinates);
        }

        public int GetUniquePositions()
        {
            return GetUniquePositions(positions);
        }

        private static int GetUniquePositions(List<int[]> positions)
        {
            List<int[]> uniquePostitions = new List<int[]>();
            foreach ( int[] position in positions )
            {
                bool addPosition = true;
                foreach ( int[] uniquePosition in uniquePostitions )
                {
                    if (uniquePosition[0] != position[0] || uniquePosition[1] != position[1]) continue;
                    addPosition = false;
                    break;
                }
                if ( addPosition )
                {
                    uniquePostitions.Add(position);
                }
            }
            return uniquePostitions.Count;
        }
    }
}
