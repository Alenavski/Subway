using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    public class Line
    {
        public string LineName { get; }
        public List<Station> Stations { get; }

        public Line(string lineName)
        {
            LineName = lineName;
            Stations = new List<Station>();
        }

        public void AddStation(string stationName)
        {
            bool notExists = true;
            foreach (var station in Stations)
            {
                if (station.StationName.Equals(stationName))
                {
                    notExists = false;
                }
            }
            if (notExists)
            {
                Stations.Add(new Station(stationName));
            }
        }
    }
}
