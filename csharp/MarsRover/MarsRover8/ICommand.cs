using System;
using System.Collections.Generic;
namespace MarsRover8
{
    public interface ICommand
    {
        Command.Compass Direction { get; set; }
        int NumberOfSteps { get; set; }
        IList<IPoint> Execute(IPoint start);
    }
}
