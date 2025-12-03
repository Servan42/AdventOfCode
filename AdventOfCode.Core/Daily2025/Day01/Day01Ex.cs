using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2025.Day01
{
    public class Day01Ex : Exercise
    {
        public override void ComputePart1()
        {
            var dial = new Dial();
            dial.RunInstructions(InputLines);
            this.Output = dial.NumberOfTimeWeSaw0.ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
