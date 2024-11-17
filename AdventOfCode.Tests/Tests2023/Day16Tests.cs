using AdventOfCode.Core.Daily2023.Day16;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day16Tests
    {
        Day16Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day16Ex();
        }

        [Test]
        public void Should_part1()
        {
            // GIVEN
            sut.InputLines = new List<string>()
            {
                @".|...\....",
                @"|.-.\.....",
                @".....|-...",
                @"........|.",
                @"..........",
                @".........\",
                @"..../.\\..",
                @".-.-/..|..",
                @".|....-|.\",
                @"..//.|...."
            };

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("46"));
        }

        [Test]
        public void Should_part2()
        {
            // GIVEN
            sut.InputLines = new List<string>()
            {
                @".|...\....",
                @"|.-.\.....",
                @".....|-...",
                @"........|.",
                @"..........",
                @".........\",
                @"..../.\\..",
                @".-.-/..|..",
                @".|....-|.\",
                @"..//.|...."
            };

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("51"));
        }
    }
}
