using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day3
{
    public class Gear
    {
        public int Power => NumbersAround.Count == 2 ? NumbersAround[0] * NumbersAround[1] : 0;
        public List<int> NumbersAround { get; set; } = new List<int>();
    }
}
