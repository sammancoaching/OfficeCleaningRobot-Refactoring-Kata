using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCleaner7
{
    /// <summary>
    /// This enumeration describes the possible direction for the robot to move 
    /// </summary>
    public enum CommandDirections
    {
        East,
        West,
        North,
        South,
        NoDirection
    }

    /// <summary>
    /// This class describes the commands to be send for execution by the robot
    /// It keeps the direction and the steps for that direction.
    /// </summary>
    public class CommandDescription
    {
        public CommandDirections Direction { get; set; }
        public int Steps { get; set; }

        private CommandDescription()
        {
        }

        public CommandDescription(CommandDirections direction, int stepsNumber)
        {
            Direction = direction;
            Steps = stepsNumber;
        }
    }
}
