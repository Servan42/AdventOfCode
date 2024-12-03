using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AdventOfCode.Core;

namespace AdventOfCode.Core.Daily2024.Day03
{
    public class Day03Ex : Exercise
    {
        public override void ComputePart1()
        {
            this.Output = ResolveMemory(GetMemory()).ToString();
        }

        public override void ComputePart2()
        {
            this.Output = Regex.Matches($"do(){GetMemory()}don't()", @"do\(\)(.*?)don't\(\)")
                .Sum(x => ResolveMemory(x.Value))
                .ToString();
        }

        private string GetMemory()
        {
            // Assuming it's just one line.
            return string.Join("", this.InputLines);
        }

        private double ResolveMemory(string memory)
        {
            return Regex.Matches(memory, @"mul\([\d]+,[\d]+\)")
                .Sum(x => ResolveMultiplication(x.Value));
        }

        private double ResolveMultiplication(string mulPattern)
        {
            return Regex.Matches(mulPattern, @"[\d]+")
                .Select(x => double.Parse(x.Value))
                .Mult();
        }
    }
}
