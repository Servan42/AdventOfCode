using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day11
{
    public class Universe
    {
        public List<string> Grid { get; set; }
        public List<(Galaxy, Galaxy)> GalaxyPairsByCoord { get; set; } = new List<(Galaxy, Galaxy)>();
        public List<Galaxy> GalaxiesByCoord { get; set; } = new List<Galaxy>();

        public Universe(List<string> grid)
        {
            Grid = grid;
        }

        public static Universe Parse(List<string> input, int expansionFactor = 2)
        {
            var universe = new Universe(input);
            universe.FillGalaxyList();
            Console.WriteLine("Graph initialized");
            universe.Expand(expansionFactor);
            return universe;
        }

        //private void DebugPrintGalaxies()
        //{
        //    for(int i = 0; i < GalaxiesByCoord.Max(g => g.ExpandedCoodRow) + 1; i++)
        //    {
        //        for(int j = 0; j < GalaxiesByCoord.Max(g => g.ExpandedCoodColumn) + 1; j++)
        //        {
        //            if (GalaxiesByCoord.Count(g => g.ExpandedCoodRow == i && g.ExpandedCoodColumn == j) == 1)
        //                Console.Write("#");
        //            else
        //                Console.Write(".");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.WriteLine();
        //}

        private void FillGalaxyList()
        {
            for (int row = 0; row < Grid.Count; row++)
            {
                if (!Grid[row].Contains('#')) continue;
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    if (Grid[row][column] == '#') GalaxiesByCoord.Add(new Galaxy(row, column));
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
            for(int rowNum = 0; rowNum < Grid.Count; rowNum++)
            {
                for (int column = 0; column < Grid[rowNum].Length; column++)
                {
                    if (ColumnMustBeExpanded(column))
                    {
                        AddExpansionToRegisteredGalaxies(rowNum, column, expansionFactor, true);
                    }
                }
            }
            Console.WriteLine("Expanded in columns");

            for (int rowNum = 0; rowNum < Grid.Count; rowNum++)
            {
                if (!Grid[rowNum].Contains('#'))
                {
                    AddExpansionToRegisteredGalaxies(rowNum, 0, expansionFactor, false);
                }
            }
            Console.WriteLine("Expanded in rows");
        }

        private void AddExpansionToRegisteredGalaxies(int row, int column, int expansionFactor, bool expandInColumn)
        {
            foreach (var galaxy in GalaxiesByCoord)
            {
                if (expandInColumn && galaxy.CoodRow == row && galaxy.CoodColumn > column)
                {
                    galaxy.ExpandedCoodColumn += (expansionFactor - 1);
                }
                else if(!expandInColumn && galaxy.CoodRow > row)
                {
                    galaxy.ExpandedCoodRow += (expansionFactor - 1);
                }
            }
        }

        private bool ColumnMustBeExpanded(int column)
        {
            return Grid.Count(row => row[column] == '#') == 0;
        }

        private double GetHeuristicDistanceToGoal(Galaxy galaxyA, Galaxy galaxyB)
        {
            return Math.Abs(galaxyA.ExpandedCoodRow - galaxyB.ExpandedCoodRow) + Math.Abs(galaxyA.ExpandedCoodColumn - galaxyB.ExpandedCoodColumn);
        }
    }
}
