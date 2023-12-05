using AdventOfCode2023.Core.Daily.Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day5Tests
    {
        Day5Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day5Ex();
        }

        private static List<string> inputLines = new List<string>()
        {
            "seeds: 79 14 55 13",
            "",
            "seed-to-soil map:",
            "50 98 2",
            "52 50 48",
            "",
            "soil-to-fertilizer map:",
            "0 15 37",
            "37 52 2",
            "39 0 15",
            "",
            "fertilizer-to-water map:",
            "49 53 8",
            "0 11 42",
            "42 0 7",
            "57 7 4",
            "",
            "water-to-light map:",
            "88 18 7",
            "18 25 70",
            "",
            "light-to-temperature map:",
            "45 77 23",
            "81 45 19",
            "68 64 13",
            "",
            "temperature-to-humidity map:",
            "0 69 1",
            "1 0 69",
            "",
            "humidity-to-location map:",
            "60 56 37",
            "56 93 4"
        };

        [Test]
        public void Should_Parse_the_Almanac_from_input()
        {
            // Given

            // When
            var almanac = Almanac.Parse(inputLines);

            // Then
            CollectionAssert.AreEqual(new List<double> { 79, 14, 55, 13 }, almanac.Seeds);
            Assert.That(almanac.Maps.Count, Is.EqualTo(7));
            Assert.That(almanac.Maps[0].Count, Is.EqualTo(2));
            Assert.That(almanac.Maps[0][0].DestinationRange, Is.EqualTo(50));
            Assert.That(almanac.Maps[0][0].SourceRange, Is.EqualTo(98));
            Assert.That(almanac.Maps[0][0].RangeLength, Is.EqualTo(2));
            Assert.That(almanac.Maps[0][1].DestinationRange, Is.EqualTo(52));
            Assert.That(almanac.Maps[0][1].SourceRange, Is.EqualTo(50));
            Assert.That(almanac.Maps[0][1].RangeLength, Is.EqualTo(48));
            Assert.That(almanac.Maps[1].Count, Is.EqualTo(3));
            Assert.That(almanac.Maps[2].Count, Is.EqualTo(4));
            Assert.That(almanac.Maps[3].Count, Is.EqualTo(2));
            Assert.That(almanac.Maps[4].Count, Is.EqualTo(3));
            Assert.That(almanac.Maps[5].Count, Is.EqualTo(2));
            Assert.That(almanac.Maps[6].Count, Is.EqualTo(2));
        }

        [TestCase("50 98 2 ", "5")]
        [TestCase("5  4  1 ", "5")]
        [TestCase("5  4  2 ", "6")]
        [TestCase("5  4  10", "6")]
        [TestCase("14 4  2 ", "15")]
        [TestCase("14 4  10", "15")]
        [TestCase("3  5  1", "3")]
        public void PART1_Should_get_map_for_seed(string mappingData, string expectedMap)
        {
            // GIVEN
            sut.InputLines.Add("seeds: 5");
            sut.InputLines.Add("");
            sut.InputLines.Add("seed-to-soil map:");
            sut.InputLines.Add(mappingData);

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedMap));
        }

        [Test]
        public void PART1_Should_get_second_map_for_seed()
        {
            // GIVEN
            sut.InputLines.Add("seeds: 1");
            sut.InputLines.Add("");
            sut.InputLines.Add("seed-to-soil map:");
            sut.InputLines.Add("60 50  2 "); // Ignored, out of range
            sut.InputLines.Add("10 0  2 "); // mapped to 11
            sut.InputLines.Add("10 0  2 "); // Ignored, went to late
            sut.InputLines.Add("");
            sut.InputLines.Add("soil-to-fertilizer map:");
            sut.InputLines.Add("20 10  2 "); // mapped to 21

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("21"));
        }

        [Test]
        public void PART1_Should_get_35()
        {
            // GIVEN
            sut.InputLines = inputLines;

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("35"));
        }

        [Test]
        public void PART2_Should_count_seeds_as_seed_range_and_get_46()
        {
            // GIVEN
            sut.InputLines = inputLines;

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("46"));
        }
    }
}
