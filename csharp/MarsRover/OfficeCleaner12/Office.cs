using System.Collections.Generic;

namespace OfficeCleaner12
{
    public class Office : IOffice
    {
        private Dictionary<PointOfCompass, object> _VisitedPlaces = new Dictionary<PointOfCompass, object>();

        public long VisitedPlacesCount
        {
            get
            {
                return _VisitedPlaces.Count;
            }
        }

        public void SetPlaceVisited(PointOfCompass placeVisited)
        {
            _VisitedPlaces[placeVisited] = null;                
        }
    }
}
