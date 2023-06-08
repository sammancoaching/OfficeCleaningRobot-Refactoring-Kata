using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MarsRover6
{
    public class PositionManager
    {
        private static PositionManager instance; //instance of Position manager class
        private ArrayList alCleanedPosition ; //list of positions cleaned by robot
        private Position oCurrentPosition ; //current position of robot in the plane 
        
        /// <summary>
        /// Private Constructor of Manager Class
        /// </summary>
        private PositionManager()
        { 
            alCleanedPosition = new ArrayList(); //Initializing Cleaned Position list
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
        /// Interface for returning list of cleaned positions by robot
        /// </summary>
        public ArrayList CleanedPositionList
        {
            get 
            {
                return this.alCleanedPosition; //returning list of cleaned positions by robot
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
        /// Checks if the Current Cleaning Position has not already been cleaned
        /// OtherWise adds the Current Cleaning Position to the cleaned Positions list
        /// </summary>
        public void AddVisitingPosition()
        {
            try
            {
                if (alCleanedPosition.Count > 0) //checking if count of already cleaned positions list > 0
                {
                    if (CheckCleanedPositionAlreadyExist(oCurrentPosition)) //call to check if current position has already been cleaned or not
                    {
                        return; //returning if the position is already in the cleaned position list
                    }
                }

                //if the current position is not previously cleaned by robot
                //adding current position to the cleaned position list
                //new Position(oCurrentPosition) will create a new instance of Position class and will use
                //copy constructor to copy the value of current position to the new position.
                //creation of new position will avoid referencing to current position when added in the list
                alCleanedPosition.Add(new Position(oCurrentPosition));
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// Checks if the Cleaning Position which is coming as an argument has not already been cleaned
        /// </summary>
        /// <param name="roCleaningPosition"></param>
        /// <returns></returns>
        private bool CheckCleanedPositionAlreadyExist(Position roCleaningPosition)
        {
            try
            {
                //The loop will iterate through the list of already cleaned positions by robot
                for (int iLoop = 0; iLoop < alCleanedPosition.Count; iLoop++)
                {
                    //Taking already cleaned position from the list
                    Position oAlreadyCleanedPosition = (Position)alCleanedPosition[iLoop];

                    if (oAlreadyCleanedPosition.Equals(roCleaningPosition))//checking if position has already been cleaned or not
                        return true; //return true if position has already been cleaned
                }

            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }

            return false; //return false if position has not previously been cleaned
        }


    }
}
