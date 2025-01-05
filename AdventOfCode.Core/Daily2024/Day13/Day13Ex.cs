using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day13
{
    public class Day13Ex : Exercise
    {
        public override void ComputePart1()
        {
            this.Output = ParseScenarios()
                .Select(s => s.GetNbTokensToWin())
                .Where(n => n > 0)
                .Sum()
                .ToString();
        }

        private List<Scenario> ParseScenarios()
        {
            var scenarios = new List<Scenario>();
            Scenario currentScenario = null;
            foreach (var line in InputLines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (line.Contains("Button A"))
                {
                    currentScenario = new Scenario();
                    currentScenario.ButtonA = ParseLine(line, '+');
                }
                else if (line.Contains("Button B"))
                {
                    currentScenario!.ButtonB = ParseLine(line, '+');
                }
                else if (line.Contains("Prize"))
                {
                    currentScenario!.Prize = ParseLine(line, '=');
                    scenarios.Add(currentScenario);
                }
            }
            return scenarios;
        }

        private (int X, int Y) ParseLine(string line, char detector)
        {
            (int X, int Y) result = new();

            result.Y = int.Parse(line.Split(detector).Last());
            result.X = int.Parse(line.Split(detector)[1].Split(',')[0]);

            return result;
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
