using System.Collections;

namespace OfficeCleaner6;

public class Program
    {
        public static void Main(string[] args)
        {
            PositionManager.Reset();
            try
            {
                args = Console.In.ReadToEnd().Split(new string[]{"\n"}, StringSplitOptions.RemoveEmptyEntries);;

                if (args.Length == 0) // if no input arguments  are provided
                    throw new Exception("Sorry! No Input Arguments Provided.");

                int iNoOfCommands = Convert.ToInt32(args[0]);//The number of commands that the robot should execute
                
                //Checking if no of commands lies in valid range 0 <= n <= 10,000)
                if(iNoOfCommands < 0 || iNoOfCommands > 10000)
                    throw new Exception("Number of commands can't be less than 0 or greater than 10000");

                string sStartingPosition = args[1]; //setting initial start position coming as argument like 10 22 

                //splitting initial start point to get x & y coordinate values
                String[] arrInitialStartPosition = sStartingPosition.Split(' '); 

                int iXPosition = Convert.ToInt32(arrInitialStartPosition[0]); // x-coordinate of the intital start position

                //Checking if x-coordinate of the intital start position lies in valid range -1,00,000 <= n <= 1,00,000)
                 if(iXPosition < -100000 || iXPosition > 100000)
                     throw new Exception("X-coordinate of the intital start position can't be less than -1,00,000 or greater than 1,00,000");

                 int iYPosition = Convert.ToInt32(arrInitialStartPosition[1]); // y-coordinate of the intital start position
                 
                //Checking if x-coordinate of the intital start position lies in valid range -1,00,000 <= n <= 1,00,000)
                 if (iYPosition < -100000 || iYPosition > 100000)
                     throw new Exception("Y-coordinate of the intital start position can't be less than -1,00,000 or greater than 1,00,000");

               
                //call to set Current position of robot as the initial start position coming as argument like 10 22
                PositionManager.Instance.SetCurrentPosition(iXPosition,iYPosition); 
               
                //call to add Current position of robot in the visited position list
                PositionManager.Instance.AddVisitingPosition();

                //Creating an array list of visiting positions
                ArrayList alPosition = new ArrayList();

                //The loop will iterate through the no of commands to be processed through robot
                for (int iLoop = 0; iLoop < iNoOfCommands; iLoop++)
                {
                  
                    //Call to add visiting position to the array list of visiting positions to be visited by robots
                    //iLoop + 2 is done becuase the first 2 arguments are arg[0] = no of commands 
                    //and arg[1] = initial start position
                    alPosition.Add(args[iLoop + 2]);
                    
                }

                RobotCleaner oRobotCleaner = new RobotCleaner(); //creating a new object of Robot class
                oRobotCleaner.StartRoving(alPosition); //call to start visiting process by Robot

                //call to get total no of visited positions
                int iNoOfPositionsVisited = oRobotCleaner.GetTotalNoOfVisitedPositions();

                //Printing total no of visited positions
                System.Console.WriteLine("=> Cleaned: " + iNoOfPositionsVisited);
                System.Console.ReadLine();
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }
            

        }

    }