using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day5
{
    public class Day5Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Almanac
                .Parse(InputLines)
                .GetSmallestMappingForSeeds()
                .ToString();
        }

        public override void ComputePart2()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            Output = Almanac
                .Parse(InputLines)
                .GetSmallestMappingForSeedsRangeMultiThread()
                .ToString();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
