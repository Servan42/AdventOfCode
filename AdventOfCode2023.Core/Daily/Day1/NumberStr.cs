using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day1
{
    internal class NumberStr
    {
        public string Substr { get; set; }
        public int FirstIndex { get; set; } = -1;
        public int LastIndex { get; set; } = -1;
        public int Value { get; set; }
    }
}
