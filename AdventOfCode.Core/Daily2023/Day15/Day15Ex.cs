using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day15
{
    public class Day15Ex : Exercise
    {
        public Dictionary<int, List<string>> Boxes { get; set; } = new Dictionary<int, List<string>>();

        public override void ComputePart1()
        {
            Output = InputLines[0]
                .Split(',')
                .Select(step => Hash(step))
                .Sum()
                .ToString();
        }

        public int Hash(string step)
        {
            double hash = 0;

            foreach(var c in step)
            {
                hash += c;
                hash *= 17;
                hash %= 256;
            }

            return (int) hash;
        }

        public override void ComputePart2()
        {
            this.ComputeBoxes();
            Output = this.CalculateFocusingPowerFromBoxes().ToString();
        }

        public void ComputeBoxes()
        {
            foreach(var step in InputLines[0].Split(','))
            {
                string label = GetLabelFromStep(step);
                int hash = Hash(label);
                if(!Boxes.ContainsKey(hash))
                    Boxes.Add(hash, new List<string>());
                
                var lenses = Boxes[hash];

                if (step.Contains('-'))
                {
                    lenses.RemoveAll(x => x.Contains(label));
                    continue;
                }
                
                int indexInBox = lenses.Select((s, idx) => new { label = s.Split(' '), idx }).FirstOrDefault(x => x.label.Contains(label))?.idx ?? -1;
                if(indexInBox == -1)
                {
                    lenses.Add(step.Replace('=', ' '));
                }
                else
                {
                    lenses[indexInBox] = step.Replace('=', ' ');
                }
            }
        }

        private string GetLabelFromStep(string step)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var c in step)
            {
                if (c == '-' || c == '=')
                    break;
                stringBuilder.Append(c);
            }
            return stringBuilder.ToString();
        }

        public int CalculateFocusingPowerFromBoxes()
        {
            return Boxes
                .Select(lenses => 
                    lenses.Value
                    .Select((lens, lensIndex) => (lenses.Key + 1) * (lensIndex + 1) * (lens[^1] - '0'))
                    .Sum())
                .Sum();
        }
    }
}
