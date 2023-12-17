using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day17
{
    public class CityBlock : Node
    {
        public CityBlock(int row, int col, int heat) : base($"{row},{col}")
        {
            Row = row;
            Col = col;
            Heat = heat;
        }

        public int Row { get; set; }
        public int Col { get; set; }
        public int Heat { get; set; }
    }
}
