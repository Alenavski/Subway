﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subway
{
    public class Line
    {
        public string LineName { get; }
        public HashSet<Station> Stations { get; }

        public Line(string lineName)
        {
            LineName = lineName;
            Stations = new HashSet<Station>();
        }
    }
}
