using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day10
{
    public class Day10Ex : Exercise
    {
        public override void ComputePart1()
        {
           this.Output = TrailMap.Build(this.InputLines)
                .GetTrailScores(true)
                .ToString();
        }

        public override void ComputePart2()
        {
            this.Output = TrailMap.Build(this.InputLines)
                .GetTrailScores(false)
                .ToString();
        }
    }
}
