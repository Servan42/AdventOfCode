using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day7
{
    public class CardHand
    {
        private const int ONE_PAIR = 15;
        private const int TWO_PAIRS = 16;
        private const int THREE_OF_A_KIND = 17;
        private const int FULL_HOUSE = 18;
        private const int FOUR_OF_A_KIND = 19;
        private const int FIVE_OF_A_KIND = 20;

        public int BidAmount { get; set; }
        public int TypeValue { get; set; }
        public string Hand { get; set; }
        public List<Card> Cards { get; set; } = new();

        public static CardHand Parse(string handLine, bool useFrequencySolution = false)
        {
            CardHand cardHand = new CardHand();
            var split = handLine.Split(' ');
            cardHand.Hand = split[0];
            cardHand.BidAmount = int.Parse(split[1]);
            cardHand.ParseCards();
            cardHand.TypeValue = cardHand.ResolveValue(useFrequencySolution);
            return cardHand;
        }

        private void ParseCards()
        {
            foreach (var c in Hand)
            {
                Cards.Add(Card.Parse(c));
            }
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

            //return Cards.Max(c => c.Value); FRO FUCK'S SAKE THIS WAS NOT SPECIFIED
            return 14;
        }

        //public string GetTypeValueAsTextForDebug(bool useFrequencySolution)
        //{
        //    if (useFrequencySolution)
        //    {
        //        switch (TypeValue)
        //        {
        //            case 4:
        //                return "five of a kind ";
        //            case 2:
        //                return "four of a kind ";
        //            case 1:
        //                return "full house     ";
        //            case 0:
        //                return "three of a kind";
        //            case -1:
        //                return "two pairs      ";
        //            case -2:
        //                return "one pair       ";
        //            default:
        //                return "highvalue    " + TypeValue;
        //        }
        //    }

        //    switch (TypeValue)
        //    {
        //        case FIVE_OF_A_KIND:
        //            return "five of a kind ";
        //        case FOUR_OF_A_KIND:
        //            return "four of a kind ";
        //        case FULL_HOUSE:
        //            return "full house     ";
        //        case THREE_OF_A_KIND:
        //            return "three of a kind";
        //        case TWO_PAIRS:
        //            return "two pairs      ";
        //        case ONE_PAIR:
        //            return "one pair       ";
        //        default:
        //            return "highvalue    " + TypeValue;
        //    }
        //}
    }
}
