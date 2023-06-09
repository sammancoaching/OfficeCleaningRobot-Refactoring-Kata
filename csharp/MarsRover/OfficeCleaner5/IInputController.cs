using System.Collections.Generic;

namespace OfficeCleaner5
{
    public interface IInputController
    {
        int[] InitialCoordinates { get; }
        List<MoveDirection> MoveDirections { get; }
        void ReadInputParameters();
    }
}
