namespace MarsRover9;

class Program
{
        
    static void Main(string[] args)
    {
        int noCommands = Convert.ToInt32(System.Console.ReadLine());
        //from problem - number of commands n(0 <= n <= 10,000).
        if (noCommands < 0 || noCommands > 10000 )
        { return; }
        //read starting location of robot
        string[] startPoints = System.Console.ReadLine().Split(' '); ;
        var robot = new Rover();
        //Cleans the starting location
        robot.StartAt(Convert.ToInt32(startPoints[0]), Convert.ToInt32(startPoints[1]));

        IList<string> listOfCommands = new List<string>();
        for (int i = 0; i < noCommands; i++)
        {
            listOfCommands.Add(System.Console.ReadLine());
        }

        //Reads the direction and number of steps and cleans the floor in each direction
        foreach (string command in listOfCommands)
        {
            string[] options = command.Split(' ');               
                
            robot.CleanFloor(Convert.ToChar(options[0]), Convert.ToInt32(options[1]));
        }
           
        System.Console.WriteLine(String.Format("Visited=> {0}", robot.visitedPlaces.Count));           
    }
}