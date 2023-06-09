using System;
using System.Collections.Generic;
namespace OfficeCleaner8
{
    public interface ICommand
    {
        Command.Compass Direction { get; set; }
        int NumberOfSteps { get; set; }
        IList<IPoint> Execute(IPoint start);
    }
}
