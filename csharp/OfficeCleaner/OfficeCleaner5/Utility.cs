
namespace OfficeCleaner5
{
    public static class Utility
    {
        public static int ValidateCoordinateRange(int coordinate)
        {
            if ( coordinate <= 100000 && coordinate >= -100000 )
            {
                return coordinate;
            }
            throw new OutOfCoordinateBoundsException();
        }

        public static int ValidateStepRange(int step)
        {
            if ( step < 100000 && step >= 0 )
            {
                return step;
            }
            throw new OutOfRangeException();
        }

        public static string ValidateCompassDirection(string compassDirection)
        {
            switch(compassDirection.ToUpper())
            {
                case "N":
                case "S":
                case "E":
                case "W":
                    return
                        compassDirection.ToUpper();
            }
            throw new InvalidCompassDirectionException();
        }
    }
}
