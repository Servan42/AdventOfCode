using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day24
{
    public class Hailstone
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal Z { get; set; }
        public decimal VectorX { get; set; }
        public decimal VectorY { get; set; }
        public decimal VectorZ { get; set; }

        // (x,y) = t(vx, vy)
        // For a point on the line (px, py)
        // px = x + tvx
        // py = y + tvy
        // So for any T a point is on the line if
        // (px - x) / vx = (py - y) / vy
        // Hence 
        // vy*px - vx*py = vy*x - vx*y
        // So under in the form of ax + by = C
            
        public decimal A => VectorY;
        public decimal B => -VectorX;
        public decimal C => VectorY * X - VectorX * Y;

        private string inputLine;

        internal static Hailstone Parse(string line)
        {
            var split = line.Replace('@', ',').Split(',', StringSplitOptions.TrimEntries);
            var hailstone = new Hailstone();
            hailstone.inputLine = line;
            hailstone.X = decimal.Parse(split[0]);
            hailstone.Y = decimal.Parse(split[1]);
            hailstone.Z = decimal.Parse(split[2]);
            hailstone.VectorX = decimal.Parse(split[3]);
            hailstone.VectorY = decimal.Parse(split[4]);
            hailstone.VectorZ = decimal.Parse(split[5]);
            return hailstone;
        }

        public (decimal x, decimal y)? Get2DIntersectionWith(Hailstone otherHailstone)
        {
            // Parallel
            if (this.Is2DParallelTo(otherHailstone))
                return null;

            // A1x + B1y = C1
            // A2x + B2y = C2
            decimal A1 = A;
            decimal B1 = B;
            decimal C1 = C;
            decimal A2 = otherHailstone.A;
            decimal B2 = otherHailstone.B;
            decimal C2 = otherHailstone.C;

            decimal Px = (C1 * B2 - C2 * B1) / (A1 * B2 - A2 * B1);
            decimal Py = (C2 * A1 - C1 * A2) / (A1 * B2 - A2 * B1);

            return (Px, Py);
        }

        private bool Is2DParallelTo(Hailstone otherHailstone)
        {
            return VectorX / otherHailstone.VectorX == VectorY / otherHailstone.VectorY;
        }

        public decimal GetTimeAtWhichItWillReachPoint((decimal x, decimal y) point)
        {
            decimal t1 = (point.x - X) / VectorX;
            decimal t2 = (point.y - Y) / VectorY;
            if (t1 != t2) throw new Exception($"{t1} =/= {t2}");
            return t1;
        }

        public override string ToString()
        {
            return inputLine;
        }
    }
}
