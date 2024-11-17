using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day7
{
    public class CardHand
    {
        private const int HIGH_CARD = 14; // -4 with frequency solution
        private const int ONE_PAIR = 15; // -2
        private const int TWO_PAIRS = 16; // -1
        private const int THREE_OF_A_KIND = 17; // 0
        private const int FULL_HOUSE = 18; // 1
        private const int FOUR_OF_A_KIND = 19; // 2
        private const int FIVE_OF_A_KIND = 20; // 4

        public int BidAmount { get; set; }
        public int TypeValue { get; set; }
        public string Hand { get; set; }
        public List<Card> Cards { get; set; } = new();

        public static CardHand Parse(string handLine, bool useFrequencySolution = false, bool handleJokers = false)
        {
            var cardHand = new CardHand();
            var split = handLine.Split(' ');
            cardHand.Hand = split[0];
            cardHand.BidAmount = int.Parse(split[1]);
            cardHand.ParseCards(handleJokers);
            if (handleJokers && cardHand.Hand.Contains('J'))
            {
                cardHand.TypeValue = cardHand.ResolveValueWithJokers(useFrequencySolution);
            }
            else
            {
                cardHand.TypeValue = cardHand.ResolveValue(useFrequencySolution);
            }
            return cardHand;
        }

        private void ParseCards(bool handleJokers)
        {
            foreach (var c in Hand)
            {
                Cards.Add(Card.Parse(c, handleJokers));
            }
        }

        private int ResolveValueWithJokers(bool useFrequencySolution)
        {
            var typeValues = new List<int>();
            foreach (var replacedCard in "AKQT98765432")
            {
                var OldHand = Hand;
                Hand = Hand.Replace('J', replacedCard);
                typeValues.Add(ResolveValue(useFrequencySolution));
                Hand = OldHand;
            }

            return typeValues.Max();
        }

        private int ResolveValue(bool useFrequencySolution)
        {
            if (useFrequencySolution)
            {
                var frequencyDic = new Dictionary<char, int>();
                foreach (var card in Hand)
                {
                    if (frequencyDic.ContainsKey(card)) frequencyDic[card]++;
                    else frequencyDic.Add(card, 1);
                }

                return frequencyDic.Values.Max() - frequencyDic.Count;
            }

            if (Hand.All(c => Hand.Count(x => x == c) == 5))
                return FIVE_OF_A_KIND;

            if (Hand.Count(c => Hand.Count(x => x == c) == 4) == 4)
                return FOUR_OF_A_KIND;

            if (Hand.Count(c => Hand.Count(x => x == c) == 3) == 3
                && Hand.Count(c => Hand.Count(x => x == c) == 2) == 2)
                return FULL_HOUSE;

            if (Hand.Count(c => Hand.Count(x => x == c) == 3) == 3)
                return THREE_OF_A_KIND;

            if (Hand.Count(c => Hand.Count(x => x == c) == 2) == 4)
                return TWO_PAIRS;

            if (Hand.Count(c => Hand.Count(x => x == c) == 2) == 2)
                return ONE_PAIR;

            //return Cards.Max(c => c.Value); FOR FUCK'S SAKE THIS WAS NOT SPECIFIED
            return HIGH_CARD;
        }
    }
}
