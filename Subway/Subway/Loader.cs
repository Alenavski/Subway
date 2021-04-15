using System.Collections.Generic;
using System.IO;

namespace Subway
{
    public class Loader
    {
        public static List<Line> Load(string filePath)
        {
            var lines = new List<Line>();

            using (var fileReader = new StreamReader(filePath))
            {
                string record;
                bool isLine = true;
                Station prevStation = null;
                Line curLine = null;
                while ((record = fileReader.ReadLine()) != null)
                {
                    if (isLine)
                    {
                        curLine = new Line(record);
                        lines.Add(curLine);
                        isLine = false;
                    }
                    else if (record == string.Empty)
                    {
                        isLine = true;
                        prevStation = null;
                    }
                    else
                    {
                        var curStation = ReturnExistedStation(record, lines);

                        if (curStation == null)
                        {
                            curStation = new Station(record);
                        }
                        curLine.AddStation(curStation);
                        
                        if (prevStation != null)
                        {
                            ConnectStations(curStation, prevStation);
                        }
                        prevStation = curStation;
                    }
                }
            }
            return lines;
        }

        private static Station ReturnExistedStation(string newStationName, List<Line> lines)
        {
            var newStation = new Station(newStationName);
            foreach (var line in lines)
            {
                if (line.Stations.TryGetValue(newStation, out Station curStation))
                {
                    return curStation;
                }
            }
            return null;
        }

        private static void ConnectStations(Station firstStation, Station secondStation)
        {
            secondStation.AddConnectedStation(firstStation);
            firstStation.AddConnectedStation(secondStation);
        }
    }
}
