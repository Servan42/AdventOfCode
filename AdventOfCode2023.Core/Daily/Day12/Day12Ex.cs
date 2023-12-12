using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day12
{
    public class Day12Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = InputLines.Sum(x => SpringGroup.Parse(x).GetNbArrangements()).ToString();
        }

        public override void ComputePart2()
        {
            Output = InputLines.Sum(x => SpringGroup.Parse(x, true).GetNbArrangements()).ToString();
        }
    }
}
