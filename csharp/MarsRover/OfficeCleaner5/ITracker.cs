namespace OfficeCleaner5
{
    public interface ITracker
    {
        void AddPosition(int[] coordinates);
        int GetUniquePositions();
    }
}
