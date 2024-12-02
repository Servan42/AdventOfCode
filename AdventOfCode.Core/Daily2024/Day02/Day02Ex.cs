using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day02
{
    public class Day02Ex : Exercise
    {
        public override void ComputePart1()
        {
            this.Output = this.InputLines
                .Select(l => new Report(l.GetSpacesSeparatedInts()))
                .Count(r => r.IsSafe())
                .ToString();
        }

        public override void ComputePart2()
        {
            this.Output = this.InputLines
                .Select(l => new Report(l.GetSpacesSeparatedInts()))
                .Count(r => r.IsSafeWithProblemDampener())
                .ToString();
        }
    }
}
