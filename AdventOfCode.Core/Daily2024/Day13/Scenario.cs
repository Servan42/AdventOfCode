using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day13
{
    internal class Scenario
    {
        public (decimal X, decimal Y) ButtonA { get; set; }
        public (decimal X, decimal Y) ButtonB { get; set; }
        public (decimal X, decimal Y) Prize { get; set; }

        private List<Iteration> seen = new();

        internal decimal GetNbTokensToWin()
        {
            Stopwatch sw = Stopwatch.StartNew();
            var fronteir = new PriorityQueue<Iteration, decimal>();
            fronteir.Enqueue(new(0, 0, 0, 0), 0);

            while (fronteir.Count > 0)
            {
                var iteration = fronteir.Dequeue();

                if (IsSatisfying(iteration))
                {
                    sw.Stop();
                    Console.WriteLine($"{sw.Elapsed} Found");
                    return iteration.nbA * 3 + iteration.nbB;
                }

                seen.Add(iteration);

                foreach (var neighbour in GetNeighbours(iteration))
                {
                    decimal manhattan = Math.Abs(neighbour.PosX - Prize.X) + Math.Abs(neighbour.PosY - Prize.Y);

                    if (!seen.Contains(neighbour)
                    && neighbour.nbA <= 100
                    && neighbour.nbB <= 100
                    && neighbour.PosX <= Prize.X && neighbour.PosY <= Prize.Y)
                        fronteir.Enqueue(neighbour, manhattan);
                }
            }

            sw.Stop();
            Console.WriteLine($"{sw.Elapsed} Not found");
            return -1;
        }

        private IEnumerable<Iteration> GetNeighbours(Iteration iteration)
        {
            var alongA = new Iteration(
                iteration.PosX + ButtonA.X,
                iteration.PosY + ButtonA.Y,
                iteration.nbA + 1,
                iteration.nbB);

            var alongB = new Iteration(
                iteration.PosX + ButtonB.X,
                iteration.PosY + ButtonB.Y,
                iteration.nbA,
                iteration.nbB + 1);

            return [alongA, alongB];
        }

        private bool IsSatisfying(Iteration iteration)
        {
            return iteration.PosX == Prize.X && iteration.PosY == Prize.Y;
        }

        internal record Iteration(decimal PosX, decimal PosY, decimal nbA, decimal nbB) { }
    }
}
