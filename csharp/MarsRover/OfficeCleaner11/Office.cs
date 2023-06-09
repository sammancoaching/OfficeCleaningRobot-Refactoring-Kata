using System.Collections.Generic;

namespace OfficeCleaner11
{
    public class Office : IOffice
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
