using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day21
{
    public class Day21Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Garden.Parse(InputLines).Walk(64).ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
