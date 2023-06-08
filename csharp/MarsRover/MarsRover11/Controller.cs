using System;

namespace MarsRover11
{
    public class Controller
    {
        IStandardInputLineReader _inputLineReader;
        IStandardOutputLineWriter _outputLineWriter;


        public Controller(IStandardInputLineReader inputView, IStandardOutputLineWriter outputView)
        {
            _inputLineReader = inputView;
            _outputLineWriter = outputView;
        }

        public void Rove()
        {
            try
            {

                IPlateau plateau = new Plateau();
                CommandsReader commandsReader = new CommandsReader(_inputLineReader);
                commandsReader.ReadCommandFromStandardInput();

                Rover rosieTheRover = new Rover(commandsReader.StartingPositionX,
                                                    commandsReader.StartingPositionY,
                                                    plateau);


                while (commandsReader.MoveForwardCommands.Count > 0)
                {
                    MoveForwardCommand command = commandsReader.MoveForwardCommands.Dequeue();

                    rosieTheRover.MoveForward(command);
                }

                _outputLineWriter.WriteLine(string.Format("=> Visited: {0}", rosieTheRover.VisitedPlacesCount));
            }
            catch (Exception e)
            {
                _outputLineWriter.WriteLine("Rosie the Rover malfunctions, call George Jetson to fix her!");
                _outputLineWriter.WriteLine("Here are the diagnostic messages:");
                _outputLineWriter.WriteLine(e.ToString());
            }
        }
    }
}
