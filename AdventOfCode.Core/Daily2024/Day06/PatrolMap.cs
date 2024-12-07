using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day06
{
    public class PatrolMap
    {

        private char[,] grid;
        
        private (int row, int col) guardCoods;
        private (int row, int col) originalGuardCoods;

        private (int row, int col) guardFacingDirection => directions[currentDirectionIndex];
        private int currentDirectionIndex = 0;
        private (int row, int col)[] directions = [(-1, 0), (0, 1), (1, 0), (0, -1)];
        
        private List<(int row, int col)> seen = new List<(int row, int col)>();
        private List<(int row, int col, int directionIndex)> seenWithDirection = new List<(int row, int col, int directionIndex)>();
        
        private const char BORDER = 'B';
        private const char OBSTRUCTION = '#';
        private const char CLEARPATH = '.';

        public static PatrolMap Build(List<string> input)
        {
            var result = new PatrolMap();
            var maxRows = input.Count + 2;
            var maxCols = input[0].Length + 2;
            result.grid = new char[maxRows, maxCols];
            for (int row = 0; row < maxRows; row++)
            {
                for (int col = 0; col < maxCols; col++)
                {
                    if (row == 0 || row == maxRows - 1
                        || col == 0 || col == maxCols - 1)
                    {
                        result.grid[row, col] = BORDER;
                        continue;
                    }

                    if (input[row - 1][col - 1] == '^')
                    {
                        result.originalGuardCoods = (row, col);
                        result.ResetGuardPosition();
                    }
                    else
                    {
                        result.grid[row, col] = input[row - 1][col - 1];
                    }
                }
            }
            return result;
        }

        internal void ResetGuardPosition()
        {
            guardCoods = originalGuardCoods;
            currentDirectionIndex = 0;
            seen.Clear();
            seenWithDirection.Clear();
            seen.Add(guardCoods);
        }

        internal int MakeGuardPatrol()
        {
            while (grid[guardCoods.row + guardFacingDirection.row, guardCoods.col + guardFacingDirection.col] != BORDER)
            {
                (int row, int col) nextCase = (guardCoods.row + guardFacingDirection.row, guardCoods.col + guardFacingDirection.col);

                if (grid[nextCase.row, nextCase.col] == OBSTRUCTION)
                {
                    currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                    continue;
                }

                guardCoods = nextCase;
                seen.Add(guardCoods);
            }
            return seen.Distinct().Count();
        }

        internal int MakeGuardPatrolToInfinite()
        {
            while (grid[guardCoods.row + guardFacingDirection.row, guardCoods.col + guardFacingDirection.col] != BORDER)
            {
                (int row, int col) nextCase = (guardCoods.row + guardFacingDirection.row, guardCoods.col + guardFacingDirection.col);

                if (grid[nextCase.row, nextCase.col] == OBSTRUCTION)
                {
                    currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                    continue;
                }

                guardCoods = nextCase;
                
                var footprint = (guardCoods.row, guardCoods.col, currentDirectionIndex);
                if (seenWithDirection.Contains(footprint))
                    return 1;

                seenWithDirection.Add(footprint);
            }
            return 0;
        }

        internal int CountObstructionsThatCreateLoop_BruteForce()
        {
            var sum = 0;

            for (int row = 0; row < grid.NbRows(); row++)
            {
                for (int col = 0; col < grid.NbColumns(); col++)
                {
                    if (grid[row, col] != CLEARPATH)
                        continue;

                    ResetGuardPosition();
                    grid[row, col] = OBSTRUCTION;
                    sum += MakeGuardPatrolToInfinite();
                    grid[row, col] = CLEARPATH;
                }
            }

            return sum;
        }
    }
}
