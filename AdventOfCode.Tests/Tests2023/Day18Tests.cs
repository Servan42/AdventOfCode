using AdventOfCode.Core.Daily2023.Day18;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day18Tests
    {
        Day18Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day18Ex();
        }

        [Test]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "R 6 (#70c710)",
                "D 5 (#0dc571)",
                "L 2 (#5713f0)",
                "D 2 (#d2c081)",
                "R 2 (#59c680)",
                "D 2 (#411b91)",
                "L 5 (#8ceee2)",
                "U 2 (#caa173)",
                "L 1 (#1b58a2)",
                "U 2 (#caa171)",
                "R 2 (#7807d2)",
                "U 3 (#a77fa3)",
                "L 2 (#015232)",
                "U 2 (#7a21e3)"
            };

            // When
            sut.ComputePart1();

            //
            Assert.That(sut.Output, Is.EqualTo("62"));
        }

        [Test]
        public void Should_part2()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "R 6 (#70c710)",
                "D 5 (#0dc571)",
                "L 2 (#5713f0)",
                "D 2 (#d2c081)",
                "R 2 (#59c680)",
                "D 2 (#411b91)",
                "L 5 (#8ceee2)",
                "U 2 (#caa173)",
                "L 1 (#1b58a2)",
                "U 2 (#caa171)",
                "R 2 (#7807d2)",
                "U 3 (#a77fa3)",
                "L 2 (#015232)",
                "U 2 (#7a21e3)"
            };

            // When
            sut.ComputePart2();

            //
            Assert.That(sut.Output, Is.EqualTo("952408144115"));
        }
    }
}
