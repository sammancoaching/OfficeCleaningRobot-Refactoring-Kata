namespace OfficeCleaner11
{
    public interface IOffice
    {
        long VisitedPlacesCount { get; }

        void SetPlaceVisited(Point placeVisited);
    }
}