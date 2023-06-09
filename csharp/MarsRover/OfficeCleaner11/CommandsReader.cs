using System;
using System.Collections.Generic;

namespace OfficeCleaner11
{
    public class CommandsReader
    {
        private static readonly Dictionary<string, PointOfCompass> MapStringToPointOfCompass;


        static CommandsReader()
        {
            MapStringToPointOfCompass = new Dictionary<string, PointOfCompass>();
            MapStringToPointOfCompass["E"] = PointOfCompass.East;
            MapStringToPointOfCompass["W"] = PointOfCompass.West;
            MapStringToPointOfCompass["S"] = PointOfCompass.South;
            MapStringToPointOfCompass["N"] = PointOfCompass.North;

        }

        private readonly IStandardInputLineReader _lineReader;
        private Queue<MoveForwardCommand> _moveForwardCommands = new Queue<MoveForwardCommand>();
        private int _startingPositionX = 0;
        private int _startingPositionY = 0;


        public CommandsReader() : this(new StandardInputLineReader()) { }

        public CommandsReader(IStandardInputLineReader lineReader)
        {
            _lineReader = lineReader;
        }


        public Queue<MoveForwardCommand> MoveForwardCommands
        {
            get { return _moveForwardCommands; }
        }

        public int StartingPositionX
        {
            get { return _startingPositionX; }
        }

        public int StartingPositionY
        {
            get { return _startingPositionY; }
        }

        public void ReadCommandFromStandardInput()
        {
            int expectedNumberOfMoveForwardCommands;
            ReadNumberOfCommands(out expectedNumberOfMoveForwardCommands);
            ReadStartingPosition();
            ReadMoveForwardCommands(expectedNumberOfMoveForwardCommands);
        }

        private void ReadNumberOfCommands(out int commandsCount)
        {
            string numberOfCommandsLine = _lineReader.ReadLine();
            commandsCount = int.Parse(numberOfCommandsLine);

        }

        private void ReadStartingPosition()
        {
            string startingPositionLine = _lineReader.ReadLine();        
            string[] coordinates = startingPositionLine.Split(' ');

            _startingPositionX = int.Parse(coordinates[0]);
            _startingPositionY = int.Parse(coordinates[1]);

        }

        private void ReadMoveForwardCommands(int commands)
        {
            for(int i = 0; i < commands; ++i)
            {
                string moveForwardLine = _lineReader.ReadLine();
                string[] moveForwardDetails = moveForwardLine.Split(' ');        

                MoveForwardCommand moveForwardCommand = new MoveForwardCommand();
                moveForwardCommand.Direction = MapStringToPointOfCompass[moveForwardDetails[0]];
                moveForwardCommand.Steps = int.Parse(moveForwardDetails[1]);

                _moveForwardCommands.Enqueue(moveForwardCommand);
            }
        }


    }
}