using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day19
{
    internal class Part
    {
        public Dictionary<string, int> SubPartValue { get; set; } = new Dictionary<string, int>();

        internal static Part Parse(string line)
        {
            Part part = new();
            var subParts = Regex.Matches(line, @"[0-9]+").Select(x => int.Parse(x.Value)).ToList();
            part.SubPartValue.Add("x", subParts[0]);
            part.SubPartValue.Add("m", subParts[1]);
            part.SubPartValue.Add("a", subParts[2]);
            part.SubPartValue.Add("s", subParts[3]);
            return part;
        }

        internal int SumFeilds()
        {
            return SubPartValue.Sum(kvp => kvp.Value);
        }
    }
}
