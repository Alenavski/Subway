using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    public class Subway
    {
        private List<Line> _lines;
        private List<Station> _path;
        private Queue<Station> _workQueue;
        private Station _curStation;
        private Station _lastStation;

        public Subway(string filePath)
        {
            _lines = Loader.Load(filePath);
            _workQueue = new Queue<Station>();
            _path = new List<Station>();
        }

        private void findPath()
        {
            HashSet<Station> visitedStations = new HashSet<Station>();
            Station visitedStation;

            _path.Add(_curStation);
            _workQueue.Enqueue(_curStation);
            visitedStations.Add(_curStation);
            while (_workQueue.Count > 0)
            {
                var prevStation = _workQueue.Dequeue();
                foreach (var connectedStation in prevStation.ConnectedStations)
                {
                    if (!visitedStations.TryGetValue(connectedStation, out visitedStation))
                    {
                        _workQueue.Enqueue(connectedStation);
                        visitedStations.Add(connectedStation);
                        if (connectedStation == _lastStation)
                        {
                            return;
                        }
                    }
                }
            }
        }

        public List<Station> getPath(string firstStation, string lastStation)
        {
            _curStation = Loader.ReturnExistedStation(firstStation, _lines);
            _lastStation = Loader.ReturnExistedStation(lastStation, _lines);

            findPath();
            return _path;
        }
    }
}
