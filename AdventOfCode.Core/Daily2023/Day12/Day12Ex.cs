using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day12
{
    public class Day12Ex : Exercise
    {
        public override void ComputePart1()
        {
            //Output = InputLines.Sum(x => SpringGroup.Parse(x).GetNbArrangements()).ToString();
            Output = InputLines.Sum(x => SpringGroup.Parse(x).GetNbArrangementsRecursive()).ToString();
        }

        public override void ComputePart2()
        {
            //Output = InputLines.Sum(x => SpringGroup.Parse(x, true).GetNbArrangements()).ToString();
            Output = InputLines.Sum(x => SpringGroup.Parse(x, true).GetNbArrangementsRecursive()).ToString();
        }
    }
}
