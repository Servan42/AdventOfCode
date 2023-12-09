using AdventOfCode2023.Core;
using AdventOfCode2023.Core.Daily.Day3;
using AdventOfCode2023.Core.Daily.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day8Tests
    {
        Day8Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day8Ex();
        }

        [Test]
        public void Should_parse_graph_from_input()
        {
            // GIVEN
            var input = new List<string>
            {
                "RL",
                "",
                "AAA = (BBB, CCC)",
                "BBB = (DDD, EEE)"
            };

            // WHEN
            var networkMap = NetworkMap.Parse(input);

            // THEN
            Assert.That(networkMap.PathInstructions, Is.EqualTo("RL"));
            Assert.That(networkMap.GetNode("AAA"), Is.Not.Null);
            Assert.That(networkMap.GetNode("BBB"), Is.Not.Null);
            Assert.That(networkMap.GetNode("CCC"), Is.Not.Null);
            Assert.That(networkMap.GetNode("DDD"), Is.Not.Null);
            Assert.That(networkMap.GetNode("EEE"), Is.Not.Null);
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("AAA")).Count(), Is.EqualTo(2));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("AAA")).Count(n => n.GetUniqueIdentifier() == "BBB"), Is.EqualTo(1));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("AAA")).Count(n => n.GetUniqueIdentifier() == "CCC"), Is.EqualTo(1));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("BBB")).Count(), Is.EqualTo(2));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("BBB")).Count(n => n.GetUniqueIdentifier() == "DDD"), Is.EqualTo(1));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("BBB")).Count(n => n.GetUniqueIdentifier() == "EEE"), Is.EqualTo(1));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("CCC")).Count(), Is.EqualTo(0));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("DDD")).Count(), Is.EqualTo(0));
            Assert.That(networkMap.GetNeighbors(networkMap.GetNode("EEE")).Count(), Is.EqualTo(0));
        }

        [Test]
        public void PART1_Should_follow_path_from_AAA_to_ZZZ_and_return_number_of_steps()
        {
            // GIVEN
            sut.InputLines.Add("LLR");
            sut.InputLines.Add("AAA = (BBB, BBB)");
            sut.InputLines.Add("BBB = (AAA, ZZZ)");
            sut.InputLines.Add("ZZZ = (ZZZ, ZZZ)");

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("6"));
        }

        [Test]
        public void PART2_Should_follow_path_from_all_XXA_to_all_XXZ_nodes()
        {
            // GIVEN
            sut.InputLines.Add("LR");
            sut.InputLines.Add("");
            sut.InputLines.Add("LLA = (LLB, XXX)");
            sut.InputLines.Add("LLB = (XXX, LLZ)");
            sut.InputLines.Add("LLZ = (LLB, XXX)");
            sut.InputLines.Add("EEA = (EEB, XXX)");
            sut.InputLines.Add("EEB = (EEC, EEC)");
            sut.InputLines.Add("EEC = (EEZ, EEZ)");
            sut.InputLines.Add("EEZ = (EEB, EEB)");
            sut.InputLines.Add("XXX = (XXX, XXX)");

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("6"));
        }

        [TestCase(15,"3*5")]
        [TestCase(105,"3*5*7")]
        [TestCase(525,"3*5*5*7")]
        [TestCase(1025,"5*5*41")]
        [TestCase(4352,"2*2*2*2*2*2*2*2*17")]
        [TestCase(73,"73")]
        [TestCase(277,"277")]
        public void Should_calculate_prime_factors(int numberToFactor, string expectedFactorsToSplit)
        {
            // GIVEN
            List<int> expectedFactors = expectedFactorsToSplit.Split('*').Select(n => int.Parse(n)).ToList();

            // WHEN
            List<int> primeFactors = numberToFactor.PrimeFactors();

            // THEN
            Assert.That(primeFactors.Mult(), Is.EqualTo(numberToFactor));
            CollectionAssert.AreEquivalent(primeFactors, expectedFactors);
        }

        [TestCase("6 8 15", 120)]
        [TestCase("140 72", 2520)]
        [TestCase("288 420", 10080)]
        public void Should_calculate_LCM(string numbersToSplit, int expectedLCM)
        {
            // GIVEN
            List<int> numbers = numbersToSplit.GetSpacesSeparatedInts();

            // WHEN
            double lcm = numbers.LeastCommonMultiple();

            // THEN
            Assert.That(lcm, Is.EqualTo(expectedLCM));
        }

    }
}
