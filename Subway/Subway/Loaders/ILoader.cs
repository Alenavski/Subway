using System.Collections.Generic;

namespace Subway
{
    public interface ILoader
    {
        List<Line> Load();
    }
}
