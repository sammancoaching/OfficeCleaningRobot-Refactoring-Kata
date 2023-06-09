namespace OfficeCleaner1;
class RobotCleanerParser
{
    private int MINIMUM_NUM_ENTRIES = 2; //Must at least be #steps, position, 0..n moves.
    private int COMMAND_OVERHEAD = 2; //# steps, position
    private const int MINIMUM_NUM_STEPS = 0; //minimum number of steps
    private const int MAXIMUM_NUM_STEPS = 100000; //maximum number of steps
    private List<string> moves;
    private Coordinate startPosition;

    private List<string> supportedMoves;

    public RobotCleanerParser(List<string> supportedMoves)
    {
        if (supportedMoves == null)
            throw new ArgumentNullException("Null passed to Robot Parser Constructor");

        if (supportedMoves.Count == 0)
            throw new ArgumentException("Empty list passed to Robot Parser Constructor");

        this.supportedMoves = supportedMoves;
    }

    public Coordinate getStartPosition()
    {
        return startPosition;
    }

    public List<string> getCommands()
    {
        return moves;
    }

    private void visit()
    {
        if (moves!= null)
            moves = null;

        startPosition = null;
    }

    public bool parse(List<string> commands)
    {
        //OMITTED: The logging statements that should precede return false;
        //perform visit
        visit();

        //first, ensure not null or incorrect number of elements
        if (commands == null || commands.Count < MINIMUM_NUM_ENTRIES)
            return false;

        //next, evaluate the number of steps
        if (System.Convert.ToInt32(commands[0], 10) < 0)
            return false;

        //parse the initial position and store it
        string[] tokens = commands[1].Split(' ');
        if (tokens.Length !=2)
            return false;

        startPosition = new Coordinate(System.Convert.ToInt32(tokens[0]),
            System.Convert.ToInt32(tokens[1]));

        //remove the first two lines - the rest are the commands to be executed
        commands.RemoveAt(0);
        commands.RemoveAt(0);

        //for each command, parse and ensure that it matches the pattern direction[space]steps
     
        foreach (string s in commands)
        {
            if (s == null)
            {
                continue;
            }
            string[] commandLineItemParts = s.Split(' ');
            if (!supportedMoves.Contains(commandLineItemParts[0]))
                return false;
            if (commandLineItemParts.Length != 2)
                return false;
            int steps = System.Convert.ToInt32(commandLineItemParts[1]);
            if ((steps < MINIMUM_NUM_STEPS) || (steps > MAXIMUM_NUM_STEPS))
                return false;
        }

        //appears to check out
        moves = commands;

        return true;
    }
}

