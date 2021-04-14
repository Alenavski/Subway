using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    class Station
    {
        public string StationName { get; }
        public HashSet<Station> NextStations { get; }

        public Station(string stationName)
        {
            StationName = stationName;
            NextStations = new HashSet<Station>();
        }

        public void AddNextStation(Station station)
        {
            NextStations.Add(station);
        }
    }
}
