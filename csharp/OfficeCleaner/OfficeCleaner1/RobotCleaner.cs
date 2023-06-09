namespace OfficeCleaner1;

class RobotCleaner
{
   private RobotCleanerParser _cleanerParser;
        private Coordinate position;
        
        // I don't have access to a HashSet, this is the next closest thing
        // using a string version means not having to write a hashing function etc. for now.
        // the int is regrettably necessary. Later versions of .NET have HashSet.
        
        private Dictionary<string, int> coordHashSet = new Dictionary<string, int>();

        // This entire block should be set up with some kind of contingency injection
        // but for now has been coded like this

        private static Direction north = new North();
        private static Direction south = new South();
        private static Direction east = new East();
        private static Direction west = new West();

        private static string northString = "N";
        private static string southString = "S";
        private static string eastString = "E";
        private static string westString = "W";

        private static List<string> moveList = new List<string>{
                northString, 
                southString,
                eastString,
                westString
            };

        private static Dictionary<string, Direction> directionTable = new Dictionary<string, Direction>
            {
                {northString, north},
                {southString, south},
                {eastString, east},
                {westString, west}
            };

        // block ends

        public RobotCleaner()
        {
            _cleanerParser = new RobotCleanerParser(moveList);
        }

        public int getVisitedPositions()
        {
            return coordHashSet.Count;
        }

        public bool parseInput(List<string> input)
        {
            coordHashSet.Clear();
            if (false == _cleanerParser.parse(input))
                return false;

            position = _cleanerParser.getStartPosition();
            coordHashSet.Add(position.ToString(), 0);

            foreach (string command in _cleanerParser.getCommands())
            {
                if (command == null)
                {
                    continue;
                }
                string[] commandParts = command.Split(' ');
                int iterations = System.Convert.ToInt32(commandParts[1]);

                Direction move = directionTable[commandParts[0]];
                for (int count = 0; count < iterations; count++)
                {
                    move.move(position);
                    if (!coordHashSet.ContainsKey(position.ToString()))
                    {
                        coordHashSet.Add(position.ToString(), 0);
                    }
                }
            }

            return true;
        }
}