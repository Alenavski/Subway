using System;
using System.Collections.Generic;
using System.Text;

namespace Subway
{
    public class ConsolePrinter : IPrinter
    {
        public void Print(List<Station> path)
        {
            var pathString = new StringBuilder();
            foreach (var station in path)
            {
                pathString.Append(station.StationName + " -> ");
            }
            Console.WriteLine(pathString.ToString()[0..^4]);
        }
    }
}
