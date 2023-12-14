using AdventOfCode2023.Core.Daily.Day14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day14Tests
    {
        Day14Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day14Ex();
        }

        [Test]
        public void Should_part1()
        {
            // GIVEN
            sut.InputLines = new List<string>
            {
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            };

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("136"));
        }

        [Test]
        public void Should_part2()
        {
            // GIVEN
            sut.InputLines = new List<string>
            {
                "O....#....",
                "O.OO#....#",
                ".....##...",
                "OO.#O....O",
                ".O.....O#.",
                "O.#..O.#.#",
                "..O..#O..O",
                ".......O..",
                "#....###..",
                "#OO..#...."
            };

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("64"));
        }
    }
}
