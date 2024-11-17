using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day7
{
    public class Day7Ex : Exercise
    {
        public override void ComputePart1()
        {
            GenericCall(false);
        }

        public override void ComputePart2()
        {
            GenericCall(true);
        }

        private void GenericCall(bool handleJokers)
        {
            List<CardHand> orderedCardHands = InputLines
                .Select(x => CardHand.Parse(x, handleJokers: handleJokers))
                .OrderBy(c => c, new CardHandComparer())
                .ToList();

            List<CardHand> orderedCardHandsFrequencySolution = InputLines
                .Select(x => CardHand.Parse(x, true, handleJokers))
                .OrderBy(c => c, new CardHandComparer())
                .ToList();

            //orderedCardHands = orderedCardHandsFrequencySolution;

            double sum = 0.0;
            for (int i = 0; i < orderedCardHands.Count; i++)
            {
                //Console.WriteLine($"{orderedCardHands[i].Hand} {orderedCardHands[i].BidAmount}");
                sum += orderedCardHands[i].BidAmount * (i + 1.0);
            }
            Output = sum.ToString();
        }
    }
}
