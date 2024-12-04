using AdventOfCode.Core.Daily2024.Day04;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day04Tests
    {
        Day04Ex sut;

        [SetUp]
        public void Part1_Setup()
        {
            sut = new Day04Ex();
        }

        [TestCase("..XMAS...", "1")]
        [TestCase("..XMAS.....XMAS...", "2")]
        [TestCase("..XMASXMAS...XMA", "2")]
        public void Part1_Should_find_XMAS_on_line(string line, string expectedCount)
        {
            // GIVEN
            sut.InputLines = [ line ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedCount));
        }

        [TestCase("..SAMX...", "1")]
        [TestCase("..SAMX.....SAMX...", "2")]
        [TestCase("..SAMXSAMX...SAM", "2")]
        public void Part1_Should_find_XMAS_on_line_reversed(string line, string expectedCount)
        {
            // GIVEN
            sut.InputLines = [ line ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedCount));
        }

        [TestCase("..SAMXMAS...", "2")]
        [TestCase("..SAMXMAS.....SAMXMAS...", "4")]
        [TestCase("..SAMXSAMXMAS...SAM", "3")]
        public void Part1_Should_find_XMAS_on_line_reverse_and_overlap(string line, string expectedCount)
        {
            // GIVEN
            sut.InputLines = [line];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedCount));
        }

        [Test]
        public void Part1_Should_find_XMAS_on_column()
        {
            // GIVEN
            sut.InputLines = [
                    "..X...",
                    "..M.X.",
                    "..A.M.",
                    "..S.A.",
                    "....S.",
                    "..X...",
                    "..M...",
                    "..A...",
                    "..S...",
                ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [Test]
        public void Part1_Should_find_XMAS_on_column_reversed()
        {
            // GIVEN
            sut.InputLines = [
                    "..S...",
                    "..A.S.",
                    "..M.A.",
                    "..X.M.",
                    "....X.",
                    "..S...",
                    "..A...",
                    "..M...",
                    "..X...",
                ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [Test]
        public void Part1_Should_find_XMAS_on_column_reversed_and_overlap()
        {
            // GIVEN
            sut.InputLines = [
                    "..S...",
                    "..A.S.",
                    "..M.A.",
                    "..X.M.",
                    "..M.X.",
                    "..A...",
                    "..S...",
                    "..M...",
                    "..X...",
                ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }

        [Test]
        public void Part1_Should_find_XMAS_on_diagonal()
        {
            // GIVEN
            sut.InputLines = [
                    ".X.....",
                    "..M....",
                    "...A...",
                    "....S..",
                ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1"));
        }

        [Test]
        public void Part1_Should_do_part_one_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("18"));
        }

        //[Test]
        //public void Should_do_part_two_from_easy_example()
        //{
        //    // GIVEN
        //    sut.InputLines = [
        //        "M.S",
        //        ".A.",
        //        "M.S"
        //    ];

        //    // WHEN
        //    sut.ComputePart1();

        //    // THEN
        //    Assert.That(sut.Output, Is.EqualTo("1"));
        //}

        //[Test]
        //public void Should_do_part_two_from_easy_example_2()
        //{
        //    // GIVEN
        //    sut.InputLines = [
        //        "S.M",
        //        ".A.",
        //        "S.M"
        //    ];

        //    // WHEN
        //    sut.ComputePart1();

        //    // THEN
        //    Assert.That(sut.Output, Is.EqualTo("1"));
        //}

        [Test]
        public void Should_do_part_two_from_example()
        {
            // GIVEN
            sut.InputLines = [
                ".M.S......",
                "..A..MSMS.",
                ".M.S.MAA..",
                "..A.ASMSM.",
                ".M.S.M....",
                "..........",
                "S.S.S.S.S.",
                ".A.A.A.A..",
                "M.M.M.M.M.",
                ".........."
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("9"));
        }
    }
}
