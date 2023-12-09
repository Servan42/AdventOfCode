using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day9
{
    public class Day9Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = InputLines
                .Select(x => HistoryLine.Parse(x).GetLastFinalExtrapolationValue())
                .Sum()
                .ToString();
        }

        public override void ComputePart2()
        {
            Output = InputLines
                .Select(x => HistoryLine.Parse(x).GetLastFinalExtrapolationValue(true))
                .Sum()
                .ToString();
        }
    }
}
