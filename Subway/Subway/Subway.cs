using System.Collections.Generic;


namespace Subway
{
    public class Subway
    {
        private List<Line> _lines;
        
        public Subway(string filePath)
        {
            _lines = Loader.Load(filePath);
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
            var _path = new Stack<Station>();
            _path.Push(lastStation);
            for (int i = iterationsCount - 1; i >= 0; i--)
            {
                foreach (var station in lastStation.ConnectedStations)
                {
                    if (visitedStations.TryGetValue(station, out int index))
                    {
                        if (index == i)
                        {
                            _path.Push(station);
                            lastStation = station;
                            break;
                        }
                    }
                }
            }
            return _path;
        }

        public Stack<Station> GetPath(string firstStationName, string lastStationName)
        {
            var firstStation = Loader.ReturnExistedStation(firstStationName, _lines);
            var lastStation = Loader.ReturnExistedStation(lastStationName, _lines);

            var stackPath = FindPath(firstStation, lastStation);
            return stackPath;
        }
    }
}
