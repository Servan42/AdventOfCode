using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day20
{
    public class Day20Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Network.Parse(InputLines).PushTheButtonXTimes(1000).ToString();
        }

        public override void ComputePart2()
        {
            Output = Network.Parse(InputLines).PushTheButtonUntilRxIsReachedWithLowPulse().ToString();
        }
    }
}
