using AdventOfCode.Core.Daily2024.Day05;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day05Tests
    {
        Day05Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day05Ex();
        }

        [Test]
        public void Should_get_children_in_precedence_graph()
        {
            // GIVEN
            List<string> input = [
                "1|3",
                "1|2",
                "2|3",
            ];

            var graph = PrecedenceGraph.Build(input);

            // WHEN
            var childrenOf1 = graph.GetDistinctChildren(1);
            var childrenOf2 = graph.GetDistinctChildren(2);
            var childrenOf3 = graph.GetDistinctChildren(3);

            // THEN
            CollectionAssert.AreEquivalent(new int[] { 2, 3 }, childrenOf1);
            CollectionAssert.AreEquivalent(new int[] { 3 }, childrenOf2);
            CollectionAssert.AreEquivalent(new int[] { }, childrenOf3);

        }

        [Test]
        public void Should_get_parent_in_precedence_graph()
        {
            // GIVEN
            List<string> input = [
                "1|3",
                "1|2",
                "2|3",
            ];

            var graph = PrecedenceGraph.Build(input);

            // WHEN
            var parentOf1 = graph.GetDistinctParent(1);
            var parentOf2 = graph.GetDistinctParent(2);
            var parentOf3 = graph.GetDistinctParent(3);

            // THEN
            CollectionAssert.AreEquivalent(new int[] { }, parentOf1);
            CollectionAssert.AreEquivalent(new int[] { 1 }, parentOf2);
            CollectionAssert.AreEquivalent(new int[] { 2, 1 }, parentOf3);

        }

        [Test]
        public void Should_do_part_one_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("143"));
        }

        [Test]
        public void Should_do_part_two_from_example()
        {
            // GIVEN
            sut.InputLines = [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
                "",
                "75,47,61,53,29",
                "97,61,53,29,13",
                "75,29,13",
                "75,97,47,61,53",
                "61,13,29",
                "97,13,75,29,47"
            ];

            // WHEN
            sut.ComputePart2();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("123"));
        }

        [TestCase("75,97,47,61,53", "97,75,47,61,53")]
        [TestCase("61,13,29", "61,29,13")]
        [TestCase("97,13,75,29,47", "97,75,47,29,13")]
        public void Should_reorder_sequence(string input, string expected)
        {
            // GIVEN
            List<string> graphInput = [
                "47|53",
                "97|13",
                "97|61",
                "97|47",
                "75|29",
                "61|13",
                "75|53",
                "29|13",
                "97|29",
                "53|29",
                "61|53",
                "97|53",
                "61|29",
                "47|13",
                "75|47",
                "97|75",
                "47|61",
                "75|61",
                "47|29",
                "75|13",
                "53|13",
            ];

            var graph = PrecedenceGraph.Build(graphInput);
            var updates_sut = Updates.Build(input);

            // THEN
            updates_sut.ReOrder(graph);

            // THEN
            Assert.That(string.Join(',', updates_sut.PageNumbers), Is.EqualTo(expected));
        }
    }
}
