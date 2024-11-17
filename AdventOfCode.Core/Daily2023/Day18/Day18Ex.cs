using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day18
{
    public class Day18Ex : Exercise
    {
        public override void ComputePart1()
        {
            var digPlanLines = InputLines.Select(x => DigPlanLine.Parse(x)).ToList();

            // search for edges
            var trenchCoods = new List<(int row, int col)>();
            int currentRow = 0;
            int currentCol = 0;
            int minRow = int.MaxValue;
            int maxRow = int.MinValue;
            int minCol = int.MaxValue;
            int maxCol = int.MinValue;
            foreach (var digPlanLine in digPlanLines)
            {
                for (int i = 0; i < digPlanLine.NbOfMetersToDig; i++)
                {
                    var newRow = currentRow + (i * digPlanLine.DirectionCood.alongRow);
                    var newCol = currentCol + (i * digPlanLine.DirectionCood.alongCol);
                    trenchCoods.Add((newRow, newCol));

                }
                currentRow += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongRow;
                currentCol += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongCol;
                minRow = Math.Min(currentRow, minRow);
                minCol = Math.Min(currentCol, minCol);
                maxRow = Math.Max(currentRow, maxRow);
                maxCol = Math.Max(currentCol, maxCol);
            }

            // offset
            for (int i = 0; i < trenchCoods.Count; i++)
            {
                (int rowToChange, int colToChange) = trenchCoods[i];
                trenchCoods[i] = (rowToChange - minRow, colToChange - minCol);
            }

            // replay digging but offseted
            var grid = new char[maxRow - minRow + 3, maxCol - minCol + 3]; // adding empty rows around because I'm TIRED of edge guard clauses
            int row = -minRow + 1;
            int col = -minCol + 1;
            foreach (var digPlanLine in digPlanLines)
            {
                for (int i = 0; i < digPlanLine.NbOfMetersToDig; i++)
                {
                    grid[row + (i * digPlanLine.DirectionCood.alongRow), col + (i * digPlanLine.DirectionCood.alongCol)] = '#';
                }
                row += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongRow;
                col += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongCol;
            }

            // count # and the ones in intervals
            int count = 0;
            for (row = 0; row < grid.NbRows(); row++)
            {
                bool isCurrentlyInsideLoop = false;
                char chainStarter = '.';
                for (col = 0; col < grid.NbColumns(); col++)
                {
                    char currentChar = grid[row, col];
                    if (currentChar == '#')
                    {
                        count++;
                        char isChainEnder = GetTypeOfChainEnderIfIsOne(row, col, grid);
                        char isChainStarter = GetTypeOfChainStarterIfIsOne(row, col, grid);

                        if (grid[row, col - 1] != '#' && grid[row, col + 1] != '#')
                            isCurrentlyInsideLoop = !isCurrentlyInsideLoop;
                        else if (isChainEnder == '7' || isChainEnder == 'J')
                        {
                            if (chainStarter == 'L' && isChainEnder == '7'
                                || chainStarter == 'F' && isChainEnder == 'J')
                                isCurrentlyInsideLoop = !isCurrentlyInsideLoop;
                        }
                        else if (isChainStarter == 'L' || isChainStarter == 'F')
                        {
                            chainStarter = isChainStarter;
                        }
                    }
                    else
                    {
                        if (isCurrentlyInsideLoop) count++;//grid[row, col] = 'O';
                    }
                }
            }
            Output = count.ToString();
            Console.WriteLine(grid.ToFlatStringWithNewLinesAndDots());
        }

        private char GetTypeOfChainStarterIfIsOne(int row, int col, char[,] grid)
        {
            if (grid[row, col - 1] != '#' && grid[row, col + 1] == '#')
            {
                if (grid[row - 1, col] == '#') return 'F';
                else if (grid[row + 1, col] == '#') return 'L';
            }
            return '\0';
        }

        private char GetTypeOfChainEnderIfIsOne(int row, int col, char[,] grid)
        {
            if (grid[row, col - 1] == '#' && grid[row, col + 1] != '#')
            {
                if (grid[row - 1, col] == '#') return '7';
                else if (grid[row + 1, col] == '#') return 'J';
            }
            return '\0';
        }

        public override void ComputePart2()
        {
            var digPlanLines = InputLines.Select(x => DigPlanLine.Parse(x, true)).ToList();

            // get points
            var trenchCoods = new List<(double row, double col)>();
            double currentRow = 0.0;
            double currentCol = 0.0;
            double boundaryPointsCount = 0.0;
            foreach (var digPlanLine in digPlanLines)
            {
                boundaryPointsCount += digPlanLine.NbOfMetersToDig;
                currentRow += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongRow;
                currentCol += digPlanLine.NbOfMetersToDig * digPlanLine.DirectionCood.alongCol;
                trenchCoods.Add((currentRow, currentCol));
            }

            // Get area using shoelace formula
            //https://en.wikipedia.org/wiki/Shoelace_formula#Other_formulas_2
            double area = 0;
            for (int i = 0; i < trenchCoods.Count; i++)
            {
                int iplus1 = (i + 1) % trenchCoods.Count;
                int iminus1 = i - 1 < 0 ? trenchCoods.Count - 1 : i - 1;
                area += trenchCoods[i].row * (trenchCoods[iplus1].col - trenchCoods[iminus1].col);
            }
            area = Math.Abs(area) / 2;

            // This also works, we need to add the half squares of the permimeter ignored by shoelace, then add 1 as the sum of each perimeter area we're missing on corners.
            //Output = (area + (boundaryPointsCount / 2.0) + 1.0).ToString();

            // Get inside area using Pick's theorem
            // https://en.wikipedia.org/wiki/Pick%27s_theorem
            double interiorArea = area - (boundaryPointsCount / 2.0) + 1.0;

            Output = (interiorArea + boundaryPointsCount).ToString();
        }
    }
}
