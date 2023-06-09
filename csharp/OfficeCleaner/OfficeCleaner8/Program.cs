namespace OfficeCleaner8;
public class Program
    {
        public static void Main(string[] args)
        {
            try 
            {
                //read inputs            
                int numberOfCommands = Int32.Parse(System.Console.ReadLine());

                if (numberOfCommands > 10000 || numberOfCommands < 0)
                {
                    throw new InvalidNumberOfCommandsException();
                }

                String start = System.Console.ReadLine();
                IPoint startingPoint = new Point();
                char[] separator = {' '};
                string[] startCoordinates = start.Split(separator);
                startingPoint.X = Int32.Parse(startCoordinates[0]);
                startingPoint.Y = Int32.Parse(startCoordinates[1]);

                IList<ICommand> commands = new List<ICommand>();
                String commandString;
                ICommand command;
                string[] commandAttributes;

                for (int i = 0; i < numberOfCommands; i++)
                {
                    commandString = System.Console.ReadLine();
                    command = new Command();
                    commandAttributes = commandString.Split(separator);

                    switch (commandAttributes[0])
                    {
                        case "N":
                            command.Direction = Command.Compass.north;
                            break;
                        case "S":
                            command.Direction = Command.Compass.south;
                            break;
                        case "W":
                            command.Direction = Command.Compass.west;
                            break;
                        case "E":
                            command.Direction = Command.Compass.east;
                            break;
                        default:
                            throw new InvalidDirectionException();
                    }

                    command.NumberOfSteps = Int32.Parse(commandAttributes[1]);
                    commands.Add(command);
                }

                //create Rover object
                var rover = new RobotCleaner();
                //Visit plateau space
                int u = rover.move(startingPoint, commands);
                //print out result to standard out
                System.Console.WriteLine("=> Cleaned: " + u);
            }
            catch (InvalidCoordinatesException e)
            {
                System.Console.WriteLine("The coordinates of the place to be Visited are out of range. visiting will not continue. MORE DETAILS: " + e.Message);
            }
            catch (InvalidNullInputException e)
            {
                System.Console.WriteLine("visiting instructions were not specified. visiting will not start. MORE DETAILS: " + e.Message);
            }
            catch (InvalidNumberOfCommandsException e)
            {
                System.Console.WriteLine("Number of commands is out of range. visiting will not continue. MORE DETAILS: " + e.Message);
            }
            catch (InvalidNumberOfStepsException e)
            {
                System.Console.WriteLine("Number of steps within at least one command is out of range. visiting will not continue. MORE DETAILS: " + e.Message);
            }
            catch (InvalidDirectionException e)
            {
                System.Console.WriteLine("The value specified for compass direction is not valid. Valid values: N, S, W, E. MORE DETAILS: " + e.Message);
            }

        }
    }