using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner6
{
    public class Position
    {
        int iXCoordinate; //X-Coordinate of the position of robot
        int iYCoordinate; //Y-Coordinate of the position of robot

        /// <summary>
        /// Default Constructor for Position class
        /// </summary>
        public Position()
        {
            iXCoordinate = 0; //initializing XCoordinate to 0
            iYCoordinate = 0; //initializing YCoordinate to 0
        }

        /// <summary>
        /// 2 Argument Constructor for Position class
        /// The constructor takes XCoordinate and YCoordinate values as input
        /// and sets local XCoordinate and YCoordinate values with them
        /// </summary>
        /// <param name="riXCoordinate"></param>
        /// <param name="riYCoordinate"></param>
        public Position (int riXCoordinate,int riYCoordinate)
        {
            this.iXCoordinate = riXCoordinate; //Setting XCoordinate to the XCoordinate value coming as input
            this.iYCoordinate = riYCoordinate; //Setting YCoordinate to the YCoordinate value coming as input
        }

        /// <summary>
        /// This constructor acts as a copy constructor as it fills the local values
        /// from the object coming as an argument
        /// </summary>
        /// <param name="roPosition"></param>
        public Position(Position roPosition)
        {
            this.iXCoordinate = roPosition.XCoordinate; //Setting XCoordinate to the XCoordinate value coming as input
            this.iYCoordinate = roPosition.YCoordinate; //Setting YCoordinate to the YCoordinate value coming as input
        }

        /// <summary>
        /// Getter and Setter functions for X-Coordinate of the Position 
        /// </summary>
        public int XCoordinate
        {
            get
            { return this.iXCoordinate; } //getting the value of X-Coordinate of Position
            set
            { this.iXCoordinate = value; } //setting the value of X-Coordinate of Position
        }

        /// <summary>
        /// Getter and Setter functions for Y-Coordinate of the Position 
        /// </summary>
        public int YCoordinate
        {
            get
            { return this.iYCoordinate; } //getting the value of Y-Coordinate of Position
            set
            { this.iYCoordinate = value; } //setting the value of Y-Coordinate of Position
        }

        /// <summary>
        /// Override Equal functions to check if 2 Position objects are equal
        /// 2 Position objects are equal if their X and Y Coordinate values are same
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool bEquals = false; //by default we are assuming objects are not equal

            //checking if object is not null and objetcs are of same type i.e of Position class
            if (obj != null && (obj.GetType().Equals(typeof(Position)))) 
            {
                //casting object to Position class type
                Position oPositionToCompare = (Position)obj; 

                bEquals = (
                        oPositionToCompare.iXCoordinate.Equals(this.iXCoordinate) && //checking if XCoordinate value is same
                        oPositionToCompare.iYCoordinate.Equals(this.iYCoordinate) //checking if YCoordinate value is same
                    ) ? true : false;
            }

            return bEquals; //return result whether objects are equal are not
        }

        /// <summary>
        /// Overriding GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode(); //call to GetHashCode Function of base class
        }

        /// <summary>
        /// Overriding default ToString() function 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //the string returned would be like Visited Position = 10,2
            return "Visited Position = " + this.iXCoordinate + " , " + this.iYCoordinate + "\n";
        } 

    }
}
