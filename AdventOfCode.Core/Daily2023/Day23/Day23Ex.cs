using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day23
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
            var maze = MazeRethink.Parse_with_edge_contraction(InputLines, true);
            Output = maze.BuildPathsAndReturnLongest().ToString();
        }
    }
}
