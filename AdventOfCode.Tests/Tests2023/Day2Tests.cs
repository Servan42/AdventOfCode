using AdventOfCode.Core.Daily2023.Day2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day2Tests
    {
        Day2Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day2Ex();
        }

        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "1")]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "2")]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "0")]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "0")]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "5")]
        public void PART1_Should_output_the_id_of_the_game_if_its_possible(string line, string expectedNumber)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void PART1_Should_sum_the_ids_of_possible_games()
        {
            // GIVEN
            sut.InputLines.Add("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
            sut.InputLines.Add("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [TestCase("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", "48")]
        [TestCase("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", "12")]
        [TestCase("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", "1560")]
        [TestCase("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", "630")]
        [TestCase("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", "36")]
        public void PART2_Should_multiply_together_the_biggest_amounts_of_each_color(string line, string expectedNumber)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void PART2_Should_sum_the_power_of_each_games()
        {
            // GIVEN
            sut.InputLines.Add("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
            sut.InputLines.Add("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo((48 + 12).ToString()));
        }
    }
}
