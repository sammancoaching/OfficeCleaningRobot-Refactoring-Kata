using System;

namespace OfficeCleaner11
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

                IOffice office = new Office();
                CommandsReader commandsReader = new CommandsReader(_inputLineReader);
                commandsReader.ReadCommandFromStandardInput();

                RobotCleaner rosieTheRobotCleaner = new RobotCleaner(commandsReader.StartingPositionX,
                                                    commandsReader.StartingPositionY,
                                                    office);


                while (commandsReader.MoveForwardCommands.Count > 0)
                {
                    MoveForwardCommand command = commandsReader.MoveForwardCommands.Dequeue();

                    rosieTheRobotCleaner.MoveForward(command);
                }

                _outputLineWriter.WriteLine(string.Format("=> Cleaned: {0}", rosieTheRobotCleaner.VisitedPlacesCount));
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
