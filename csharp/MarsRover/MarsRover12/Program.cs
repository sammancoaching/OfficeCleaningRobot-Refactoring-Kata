namespace MarsRover12;

public static class Program
{
    public static void Main()
    {
        try
        {

            IPlateau plateau = new Plateau();
            CommandLineParser commandLineParser = new CommandLineParser();
            commandLineParser.ReadCommandFromStandardInput();

            var rosieTheRover = new Rover(commandLineParser.StartingPositionX,
                commandLineParser.StartingPositionY,
                plateau);


            while (commandLineParser.MoveCommands.Count > 0)
            {
                var command = commandLineParser.MoveCommands.Dequeue();

                rosieTheRover.Move(command.Item1, command.Item2);
            }

            System.Console.WriteLine(string.Format("=> Visited: {0}", rosieTheRover.visitedPlacesCount));
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Rosie the Rover malfunctions, call George Jetson to fix her!");
            System.Console.WriteLine("Here are the diagnostic messages:");
            System.Console.WriteLine(e.ToString());
        }
    }
}