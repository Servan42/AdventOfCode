using AdventOfCode2023.Core.Daily.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day3Tests
    {
        Day3Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day3Ex();
        }

        [Test]
        public void PART1_Should_find_a_digit()
        {
            // GIVEN
            sut.InputLines.Add("...");
            sut.InputLines.Add(".1.");
            sut.InputLines.Add("..2");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForPartNumbersInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Numbers.Count, Is.EqualTo(2));
            Assert.That(engineSchematic_sut.Numbers.First().Value, Is.EqualTo("1"));
            Assert.That(engineSchematic_sut.Numbers.Last().Value, Is.EqualTo("2"));
        }

        [Test]
        public void PART1_Should_find_a_number()
        {
            // GIVEN
            sut.InputLines.Add("...");
            sut.InputLines.Add("123");
            sut.InputLines.Add(".56");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForPartNumbersInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Numbers.Count, Is.EqualTo(2));
            Assert.That(engineSchematic_sut.Numbers.First().Value, Is.EqualTo("123"));
            Assert.That(engineSchematic_sut.Numbers.Last().Value, Is.EqualTo("56"));
        }

        [Test]
        public void PART1_Should_find_a_PartNumber()
        {
            // GIVEN
            sut.InputLines.Add(".#.");
            sut.InputLines.Add("123");
            sut.InputLines.Add(".56");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForPartNumbersInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Numbers.Count, Is.EqualTo(2));
            Assert.That(engineSchematic_sut.Numbers.First().Value, Is.EqualTo("123"));
            Assert.That(engineSchematic_sut.Numbers.First().IsPartNumber, Is.EqualTo(true));
            Assert.That(engineSchematic_sut.Numbers.Last().Value, Is.EqualTo("56"));
            Assert.That(engineSchematic_sut.Numbers.Last().IsPartNumber, Is.EqualTo(false));
        }

        [Test]
        public void PART1_Should_output_the_sum_of_part_numbers()
        {
            // GIVEN
            sut.InputLines.Add("467..114..");
            sut.InputLines.Add("...*......");
            sut.InputLines.Add("..35..633.");
            sut.InputLines.Add("......#...");
            sut.InputLines.Add("617*......");
            sut.InputLines.Add(".....+.58.");
            sut.InputLines.Add("..592.....");
            sut.InputLines.Add("......755.");
            sut.InputLines.Add("...$.*....");
            sut.InputLines.Add(".664.598..");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("4361"));
        }

        [Test]
        public void PART2_Should_find_a_gear()
        {
            // GIVEN
            sut.InputLines.Add("...");
            sut.InputLines.Add(".*.");
            sut.InputLines.Add("..*");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForGearsInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Gears.Count, Is.EqualTo(2));
            Assert.That(engineSchematic_sut.Gears.All(g => g.Power == 0), Is.EqualTo(true));
        }

        [Test]
        public void PART2_Should_find_gear_power_for_digit()
        {
            // GIVEN
            sut.InputLines.Add("*.*");
            sut.InputLines.Add("3*.");
            sut.InputLines.Add("..2");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForGearsInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Gears.Count, Is.EqualTo(3));
            Assert.That(engineSchematic_sut.Gears.Count(g => g.Power == 6), Is.EqualTo(1));
        }

        [Test]
        public void PART2_Should_find_gear_power_for_numbers()
        {
            // GIVEN
            sut.InputLines.Add("....");
            sut.InputLines.Add("30*.");
            sut.InputLines.Add(".100");
            EngineSchematic engineSchematic_sut = new(3, 4);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForGearsInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Gears.Count, Is.EqualTo(1));
            Assert.That(engineSchematic_sut.Gears.First().Power, Is.EqualTo(3000));
        }

        [Test]
        public void PART2_Should_find_gear_power_for_similar_numbers_and_same_line()
        {
            // GIVEN
            sut.InputLines.Add("10.10");
            sut.InputLines.Add("..*..");
            EngineSchematic engineSchematic_sut = new(2, 5);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForGearsInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Gears.Count, Is.EqualTo(1));
            Assert.That(engineSchematic_sut.Gears.First().Power, Is.EqualTo(100));
        }

        [Test]
        public void PART2_Should_find_gear_power_for_similar_numbers_with_same_column_index()
        {
            // GIVEN
            sut.InputLines.Add("720");
            sut.InputLines.Add(".*.");
            sut.InputLines.Add("720");
            EngineSchematic engineSchematic_sut = new(3, 3);
            engineSchematic_sut.LoadFromInputLines(sut.InputLines);

            // WHEN
            engineSchematic_sut.LookForGearsInGrid();

            // THEN
            Assert.That(engineSchematic_sut.Gears.Count, Is.EqualTo(1));
            Assert.That(engineSchematic_sut.Gears.First().Power, Is.EqualTo(720*720));
        }

        [Test]
        public void PART2_Should_output_the_sum_of_gear_powers()
        {
            // GIVEN
            sut.InputLines.Add("467..114..");
            sut.InputLines.Add("...*......");
            sut.InputLines.Add("..35..633.");
            sut.InputLines.Add("......#...");
            sut.InputLines.Add("617*......");
            sut.InputLines.Add(".....+.58.");
            sut.InputLines.Add("..592.....");
            sut.InputLines.Add("......755.");
            sut.InputLines.Add("...$.*....");
            sut.InputLines.Add(".664.598..");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("467835"));
        }
    }
}
