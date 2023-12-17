using AdventOfCode2023.Core.Daily.Day17;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day17Tests
    {
        Day17Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day17Ex();
        }

        [Test]
        public void Should_part1()
        {
            sut.InputLines = new List<string>
            {
                "2413432311323",
                "3215453535623",
                "3255245654254",
                "3446585845452",
                "4546657867536",
                "1438598798454",
                "4457876987766",
                "3637877979653",
                "4654967986887",
                "4564679986453",
                "1224686865563",
                "2546548887735",
                "4322674655533"
            };

            sut.ComputePart1();

            Assert.That(sut.Output, Is.EqualTo("102"));
        }

        [Test]
        public void Should_part2_1()
        {
            sut.InputLines = new List<string>
            {
                "2413432311323",
                "3215453535623",
                "3255245654254",
                "3446585845452",
                "4546657867536",
                "1438598798454",
                "4457876987766",
                "3637877979653",
                "4654967986887",
                "4564679986453",
                "1224686865563",
                "2546548887735",
                "4322674655533"
            };

            sut.ComputePart2();

            Assert.That(sut.Output, Is.EqualTo("94"));
        }

        [Test]
        public void Should_part2_2()
        {
            sut.InputLines = new List<string>
            {
                "111111111111",
                "999999999991",
                "999999999991",
                "999999999991",
                "999999999991"
            };

            sut.ComputePart2();

            Assert.That(sut.Output, Is.EqualTo("71"));
        }
    }
}
