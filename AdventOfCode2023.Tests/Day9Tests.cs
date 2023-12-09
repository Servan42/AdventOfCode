using AdventOfCode2023.Core.Daily.Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day9Tests
    {
        Day9Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day9Ex();
        }

        [Test]
        public void Should_parse_one_line()
        {
            // WHEN
            var historyLine = HistoryLine.Parse("0 3 6 -9 12 15");

            // THEN
            CollectionAssert.AreEqual(new List<double> { 0, 3, 6, -9, 12, 15 }, historyLine.HistoryExtrapolations[0]);
        }

        [TestCase("0 3 6 9 12 15", 18)]
        [TestCase("1 3 6 10 15 21", 28)]
        [TestCase("10 13 16 21 30 45", 68)]
        public void Should_extrapolate_history(string inputLine, double expectedResult)
        {
            // GIVEN
            var hl = HistoryLine.Parse(inputLine);

            // WHEN
            var result = hl.GetLastFinalExtrapolationValue();

            // THEN
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_sum_every_final_extrapolations()
        {
            // GIVEN
            sut.InputLines.Add("0 3 6 9 12 15");
            sut.InputLines.Add("1 3 6 10 15 21");
            sut.InputLines.Add("10 13 16 21 30 45");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("114"));
        }

        [TestCase("0 3 6 9 12 15", -3)]
        [TestCase("1 3 6 10 15 21", 0)]
        [TestCase("10 13 16 21 30 45", 5)]
        public void Should_extrapolate_history_backwards(string inputLine, double expectedResult)
        {
            // GIVEN
            var hl = HistoryLine.Parse(inputLine);

            // WHEN
            var result = hl.GetLastFinalExtrapolationValue(true);

            // THEN
            Assert.That(result, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_sum_every_final_extrapolations_backwards()
        {
            // GIVEN
            sut.InputLines.Add("0 3 6 9 12 15");
            sut.InputLines.Add("1 3 6 10 15 21");
            sut.InputLines.Add("10 13 16 21 30 45");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("2"));
        }
    }
}
