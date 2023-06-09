using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace OfficeCleaner6
{
    public class PositionManager
    {
        private static PositionManager instance; //instance of Position manager class
        private ArrayList alVisitedPosition ; //list of positions Visited by robot
        private Position oCurrentPosition ; //current position of robot in the plane 
        
        /// <summary>
        /// Private Constructor of Manager Class
        /// </summary>
        private PositionManager()
        { 
            alVisitedPosition = new ArrayList(); //Initializing Visited Position list
            oCurrentPosition = new Position(); //Initializing Current Position variable
        }

        /// <summary>
        /// Singleton class code to ensure that only a single instance of PsoitionManager class is generated
        /// </summary>
        public static PositionManager Instance
        {
            get 
            {
                //Checking if instance of class is not already created create a new instance
                //otherwise return the previously created instance
                return (instance == null) ? instance = new PositionManager() : instance;
            }
        }

        public static void Reset()
        {
            instance = null;
        }

        /// <summary>
        /// Setter and Getter for the Current Psotiton of the robot
        /// </summary>
        public Position CurrentPosition
        {
            get 
            {
                return oCurrentPosition; //returning current position of the robot
            }
            set
            {
                oCurrentPosition = value; //setting current position of the robot
            }
        }

        /// <summary>
        /// Interface for returning list of Visited positions by robot
        /// </summary>
        public ArrayList VisitedPositionList
        {
            get 
            {
                return this.alVisitedPosition; //returning list of Visited positions by robot
            }
        }

        /// <summary>
        /// Sets Current Position of Robot
        /// riXCoordinate  = X-Coordinate of robot position
        /// riYCoordinate  = Y-Coordinate of robot position
        /// </summary>
        /// <param name="riXCoordinate"></param>
        /// <param name="riYCoordinate"></param>
        public void SetCurrentPosition(int riXCoordinate,int riYCoordinate)
        {
            oCurrentPosition.XCoordinate = riXCoordinate; //setting xCoordinate of Robot position
            oCurrentPosition.YCoordinate = riYCoordinate; //setting YCoordinate of Robot position
        }

        /// <summary>
        /// Checks if the Current visiting Position has not already been Visited
        /// OtherWise adds the Current visiting Position to the Visited Positions list
        /// </summary>
        public void AddVisitingPosition()
        {
            try
            {
                if (alVisitedPosition.Count > 0) //checking if count of already Visited positions list > 0
                {
                    if (CheckVisitedPositionAlreadyExist(oCurrentPosition)) //call to check if current position has already been Visited or not
                    {
                        return; //returning if the position is already in the Visited position list
                    }
                }

                //if the current position is not previously Visited by robot
                //adding current position to the Visited position list
                //new Position(oCurrentPosition) will create a new instance of Position class and will use
                //copy constructor to copy the value of current position to the new position.
                //creation of new position will avoid referencing to current position when added in the list
                alVisitedPosition.Add(new Position(oCurrentPosition));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// Checks if the visiting Position which is coming as an argument has not already been Visited
        /// </summary>
        /// <param name="rovisitingPosition"></param>
        /// <returns></returns>
        private bool CheckVisitedPositionAlreadyExist(Position rovisitingPosition)
        {
            try
            {
                //The loop will iterate through the list of already Visited positions by robot
                for (int iLoop = 0; iLoop < alVisitedPosition.Count; iLoop++)
                {
                    //Taking already Visited position from the list
                    Position oAlreadyVisitedPosition = (Position)alVisitedPosition[iLoop];

                    if (oAlreadyVisitedPosition.Equals(rovisitingPosition))//checking if position has already been Visited or not
                        return true; //return true if position has already been Visited
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }

            return false; //return false if position has not previously been Visited
        }


    }
}
