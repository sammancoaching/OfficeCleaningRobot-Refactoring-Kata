namespace OfficeCleaner3;

using con = System.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        int movements = Convert.ToInt32(con.ReadLine());
        string[] coords = con.ReadLine().Split(' ');
        var rob = new RobotCleaner(Convert.ToInt32(coords[0]), Convert.ToInt32(coords[1]));
        for (int i = 0; i < movements; i++)
        {
            string[] movement = con.ReadLine().Split(' ');
            Direction dir = (Direction)Enum.Parse(typeof(Direction), movement[0], true);
            int steps = Convert.ToInt32(movement[1]);
            rob.Move(dir, steps);
        }
        con.WriteLine("=> Cleaned: " + rob.Counter);
    }
}