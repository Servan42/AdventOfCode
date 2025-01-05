using AdventOfCode.Core.Daily2024.Day13;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day13Tests
    {
        Day13Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day13Ex();
        }

        [Test]
        public void Should_do_part_one_from_example_sub1()
        {
            // GIVEN
            sut.InputLines = [
                "Button A: X+94, Y+34",
                "Button B: X+22, Y+67",
                "Prize: X=8400, Y=5400",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("280"));
        }

        [Test]
        public void Should_do_part_one_from_example_sub2()
        {
            // GIVEN
            sut.InputLines = [
                "Button A: X+26, Y+66",
                "Button B: X+67, Y+21",
                "Prize: X=12748, Y=12176",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("0"));
        }

        [Test]
        public void Should_do_part_one_from_example_sub3()
        {
            // GIVEN
            sut.InputLines = [
                "Button A: X+17, Y+86",
                "Button B: X+84, Y+37",
                "Prize: X=7870, Y=6450",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("200"));
        }

        [Test]
        public void Should_do_part_one_from_example_full()
        {
            // GIVEN
            sut.InputLines = [
                "Button A: X+94, Y+34",
                "Button B: X+22, Y+67",
                "Prize: X=8400, Y=5400",
                "",
                "Button A: X+26, Y+66",
                "Button B: X+67, Y+21",
                "Prize: X=12748, Y=12176",
                "",
                "Button A: X+17, Y+86",
                "Button B: X+84, Y+37",
                "Prize: X=7870, Y=6450",
                "",
                "Button A: X+69, Y+23",
                "Button B: X+27, Y+71",
                "Prize: X=18641, Y=10279",
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("480"));
        }
    }
}
