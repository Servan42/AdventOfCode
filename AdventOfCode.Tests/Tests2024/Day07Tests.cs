using AdventOfCode.Core.Daily2024.Day07;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day07Tests
    {
        Day07Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day07Ex();
        }

        [Test]
        public void Should_do_part_one_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20"
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3749"));
        }

        [Test]
        public void Should_do_part_two_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [
                "190: 10 19",
                "3267: 81 40 27",
                "83: 17 5",
                "156: 15 6",
                "7290: 6 8 6 15",
                "161011: 16 10 13",
                "192: 17 8 14",
                "21037: 9 7 18 13",
                "292: 11 6 16 20"
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("11387"));
        }
    }
}
