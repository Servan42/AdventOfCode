using AdventOfCode.Core.Daily2024.Day02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day02Tests
    {
        Day02Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day02Ex();
        }

        [Test]
        public void Should_do_part_one_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
                "67 66 68 70 71 74 76",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("2"));
        }

        [Test]
        public void Should_do_part_two_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("4"));
        }
    }
}
