namespace OfficeCleaner12;

public static class Program
{
    public static void Main(string[] args)
    {
        try
        {

            IOffice office = new Office();
            CommandLineParser commandLineParser = new CommandLineParser();
            commandLineParser.ReadCommandFromStandardInput();

            var rosieTheRover = new RobotCleaner(commandLineParser.StartingPositionX,
                commandLineParser.StartingPositionY,
                office);


            while (commandLineParser.MoveCommands.Count > 0)
            {
                var command = commandLineParser.MoveCommands.Dequeue();

                rosieTheRover.Move(command.Item1, command.Item2);
            }

            System.Console.WriteLine(string.Format("=> Cleaned: {0}", rosieTheRover.visitedPlacesCount));
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Rosie the Rover malfunctions, call George Jetson to fix her!");
            System.Console.WriteLine("Here are the diagnostic messages:");
            System.Console.WriteLine(e.ToString());
        }
    }
}