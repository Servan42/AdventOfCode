using AdventOfCode.Core.Daily2023.Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day7Tests
    {
        Day7Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day7Ex();
        }

        [TestCase('2', 2)]
        [TestCase('3', 3)]
        [TestCase('4', 4)]
        [TestCase('5', 5)]
        [TestCase('6', 6)]
        [TestCase('7', 7)]
        [TestCase('8', 8)]
        [TestCase('9', 9)]
        [TestCase('T', 10)]
        [TestCase('J', 11)]
        [TestCase('Q', 12)]
        [TestCase('K', 13)]
        [TestCase('A', 14)]
        public void Should_parse_card(char character, int value)
        {
            // WHEN
            Card card = Card.Parse(character);

            // THEN
            Assert.That(card.Value, Is.EqualTo(value));
            Assert.That(card.Character, Is.EqualTo(character));
        }

        public void Should_parse_card_joker()
        {
            // WHEN
            Card card = Card.Parse('J', true);

            // THEN
            Assert.That(card.Value, Is.EqualTo(1));
            Assert.That(card.Character, Is.EqualTo('J'));
        }

        [TestCase("23456 1", 14)]
        [TestCase("34567 1", 14)]
        [TestCase("45678 1", 14)]
        [TestCase("56789 1", 14)]
        [TestCase("6789T 1", 14)]
        [TestCase("789TJ 1", 14)]
        [TestCase("89TJQ 1", 14)]
        [TestCase("9TJQK 1", 14)]
        [TestCase("TJQKA 1", 14)]
        [TestCase("22345 1", 15)]
        [TestCase("345AA 1", 15)]
        [TestCase("Q345Q 1", 15)]
        [TestCase("225AA 1", 16)]
        [TestCase("TT552 1", 16)]
        [TestCase("22234 1", 17)]
        [TestCase("23AAA 1", 17)]
        [TestCase("A2A3A 1", 17)]
        [TestCase("22233 1", 18)]
        [TestCase("22323 1", 18)]
        [TestCase("33AAA 1", 18)]
        [TestCase("A3A3A 1", 18)]
        [TestCase("22223 1", 19)]
        [TestCase("22A22 1", 19)]
        [TestCase("3AAAA 1", 19)]
        [TestCase("22222 1", 20)]
        [TestCase("AAAAA 1", 20)]
        public void Should_parse_card_hand(string hand, int typeValue)
        {
            // WHEN
            CardHand cardHand = CardHand.Parse(hand);

            // THEN
            Assert.That(cardHand.Hand, Is.EqualTo(hand.Split(' ')[0]));
            Assert.That(cardHand.BidAmount, Is.EqualTo(1));
            Assert.That(cardHand.TypeValue, Is.EqualTo(typeValue));
        }

        [TestCase("23456 1", "23456 1", 0)]
        [TestCase("AAAA2 1", "AAAAA 1", -1)]
        [TestCase("AAAAA 1", "AAAA2 1", 1)]
        [TestCase("33332 1", "2AAAA 1", 1)]
        [TestCase("77888 1", "77788 1", 1)]
        public void Should_compare_two_card_hands(string handX, string handY, int expectedResult)
        {
            // GIVEN
            var comparer = new CardHandComparer();

            // WHEN
            int result = comparer.Compare(CardHand.Parse(handX), CardHand.Parse(handY));

            // THEN
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [TestCase]
        public void PART1_Should_rank_cards_and_multiply_bid_value_by_their_rank()
        {
            // GIVEN
            sut.InputLines.Add("32T3K 765");
            sut.InputLines.Add("T55J5 684");
            sut.InputLines.Add("KK677 28");
            sut.InputLines.Add("KTJJT 220");
            sut.InputLines.Add("QQQJA 483");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("6440"));
        }

        [TestCase]
        public void PART2_Should_rank_cards_with_jokers_and_multiply_bid_value_by_their_rank()
        {
            // GIVEN
            sut.InputLines.Add("32T3K 765");
            sut.InputLines.Add("T55J5 684");
            sut.InputLines.Add("KK677 28");
            sut.InputLines.Add("KTJJT 220");
            sut.InputLines.Add("QQQJA 483");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("5905"));
        }

        [Test]
        public void PART1_Should_rank_cards_and_multiply_bid_value_by_their_rank_2()
        {
            // GIVEN
            sut.InputLines.Add("2345A 1");
            sut.InputLines.Add("Q2KJJ 13");
            sut.InputLines.Add("Q2Q2Q 19");
            sut.InputLines.Add("T3T3J 17");
            sut.InputLines.Add("T3Q33 11");
            sut.InputLines.Add("2345J 3");
            sut.InputLines.Add("J345A 2");
            sut.InputLines.Add("32T3K 5");
            sut.InputLines.Add("T55J5 29");
            sut.InputLines.Add("KK677 7");
            sut.InputLines.Add("KTJJT 34");
            sut.InputLines.Add("QQQJA 31");
            sut.InputLines.Add("JJJJJ 37");
            sut.InputLines.Add("JAAAA 43");
            sut.InputLines.Add("AAAAJ 59");
            sut.InputLines.Add("AAAAA 61");
            sut.InputLines.Add("2AAAA 23");
            sut.InputLines.Add("2JJJJ 53");
            sut.InputLines.Add("JJJJ2 41");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("6592"));
        }

        [Test]
        public void PART2_Should_rank_cards_with_jokers_and_multiply_bid_value_by_their_rank_2()
        {
            // GIVEN
            sut.InputLines.Add("2345A 1");
            sut.InputLines.Add("Q2KJJ 13");
            sut.InputLines.Add("Q2Q2Q 19");
            sut.InputLines.Add("T3T3J 17");
            sut.InputLines.Add("T3Q33 11");
            sut.InputLines.Add("2345J 3");
            sut.InputLines.Add("J345A 2");
            sut.InputLines.Add("32T3K 5");
            sut.InputLines.Add("T55J5 29");
            sut.InputLines.Add("KK677 7");
            sut.InputLines.Add("KTJJT 34");
            sut.InputLines.Add("QQQJA 31");
            sut.InputLines.Add("JJJJJ 37");
            sut.InputLines.Add("JAAAA 43");
            sut.InputLines.Add("AAAAJ 59");
            sut.InputLines.Add("AAAAA 61");
            sut.InputLines.Add("2AAAA 23");
            sut.InputLines.Add("2JJJJ 53");
            sut.InputLines.Add("JJJJ2 41");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("6839"));
        }
    }
}
