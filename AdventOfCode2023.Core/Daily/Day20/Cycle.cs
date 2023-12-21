using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day20
{
    internal class Cycle
    {
        public int CurrentCycle { get; set; }
        public int LastCycle { get; set; }
        public bool LastWasEqualToCurrent { get; set; }
    }
}
