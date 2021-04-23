using System.Collections.Generic;

namespace Subway
{
    public class Line
    {
        public string LineName { get; }
        public HashSet<Station> Stations { get; }

        public Line(string lineName)
        {
            LineName = lineName;
            Stations = new HashSet<Station>();
        }

        public void AddStation(Station station)
        {
            Stations.Add(station);
        }
    }
}
