using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day25
{
    public class Day25Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = WeatherMachine.Parse(InputLines).Part1().ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
