using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day1
{
    public class Day1Ex : Exercise
    {
        private List<NumberStr> substringsAndIndexes = new()
        {
            new NumberStr { Substr = "one", Value = 1 },
            new NumberStr { Substr = "two", Value = 2 },
            new NumberStr { Substr = "three", Value = 3 },
            new NumberStr { Substr = "four", Value = 4 },
            new NumberStr { Substr = "five", Value = 5 },
            new NumberStr { Substr = "six", Value = 6 },
            new NumberStr { Substr = "seven", Value = 7 },
            new NumberStr { Substr = "eight", Value = 8 },
            new NumberStr { Substr = "nine", Value = 9 },
            new NumberStr { Substr = "1", Value = 1 },
            new NumberStr { Substr = "2", Value = 2 },
            new NumberStr { Substr = "3", Value = 3 },
            new NumberStr { Substr = "4", Value = 4 },
            new NumberStr { Substr = "5", Value = 5 },
            new NumberStr { Substr = "6", Value = 6 },
            new NumberStr { Substr = "7", Value = 7 },
            new NumberStr { Substr = "8", Value = 8 },
            new NumberStr { Substr = "9", Value = 9 },
        };

        public override void ComputePart1()
        {
            int sum = 0;
            foreach (var line in InputLines)
            {
                char firstNumber = line.First(c => IsCharANumber(c));
                char lastNumber = line.Last(c => IsCharANumber(c));
                int lineNumber = int.Parse($"{firstNumber}{lastNumber}");
                sum += lineNumber;
            }
            Output = sum.ToString();
        }

        public override void ComputePart2()
        {
            int sum = 0;
            foreach (var line in InputLines)
            {
                foreach (var substr in substringsAndIndexes)
                {
                    substr.FirstIndex = line.IndexOf(substr.Substr);
                    substr.LastIndex = line.LastIndexOf(substr.Substr);
                }

                var firstNumber = substringsAndIndexes
                    .Where(x => x.FirstIndex > -1)
                    .OrderBy(x => x.FirstIndex)
                    .Select(x => x.Value)
                    .First();

                var lastNumber = substringsAndIndexes
                    .Where(x => x.LastIndex > -1)
                    .OrderByDescending(x => x.LastIndex)
                    .Select(x => x.Value)
                    .First();

                int lineNumber = int.Parse($"{firstNumber}{lastNumber}");

                sum += lineNumber;
            }
            Output = sum.ToString();
        }

        private bool IsCharANumber(char c)
        {
            return c >= '0' && c <= '9';
        }
    }
}
