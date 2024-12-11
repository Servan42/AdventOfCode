using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheBehaviorDelegate
{
    internal class Equation
    {
        private List<double> numbers = [];
        public double TestValue { get; private set; }

        public Action<double, List<double>, double> part1Handler { get; }
        public Action<double, List<double>, double> part2Handler { get; }

        public Equation()
        {
            part1Handler = ComputeCurrentNumberPart1;
            part2Handler = ComputeCurrentNumberPart2;
        }

        public static Equation Build(string inputLine)
        {
            var equation = new Equation();
            var testValueAndNumbers = inputLine.Split(':');
            equation.TestValue = double.Parse(testValueAndNumbers[0]);
            equation.numbers = testValueAndNumbers[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            return equation;
        }

        public bool CanBeMadeTrue(Action<double, List<double>, double> computeCurrentNumberHandler)
        {
            List<double> expressionsResults = [ numbers[0] ];
            foreach (var number in numbers.Skip(1))
            {
                var newExpressionsResults = new List<double>();
                foreach (var alreadyComputed in expressionsResults)
                {
                    computeCurrentNumberHandler(number, newExpressionsResults, alreadyComputed);
                }
                expressionsResults = newExpressionsResults;
            }
            return expressionsResults.Contains(TestValue);
        }

        private void ComputeCurrentNumberPart1(double number, List<double> newExpressionsResults, double alreadyComputed)
        {
            newExpressionsResults.Add(alreadyComputed + number);
            newExpressionsResults.Add(alreadyComputed * number);
        }

        private void ComputeCurrentNumberPart2(double number, List<double> newExpressionsResults, double alreadyComputed)
        {
            newExpressionsResults.Add(alreadyComputed + number);
            newExpressionsResults.Add(alreadyComputed * number);
            newExpressionsResults.Add(double.Parse(alreadyComputed.ToString() + number.ToString()));
        }
    }
}
