using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
    public static class DataStructureExtensions
    {
        public static readonly (int alongRow, int alongCol)[] CrossDirections = [(-1, 0), (0, 1), (1, 0), (0, -1)];
        public static readonly (int alongRow, int alongCol)[] StarDirections = [(-1, -1), (-1, 0), (-1, 1), (0, 1), (1, 1), (1, 0), (1, -1), (0, -1)];

        public static List<double> GetSpacesSeparatedDoubles(this string str)
        {
            return str
                .Split(' ')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => double.Parse(s))
                .ToList();
        }

        public static List<int> GetSpacesSeparatedInts(this string str)
        {
            return str
                .Split(' ')
                .Where(s => !string.IsNullOrEmpty(s))
                .Select(s => int.Parse(s))
                .ToList();
        }

        public static int NbColumns(this char[,] grid)
        {
            return grid.GetLength(1);
        }

        public static int NbRows(this char[,] grid)
        {
            return grid.GetLength(0);
        }

        /// <summary>
        /// O(n²)
        /// </summary>
        public static string ToFlatString(this char[,] chars)
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

        /// <summary>
        /// O(n²)
        /// </summary>
        public static string ToFlatStringWithNewLinesAndDots(this char[,] chars)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < chars.GetLength(0); i++)
            {
                for (int j = 0; j < chars.GetLength(1); j++)
                {
                    char current = chars[i, j];
                    stringBuilder.Append(current == '\0' ? '.' : current);
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// O(n²)
        /// </summary>
        public static char[,] ToCharArray(this List<string> stringList)
        {
            var result = new char[stringList.Count, stringList[0].Length];
            for (int row = 0; row < stringList.Count; row++)
            {
                for (int col = 0; col < stringList[0].Length; col++)
                {
                    result[row, col] = stringList[row][col];
                }
            }
            return result;
        }

        /// <summary>
        /// O(n²)
        /// </summary>
        public static char[,] ToCharArrayWithBorder(this List<string> stringList, char borderChar)
        {
            var maxRows = stringList.Count + 2;
            var maxCols = stringList[0].Length + 2;
            var result = new char[maxRows, maxCols];

            for (int row = 0; row < stringList.Count + 2; row++)
            {
                for (int col = 0; col < stringList[0].Length + 2; col++)
                {
                    if (row == 0 || row == maxRows - 1
                        || col == 0 || col == maxCols - 1)
                    {
                        result[row, col] = borderChar;
                        continue;
                    }

                    result[row, col] = stringList[row - 1][col - 1];
                }
            }
            return result;
        }

        public static void PrintGridInTerminal(this char[,] grid)
        {
            for (int row = 0; row < grid.NbRows(); row++)
            {
                for (int col = 0; col < grid.NbColumns(); col++)
                {
                    Console.Write(grid[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}

