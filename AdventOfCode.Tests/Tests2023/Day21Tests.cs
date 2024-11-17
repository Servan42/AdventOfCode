using AdventOfCode.Core.Daily2023.Day21;

namespace AdventOfCode.Tests.Tests2023
{
    internal class Day21Tests
    {
        Day21Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day21Ex();
        }

        [Test]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "...........",
                ".....###.#.",
                ".###.##..#.",
                "..#.#...#..",
                "....#.#....",
                ".##..S####.",
                ".##..#...#.",
                ".......##..",
                ".##.#.####.",
                ".##..##.##.",
                "..........."
            };

            // When
            var result = Garden.Parse(sut.InputLines).Walk(6).ToString();

            // Then
            Assert.That(result, Is.EqualTo("16"));
        }
    }
}
