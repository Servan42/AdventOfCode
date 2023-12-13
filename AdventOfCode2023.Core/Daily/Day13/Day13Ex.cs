using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day13
{
    public class Day13Ex : Exercise
    {
        public override void ComputePart1()
        {
            GenericCall(true);
        }
        public override void ComputePart2()
        {
            GenericCall(false);
        }

        private void GenericCall(bool isPart1)
        {
            var currentMirrorToParse = new List<string>();
            var mirrors = new List<Mirror>();
            InputLines.Add("");
            foreach (var line in InputLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    mirrors.Add(Mirror.Parse(currentMirrorToParse, isPart1));
                    currentMirrorToParse.Clear();
                }
                else
                {
                    currentMirrorToParse.Add(line);
                }
            }

            var result = mirrors.Sum(m => m.VerticalCount) + (100 * mirrors.Sum(m => m.HorizontalCount));
            Output = result.ToString();
        }
    }
}
