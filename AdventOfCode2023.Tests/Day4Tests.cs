using AdventOfCode2023.Core.Daily.Day4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day4Tests
    {
        Day4Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day4Ex();
        }

        [Test]
        public void PART1_Should_have_one_point_for_one_winning_number()
        {
            // GIVEN
            sut.InputLines.Add("Card 1: 41  5 83 | 83 86  6");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1"));
        }

        [Test]
        public void PART1_Should_have_2powN_points_for_N_winning_numbers()
        {
            // GIVEN
            sut.InputLines.Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("8"));
        }

        [Test]
        public void PART1_Should_sum_points_for_each_lines()
        {
            // GIVEN
            sut.InputLines.Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
            sut.InputLines.Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19");
            sut.InputLines.Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");
            sut.InputLines.Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83");
            sut.InputLines.Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36");
            sut.InputLines.Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("13"));
        }

        [Test]
        public void PART2_Should_give_one_copy_of_not_winning_card_two()
        {
            // GIVEN
            sut.InputLines.Add("Card 1:  0 20 30 |  0 21 31");
            sut.InputLines.Add("Card 2:  0 20 30 |  1 21 31");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [Test]
        public void PART2_Should_give_one_copy_of_winning_card_two()
        {
            // GIVEN
            sut.InputLines.Add("Card 1:  0 20 30 |  0 21 31");
            sut.InputLines.Add("Card 2:  0 20 30 |  0 21 31");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [Test]
        public void PART2_Should_give_one_copy_of_not_winning_card_two_and_one_copy_of_not_winning_card_three()
        {
            // GIVEN
            sut.InputLines.Add("Card 1:  0 20 30 |  0 20 30");
            sut.InputLines.Add("Card 2:  0 20 30 |  1 21 31");
            sut.InputLines.Add("Card 2:  0 20 30 |  1 21 31");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("5"));
        }

        [Test]
        public void PART2_Should_give_one_copy_of_winning_card_two_and_three_copies_of_not_winning_card_three()
        {
            // GIVEN
            sut.InputLines.Add("Card 1:  0 20 30 |  0 20 30");
            sut.InputLines.Add("Card 2:  0 20 30 |  0 21 31");
            sut.InputLines.Add("Card 2:  0 20 30 |  1 21 31");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("7"));
        }

        [Test]
        public void PART2_Should_find_30()
        {
            // GIVEN
            sut.InputLines.Add("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
            sut.InputLines.Add("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19");
            sut.InputLines.Add("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1");
            sut.InputLines.Add("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83");
            sut.InputLines.Add("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36");
            sut.InputLines.Add("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("30"));
        }
    }
}
