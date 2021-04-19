using System;
using System.Collections.Generic;

namespace Subway
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Subway subway = new Subway("D:\\Subway\\Subway\\Subway\\StationList.txt");
            Stack<Station> path = subway.GetPath("AjaxRapids", "GoF Gardens");
            
            foreach (var station in path)
            {
                Console.Write(station.StationName, " ");
            }

        }
    }
}
