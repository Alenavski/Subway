using System;

namespace Subway
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new FileLoader("C:\\projects\\Subway\\Subway\\StationList.txt");
            Subway subway = new Subway(loader.Load());
            var path = subway.GetPath("AjaxRapids", "GoF Gardens");
            IPrinter printer = new ConsolePrinter();
            printer.Print(path);
            printer = new FilePrinter("C:\\projects\\Subway\\Subway\\StationPath.txt");
            printer.Print(path);
        }
    }
}
