using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Subway
{
    public class FilePrinter : IPrinter
    {
        private string _filePath;

        public FilePrinter(string filePath)
        {
            _filePath = filePath;
        }

        public void Print(List<Station> path)
        {
            using (var fileWriter = new StreamWriter(_filePath))
            {
                var pathString = new StringBuilder();
                foreach (var station in path)
                {
                    pathString.Append(station.StationName + " -> ");
                }
                fileWriter.Write(pathString.ToString()[0..^4]);
            }
        }
    }
}
