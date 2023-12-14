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
            char[,] tiltedGrid = ToCharArray(InputLines.ToArray());
            int rowLength = InputLines.Count;
            int colLength = InputLines[0].Length;
            Output = TiltNorth(tiltedGrid, rowLength, colLength).ToString();
        }

        public override void ComputePart2()
        {
            int rowLength = InputLines.Count;
            int colLength = InputLines[0].Length;
            char[,] tiltedGrid = ToCharArray(InputLines.ToArray());

            int loadEast;
            Dictionary<string, int> history = new Dictionary<string, int>();
            int firstCyclelengh = 0;
            int lastCycleLength = 0;
            for (int cycle = 0; cycle < 1000000000; cycle++)
            {
                TiltNorth(tiltedGrid, rowLength, colLength);
                TiltWest(tiltedGrid, rowLength, colLength);
                TiltSouth(tiltedGrid, rowLength, colLength);
                loadEast = TiltEast(tiltedGrid, rowLength, colLength);
                if (cycle % 10000 == 0) Console.WriteLine(cycle * 100.0 / 1000000000.0);
                //Console.WriteLine(PrintGrid(rowLength, colLength, tiltedGrid));
                string key = CharArray2DToString(tiltedGrid);
                if (history.ContainsKey(key))
                {
                    if (firstCyclelengh == 0) firstCyclelengh = cycle;
                    if (lastCycleLength == history.Count) break;
                    lastCycleLength = history.Count;
                    history.Clear();
                }
                history.Add(key, loadEast);
            }

            int index = (1000000000 - firstCyclelengh - 1) % lastCycleLength;
            Output = history.Values.ElementAt(index).ToString();
        }

        public void D14()
        {
            var inputLines = File.ReadAllLines("AoC/input.txt");
            int rowLength = inputLines.Length;
            int colLength = inputLines[0].Length;
            char[,] tiltedGrid = ToCharArray(inputLines);

            int loadEast = 0;
            int firstLoadNorth = 0;
            Dictionary<string, int> history = new Dictionary<string, int>();
            int lastCycleLength = 0;
            for (double cycle = 0; cycle < 1000000000.0; cycle++)
            {
                //if(cycle == 0) firstLoadNorth = TiltNorth(tiltedGrid, rowLength, colLength);
                TiltNorth(tiltedGrid, rowLength, colLength);
                TiltWest(tiltedGrid, rowLength, colLength);
                TiltSouth(tiltedGrid, rowLength, colLength);
                loadEast = TiltEast(tiltedGrid, rowLength, colLength);
                if (cycle % 10000 == 0) Console.WriteLine(cycle * 100.0 / 1000000000.0);
                //Console.WriteLine(PrintGrid(rowLength, colLength, tiltedGrid));
                string key = CharArray2DToString(tiltedGrid);
                if (history.ContainsKey(key))
                {
                    Console.WriteLine($"key already present. cycle {cycle}. cycle lengh {history.Count}, clear");
                    if (lastCycleLength == history.Count) break;
                    lastCycleLength = history.Count;
                    history.Clear();
                }
                history.Add(key, loadEast);
            }

            Console.WriteLine((1000000000.0 - 119) % 7);
            //Console.WriteLine(history[(1000000000.0 - i) % (history.Count - i) + i]);
            Console.WriteLine(history.First().Value);
            //Console.WriteLine(loadNorth == 109665);
            Console.WriteLine(firstLoadNorth == 136);
            Console.WriteLine(loadEast == 64);
            //Console.WriteLine(loadEast == 96061); index 5
            //Console.WriteLine(PrintGrid(rowLength, colLength, tiltedGrid));

            Console.WriteLine(loadEast);
            Console.ReadLine();
        }

        public static string CharArray2DToString(char[,] chars)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    stringBuilder.Append(chars[i, j]);
                }
            }
            return stringBuilder.ToString();
        }

        private static int TiltNorth(char[,] gridToTilt, int rowLength, int colLength)
        {
            int[] lastEmptyIndex = new int[colLength];
            int load = 0;
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                    {
                        lastEmptyIndex[col] = Math.Min(lastEmptyIndex[col], row);
                    }
                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[col] = row + 1;
                    }
                    else
                    {
                        if (lastEmptyIndex[col] == row)
                        {
                            load += rowLength - row;
                            lastEmptyIndex[col] = row + 1;
                        }
                        else
                        {
                            load += rowLength - lastEmptyIndex[col];
                            gridToTilt[lastEmptyIndex[col], col] = currentChar;
                            gridToTilt[row, col] = '.';
                            lastEmptyIndex[col]++;
                        }
                    }
                }
            }

            return load;
        }

        private static void TiltSouth(char[,] gridToTilt, int rowLength, int colLength)
        {
            int[] lastEmptyIndex = Enumerable.Repeat(rowLength - 1, colLength).ToArray();
            for (int row = rowLength - 1; row >= 0; row--)
            {
                for (int col = 0; col < colLength; col++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                    {
                        lastEmptyIndex[col] = Math.Max(lastEmptyIndex[col], row);
                    }
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

        private static void TiltWest(char[,] gridToTilt, int rowLength, int colLength)
        {
            int[] lastEmptyIndex = new int[colLength];
            for (int col = 0; col < colLength; col++)
            {
                for (int row = 0; row < rowLength; row++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                    {
                        lastEmptyIndex[row] = Math.Min(lastEmptyIndex[row], col);
                    }
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

        private static int TiltEast(char[,] gridToTilt, int rowLength, int colLength)
        {
            int load = 0;
            int[] lastEmptyIndex = Enumerable.Repeat(colLength - 1, rowLength).ToArray();
            for (int col = colLength - 1; col >= 0; col--)
            {
                for (int row = 0; row < rowLength; row++)
                {
                    char currentChar = gridToTilt[row, col];
                    if (currentChar == '.')
                    {
                        lastEmptyIndex[row] = Math.Max(lastEmptyIndex[row], col);
                    }
                    else if (currentChar == '#')
                    {
                        lastEmptyIndex[row] = col - 1;
                    }
                    else
                    {
                        load += rowLength - row;
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

        private static string PrintGrid(int rowLength, int colLength, char[,] tiltedGrid)
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < rowLength; row++)
            {
                for (int col = 0; col < colLength; col++)
                {
                    sb.Append(tiltedGrid[row, col]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public static char[,] ToCharArray(string[] stringArray)
        {
            var result = new char[stringArray.Length, stringArray[0].Length];
            for (int i = 0; i < stringArray.Length; i++)
            {
                for (int j = 0; j < stringArray[0].Length; j++)
                {
                    result[i, j] = stringArray[i][j];
                }
            }
            return result;
        }
    }
}
