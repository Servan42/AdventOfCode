using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day05
{
    public class Day05Ex : Exercise
    {
        private PrecedenceGraph precedenceGraph;
        private List<Updates> updates = new();

        public override void ComputePart1()
        {
            LoadInput();
            this.Output = updates
                .Where(p => p.AreInTheRightOrder(precedenceGraph))
                .Sum(p => p.GetMiddleNumber())
                .ToString();
        }

        public override void ComputePart2()
        {
            LoadInput();
            this.Output = updates
                .Where(p => !p.AreInTheRightOrder(precedenceGraph))
                .Select(p => p.ReOrder(precedenceGraph))
                .Sum(p => p.GetMiddleNumber())
                .ToString();
        }

        private void LoadInput()
        {
            precedenceGraph = PrecedenceGraph.Build(this.InputLines.Where(l => l.Contains('|')).ToList());
            foreach (var line in this.InputLines.Where(l => l.Contains(',')))
            {
                updates.Add(Updates.Build(line));
            }
        }
    }
}
