using System.Collections.Generic;
using System;

namespace OfficeCleaner12
{
	using MoveCommand = Tuple<PointOfCompass, int>;

    public class CommandLineParser
    {
        private static readonly Dictionary<string, PointOfCompass> MapStringToPointOfCompass;


        static CommandLineParser()
        {
            MapStringToPointOfCompass = new Dictionary<string, PointOfCompass>();
            MapStringToPointOfCompass["E"] = PointOfCompass.East;
            MapStringToPointOfCompass["W"] = PointOfCompass.West;
            MapStringToPointOfCompass["S"] = PointOfCompass.South;
            MapStringToPointOfCompass["N"] = PointOfCompass.North;

        }

        private Queue<MoveCommand> _moveCommands = new Queue<MoveCommand>();
        private int _startingPositionX = 0;
        private int _startingPositionY = 0;


        public Queue<MoveCommand> MoveCommands
        {
            get { return _moveCommands; }
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
            int expectedNumberOfMoveCommands;
            ReadNumberOfCommands(out expectedNumberOfMoveCommands);
            ReadStartingPosition();
            ReadMoveCommands(expectedNumberOfMoveCommands);
        }

        private void ReadNumberOfCommands(out int commandsCount)
        {
            string numberOfCommandsLine = System.Console.ReadLine();
            commandsCount = int.Parse(numberOfCommandsLine);

        }

        private void ReadStartingPosition()
        {
            string startingPositionLine = System.Console.ReadLine();        
            string[] coordinates = startingPositionLine.Split(' ');

            _startingPositionX = int.Parse(coordinates[0]);
            _startingPositionY = int.Parse(coordinates[1]);

        }

        private void ReadMoveCommands(int commands)
        {
            for(int i = 0; i < commands; ++i)
            {
                string moveCommandLine = System.Console.ReadLine();
                string[] moveCommandDetails = moveCommandLine.Split(' ');        

                var direction = MapStringToPointOfCompass[moveCommandDetails[0]];
                var steps = int.Parse(moveCommandDetails[1]);

                _moveCommands.Enqueue(Tuple.Create(direction, steps));
            }
        }


    }
}