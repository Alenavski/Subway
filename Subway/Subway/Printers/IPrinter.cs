using System.Collections.Generic;

namespace Subway
{
    public interface IPrinter
    {
        void Print(List<Station> path);
    }
}
