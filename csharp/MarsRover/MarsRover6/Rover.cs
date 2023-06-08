using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace MarsRover6
{
    public class Rover
    {
        /// <summary>
        /// The StartCleanUp process will do the actual cleaning process by rover
        /// ralCleaningPoints contains list of all cleaning positions which the rover has to clean
        /// </summary>
        /// <param name="ralCleaningPoints"></param>
        public void StartRoving(ArrayList ralCleaningPoints)
        {
            try
            {
                //oRobotCurrentPosition will store the current position of the rover
                Position oRobotCurrentPosition;

                //The loop will iterate through the list of all cleaning positions which the rover has to clean
                for (int iLoop = 0; iLoop < ralCleaningPoints.Count; iLoop++)
                {
                    //Storing the current position of rover
                    oRobotCurrentPosition = PositionManager.Instance.CurrentPosition;

                    //calculating next Rover position from the list of all cleaning positions which the rover has to clean
                    String sNextRoverPosition = (String)ralCleaningPoints[iLoop];

                    //splitting next Rover position to get the direction and no of steps the rover has to move
                    String[] arrRoverPositions = sNextRoverPosition.Split(' ');

                    //Storing next direction which the rover has to move the directions are North,South,East and West
                    String sNextDirection = arrRoverPositions[0];

                    //Calculating the no of steps which the rover has to move
                    int iNoOfSteps = Convert.ToInt32(arrRoverPositions[1]);

                    //Checking if no of commands lies in valid range 0 <= n <= 1,00,000)
                    if (iNoOfSteps < 0 || iNoOfSteps > 100000)
                        throw new Exception("Number of steps for the rover can't be less than 0 or greater than 1,00,000");

                    //The loop will iterate through the no of steps which the rover has to take
                    //based on the direction the current rover position will be getting incremented or decremented
                    //if the current position of rover is unique it would be added to the cleaned positions list
                    for (int iInnerLoop = 0; iInnerLoop < iNoOfSteps; iInnerLoop++)
                    {
                        switch (sNextDirection.ToUpper())//switch  case on the direction of rover
                        {

                            case "N": //if the direction is North
                                {
                                    //The y-Coordinate of the rover current position will be incremented by 1
                                    oRobotCurrentPosition.YCoordinate = oRobotCurrentPosition.YCoordinate + 1;
                                    break;
                                }
                            case "S": //if the direction is South
                                {
                                    //The y-Coordinate of the rover current position will be decremented by 1
                                    oRobotCurrentPosition.YCoordinate = oRobotCurrentPosition.YCoordinate - 1;
                                    break;
                                }
                            case "E": //if the direction is East
                                {
                                    //The x-Coordinate of the rover current position will be incremented by 1
                                    oRobotCurrentPosition.XCoordinate = oRobotCurrentPosition.XCoordinate + 1;
                                    break;
                                }
                            case "W": //if the direction is West
                                {
                                    //The x-Coordinate of the rover current position will be decremented by 1
                                    oRobotCurrentPosition.XCoordinate = oRobotCurrentPosition.XCoordinate - 1;
                                    break;
                                }
                        }

                        //Call to add the current position of the rover to the cleaned positions list
                        PositionManager.Instance.AddVisitingPosition();
                    }

                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }
        }

        /// <summary>
        /// The function will return the total no of unique positions cleaned by rover
        /// </summary>
        /// <returns></returns>
        public int GetTotalNoOfVisitedPositions()
        {
            try
            {
                //retruning count of the list of unique positions cleaned by rover
                return PositionManager.Instance.CleanedPositionList.Count;
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error Message  = " + ex.Message);
                System.Console.WriteLine("Trace  = " + ex.StackTrace);
                System.Console.ReadLine();
            }

            return 0;
        }
    }
}
