using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day4
{
    public class Day4Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = InputLines
                .Select(line => Card.Parse(line).CalculatePoints())
                .Sum()
                .ToString();
        }

        public override void ComputePart2()
        {
            var cards = new List<Card>();
            foreach (var line in InputLines)
            {
                cards.Add(Card.Parse(line));
            }

            int nextCardIndex = 0;
            foreach(var card in cards)
            {
                nextCardIndex++;
                AddPlusXToNextYCardsAmount(card.NbOfWinningNumbers, nextCardIndex, card.Amount, cards);
            }

            Output = cards.Sum(c => c.Amount).ToString();
        }

        private void AddPlusXToNextYCardsAmount(int nbOfCardsToUp, int fromIndex, int amountToAdd, List<Card> cards)
        {
            for(int i = fromIndex; i < Math.Min(fromIndex + nbOfCardsToUp, cards.Count); i++)
            {
                cards[i].Amount += amountToAdd;
            }
        }
    }
}
