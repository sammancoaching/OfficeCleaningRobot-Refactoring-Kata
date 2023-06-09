namespace OfficeCleaner5
{
    public class MoveDirection
    {
        private string compassDirection;
        public string CompassDirection
        {
            get { return compassDirection; }
            set { compassDirection = value; }
        }

        private int moveSteps;
        public int MoveSteps
        {
            get { return moveSteps; }
            set { moveSteps = value ; }
        }
    }
}
