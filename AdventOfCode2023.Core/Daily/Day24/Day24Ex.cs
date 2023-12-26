using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day24
{
    public class Day24Ex : Exercise
    {
        private List<Hailstone> hailstones = new List<Hailstone>();

        public override void ComputePart1()
        {
            decimal lb = 200000000000000;
            decimal hb = 400000000000000;
            //decimal lb = 7;
            //decimal hb = 27;
            hailstones = InputLines.Select(l => Hailstone.Parse(l)).ToList();

            List<string> seenCouple = new();
            decimal count = 0;
            foreach (var a in hailstones)
            {
                foreach (var b in hailstones)
                {
                    if (a.ToString() == b.ToString()
                        || seenCouple.Contains(b.ToString() + "," + a.ToString()))
                        continue;

                    seenCouple.Add(a.ToString() + "," + b.ToString());

                    var intersectionPoint = a.Get2DIntersectionWith(b);

                    if (intersectionPoint == null)
                        continue;

                    if ((a.VectorX >= 0 && intersectionPoint.Value.x < a.X
                        || a.VectorX < 0 && intersectionPoint.Value.x > a.X)
                        && (a.VectorY >= 0 && intersectionPoint.Value.y < a.Y
                        || a.VectorY < 0 && intersectionPoint.Value.y > a.Y)
                        || 
                        (b.VectorX >= 0 && intersectionPoint.Value.x < b.X
                        || b.VectorX < 0 && intersectionPoint.Value.x > b.X)
                        && (b.VectorY >= 0 && intersectionPoint.Value.y < b.Y
                        || b.VectorY < 0 && intersectionPoint.Value.y > b.Y)
                        )
                        continue;

                    if (intersectionPoint.Value.x >= lb
                        && intersectionPoint.Value.y >= lb
                        && intersectionPoint.Value.x <= hb
                        && intersectionPoint.Value.y <= hb)
                    {
                        count++;
                    }
                }
            }

            Output = count.ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
