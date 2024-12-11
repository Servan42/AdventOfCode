﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheFactoryLover
{
    internal class NumberComputerPart2 : NumberComputer
    {
        public override void ComputeCurrentNumber(double number, List<double> newExpressionsResults, double alreadyComputed)
        {
            newExpressionsResults.Add(alreadyComputed + number);
            newExpressionsResults.Add(alreadyComputed * number);
            newExpressionsResults.Add(double.Parse(alreadyComputed.ToString() + number.ToString()));
        }
    }
}
