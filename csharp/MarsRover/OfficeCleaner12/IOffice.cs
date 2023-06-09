namespace OfficeCleaner12
{
    public interface IOffice
    {
        long VisitedPlacesCount { get; }

        void SetPlaceVisited(PointOfCompass placeVisited);
    }
}