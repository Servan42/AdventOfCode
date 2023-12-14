using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day14
{
    public class Day14Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = TiltNorth(InputLines.ToCharArray()).ToString();
        }

        public override void ComputePart2()
        {
            char[,] tiltedGrid = InputLines.ToCharArray();

            Dictionary<string, int> history = new Dictionary<string, int>();
            int firstCyclelengh = 0;
            int lastCycleLength = 0;
            for (int cycle = 0; cycle < 1000000000; cycle++)
            {
                TiltNorth(tiltedGrid);
                TiltWest(tiltedGrid);
                TiltSouth(tiltedGrid);
                int loadEast = TiltEast(tiltedGrid);
                string key = tiltedGrid.ToFlatString();

                if (history.ContainsKey(key))
                {
                    if (firstCyclelengh == 0) firstCyclelengh = cycle;
                    if (lastCycleLength == history.Count)
                        break;
                    lastCycleLength = history.Count;
                    history.Clear();
                }

                history.Add(key, loadEast);
            }

            int index = (1000000000 - firstCyclelengh - 1) % lastCycleLength;
            Output = history.Values.ElementAt(index).ToString();
        }

        private static int TiltNorth(char[,] gridToTilt)
        {
            int[] lastEmptyIndex = new int[gridToTilt.NbColumns()];
            int load = 0;
            for (int row = 0; row < gridToTilt.NbRows(); row++)
            {
                for (int col = 0; col < gridToTilt.NbColumns(); col++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                        continue;

                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[col] = row + 1;
                    }
                    else
                    {
                        if (lastEmptyIndex[col] == row)
                        {
                            load += gridToTilt.NbRows() - row;
                            lastEmptyIndex[col] = row + 1;
                        }
                        else
                        {
                            load += gridToTilt.NbRows() - lastEmptyIndex[col];
                            gridToTilt[lastEmptyIndex[col], col] = currentChar;
                            gridToTilt[row, col] = '.';
                            lastEmptyIndex[col]++;
                        }
                    }
                }
            }

            return load;
        }

        private static void TiltSouth(char[,] gridToTilt)
        {
            int[] lastEmptyIndex = Enumerable.Repeat(gridToTilt.NbRows() - 1, gridToTilt.NbColumns()).ToArray();
            for (int row = gridToTilt.NbRows() - 1; row >= 0; row--)
            {
                for (int col = 0; col < gridToTilt.NbColumns(); col++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                        continue;

                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[col] = row - 1;
                    }
                    else
                    {
                        if (lastEmptyIndex[col] == row)
                        {
                            lastEmptyIndex[col] = row - 1;
                        }
                        else
                        {
                            gridToTilt[lastEmptyIndex[col], col] = currentChar;
                            gridToTilt[row, col] = '.';
                            lastEmptyIndex[col]--;
                        }
                    }
                }
            }
        }

        private static void TiltWest(char[,] gridToTilt)
        {
            int[] lastEmptyIndex = new int[gridToTilt.NbColumns()];
            for (int col = 0; col < gridToTilt.NbColumns(); col++)
            {
                for (int row = 0; row < gridToTilt.NbRows(); row++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                        continue;

                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[row] = col + 1;
                    }
                    else
                    {
                        if (lastEmptyIndex[row] == col)
                        {
                            lastEmptyIndex[row] = col + 1;
                        }
                        else
                        {
                            gridToTilt[row, lastEmptyIndex[row]] = currentChar;
                            gridToTilt[row, col] = '.';
                            lastEmptyIndex[row]++;
                        }
                    }
                }
            }
        }

        private static int TiltEast(char[,] gridToTilt)
        {
            int load = 0;
            int[] lastEmptyIndex = Enumerable.Repeat(gridToTilt.NbColumns() - 1, gridToTilt.NbRows()).ToArray();
            for (int col = gridToTilt.NbColumns() - 1; col >= 0; col--)
            {
                for (int row = 0; row < gridToTilt.NbRows(); row++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                        continue;
                    
                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[row] = col - 1;
                    }
                    else
                    {
                        load += gridToTilt.NbRows() - row;
                        if (lastEmptyIndex[row] == col)
                        {
                            lastEmptyIndex[row] = col - 1;
                        }
                        else
                        {
                            gridToTilt[row, lastEmptyIndex[row]] = currentChar;
                            gridToTilt[row, col] = '.';
                            lastEmptyIndex[row]--;
                        }
                    }
                }
            }
            return load;
        }
    }
}
