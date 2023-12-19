using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core
{
    public static class DataStructureExtensions
    {
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
            for (int i = 0; i < stringList.Count; i++)
            {
                for (int j = 0; j < stringList[0].Length; j++)
                {
                    result[i, j] = stringList[i][j];
                }
            }
            return result;
        }
    }
}

