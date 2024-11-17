using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core
{
    public static class MathsExtensions
    {
        public static List<int> PrimeFactors(this int number)
        {
            var primes = new List<int>();

            for (int div = 2; div <= number; div++)
            {
                while (number % div == 0)
                {
                    primes.Add(div);
                    number /= div;
                }
            }

            return primes;
        }

        public static double LeastCommonMultiple(this IEnumerable<int> numbers)
        {
            Dictionary<int, int> factorAndHighestPower = new();
            foreach (var number in numbers)
            {
                var primeFactors = number.PrimeFactors();
                foreach (var factor in primeFactors)
                {
                    int power = primeFactors.Count(f => f == factor);
                    if (factorAndHighestPower.ContainsKey(factor))
                    {
                        factorAndHighestPower[factor] = Math.Max(factorAndHighestPower[factor], power);
                    }
                    else
                    {
                        factorAndHighestPower.Add(factor, power);
                    }
                }
            }

            return factorAndHighestPower
                .Select(np => Math.Pow(np.Key, np.Value))
                .Mult();
        }

        public static int Mult(this IEnumerable<int> numbers)
        {
            int mult = 1;
            foreach (var number in numbers)
            {
                mult *= number;
            }
            return mult;
        }

        public static double Mult(this IEnumerable<double> numbers)
        {
            double mult = 1;
            foreach (var number in numbers)
            {
                mult *= number;
            }
            return mult;
        }
    }
}
