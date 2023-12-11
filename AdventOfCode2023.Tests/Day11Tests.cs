using AdventOfCode2023.Core.Daily.Day11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day11Tests
    {
        Day11Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day11Ex();
        }

        private static List<string> universeExample = new List<string>
        {
            "...#......",
            ".......#..",
            "#.........",
            "..........",
            "......#...",
            ".#........",
            ".........#",
            "..........",
            ".......#..",
            "#...#....."
        };

        [Test]
        public void Should_expand_universe()
        {
            // Given
            List<string> input = new List<string>
            {
                "#.#",
                "...",
                "#.#"
            };

            // When
            var universe = Universe.Parse(input);

            // Then
            CollectionAssert.AreEqual(new List<string>
            {
                "#..#",
                "....",
                "....",
                "#..#",
            }, universe.Grid);
        }

        [Test]
        public void Should_expand_universe_from_example()
        {
            // Given
            List<string> input = universeExample;

            // When
            var universe = Universe.Parse(input);

            // Then
            CollectionAssert.AreEqual(new List<string>
            {
                "....#........",
                ".........#...",
                "#............",
                ".............",
                ".............",
                "........#....",
                ".#...........",
                "............#",
                ".............",
                ".............",
                ".........#...",
                "#....#......."
            }, universe.Grid);
        }

        [Test]
        public void Should_parse_to_a_nodegraph()
        {
            // Given
            List<string> input = new List<string>
            {
                "#.#",
                "...",
                "#.#"
            };

            // When
            var universe = Universe.Parse(input);

            // Then
            Assert.That(universe.GetNodesCount(), Is.EqualTo(4 * 4));
            Assert.That(universe.Galaxies.Count, Is.EqualTo(4));
        }

        [Test]
        public void Should_parse_to_a_nodegraph_from_example()
        {
            // Given
            List<string> input = universeExample;

            // When
            var universe = Universe.Parse(input);

            // Then
            Assert.That(universe.GetNodesCount(), Is.EqualTo(12 * 13));
            Assert.That(universe.Galaxies.Count, Is.EqualTo(9));
        }

        [Test]
        public void Should_generate_pairs()
        {
            // Given
            List<string> input = new List<string>
            {
                "#.#",
                "...",
                "#.#"
            };

            // When
            var universe = Universe.Parse(input);

            // Then
            Assert.That(universe.GalaxyPairs.Count, Is.EqualTo(6));
        }

        [Test]
        public void Should_generate_pairs_from_example()
        {
            // Given
            List<string> input = universeExample;

            // When
            var universe = Universe.Parse(input);

            // Then
            Assert.That(universe.GalaxyPairs.Count, Is.EqualTo(36));
        }

        [TestCase("0,4", "10,9", 15)]
        [TestCase("2,0", "7,12", 17)]
        [TestCase("11,0", "11,5", 5)]
        public void Pathfinder_should_work(string startNodeId, string destinationNodeId, int expectedPathLength)
        {
            // Given
            var universe = Universe.Parse(universeExample);
            var startNode = universe.GetNode(startNodeId);
            var destinationNode = universe.GetNode(destinationNodeId);

            // When
            var bfsPath = universe.BreadthFirstSearch(startNode, destinationNode);
            var djiPath = universe.DijkstrasAlgorithm(startNode, destinationNode);
            var heuPath = universe.HeuristicSearch(startNode, destinationNode);
            var astPath = universe.AstarAlgorithm(startNode, destinationNode);
            
            // Then
            Assert.Multiple(() =>
            {
                Assert.That(bfsPath.Count - 1, Is.EqualTo(expectedPathLength));
                Assert.That(djiPath.Count - 1, Is.EqualTo(expectedPathLength));
                Assert.That(heuPath.Count - 1, Is.EqualTo(expectedPathLength));
                Assert.That(astPath.Count - 1, Is.EqualTo(expectedPathLength));
            });
        }

        [Test]
        public void Part1_Should_Get_Sum_Of_Shortest_Path_For_All_Pairs_Of_Galaxies()
        {
            // GIVEN
            sut.InputLines = universeExample;

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("374"));
        }
    }
}
