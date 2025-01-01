using AdventOfCode.Core.Daily2024.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day12Tests
    {
        Day12Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day12Ex();
        }

        [Test]
        public void Should_do_part_one_from_example_1()
        {
            // GIVEN
            sut.InputLines = [
                "AAAA",
                "BBCD",
                "BBCC",
                "EEEC",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("140"));
        }

        [Test]
        public void Should_do_part_one_from_example_2()
        {
            // GIVEN
            sut.InputLines = [
                "OOOOO",
                "OXOXO",
                "OOOOO",
                "OXOXO",
                "OOOOO",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("772"));
        }

        [Test]
        public void Should_do_part_one_from_example_3()
        {
            // GIVEN
            sut.InputLines = [
                "RRRRIICCFF",
                "RRRRIICCCF",
                "VVRRRCCFFF",
                "VVRCCCJFFF",
                "VVVVCJJCFE",
                "VVIVCCJJEE",
                "VVIIICJJEE",
                "MIIIIIJJEE",
                "MIIISIJEEE",
                "MMMISSJEEE",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1930"));
        }

        [Test]
        public void Should_do_part_two_from_example_1()
        {
            // GIVEN
            sut.InputLines = [
                "AAAA",
                "BBCD",
                "BBCC",
                "EEEC",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("80"));
        }

        [Test]
        public void Should_do_part_two_from_example_2()
        {
            // GIVEN
            sut.InputLines = [
                "EEEEE",
                "EXXXX",
                "EEEEE",
                "EXXXX",
                "EEEEE",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("236"));
        }

        [Test]
        public void Should_do_part_two_from_example_3()
        {
            // GIVEN
            sut.InputLines = [
                "AAAAAA",
                "AAABBA",
                "AAABBA",
                "ABBAAA",
                "ABBAAA",
                "AAAAAA",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("368"));
        }

        [Test]
        public void Should_do_part_one_from_example_4()
        {
            // GIVEN
            sut.InputLines = [
                "RRRRIICCFF",
                "RRRRIICCCF",
                "VVRRRCCFFF",
                "VVRCCCJFFF",
                "VVVVCJJCFE",
                "VVIVCCJJEE",
                "VVIIICJJEE",
                "MIIIIIJJEE",
                "MIIISIJEEE",
                "MMMISSJEEE",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1206"));
        }

        [Test]
        public void Should_do_part_two_from_example_extra_1()
        {
            // GIVEN
            sut.InputLines = [
                "AAAC",
                "AAAC",
                "BBBA",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("48"));
        }

        [Test]
        public void Should_do_part_two_from_example_extra_2()
        {
            // GIVEN
            sut.InputLines = [
                "AAAB",
                "AAAB",
                "BBBA",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("48"));
        }

        [Test]
        public void Should_do_part_two_from_example_extra_3()
        {
            // GIVEN
            sut.InputLines = [
                "AAA",
                "ACA",
                "AAB",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("78"));
        }

        [Test]
        public void Should_do_part_two_from_example_extra_4()
        {
            // GIVEN
            sut.InputLines = [
                "AAA",
                "ABA",
                "AAB",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("78"));
        }

        [Test]
        public void Should_do_part_two_from_example_extra_5()
        {
            // GIVEN
            sut.InputLines = [
                "AAAAA",
                "AACAA",
                "ACACA",
                "AACAA",
                "AAAAA",
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("340"));
        }
    }
}
