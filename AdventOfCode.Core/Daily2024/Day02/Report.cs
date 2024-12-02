using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day02
{
    internal class Report
    {
        private List<int> levels;

        public Report(List<int> levels)
        {
            this.levels = levels;
        }

        internal bool IsSafe()
        {
            bool isIncreasing = (levels[1] - levels[0]) > 0;
            for (int i = 1; i < levels.Count; i++)
            {
                int distanceToLast = levels[i] - levels[i - 1];

                if (Math.Abs(distanceToLast) < 1 
                    || Math.Abs(distanceToLast) > 3)
                    return false;

                if (distanceToLast < 0 && isIncreasing 
                    || distanceToLast > 0 && !isIncreasing)
                    return false;
            }
            return true;
        }

        internal bool IsSafeWithProblemDampener()
        {
            for (int i = 0; i < this.levels.Count; i++)
            {
                var subreport = new Report(new List<int>(this.levels));
                subreport.levels.RemoveAt(i);
                if(subreport.IsSafe())
                    return true;
            }
            return false;
        }
    }
}
