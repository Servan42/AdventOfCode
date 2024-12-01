using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day01
{
    public class Day01Ex : Exercise
    {
        public override void ComputePart1()
        {
            var (firstList, secondList) = GetBothListsFromInput();

            firstList.Sort();
            secondList.Sort();

            double sum = 0;
            for (int i = 0; i < firstList.Count; i++)
            {
                sum += Math.Abs(firstList[i] - secondList[i]);
            }

            this.Output = sum.ToString();
        }

        private (List<double>, List<double>) GetBothListsFromInput()
        {
            var firstList = new List<double>();
            var secondList = new List<double>();

            foreach (var line in InputLines)
            {
                var locationIds = line.GetSpacesSeparatedDoubles();
                firstList.Add(locationIds[0]);
                secondList.Add(locationIds[1]);
            }

            return (firstList, secondList);
        }

        public override void ComputePart2()
        {
            var (firstList, secondList) = GetBothListsFromInput();
            this.Output = firstList
                .Sum(x => GetSimilarityScore(x, secondList))
                .ToString();
        }

        private double GetSimilarityScore(double firstListNumber, List<double> secondList)
        {
            return firstListNumber * secondList.Count(x => x == firstListNumber);
        }
    }
}
