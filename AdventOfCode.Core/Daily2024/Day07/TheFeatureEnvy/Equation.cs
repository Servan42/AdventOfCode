using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheFeatureEnvy
{
    internal class Equation
    {
        private List<double> numbers = [];
        private readonly INumberComputerService numberComputerService;

        public double TestValue { get; private set; }

        public Equation(INumberComputerService numberComputerService)
        {
            this.numberComputerService = numberComputerService;
        }

        public static Equation Build(string inputLine, INumberComputerService numberComputerService)
        {
            var equation = new Equation(numberComputerService);
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
                    this.numberComputerService.ComputeCurrentNumber(number, newExpressionsResults, alreadyComputed);
                }
                expressionsResults = newExpressionsResults;
            }

            return expressionsResults.Contains(TestValue);
        }
    }
}
