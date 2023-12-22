using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day21
{
    public class Day21Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = Garden.Parse(InputLines).Walk(64).ToString();
        }

        public void AssertInputDataAssumption()
        {
            Assert.That(InputLines.Count == InputLines[0].Length, "Should be a square");
            var sqSize = InputLines.Count;
            Assert.That(InputLines[sqSize / 2][sqSize / 2] == 'S', "Should start in the middle of the grid");
            Assert.That(26501365 % sqSize == sqSize / 2, "Step count is a multiple of full grid + half grid lengh");
        }

        public override void ComputePart2()
        {
            AssertInputDataAssumption();
            var sqSize = InputLines.Count;
            var steps = 26501365;
            (int row, int col) startPoint = (sqSize / 2, sqSize / 2);

            var reachableSqSize = (steps / sqSize) - 1;

            // Counting the number of odd grids and even grids that are reachable with the given steps.
            // This does not count the edge cases, aka the grid that will not be fully explored on edges.
            // An odd grid is a grid where the number of steps we start with is odd
            double nbOfOddGrid = (reachableSqSize / 2 * 2 + 1);
            nbOfOddGrid *= nbOfOddGrid;
            double nbOfEvenGrid = ((reachableSqSize + 1) / 2 * 2);
            nbOfEvenGrid *= nbOfEvenGrid;

            var garden = Garden.Parse(InputLines);
            double oddGridPoints = garden.Walk(sqSize * 2 + 1); // Walking a big enough odd number to cover the whole grid.
            double evenGridPoints = garden.Walk(sqSize * 2);

            // Handling edge grirds that will not be totally walked through
            // Counting the 4 corners that will be explored like a little house shape (ex right: [>) 
            double topEdgeGridPoints = garden.Walk(sqSize - 1, $"{sqSize - 1},{startPoint.col}");
            double bottomEdgeGridPoints = garden.Walk(sqSize - 1, $"0,{startPoint.col}");
            double rightEdgeGridPoints = garden.Walk(sqSize - 1, $"{startPoint.row},0");
            double leftEdgeGridPoints = garden.Walk(sqSize - 1, $"{startPoint.row},{sqSize - 1}");

            // Counting the edge grids that are between corners (small triangles)
            double smallTopRightGridPoints = garden.Walk(sqSize / 2 - 1, $"{sqSize - 1},0");
            double smallTopLeftGridPoints = garden.Walk(sqSize / 2 - 1, $"{sqSize - 1},{sqSize - 1}");
            double smallBottomRightGridPoints = garden.Walk(sqSize / 2 - 1, "0,0");
            double smallBottomLeftGridPoints = garden.Walk(sqSize / 2 - 1, $"0,{sqSize - 1}");

            // Counting the edge grids that are between corners (large ones)
            double largeTopRightGridPoints = garden.Walk(sqSize * 3 / 2 - 1, $"{sqSize - 1},0");
            double largeTopLeftGridPoints = garden.Walk(sqSize * 3 / 2 - 1, $"{sqSize - 1},{sqSize - 1}");
            double largeBottomRightGridPoints = garden.Walk(sqSize * 3 / 2 - 1, "0,0");
            double largeBottomLeftGridPoints = garden.Walk(sqSize * 3 / 2 - 1, $"0,{sqSize - 1}");

            double result = nbOfOddGrid * oddGridPoints
                + nbOfEvenGrid * evenGridPoints
                + topEdgeGridPoints
                + bottomEdgeGridPoints
                + rightEdgeGridPoints
                + leftEdgeGridPoints
                + (reachableSqSize + 1) * (smallBottomLeftGridPoints + smallBottomRightGridPoints + smallTopLeftGridPoints + smallTopRightGridPoints)
                + reachableSqSize * (largeBottomLeftGridPoints + largeBottomRightGridPoints + largeTopLeftGridPoints + largeTopRightGridPoints);

            Output = result.ToString();
        }
    }
}
