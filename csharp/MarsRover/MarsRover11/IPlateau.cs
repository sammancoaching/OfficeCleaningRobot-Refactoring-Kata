namespace MarsRover11
{
    public interface IPlateau
    {
        long VisitedPlacesCount { get; }

        void SetPlaceVisited(Point placeVisited);
    }
}