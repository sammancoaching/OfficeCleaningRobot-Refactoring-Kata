// See https://aka.ms/new-console-template for more information


class Program
{
    private const int commandNum = 4;
 
    static void Main(string[] args)
    {
        var mainRobot = new Rover();
        List<String> inputCommands = new List<String>();

        for (int count = 0; count < commandNum; count++)
        {
            inputCommands.Add(System.Console.ReadLine());            
        }

        if (false ==mainRobot.parseInput(inputCommands))
            System.Console.Write("There was an error. Please check the logs");

        System.Console.Write("=> Visited:" + mainRobot.getVisitedPositions());
    }
}