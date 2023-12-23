using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day22
{
    public class Day22Ex : Exercise
    {
        public override void ComputePart1()
        {
            var tower = Tower.Parse(InputLines);
            tower.MakeBlocksFall();
            Output = tower.CountBricksThatAreSafeToDesintegrate().ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
