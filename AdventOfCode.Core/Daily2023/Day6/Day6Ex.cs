using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day6
{
    public class Day6Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = RaceData.Parse(InputLines).ComputeNumbersOfWayToBeatTheRecordMultiplied();
        }

        public override void ComputePart2()
        {
            Output = RaceData.ParsePart2(InputLines).ComputeNumbersOfWayToBeatTheRecordMultiplied();
        }
    }
}
