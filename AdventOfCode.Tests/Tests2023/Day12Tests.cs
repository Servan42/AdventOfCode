using AdventOfCode.Core.Daily2023.Day12;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day12Tests
    {
        Day12Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day12Ex();
        }

        [TestCase("#.#.### 1,1,3")]
        [TestCase(".#...#....###. 1,1,3")]
        [TestCase(".#.###.#.###### 1,3,1,6")]
        [TestCase("####.#...#... 4,1,1")]
        [TestCase("#....######..#####. 1,6,5")]
        [TestCase(".###.##....# 3,2,1")]
        public void Should_evaluate_line(string inputLine)
        {
            string evaluation = new SpringGroup("", "").EvaluateSprings(inputLine.Split(' ')[0]);
            Assert.That(evaluation, Is.EqualTo(inputLine.Split(' ')[1]));
        }

        //[Test]
        //public void Should_compute_possibilites_of_removing_question_marks()
        //{
        //    var possibilities = new SpringGroup(".??#.?", "").GetAllPossibilitiesWhenReplacingQuestionMarks();
        //    Assert.Multiple(() =>
        //    {
        //        Assert.That(possibilities.Contains("...#.."));
        //        Assert.That(possibilities.Contains("...#.#"));
        //        Assert.That(possibilities.Contains("..##.."));
        //        Assert.That(possibilities.Contains("..##.#"));
        //        Assert.That(possibilities.Contains(".#.#.."));
        //        Assert.That(possibilities.Contains(".#.#.#"));
        //        Assert.That(possibilities.Contains(".###.."));
        //        Assert.That(possibilities.Contains(".###.#"));
        //    });
        //}

        [TestCase("???.### 1,1,3", 1)]
        [TestCase(".??..??...?##. 1,1,3", 4)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
        [TestCase("????.#...#... 4,1,1", 1)]
        [TestCase("????.######..#####. 1,6,5", 4)]
        [TestCase("?###???????? 3,2,1", 10)]
        public void Should_get_nb_arrangements(string inputLine, int expectedNb)
        {
            // GIVEN
            var springGroup = SpringGroup.Parse(inputLine);

            // WHEN
            var nb = springGroup.GetNbArrangements();

            // THEN
            Assert.That(nb, Is.EqualTo(expectedNb));
        }

        [TestCase("???.### 1,1,3", 1)]
        [TestCase(".??..??...?##. 1,1,3", 4)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
        [TestCase("????.#...#... 4,1,1", 1)]
        [TestCase("????.######..#####. 1,6,5", 4)]
        [TestCase("?###???????? 3,2,1", 10)]
        public void Should_get_nb_arrangements_recursive(string inputLine, int expectedNb)
        {
            // GIVEN
            var springGroup = SpringGroup.Parse(inputLine);

            // WHEN
            var nb = springGroup.GetNbArrangementsRecursive();

            // THEN
            Assert.That(nb, Is.EqualTo(expectedNb));
        }

        [Test]
        public void Should_sum_for_part1()
        {
            // GIVEN
            sut.InputLines.Add("???.### 1,1,3");
            sut.InputLines.Add(".??..??...?##. 1,1,3");
            sut.InputLines.Add("?#?#?#?#?#?#?#? 1,3,1,6");
            sut.InputLines.Add("????.#...#... 4,1,1");
            sut.InputLines.Add("????.######..#####. 1,6,5");
            sut.InputLines.Add("?###???????? 3,2,1");

            // WHEN
            sut.ComputePart1();

            Assert.That(sut.Output, Is.EqualTo("21"));
        }

        [TestCase(".# 1", ".#?.#?.#?.#?.# 1,1,1,1,1")]
        [TestCase("???.### 1,1,3", "???.###????.###????.###????.###????.### 1,1,3,1,1,3,1,1,3,1,1,3,1,1,3")]
        public void Should_unfold_springs(string inputline, string unfoldedSprings)
        {
            // GIVEN
            var springGroup = SpringGroup.Parse(inputline);

            // WHEN
            springGroup.Unfold();

            // WHEN
            Assert.That(springGroup.Springs, Is.EqualTo(unfoldedSprings.Split(' ')[0]));
            Assert.That(springGroup.DamagedSpringSizes, Is.EqualTo(unfoldedSprings.Split(' ')[1]));
        }

        [TestCase("???.### 1,1,3", 1)]
        [TestCase(".??..??...?##. 1,1,3", 16384)]
        [TestCase("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
        [TestCase("????.#...#... 4,1,1", 16)]
        [TestCase("????.######..#####. 1,6,5", 2500)]
        [TestCase("?###???????? 3,2,1", 506250)]
        public void Should_get_nb_arrangements_recursive_when_unfolded(string inputLine, int expectedNb)
        {
            // GIVEN
            var springGroup = SpringGroup.Parse(inputLine, true);

            // WHEN
            var nb = springGroup.GetNbArrangementsRecursive();

            // THEN
            Assert.That(nb, Is.EqualTo(expectedNb));
        }
    }
}
