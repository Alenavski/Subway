using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    public class Station
    {
        public string StationName { get; }
        public List<Station> NextStations { get; }

        public Station(string stationName)
        {
            StationName = stationName;
            NextStations = new List<Station>();
        }

        public void AddNextStation(Station station)
        {
            NextStations.Add(station);
        }
    }
}
