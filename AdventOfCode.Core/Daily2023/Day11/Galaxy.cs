using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day11
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
