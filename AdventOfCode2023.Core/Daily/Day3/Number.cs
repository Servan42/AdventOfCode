using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day3
{
    public class Number
    {
        public string Value { get; set; }
        public bool IsPartNumber { get; set; } = false;
        public string ColumnIndexConcatStartIndex { get; set; }
    }
}
