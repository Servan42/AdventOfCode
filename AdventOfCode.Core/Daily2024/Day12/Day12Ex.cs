using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day12
{
    public class Day12Ex : Exercise
    {
        private char[,] grid;
        private List<(int row, int col)> alreadyComputed;
        private int currentArea;
        private int currentPerimeter;

        private int currentSides;
        Dictionary<(int drow, int dcol), List<(int x, int y)>> pointsOnTheSidePerDirection = new();

        public override void ComputePart1()
        {
            double total = 0;
            this.grid = InputLines.ToCharArrayWithBorder('.');
            this.alreadyComputed = new();
            for (int row = 0; row < grid.NbRows(); row++)
            {
                for (int col = 0; col < grid.NbColumns(); col++)
                {
                    if (grid[row, col] == '.')
                        continue;

                    if (alreadyComputed.Contains((row, col)))
                        continue;

                    currentArea = 0;
                    currentPerimeter = 0;
                    CalculateAreaAndPerimeter(row, col);
                    total += currentArea * currentPerimeter;
                }
            }
            this.Output = total.ToString();
        }

        private void CalculateAreaAndPerimeter(int row, int col)
        {
            var fronteir = new Queue<(int row, int col)>();
            fronteir.Enqueue((row, col));

            while (fronteir.Count > 0)
            {
                var currentCood = fronteir.Dequeue();
                char currentChar = grid[currentCood.row, currentCood.col];
                this.alreadyComputed.Add(currentCood);
                this.currentArea++;

                int neighboursCount = 0;
                foreach (var direction in DataStructureExtensions.CrossDirections)
                {
                    (int row, int col) neighbourCood = (currentCood.row + direction.alongRow, currentCood.col + direction.alongCol);
                    var neighbourChar = grid[neighbourCood.row, neighbourCood.col];

                    if (neighbourChar == currentChar)
                    {
                        neighboursCount++;
                        if (!this.alreadyComputed.Contains(neighbourCood) && !fronteir.Contains(neighbourCood))
                        {
                            fronteir.Enqueue(neighbourCood);
                        }
                    }
                }
                this.currentPerimeter += 4 - neighboursCount;
            }
        }

        public override void ComputePart2()
        {
            double total = 0;
            this.grid = InputLines.ToCharArrayWithBorder('.');
            this.alreadyComputed = new();
            for (int row = 0; row < grid.NbRows(); row++)
            {
                for (int col = 0; col < grid.NbColumns(); col++)
                {
                    if (grid[row, col] == '.')
                        continue;

                    if (alreadyComputed.Contains((row, col)))
                        continue;

                    currentArea = 0;
                    currentSides = 0;
                    pointsOnTheSidePerDirection.Clear();
                    CalculateAreaAndStoreSides(row, col);
                    CalculateSides();
                    total += currentArea * currentSides;
                }
            }
            this.Output = total.ToString();
        }

        private void CalculateAreaAndStoreSides(int row, int col)
        {
            var fronteir = new Queue<(int row, int col)>();
            fronteir.Enqueue((row, col));

            while (fronteir.Count > 0)
            {
                var currentCood = fronteir.Dequeue();
                char currentChar = grid[currentCood.row, currentCood.col];
                this.alreadyComputed.Add(currentCood);
                this.currentArea++;

                foreach (var direction in DataStructureExtensions.CrossDirections)
                {
                    (int row, int col) neighbourCood = (currentCood.row + direction.alongRow, currentCood.col + direction.alongCol);
                    var neighbourChar = grid[neighbourCood.row, neighbourCood.col];

                    if (neighbourChar == currentChar
                        && !this.alreadyComputed.Contains(neighbourCood) 
                        && !fronteir.Contains(neighbourCood))
                    {
                        fronteir.Enqueue(neighbourCood);
                    }
                    else if (neighbourChar != currentChar)
                    {
                        if (pointsOnTheSidePerDirection.ContainsKey(direction))
                            pointsOnTheSidePerDirection[direction].Add(currentCood);
                        else
                            pointsOnTheSidePerDirection.Add(direction, [currentCood]);
                    }
                }
            }
        }

        private void CalculateSides()
        {
            foreach (var kvp in pointsOnTheSidePerDirection)
            {
                var sidePoints = kvp.Value;
                if (kvp.Key.drow == 0)
                    sidePoints = InvertXandY(sidePoints);

                var orderedSidePoints = sidePoints
                    .OrderBy(cood => cood.x)
                    .ThenBy(cood => cood.y)
                    .ToList();

                int lastX = -1;
                for (int i = 0; i < orderedSidePoints.Count; i++)
                {
                    if (orderedSidePoints[i].x != lastX)
                    {
                        lastX = orderedSidePoints[i].x;
                        this.currentSides++;
                    }

                    if (i > 0
                        && orderedSidePoints[i - 1].x == orderedSidePoints[i].x
                        && Math.Abs(orderedSidePoints[i - 1].y - orderedSidePoints[i].y) != 1)
                    {
                        this.currentSides++;
                    }
                }
            }
        }

        private List<(int x, int y)> InvertXandY(List<(int x, int y)> sidePoints)
        {
            var result = new List<(int x, int y)>();
            foreach (var point in sidePoints)
            {
                result.Add((point.y, point.x));
            }
            return result;
        }
    }
}
