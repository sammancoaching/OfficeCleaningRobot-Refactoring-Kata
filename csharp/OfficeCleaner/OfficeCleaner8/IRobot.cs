using System;
namespace OfficeCleaner8
{
    public interface IRobot
    {
        int move(IPoint start, System.Collections.Generic.IList<ICommand> commands);
    }
}
