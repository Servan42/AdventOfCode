using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day19
{
    public class Day19Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = ProductionLine.Parse(InputLines).ProcessParts().ToString();
        }

        public override void ComputePart2()
        {
            Output = ProductionLine.Parse(InputLines).GetTotalWorkflowsNbCombinations().ToString();
        }
    }
}
