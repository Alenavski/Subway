using System;
using System.Collections.Generic;

namespace Subway
{
    public class Station
    {
        public string StationName { get; }
        public HashSet<Station> ConnectedStations { get; }

        public Station(string stationName)
        {
            StationName = stationName;
            ConnectedStations = new HashSet<Station>();
        }
        public override bool Equals(Object obj)
        {
            if (this.GetHashCode() == obj.GetHashCode())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.StationName.GetHashCode();
        }

        public void AddConnectedStation(Station station)
        {
            ConnectedStations.Add(station);
        }
    }
}
