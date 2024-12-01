using AdventOfCode.Core.Daily2024.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day01Tests
    {
        Day01Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day01Ex();
        }

        [Test]
        public void Should_do_part_one_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("11"));
        }

        [Test]
        public void Should_do_part_two_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("31"));
        }
    }
}
