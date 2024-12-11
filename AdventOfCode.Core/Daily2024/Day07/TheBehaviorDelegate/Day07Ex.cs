using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheBehaviorDelegate
{
    public class Day07Ex : Exercise
    {
        public override void ComputePart1()
        {
            this.Output = this.InputLines
                .Select(l => Equation.Build(l))
                .Where(e => e.CanBeMadeTrue(e.part1Handler))
                .Sum(e => e.TestValue)
                .ToString();
        }

        public override void ComputePart2()
        {
            this.Output = this.InputLines
                .Select(l => Equation.Build(l))
                .Where(e => e.CanBeMadeTrue(e.part2Handler))
                .Sum(e => e.TestValue)
                .ToString();
        }
    }
}
