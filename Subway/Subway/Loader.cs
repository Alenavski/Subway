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
                Line curLine = null;
                while ((record = fileReader.ReadLine()) != null)
                {
                    if (isLine)
                    {
                        curLine = new Line(record);
                        lines.Add(curLine);
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
                            var firstStation = curLine.Stations.FirstOrDefault();
                            if (IsFirstStationOfCircledLine(firstStation, record))
                            {
                                prevStation = ConnectFirstAndLastStations(firstStation, prevStation);
                            }
                            else
                            {
                                prevStation = AddNewStation(curLine.Stations, record, prevStation);
                            }
                        }
                    }
                }
            }

            return lines;
        }

        public static Station AddNewStation(HashSet<Station> stations, string newStationName, Station prevStation)
        {
            var curStation = new Station(newStationName);
            stations.Add(curStation);
            if (prevStation != null)
            {
                ConnectStations(curStation, prevStation);
            }
            prevStation = curStation;
            return prevStation;
        }

        private static bool IsFirstStationOfCircledLine(Station firstStation, string newStationName)
        {
            if ((firstStation != null) && (firstStation.StationName.Equals(newStationName)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static Station ConnectFirstAndLastStations(Station firstStation, Station lastStation)
        { 
            if (lastStation == null)
            {
                lastStation = firstStation;
            }
            else
            {
                ConnectStations(firstStation, lastStation);
                lastStation = null;
            }
            return lastStation;
        }

        private static void ConnectStations(Station firstStation, Station secondStation)
        {
            secondStation.AddConnectedStation(firstStation);
            firstStation.AddConnectedStation(secondStation);
        }
    }
}
