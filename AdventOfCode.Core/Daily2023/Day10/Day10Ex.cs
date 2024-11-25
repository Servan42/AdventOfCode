﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day10
{
    public class Day10Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = PipeMaze
                .Parse(InputLines)
                .GetNbStepsToNavigateToFarthestPoint()
                .ToString();
        }

        public override void ComputePart2()
        {
            Output = PipeMaze
                .Parse(InputLines)
                .GetNbTilesThatAreInsideTheLoop()
                .ToString();
        }
    }
}
