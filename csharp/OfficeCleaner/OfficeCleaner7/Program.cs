using System.Drawing;

namespace OfficeCleaner7;

public class Program
    {
        public static void Main(string[] args)
        {
            //Reading the number of commands to expect
            int totalCommands = int.Parse(System.Console.In.ReadLine());
            
            //Variable to be used for reading 2 value lines.
            string[] nextRowValues;

            //Reading the initial possition of the robot
            nextRowValues = GetInputValues(System.Console.In.ReadLine());
            Point startPosition = new Point(int.Parse(nextRowValues[0]), int.Parse(nextRowValues[1]));
            RobotCleaner robotCleaner = new RobotCleaner();
            robotCleaner.CurrentPosition = startPosition;
            for (int i = 0; i < totalCommands; i++)
            {
                nextRowValues = GetInputValues(System.Console.In.ReadLine());
                CommandDescription command = new CommandDescription(GetDirectionFromIdentifier(nextRowValues[0]), int.Parse(nextRowValues[1]));
                robotCleaner.ExecuteCommand(command);
            }
            System.Console.Out.Write(string.Format("=> Cleaned: {0}",robotCleaner.VisitedPlacesCount));
        }

        /// <summary>
        /// This method parses the command identificator letter
        /// </summary>
        /// <param name="symbol">Command identificator letter</param>
        /// <returns>Command direction matching the identificator letter</returns>
        static CommandDirections GetDirectionFromIdentifier(string symbol)
        {
            switch (symbol)
            {
                case "E":
                    return CommandDirections.East;
                    break;
                case "W":
                    return CommandDirections.West;
                    break;
                case "N":
                    return CommandDirections.North;
                    break;
                case "S":
                    return CommandDirections.South;
                    break;
                default:
                    return CommandDirections.NoDirection; 
                    break;
            }
        }

        /// <summary>
        /// This method gets a whole line, splits it and returns the the input values it contains as an array
        /// </summary>
        /// <param name="line">The line that holds the values, delimited by a white space</param>
        /// <returns>The read values from the given row</returns>
        static string[] GetInputValues(string line)
        {
            return line.Split(new string[]{" "}, StringSplitOptions.RemoveEmptyEntries);
        }
    }