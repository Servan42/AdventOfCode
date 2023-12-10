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
            sut.InputLines = mazeLoopNoExtraPipes;

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("4"));
        }

        [Test]
        public void Should_parse_maze_from_inputLines_simple_maze_loop_no_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(mazeLoopNoExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(8));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,1"), pipeMaze.GetNode("1,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,2"), pipeMaze.GetNode("1,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,3"), pipeMaze.GetNode("2,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,3"), pipeMaze.GetNode("3,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,3"), pipeMaze.GetNode("3,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,2"), pipeMaze.GetNode("3,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,1"), pipeMaze.GetNode("2,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,1"), pipeMaze.GetNode("1,1")));
            // bidirectional
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,2"), pipeMaze.GetNode("1,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,3"), pipeMaze.GetNode("1,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,3"), pipeMaze.GetNode("1,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,3"), pipeMaze.GetNode("2,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,2"), pipeMaze.GetNode("3,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,1"), pipeMaze.GetNode("3,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,1"), pipeMaze.GetNode("3,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,1"), pipeMaze.GetNode("2,1")));
        }

        [Test]
        public void Should_parse_maze_from_inputLines_simple_maze_loop_With_extra_pipes()
        {
            // WHEN
            var pipeMaze = PipeMaze.Parse(mazeLoopWithExtraPipes);

            // THEN
            Assert.That(pipeMaze.GetNodesCount(), Is.EqualTo(25));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,1"), pipeMaze.GetNode("1,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,2"), pipeMaze.GetNode("1,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,3"), pipeMaze.GetNode("2,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,3"), pipeMaze.GetNode("3,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,3"), pipeMaze.GetNode("3,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,2"), pipeMaze.GetNode("3,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,1"), pipeMaze.GetNode("2,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,1"), pipeMaze.GetNode("1,1")));
            // bidirectional
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,2"), pipeMaze.GetNode("1,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,3"), pipeMaze.GetNode("1,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,3"), pipeMaze.GetNode("1,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,3"), pipeMaze.GetNode("2,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,2"), pipeMaze.GetNode("3,3")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("3,1"), pipeMaze.GetNode("3,2")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("2,1"), pipeMaze.GetNode("3,1")));
            Assert.DoesNotThrow(() => pipeMaze.GetEdgeWeight(pipeMaze.GetNode("1,1"), pipeMaze.GetNode("2,1")));
        }
    }
}
