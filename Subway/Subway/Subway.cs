using System.Collections.Generic;

namespace Subway
{
    public class Subway
    {
        private List<Line> _lines;

        public Subway(List<Line> lines)
        {
            _lines = lines;
        }

        private static Stack<Station> FindPath(Station curStation, Station lastStation)
        {
            var workQueue = new Queue<Station>();
            var visitedStations = new Dictionary<Station, int>();
            int iteration = 0;

            workQueue.Enqueue(curStation);
            visitedStations.Add(curStation, iteration);
            iteration++;
            while (workQueue.Count > 0)
            {
                int size = workQueue.Count;
                for (int i = 0; i < size; i++)
                {
                    var prevStation = workQueue.Dequeue();
                    foreach (var connectedStation in prevStation.ConnectedStations)
                    {
                        if (!visitedStations.ContainsKey(connectedStation))
                        {
                            workQueue.Enqueue(connectedStation);
                            visitedStations.Add(connectedStation, iteration);
                            if (connectedStation == lastStation)
                            {
                                var path = FormPath(iteration, visitedStations, lastStation);
                                return path;
                            }
                        }
                    }
                }                
                iteration++;
            }
            return null ;
        }

        private static Stack<Station> FormPath(int iterationsCount, Dictionary<Station, int> visitedStations, Station lastStation)
        {
            var path = new Stack<Station>();
            path.Push(lastStation);
            for (int i = iterationsCount - 1; i >= 0; i--)
            {
                foreach (var station in lastStation.ConnectedStations)
                {
                    if (visitedStations.TryGetValue(station, out int index))
                    {
                        if (index == i)
                        {
                            path.Push(station);
                            lastStation = station;
                            break;
                        }
                    }
                }
            }
            return path;
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

        public List<Station> GetPath(string firstStationName, string lastStationName)
        {
            var firstStation = ReturnExistedStation(firstStationName, _lines);
            var lastStation = ReturnExistedStation(lastStationName, _lines);

            var stackPath = FindPath(firstStation, lastStation);

            var path = new List<Station>();
            while (stackPath.Count > 0)
            {
                path.Add(stackPath.Pop());
            }
            return path;
        }
    }
}
