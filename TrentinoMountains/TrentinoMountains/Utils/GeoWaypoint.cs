using System;
using System.Collections.Generic;
using System.Text;

namespace TrentinoMountains.Utils
{
    public class GeoWaypoint
    {
        #region Properties
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        #endregion

        #region Constructor
        public GeoWaypoint(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }
        #endregion
    }
}
