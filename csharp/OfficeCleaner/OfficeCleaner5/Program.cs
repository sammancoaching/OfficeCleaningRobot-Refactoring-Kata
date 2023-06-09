
namespace OfficeCleaner5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InputController input = new InputController(); 
            input.ReadInputParameters();
            var robot = new RobotCleaner(input.InitialCoordinates);
            robot.Move(input.MoveDirections);
            System.Console.WriteLine("=> Cleaned: {0}",robot.Report());
        }
    }
}
