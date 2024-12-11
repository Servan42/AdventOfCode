using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheFeatureFlag
{
    public class Day07Ex : Exercise
    {
        public override void ComputePart1()
        {
            this.Output = this.InputLines
                .Select(l => Equation.Build(l))
                .Where(e => e.CanBeMadeTrue(false))
                .Sum(e => e.TestValue)
                .ToString();
        }

        public override void ComputePart2()
        {
            this.Output = this.InputLines
                .Select(l => Equation.Build(l))
                .Where(e => e.CanBeMadeTrue(true))
                .Sum(e => e.TestValue)
                .ToString();
        }
    }
}
