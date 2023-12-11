using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day11
{
    public class Day11Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Universe.Parse(InputLines).GetSumOfShortestPathForAllPairsOfGalaxies().ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
