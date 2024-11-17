using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day5
{
    public class MapRange
    {
        public MapRange(double destinationRange, double sourceRange, double rangeLength)
        {
            DestinationRange = destinationRange;
            SourceRange = sourceRange;
            RangeLength = rangeLength;
        }

        public double DestinationRange { get; set; }
        public double SourceRange { get; set; }
        public double RangeLength { get; set; }

        internal double Map(double seed)
        {
            if (seed < SourceRange || seed > SourceRange + RangeLength - 1)
                return seed;

            return seed + (DestinationRange - SourceRange);
        }
    }
}
