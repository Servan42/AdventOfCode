using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day3
{
    public class Day3Ex : Exercise
    {
        public override void ComputePart1()
        {
            EngineSchematic engineSchematic = new EngineSchematic(InputLines.Count, InputLines[0].Length);
            engineSchematic.LoadFromInputLines(InputLines);
            engineSchematic.LookForPartNumbersInGrid();
            Output = engineSchematic.GetPartNumbersSum();
        }

        public override void ComputePart2()
        {
            EngineSchematic engineSchematic = new EngineSchematic(InputLines.Count, InputLines[0].Length);
            engineSchematic.LoadFromInputLines(InputLines);
            engineSchematic.LookForGearsInGrid();
            Output = engineSchematic.GetGearPowersSum();
        }
    }
}
