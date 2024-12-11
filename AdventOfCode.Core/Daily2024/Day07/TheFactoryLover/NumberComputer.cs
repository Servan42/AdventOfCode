using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheFactoryLover
{
    internal abstract class NumberComputer
    {
        public abstract void ComputeCurrentNumber(double number, List<double> newExpressionsResults, double alreadyComputed);
    }
}
