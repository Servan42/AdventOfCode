using AdventOfCode.Core.Daily2024.Day07.TheFeatureFlag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheNonLiskovianInheritance
{
    internal abstract class Equation
    {
        private List<double> numbers = [];
        public double TestValue { get; private set; }

        public static Equation Build<T>(string inputLine)
            where T : Equation, new()
        {
            var equation = new T();
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
                    ComputeCurrentNumber(number, newExpressionsResults, alreadyComputed);
                }
                expressionsResults = newExpressionsResults;
            }

            return expressionsResults.Contains(TestValue);
        }

        protected abstract void ComputeCurrentNumber(double number, List<double> newExpressionsResults, double alreadyComputed);
    }
}
