using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day11
{
    public class Universe
    {
        public List<string> Grid { get; set; }
        public List<((double, double), (double, double))> GalaxyPairsByCoord { get; set; } = new List<((double, double), (double, double))>();
        public List<(double, double)> GalaxiesByCoord { get; set; } = new List<(double, double)>();

        public Universe(List<string> grid)
        {
            Grid = grid;
        }

        public static Universe Parse(List<string> input, int expansionFactor = 2)
        {
            var universe = new Universe(input);
            universe.Expand(expansionFactor);
            universe.FillGalaxyList();
            Console.WriteLine("Graph initialized");
            return universe;
        }

        private void FillGalaxyList()
        {
            for (int row = 0; row < Grid.Count; row++)
            {
                if (!Grid[row].Contains('#')) continue;
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    if (Grid[row][column] == '#') GalaxiesByCoord.Add((row, column));
                }
            }
        }

        public double GetSumOfShortestPathForAllPairsOfGalaxies()
        {
            double sum = 0;

            foreach (var galaxyA in GalaxiesByCoord)
            {
                foreach (var galaxyB in GalaxiesByCoord)
                {
                    if (!GalaxyPairsByCoord.Contains((galaxyB, galaxyA)) && galaxyB != galaxyA)
                    {
                        GalaxyPairsByCoord.Add((galaxyA, galaxyB));
                        sum += GetHeuristicDistanceToGoal(galaxyA, galaxyB);
                    }
                }
            }

            return sum;
        }

        private void Expand(int expansionFactor)
        {
            var expandedInColumns = new List<string>();
            foreach (var row in Grid)
            {
                var newRow = new StringBuilder();
                for (int column = 0; column < row.Length; column++)
                {
                    newRow.Append(row[column]);
                    if (ColumnMustBeExpanded(column))
                    {
                        for (int i = 1; i < expansionFactor; i++)
                            newRow.Append(row[column]);
                    }
                }
                expandedInColumns.Add(newRow.ToString());
            }
            Console.WriteLine("Expanded in columns");
            Grid = expandedInColumns;
            var expandedInRows = new List<string>();
            foreach (var row in Grid)
            {
                expandedInRows.Add(row);
                if (!row.Contains('#'))
                {
                    for (int i = 1; i < expansionFactor; i++)
                        expandedInRows.Add(row);
                }
            }
            Console.WriteLine("Expanded in rows");
            Grid = expandedInRows;
        }

        private bool ColumnMustBeExpanded(int column)
        {
            return Grid.Count(row => row[column] == '#') == 0;
        }
        
        private double GetHeuristicDistanceToGoal((double, double) galaxyA, (double, double) galaxyB)
        {
            return Math.Abs(galaxyA.Item1 - galaxyB.Item1) + Math.Abs(galaxyA.Item2 - galaxyB.Item2);
        }
    }
}
