using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day11
{
    public class Galaxy
    {
        public Galaxy(double coodX, double coodY)
        {
            CoodRow = coodX;
            CoodColumn = coodY;
            ExpandedCoodRow = coodX;
            ExpandedCoodColumn = coodY;
        }

        public double CoodRow { get; set; }
        public double CoodColumn { get; set; }

        public double ExpandedCoodRow { get; set; }
        public double ExpandedCoodColumn { get; set; }
    }
}
