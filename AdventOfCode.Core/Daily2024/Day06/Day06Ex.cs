using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day06
{
    public class Day06Ex : Exercise
    {
        public override void ComputePart1()
        {
            PatrolMap map = PatrolMap.Build(this.InputLines);
            this.Output = map.MakeGuardPatrol().ToString();
        }

        public override void ComputePart2()
        {
            PatrolMap map = PatrolMap.Build(this.InputLines);
            Console.WriteLine("BruteForce. Took 1min03 on my computer");
            this.Output = map.CountObstructionsThatCreateLoop_BruteForce().ToString();
        }
    }
}
