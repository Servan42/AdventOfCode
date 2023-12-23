using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day22
{
    public class Block
    {
        public (int x, int y, int z) Extremity1 { get; set; }
        public (int x, int y, int z) Extremity2 { get; set; }

        public static Block Parse(string line)
        {
            var block = new Block();
            var coods = line.Split('~');
            var ext1 = coods[0].Split(',').Select(x => int.Parse(x)).ToList();
            var ext2 = coods[1].Split(',').Select(x => int.Parse(x)).ToList();
            block.Extremity1 = (ext1[0], ext1[1], ext1[2]);
            block.Extremity2 = (ext2[0], ext2[1], ext2[2]);
            return block;
        }

        public List<int> GetCurrentLayers()
        {
            return Enumerable.Range(Extremity1.z, 1 + Extremity2.z - Extremity1.z).ToList();
        }

        internal void FallBy(int nb)
        {
            Extremity1 = (Extremity1.x, Extremity1.y, Extremity1.z - nb);
            Extremity2 = (Extremity2.x, Extremity2.y, Extremity2.z - nb);
        }

        internal List<int> GetXs()
        {
            int minX = Math.Min(Extremity1.x, Extremity2.x);
            int maxX = Math.Max(Extremity1.x, Extremity2.x);
            return Enumerable.Range(minX, 1 + maxX - minX).ToList();
        }

        internal List<int> GetYs()
        {
            int minY = Math.Min(Extremity1.y, Extremity2.y);
            int maxY = Math.Max(Extremity1.y, Extremity2.y);
            return Enumerable.Range(minY, 1 + maxY - minY).ToList();
        }

        internal List<(int x, int y)> GetCoods()
        {
            var xs = GetXs();
            var ys = GetYs();
            if (xs.Count == 1)
                return ys.Select(y => (xs.First(), y)).ToList();
            else
                return xs.Select(x => (x, ys.First())).ToList();
        }

        internal bool IsSupporting(Block blockAbove)
        {
            if (this.GetCoods().Any(thisCoods => blockAbove.GetCoods().Contains(thisCoods)))
                return true;

            return false;
        }

        internal int MaxX()
        {
            return Math.Max(Extremity1.x, Extremity2.x);
        }

        internal int MaxY()
        {
            return Math.Max(Extremity1.y, Extremity2.y);
        }
    }
}
