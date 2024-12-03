using AdventOfCode.Core.Daily2024.Day03;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day03Tests
    {
        Day03Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day03Ex();
        }

        [Test]
        public void Should_do_part_one_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("161"));
        }

        [Test]
        public void Should_do_part_two_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+don't()mul(32,64](mul(11,8)undo()?mul(8,5))",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("48"));
        }
    }
}
