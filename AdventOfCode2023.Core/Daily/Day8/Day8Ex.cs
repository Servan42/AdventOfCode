using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day8
{
    public class Day8Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = NetworkMap.Parse(InputLines).FollowPathFromAAAToZZZ().ToString();
        }

        public override void ComputePart2()
        {
            Output = NetworkMap.Parse(InputLines).ComputeNumberOfStepsToSyncForPart2().ToString();
        }
    }
}
