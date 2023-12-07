﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day7
{
    public class Day7Ex : Exercise
    {
        public override void ComputePart1()
        {
            List<CardHand> orderedCardHands = InputLines
                .Select(x => CardHand.Parse(x))
                .OrderBy(c => c, new CardHandComparer())
                .ToList();

            List<CardHand> orderedCardHandsFrequencySolution = InputLines
                .Select(x => CardHand.Parse(x, true))
                .OrderBy(c => c, new CardHandComparer())
                .ToList();

            //orderedCardHands = orderedCardHandsFrequencySolution;

            double sum = 0.0;
            for (int i = 0; i < orderedCardHands.Count; i++)
            {
                Console.WriteLine($"{orderedCardHands[i].Hand} {orderedCardHands[i].BidAmount}");
                sum += orderedCardHands[i].BidAmount * (i + 1.0);
            }
            Output = sum.ToString();
        }

        public override void ComputePart2()
        {
            throw new NotImplementedException();
        }
    }
}
