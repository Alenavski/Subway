using System;

namespace Subway
{
    class Program
    {
        static void Main(string[] args)
        {
            Subway subway = new Subway(Loader.Load("D:\\Subway\\Subway\\Subway\\StationList.txt"));
            var path = subway.GetPath("AjaxRapids", "GoF Gardens");

            foreach (var station in path)
            {
                Console.WriteLine(station.StationName);
            }
        }
    }
}
