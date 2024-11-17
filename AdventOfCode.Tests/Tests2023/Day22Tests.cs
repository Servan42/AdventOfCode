using AdventOfCode.Core.Daily2023.Day22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day22Tests
    {
        Day22Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day22Ex();
        }

        [Test]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "1,0,1~1,2,1",
                "0,0,2~2,0,2",
                "0,2,3~2,2,3",
                "0,0,4~0,2,4",
                "2,0,5~2,2,5",
                "0,1,6~2,1,6",
                "1,1,8~1,1,9"
            };

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("5"));
        }

        [Test]
        public void Should_part2()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "1,0,1~1,2,1",
                "0,0,2~2,0,2",
                "0,2,3~2,2,3",
                "0,0,4~0,2,4",
                "2,0,5~2,2,5",
                "0,1,6~2,1,6",
                "1,1,8~1,1,9"
            };

            // When
            sut.ComputePart2();

            // Then
            Assert.That(sut.Output, Is.EqualTo("7"));
        }
    }
}
