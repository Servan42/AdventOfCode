using AdventOfCode.Core.Daily2023.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day11Tests
    {
        Day11Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day11Ex();
        }

        private static List<string> universeExample = new List<string>
        {
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#....."
        };

        [Test]
        public void Part1_Should_Get_Sum_Of_Shortest_Path_For_All_Pairs_Of_Galaxies()
        {
            // GIVEN
            sut.InputLines = universeExample;

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("374"));
        }

        [TestCase(2, 374)]
        [TestCase(10, 1030)]
        [TestCase(100, 8410)]
        public void Part2_Should_Get_Sum_Of_Shortest_Path_For_All_Pairs_Of_Galaxies(int expansionFactor, int expectedResult)
        {
            // GIVEN
            var universe = Universe.Parse(universeExample, expansionFactor);

            // WHEN
            var result = universe.GetSumOfShortestPathForAllPairsOfGalaxies();

            // THEN
            Assert.That(result, Is.EqualTo(expectedResult));
        }
    }
}
