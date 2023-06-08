namespace MarsRover12
{
    public interface IPlateau
    {
        long VisitedPlacesCount { get; }

        void SetPlaceVisited(PointOfCompass placeVisited);
    }
}