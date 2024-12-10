using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07
{
    internal class Equation
    {
        private List<double> numbers = [];
        public double TestValue { get; private set; }

        public static Equation Build(string inputLine)
        {
            var equation = new Equation();
            var testValueAndNumbers = inputLine.Split(':');
            equation.TestValue = double.Parse(testValueAndNumbers[0]);
            equation.numbers = testValueAndNumbers[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToList();
            return equation;
        }

        public bool CanBeMadeTrue()
        {
            List<double> expressionsResults = [ numbers[0] ];
            foreach (var number in numbers.Skip(1))
            {
                var newExpressionsResults = new List<double>();
                foreach (var alreadyComputed in expressionsResults)
                {
                    newExpressionsResults.Add(alreadyComputed + number);
                    newExpressionsResults.Add(alreadyComputed * number);
                }
                expressionsResults = newExpressionsResults;
            }

            return expressionsResults.Contains(TestValue);
        }

        public bool CanBeMadeTruePart2()
        {
            List<double> expressionsResults = [numbers[0]];
            foreach (var number in numbers.Skip(1))
            {
                var newExpressionsResults = new List<double>();
                foreach (var alreadyComputed in expressionsResults)
                {
                    newExpressionsResults.Add(alreadyComputed + number);
                    newExpressionsResults.Add(alreadyComputed * number);
                    newExpressionsResults.Add(double.Parse(alreadyComputed.ToString() + number.ToString()));
                }
                expressionsResults = newExpressionsResults;
            }

            return expressionsResults.Contains(TestValue);
        }
    }
}
