using AdventOfCode.Core.Daily2023.Day23;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day23Tests
    {
        Day23Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day23Ex();
        }

        [Test]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "#.#####################",
                "#.......#########...###",
                "#######.#########.#.###",
                "###.....#.>.>.###.#.###",
                "###v#####.#v#.###.#.###",
                "###.>...#.#.#.....#...#",
                "###v###.#.#.#########.#",
                "###...#.#.#.......#...#",
                "#####.#.#.#######.#.###",
                "#.....#.#.#.......#...#",
                "#.#####.#.#.#########v#",
                "#.#...#...#...###...>.#",
                "#.#.#v#######v###.###v#",
                "#...#.>.#...>.>.#.###.#",
                "#####v#.#.###v#.#.###.#",
                "#.....#...#...#.#.#...#",
                "#.#########.###.#.#.###",
                "#...###...#...#...#.###",
                "###.###.#.###v#####v###",
                "#...#...#.#.>.>.#.>.###",
                "#.###.###.#.###.#.#v###",
                "#.....###...###...#...#",
                "#####################.#"
            };

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("94"));
        }

        [Test]
        public void Should_part1_simple()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "#.#####",
                "#.#####",
                "#.....#",
                "#.###.#",
                "#.#...#",
                "#...###",
                "###.###",
                "###.###"
            };

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("13"));
        }

        [Test]
        public void Should_part1_rethink()
        {
            // Given
            var inputLines = new List<string>
            {
                "#.#####################",
                "#.......#########...###",
                "#######.#########.#.###",
                "###.....#.>.>.###.#.###",
                "###v#####.#v#.###.#.###",
                "###.>...#.#.#.....#...#",
                "###v###.#.#.#########.#",
                "###...#.#.#.......#...#",
                "#####.#.#.#######.#.###",
                "#.....#.#.#.......#...#",
                "#.#####.#.#.#########v#",
                "#.#...#...#...###...>.#",
                "#.#.#v#######v###.###v#",
                "#...#.>.#...>.>.#.###.#",
                "#####v#.#.###v#.#.###.#",
                "#.....#...#...#.#.#...#",
                "#.#########.###.#.#.###",
                "#...###...#...#...#.###",
                "###.###.#.###v#####v###",
                "#...#...#.#.>.>.#.>.###",
                "#.###.###.#.###.#.#v###",
                "#.....###...###...#...#",
                "#####################.#"
            };

            // When
            int result = MazeRethink.Parse_with_edge_contraction(inputLines).BuildPathsAndReturnLongest();

            // Then
            Assert.That(result, Is.EqualTo(94));
        }

        [Test]
        [Ignore("Current edge contraction & node graph implementation do not allow multiple unidirectional edge between node A and B")]
        public void Should_part1_simple_rethink()
        {
            // Given
            var inputLines = new List<string>
            {
                "#.#####",
                "#.#####",
                "#.....#",
                "#.###.#",
                "#.#...#",
                "#...###",
                "###.###",
                "###.###"
            };

            // When
            int result = MazeRethink.Parse_with_edge_contraction(inputLines).BuildPathsAndReturnLongest();

            // Then
            Assert.That(result, Is.EqualTo(13));
        }

        [Test]
        public void Should_part2()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "#.#####################",
                "#.......#########...###",
                "#######.#########.#.###",
                "###.....#.>.>.###.#.###",
                "###v#####.#v#.###.#.###",
                "###.>...#.#.#.....#...#",
                "###v###.#.#.#########.#",
                "###...#.#.#.......#...#",
                "#####.#.#.#######.#.###",
                "#.....#.#.#.......#...#",
                "#.#####.#.#.#########v#",
                "#.#...#...#...###...>.#",
                "#.#.#v#######v###.###v#",
                "#...#.>.#...>.>.#.###.#",
                "#####v#.#.###v#.#.###.#",
                "#.....#...#...#.#.#...#",
                "#.#########.###.#.#.###",
                "#...###...#...#...#.###",
                "###.###.#.###v#####v###",
                "#...#...#.#.>.>.#.>.###",
                "#.###.###.#.###.#.#v###",
                "#.....###...###...#...#",
                "#####################.#"
            };

            // When
            sut.ComputePart2();

            // Then
            Assert.That(sut.Output, Is.EqualTo("154"));
        }
    }
}
