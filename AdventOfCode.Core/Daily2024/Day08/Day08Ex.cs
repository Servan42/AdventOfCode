using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day08
{
    public class Day08Ex : Exercise
    {
        public override void ComputePart1()
        {
            var roof = Roof.Build(this.InputLines);
            this.Output = roof.CalculateAntinodesForEachFrequencies().ToString();
        }

        public override void ComputePart2()
        {
            var roof = Roof.Build(this.InputLines, true);
            this.Output = roof.CalculateAntinodesForEachFrequencies().ToString();
        }
    }
}
