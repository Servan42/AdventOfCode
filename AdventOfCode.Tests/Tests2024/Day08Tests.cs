using AdventOfCode.Core.Daily2024.Day08;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day08Tests
    {
        Day08Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day08Ex();
        }

        [Test]
        public void Should_do_part_one_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............"
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("14"));
        }

        [Test]
        public void Should_do_part_two_from_exmaple_1()
        {
            // GIVEN
            sut.InputLines = [
                "T.........",
                "...T......",
                ".T........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                "..........",
                ".........."
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("9"));
        }

        [Test]
        public void Should_do_part_two_from_exmaple_2()
        {
            // GIVEN
            sut.InputLines = [
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............"
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("34"));
        }
    }
}
