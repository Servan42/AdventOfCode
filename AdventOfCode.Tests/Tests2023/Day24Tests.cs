using AdventOfCode.Core.Daily2023.Day24;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day24Tests
    {
        Day24Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day24Ex();
        }

        [Test]
        [Ignore("Change the size of the collision windows hardocded")]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "19, 13, 30 @ -2,  1, -2",
                "18, 19, 22 @ -1, -1, -2",
                "20, 25, 34 @ -2, -2, -4",
                "12, 31, 28 @ -1, -2, -1",
                "20, 19, 15 @  1, -5, -3"
            };

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("2"));
        }

        [Test]
        public void Should_get_intersection()
        {
            // Given
            var hailstone1 = new Hailstone()
            {
                X = 19,
                Y = 13,
                VectorX = -2,
                VectorY = 1,
            };
            var hailstone2 = new Hailstone()
            {
                X = 18,
                Y = 19,
                VectorX = -1,
                VectorY = -1,
            };

            // When
            var result = hailstone1.Get2DIntersectionWith(hailstone2);

            // Then
            result = TruncateTo3Decimals(result.Value);
            Assert.That(result, Is.EqualTo((14.333, 15.333)));
        }

        private (decimal x, decimal y) TruncateTo3Decimals((decimal x, decimal y) toReduce)
        {
            return (decimal.Parse(toReduce.x.ToString("#.###")), decimal.Parse(toReduce.y.ToString("#.###")));
        }
    }
}
