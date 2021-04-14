using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    public class Loader
    {
        public Dictionary<string, Line> Load(string filePath)
        {
            var lines = new Dictionary<string, Line>();

            string record;
            string lineName = "";
            using (StreamReader fileReader = new StreamReader(filePath))
            {
                if ((record = fileReader.ReadLine()) != null)
                {
                    lines.Add(record, new Line(record));
                    lineName = record;
                }
                while ((record = fileReader.ReadLine()) != null)
                {
                    if (record == "")
                    {
                        if ((record = fileReader.ReadLine()) != null)
                        {
                            lines.Add(record, new Line(record));
                            lineName = record;
                        }
                    }
                    else
                    {
                        lines[lineName].Stations.Add(new Station(record));
                    }
                }
            }
            SetNextStations(lines);
            return lines;
        }

        private void SetNextStations(Dictionary<string,Line> lines)
        {
            Station firstStation;
            Station lastStation;
            Station prevStation = null;
            foreach (var line in lines)
            {
                firstStation = line.Value.Stations.FirstOrDefault();
                lastStation = line.Value.Stations.LastOrDefault();
                firstStation.NextStations.Add(lastStation);
                lastStation.NextStations.Add(firstStation);
                foreach (var station in line.Value.Stations)
                {
                    if (station == firstStation)
                    {
                        prevStation = station;
                    }
                    else
                    {
                        station.NextStations.Add(prevStation);
                        prevStation.NextStations.Add(station);
                        prevStation = station;
                    }
                }                
            }
        }

    }
}
