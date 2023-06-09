
namespace OfficeCleaner1
{
    
    public class Program
    {
        
        public static void Main(string[] args)
        {
            var firstLine = System.Console.ReadLine();
            int commandNum = Convert.ToInt32(firstLine);

            List<String> inputCommands = new List<String>();
            inputCommands.Add(firstLine);
            var secondLine = System.Console.ReadLine();
            inputCommands.Add(secondLine);
            var mainRobot = new RobotCleaner();
            

            for (int count = 0; count < commandNum; count++)
            {
                inputCommands.Add(System.Console.ReadLine());
            }

            if (false == mainRobot.parseInput(inputCommands))
                System.Console.Write("There was an error. Please check the logs");

            System.Console.Write("=> Cleaned: " + mainRobot.getVisitedPositions());
        }
    }
}