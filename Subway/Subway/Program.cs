using System;
using System.Collections.Generic;

namespace Subway
{
    class Program
    {
        static void Main(string[] args)
        {
            Subway subway = new Subway("D:\\Subway\\Subway\\Subway\\StationList.txt");
            string path = subway.GetPath("AjaxRapids", "GoF Gardens");

            Console.WriteLine(path);
        }
    }
}
