
namespace OfficeCleaner2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            RobotCleaner myRobotCleaner;
            Queue<Command> commandQueue = new Queue<Command>();
            int numOfCommands;
            string[] coords;
            int startX, startY;
            numOfCommands = int.Parse(System.Console.In.ReadLine());
            coords = System.Console.In.ReadLine().Split(' ');
            startX = int.Parse(coords[0]);
            startY = int.Parse(coords[1]);
            myRobotCleaner = new RobotCleaner(startX, startY);
            if (numOfCommands > 0)
            {
                for (int i = 1; i <= numOfCommands; i++)
                {
                    string[] input = System.Console.In.ReadLine().Split(' ');
                    Command cmd = new Command(GetDirection(input[0]), int.Parse(input[1]));
                    commandQueue.Enqueue(cmd);
                }
                myRobotCleaner.VisitOffice(commandQueue);
                System.Console.Out.WriteLine("=> Cleaned: " + myRobotCleaner.GetNumberOfUniquePlacesVisited());
            }
            else
            {
                System.Console.Out.WriteLine("=> Cleaned: 1");
            }
            
        }

        static Direction GetDirection(string dir)
        {
            switch (dir)
            {
                case "E":
                    return Direction.East;
                case "W":
                    return Direction.West;
                case "S":
                    return Direction.South;
                case "N":
                    return Direction.North;
                default:
                    return Direction.East;
            }
        }
    }
}