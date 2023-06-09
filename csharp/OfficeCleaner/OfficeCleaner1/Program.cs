
namespace OfficeCleaner1
{
    
    public class Program
    {
        private const int commandNum = 4;

        public static void Main(string[] args)
        {
            var mainRobot = new RobotCleaner();
            List<String> inputCommands = new List<String>();

            for (int count = 0; count < commandNum; count++)
            {
                inputCommands.Add(System.Console.ReadLine());
            }

            if (false == mainRobot.parseInput(inputCommands))
                System.Console.Write("There was an error. Please check the logs");

            System.Console.Write("=> Cleaned:" + mainRobot.getVisitedPositions());
        }
    }
}