using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day11
{
    public class Day11Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Universe.Parse(InputLines).GetSumOfShortestPathForAllPairsOfGalaxies().ToString();
        }

        public override void ComputePart2()
        {
            Output = Universe.Parse(InputLines, 1000000).GetSumOfShortestPathForAllPairsOfGalaxies().ToString();
        }
    }
}
