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
        public static Dictionary<string, Line> Load(string filePath)
        {
            var lines = new Dictionary<string, Line>();

            using (var fileReader = new StreamReader(filePath))
            {
                string record;
                string lineName = "";
                bool isLine = true;
                
                while ((record = fileReader.ReadLine()) != null)
                {
                    if (isLine)
                    {
                        lines.Add(record, new Line(record));
                        lineName = record;
                        isLine = false;
                    }
                    else
                    {
                        if (record == String.Empty)
                        {
                            isLine = true;
                        }
                        else
                        {
                            lines[lineName].Stations.Add(new Station(record));
                        }
                    }
                }
            }
            SetNextStations(lines);
            return lines;
        }

        private static void SetNextStations(Dictionary<string, Line> lines)
        {
            foreach (var line in lines)
            {
                Station firstStation = line.Value.Stations.FirstOrDefault();
                Station lastStation = line.Value.Stations.LastOrDefault();
                firstStation.NextStations.Add(lastStation);
                lastStation.NextStations.Add(firstStation);

                Station prevStation = null;
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
