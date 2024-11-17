using AdventOfCode.Core.Daily2023.Day13;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day13Tests
    {
        Day13Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day13Ex();
        }

        [Test]
        public void Should_part1()
        {
            // GIVEN
            sut.InputLines = new List<string>
            {
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
                "",
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#"
            };

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("405"));
        }

        [Test]
        public void Should_part2()
        {
            // GIVEN
            sut.InputLines = new List<string>
            {
                "#.##..##.",
                "..#.##.#.",
                "##......#",
                "##......#",
                "..#.##.#.",
                "..##..##.",
                "#.#.##.#.",
                "",
                "#...##..#",
                "#....#..#",
                "..##..###",
                "#####.##.",
                "#####.##.",
                "..##..###",
                "#....#..#",
            };

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("400"));
        }

        [Test]
        public void Should_part2_2()
        {
            // GIVEN
            sut.InputLines = new List<string>
            {
                "###...###..",
                "###...###..",
                "#.#.#.#...#",
                "...#..##.#.",
                "...#..#....",
                ".###.#.###.",
                "#..##.###..",
                "..#..#.#.##",
                "..#..#.#.##",
                "#..##.###..",
                ".###.#.###.",
                "...#..#....",
                "...#..##.#.",
                "#.#.#.#.#.#",
                "###...###.."
            };

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("800"));
        }
    }
}
