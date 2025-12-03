using AdventOfCode.Core.Daily2025.Day01;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2025
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
                "L68",
                "L30",
                "R48",
                "L5",
                "R60",
                "L55",
                "L1",
                "L99",
                "R14",
                "L82"
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("3"));
        }
    }
}
