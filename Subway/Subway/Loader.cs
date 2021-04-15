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
        public static List<Line> Load(string filePath)
        {
            var lines = ReadLines(filePath);            
            return lines;
        }

        private static List<Line> ReadLines(string filePath)
        {
            var lines = new List<Line>();

            using (var fileReader = new StreamReader(filePath))
            {
                string record;
                bool isLine = true;
                Station prevStation = null;
                while ((record = fileReader.ReadLine()) != null)
                {
                    if (isLine)
                    {
                        lines.Add(new Line(record));
                        isLine = false;
                    }
                    else
                    {
                        if (record == string.Empty)
                        {

                            isLine = true;
                        }
                        else
                        {
                            SetStations(lines, record, ref prevStation);
                        }
                    }
                }
            }

            return lines;
        }

        public static void SetStations(List<Line> lines, string record, ref Station prevStation)
        {
            if ((lines.Last().Stations.FirstOrDefault() != null) && (lines.Last().Stations.FirstOrDefault().StationName.Equals(record)))
            {
                if (prevStation == null)
                {
                    prevStation = lines.Last().Stations.First();
                }
                else
                {
                    prevStation.ConnectedStations.Add(lines.Last().Stations.First());
                    lines.Last().Stations.First().ConnectedStations.Add(prevStation);
                    prevStation = null;
                }
            }
            else
            {
                lines.Last().Stations.Add(new Station(record));
                var curStation = lines.Last().Stations.Last();
                if (prevStation != null)
                {
                    curStation.ConnectedStations.Add(prevStation);
                    prevStation.ConnectedStations.Add(curStation);
                }
                prevStation = curStation;
            }
        }
    }
}
