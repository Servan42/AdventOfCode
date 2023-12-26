﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day23
{
    public class Day23Ex : Exercise
    {
        public override void ComputePart1()
        {
            var maze = Maze.Parse(InputLines);
            maze.BFS();
            Output = maze.BuildPathsAndReturnLongest().ToString();
        }

        public override void ComputePart2()
        {
            var maze = Maze.Parse(InputLines, true);
            maze.BFS();
            //maze.DebugPrintSubSegments();
            maze.AddReversedSubSegments();
            Output = maze.BuildPathsAndReturnLongest_no_stackoverflow().ToString();
        }
    }
}