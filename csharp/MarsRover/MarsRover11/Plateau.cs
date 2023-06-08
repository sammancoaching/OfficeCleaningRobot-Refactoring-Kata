using System.Collections.Generic;

namespace MarsRover11
{
    public class Plateau : IPlateau
    {
        private Dictionary<Point, object> _VisitedPlaces = new Dictionary<Point, object>();

        public long VisitedPlacesCount
        {
            get
            {
                return _VisitedPlaces.Count;
            }
        }

        public void SetPlaceVisited(Point placeVisited)
        {
            _VisitedPlaces[placeVisited] = null;                
        }
    }
}
