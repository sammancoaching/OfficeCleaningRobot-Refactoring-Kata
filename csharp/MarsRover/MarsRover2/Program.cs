
namespace MarsRover2
{
    class Program
    {
        static void Main(string[] args)
        {
            Rover myRover;
            Queue<Command> commandQueue = new Queue<Command>();
            int numOfCommands;
            string[] coords;
            int startX, startY;
            numOfCommands = int.Parse(System.Console.In.ReadLine());
            coords = System.Console.In.ReadLine().Split(' ');
            startX = int.Parse(coords[0]);
            startY = int.Parse(coords[1]);
            myRover = new Rover(startX, startY);
            for (int i = 1; i <= numOfCommands; i++)
            {
                string[] input = System.Console.In.ReadLine().Split(' ');
                Command cmd = new Command(GetDirection(input[0]), int.Parse(input[1]));
                commandQueue.Enqueue(cmd);
            }

            myRover.Visitplateau(commandQueue);
            System.Console.Out.WriteLine("=> Visited: " + myRover.GetNumberOfUniquePlacesVisited());
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