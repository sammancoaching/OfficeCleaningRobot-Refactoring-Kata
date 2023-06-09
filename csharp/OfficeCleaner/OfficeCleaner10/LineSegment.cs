namespace OfficeCleaner10
{
    struct LineSegment
    {
        public readonly int value, min, max;
        public readonly char alongAxis;
		
        public LineSegment(int value, int min, int max, char alongAxis)
        {
            this.value = value;
            this.min = min;
            this.max = max;
            this.alongAxis = alongAxis;
        }	
    }
}