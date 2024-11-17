using AdventOfCode.Core.Daily2023.Day1;
using System.Reflection.Metadata;

namespace AdventOfCode.Tests.Tests2023
{
    public class Day1Tests
    {
        Day1Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day1Ex();
        }

        [TestCase("1abc2", "12")]
        [TestCase("pqr3stu8vwx", "38")]
        [TestCase("a1b2c3d4e5f", "15")]
        public void PART1_Should_find_first_and_last_number_in_line(string line, string expectedNumber)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void PART1_Should_duplicate_number_if_its_alone()
        {
            // GIVEN
            sut.InputLines.Add("treb7uchet");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("77"));
        }

        [Test]
        public void PART1_Should_sum_the_numbers_of_all_lines()
        {
            // GIVEN
            sut.InputLines.Add("1abc2");
            sut.InputLines.Add("pqr3stu8vwx");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("50"));
        }

        [TestCase("trebuchet")]
        [TestCase("")]
        public void PART1_Should_throw_exception_when_no_number_was_found_on_a_line(string line)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN/THEN
            var ex = Assert.Throws<InvalidOperationException>(() => sut.ComputePart1());
        }

        [TestCase("*one*1*", "11")]
        [TestCase("*two*2*", "22")]
        [TestCase("*three*3*", "33")]
        [TestCase("*four*4*", "44")]
        [TestCase("*five*5*", "55")]
        [TestCase("*six*6*", "66")]
        [TestCase("*seven*7*", "77")]
        [TestCase("*eight*8*", "88")]
        [TestCase("*nine*9*", "99")]
        [TestCase("two1nine", "29")]
        [TestCase("eightwothree", "83")]
        [TestCase("abcone2threexyz", "13")]
        [TestCase("xtwone3four", "24")]
        [TestCase("4nineeightseven2", "42")]
        [TestCase("zoneight234", "14")]
        [TestCase("7pqrstsixteen", "76")]
        [TestCase("fmclk42six4", "44")]
        public void PART2_Should_find_number_as_string_in_line(string line, string expectedNumber)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedNumber));
        }

        [TestCase("treb7uchet", "77")]
        [TestCase("trebsevenuchet", "77")]
        public void PART2_Should_duplicate_number_if_its_alone(string line, string expectedNumber)
        {
            // GIVEN
            sut.InputLines.Add(line);

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedNumber));
        }

        [Test]
        public void PART2_Should_sum_the_numbers_of_all_lines()
        {
            // GIVEN
            sut.InputLines.Add("1abctwo");
            sut.InputLines.Add("pqr3stu8vwx");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("50"));
        }
    }
}