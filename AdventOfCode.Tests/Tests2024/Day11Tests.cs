using AdventOfCode.Core.Daily2024.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day11Tests
    {
        Day11Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day11Ex();
        }

        [Test]
        public void Should_do_part_one_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [
                "125 17",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("55312"));
        }
    }
}
