namespace OfficeCleaner10
{
    struct Point
    {
        public readonly int x, y;
		
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
		
        public Point(Point p)
        {
            this.x = p.x;
            this.y = p.y;
        }
    }
}