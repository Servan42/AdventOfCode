using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core
{
    public static class StringExtensions
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
    }
}
