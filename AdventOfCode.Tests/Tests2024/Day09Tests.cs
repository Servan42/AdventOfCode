using AdventOfCode.Core.Daily2024.Day09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day09Tests
    {
        Day09Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day09Ex();
        }

        [Test]
        public void Should_do_part_one_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [ "2333133121414131402" ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1928"));
        }

        [Test]
        public void Should_do_part_two_from_exmaple()
        {
            // GIVEN
            sut.InputLines = ["2333133121414131402"];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("2858"));
        }
    }
}
