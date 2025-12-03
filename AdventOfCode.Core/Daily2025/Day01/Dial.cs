using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2025.Day01
{
    internal class Dial
    {
        private int currentPosition = 50;
        public int NumberOfTimeWeSaw0 { get; private set; } = 0;

        internal void RunInstructions(List<string> instructions)
        {
            foreach (var instruction in instructions.Select(ParseIntruction))
            {
                currentPosition = (currentPosition + instruction) % 100;
                if (currentPosition == 0) NumberOfTimeWeSaw0++;
            }
        }

        private int ParseIntruction(string instruction)
        {
            var isAdd = instruction[0] == 'R';
            return int.Parse(instruction.Substring(1)) * (isAdd ? 1 : -1);
        }
    }
}
