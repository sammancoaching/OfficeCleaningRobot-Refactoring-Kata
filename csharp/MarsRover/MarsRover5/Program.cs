
namespace MarsRover5
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InputController input = new InputController(); 
            input.ReadInputParameters();
            var robot = new Rover(input.InitialCoordinates);
            robot.Move(input.MoveDirections);
            System.Console.WriteLine("=> Visited: {0}",robot.Report());
        }
    }
}
