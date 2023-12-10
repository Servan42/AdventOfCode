using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10
{
    public class PipeMaze : NodeGraph
    {
        // "line,column" -> "0,0" on top left

        public static PipeMaze Parse(List<string> inputLines)
        {
            var pipeMaze = new PipeMaze();
            return pipeMaze;
        }
    }
}
