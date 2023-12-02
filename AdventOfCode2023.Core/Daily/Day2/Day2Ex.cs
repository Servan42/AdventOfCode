using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day2
{
    public class Day2Ex : Exercise
    {
        public override void ComputePart1()
        {
            const int MAX_RED = 12;
            const int MAX_GREEN = 13;
            const int MAX_BLUE = 14;

            int sum = 0;
            foreach (var line in InputLines)
            {
                if (FindTheBiggestNumberForColor("red", line) > MAX_RED
                    || FindTheBiggestNumberForColor("green", line) > MAX_GREEN
                    || FindTheBiggestNumberForColor("blue", line) > MAX_BLUE)
                    continue;
                
                sum += GetGameNumber(line);
            }
            Output = sum.ToString();
        }

        private int GetGameNumber(string line)
        {
            return int.Parse(line.Split(':')[0].Replace("Game ", ""));
        }

        private int FindTheBiggestNumberForColor(string color, string line)
        {
            return line
                .Split(':')[1]
                .Replace(';', ',')
                .Split(',')
                .Where(x => x.Contains(color))
                .Select(x => int.Parse(x.Trim().Split(' ')[0]))
                .Max();
        }

        public override void ComputePart2()
        {
            var sum = 0;
            foreach(var line in InputLines)
            {
                sum += (FindTheBiggestNumberForColor("red", line) * FindTheBiggestNumberForColor("blue", line) * FindTheBiggestNumberForColor("green", line));
            }
            Output = sum.ToString();
        }
    }
}
