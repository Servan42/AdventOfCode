using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day08
{
    internal class Roof
    {
        private Dictionary<char, List<(int row, int col)>> antennasByFrequency = new();
        private List<(int row, int col)> antiNodes = new();
        private int maxRow;
        private int maxCol;
        private bool isPart2;

        public static Roof Build(List<string> inputLines, bool isPart2 = false)
        {
            var roof = new Roof()
            {
                maxRow = inputLines.Count - 1,
                maxCol = inputLines[0].Length - 1,
                isPart2 = isPart2
            };
            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    var current = inputLines[row][col];
                    if (current == '.')
                        continue;

                    if (roof.antennasByFrequency.ContainsKey(current))
                    {
                        roof.antennasByFrequency[current].Add((row, col));
                    }
                    else
                    {
                        roof.antennasByFrequency.Add(current, [(row, col)]);
                    }
                }
            }
            return roof;
        }

        public int CalculateAntinodesForEachFrequencies()
        {
            foreach (var antennasCoods in antennasByFrequency.Values)
            {
                CalculateAntinodesForEachPair(antennasCoods);
            }
            return antiNodes.Distinct().Count();
        }

        private void CalculateAntinodesForEachPair(List<(int row, int col)> antennasCoods)
        {
            foreach (var antenna1 in antennasCoods)
            {
                foreach (var antenna2 in antennasCoods)
                {
                    if (antenna1 == antenna2)
                        continue;

                    if (isPart2)
                        CalculateAntinodePart2(antenna1, antenna2);
                    else
                        CalculateAntinodePart1(antenna1, antenna2);
                }
            }
        }

        private void CalculateAntinodePart1((int row, int col) antenna1, (int row, int col) antenna2)
        {
            (int x, int y) vector = antenna1.Sub(antenna2);
            var antinode = antenna1.Add(vector);
            if (IsInRoof(antinode))
                antiNodes.Add(antinode);
        }

        private void CalculateAntinodePart2((int row, int col) antenna1, (int row, int col) antenna2)
        {
            (int x, int y) vector = antenna1.Sub(antenna2);
            var antinode = antenna1;
            while (IsInRoof(antinode))
            {
                antiNodes.Add(antinode);
                antinode = antinode.Add(vector);
            }
        }

        private bool IsInRoof((int row, int col) antinode)
        {
            return antinode.row >= 0
                && antinode.row <= maxRow
                && antinode.col >= 0
                && antinode.col <= maxCol;
        }
    }
}
