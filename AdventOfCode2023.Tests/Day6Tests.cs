using AdventOfCode2023.Core.Daily.Day6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day6Tests
    {
        Day6Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day6Ex();
        }

        [Test]
        public void Should_parse_input_for_part1()
        {
            // GIVEN
            sut.InputLines.Add("Time:      7  15   30");
            sut.InputLines.Add("Distance:  9  40  200");

            // WHEN
            RaceData raceData = RaceData.Parse(sut.InputLines);

            // THEN
            Assert.That(raceData.Races[0].Time, Is.EqualTo(7));
            Assert.That(raceData.Races[0].Distance, Is.EqualTo(9));
            Assert.That(raceData.Races[1].Time, Is.EqualTo(15));
            Assert.That(raceData.Races[1].Distance, Is.EqualTo(40));
            Assert.That(raceData.Races[2].Time, Is.EqualTo(30));
            Assert.That(raceData.Races[2].Distance, Is.EqualTo(200));
        }

        [Test]
        public void PART1_Should_ouptut_the_number_of_ways_to_beat_the_record_for_one_race()
        {
            // GIVEN
            sut.InputLines.Add("Time: 3");
            sut.InputLines.Add("Distance: 1");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("2")); // Hold for 1ms and for 2ms
        }

        [Test]
        public void PART1_Should_ouptut_the_numbers_of_ways_to_beat_the_record_for_multipleraces_multiplied()
        {
            // GIVEN
            sut.InputLines.Add("Time:      7  15   30");
            sut.InputLines.Add("Distance:  9  40  200");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("288"));
        }

        [Test]
        public void Should_parse_input_for_part2()
        {
            // GIVEN
            sut.InputLines.Add("Time:      7  15   30");
            sut.InputLines.Add("Distance:  9  40  200");

            // WHEN
            RaceData raceData = RaceData.ParsePart2(sut.InputLines);

            // THEN
            Assert.That(raceData.Races[0].Time, Is.EqualTo(71530));
            Assert.That(raceData.Races[0].Distance, Is.EqualTo(940200));
        }

        [Test]
        public void PART2_Should_ouptut_the_number_of_ways_to_beat_the_record_for_one__big_race()
        {
            // GIVEN
            sut.InputLines.Add("Time:      7  15   30");
            sut.InputLines.Add("Distance:  9  40  200");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("71503"));
        }
    }
}
