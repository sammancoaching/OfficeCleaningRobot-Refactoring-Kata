
namespace MarsRover4;

class Program
{
    static void Main(string[] args)
    {
        string strNumCommands = System.Console.ReadLine();
        string startPos = System.Console.ReadLine();
        string [] positions = startPos.Split(" ".ToCharArray());
        int numCommands = Int32.Parse(strNumCommands);
        Rover r = new Rover(Int32.Parse(positions[0]), Int32.Parse(positions[1]));
        for (int i = 0; i < numCommands; i++)
        {
            string strMovement = System.Console.ReadLine();
            string[] moves = strMovement.Split(" ".ToCharArray());
            r.Move(moves[0], Int32.Parse(moves[1]));
        }
        System.Console.WriteLine("=> Visited: " + r.VisitedSpots.ToString());
    }
}