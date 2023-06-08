namespace MarsRover5
{
    public interface ITracker
    {
        void AddPosition(int[] coordinates);
        int GetUniquePositions();
    }
}
