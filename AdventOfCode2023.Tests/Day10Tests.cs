using AdventOfCode2023.Core.Daily.Day10;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    public class Day10Tests
    {
        Day10Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day10Ex();
        }

        private static readonly List<string> mazeLoopNoExtraPipes = new List<string>
        {
            ".....",
            ".S-7.",
            ".|.|.",
            ".L-J.",
            "....."
        };

        private static readonly List<string> mazeLoopWithExtraPipes = new List<string>
        {
            "-L|F7",
            "7S-7|",
            "L|7||",
            "-L-J|",
            "L|-JF"
        };

        private static readonly List<string> complexMazeLoopNoExtraPipes = new List<string>
        {
            "..F7.",
            ".FJ|.",
            "SJ.L7",
            "|F--J",
            "LJ..."
        };

        private static readonly List<string> complexMazeLoopWithExtraPipes = new List<string>
        {
            "7-F7-",
            ".FJ|7",
            "SJLL7",
            "|F--J",
            "LJ.LJ"
        };

        private static IEnumerable<TestCaseData> Part1Examples()
        {
            yield return new TestCaseData(mazeLoopNoExtraPipes, "4");
            yield return new TestCaseData(mazeLoopWithExtraPipes, "4");
            yield return new TestCaseData(complexMazeLoopNoExtraPipes, "8");
            yield return new TestCaseData(complexMazeLoopWithExtraPipes, "8");
        }

        [TestCaseSource(nameof(Part1Examples))]
        public void Should_find_nb_steps_to_get_from_start_to_farthest_point(List<string> inputLines, string expectedResult)
        {
            // GIVEN
            sut.InputLines = inputLines;

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo(expectedResult));
        }

        [Test]
        public void Should_parse_maze_from_inputLines_simple_maze_loop_no_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(mazeLoopNoExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(8));
            var path = new List<string> { "1,1", "1,2", "1,3", "2,3", "3,3", "3,2", "3,1", "2,1", "1,1" };
            AssertEdgesArePresent(pipeMaze, path);
        }

        private static void AssertEdgesArePresent(PipeMaze pipeMaze, List<string> path)
        {
            var pathReversed = new List<string>(path);
            pathReversed.Reverse();
            for (int i = 1; i < path.Count; i++)
            {
                Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode(path[i - 1]), pipeMaze.GetNode(path[i])), $"Edge {path[i - 1]} -> {path[i]} does not exist");
                Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode(pathReversed[i - 1]), pipeMaze.GetNode(pathReversed[i])), $"Edge {pathReversed[i - 1]} -> {pathReversed[i]} does not exist");
            }
        }

        [Test]
        public void Should_parse_maze_from_inputLines_simple_maze_loop_With_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(mazeLoopWithExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(25));
            var path = new List<string> { "1,1", "1,2", "1,3", "2,3", "3,3", "3,2", "3,1", "2,1", "1,1" };
            AssertEdgesArePresent(pipeMaze, path);
        }

        [Test]
        public void Should_parse_maze_from_inputLines_complex_maze_loop_no_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(complexMazeLoopNoExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(16));
            var path = new List<string> { "2,0", "2,1", "1,1", "1,2", "0,2", "0,3", "1,3", "2,3", "2,4", "3,4", "3,3", "3,2", "3,1", "4,1", "4,0", "3,0", "2,0" };
            AssertEdgesArePresent(pipeMaze, path);
        }

        [Test]
        public void Should_parse_maze_from_inputLines_complex_maze_loop_with_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(complexMazeLoopWithExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(25 - 2));
            var path = new List<string> { "2,0", "2,1", "1,1", "1,2", "0,2", "0,3", "1,3", "2,3", "2,4", "3,4", "3,3", "3,2", "3,1", "4,1", "4,0", "3,0", "2,0" };
            AssertEdgesArePresent(pipeMaze, path);
        }
    }
}
