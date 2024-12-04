using AdventOfCode.Core.Daily2023.Day13;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day04
{
    public class Day04Ex : Exercise
    {
        private List<(int x, int y)> COOD_AROUND_SQUARE_8 = [(-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1)];
        private List<(int x, int y)> COOD_AROUND_DIAGONAL = [(-1, -1), (-1, 1), (1, -1), (1, 1)];

        public override void ComputePart1()
        {
            this.Output = CountXmas(CountAroundX, 'X').ToString();
        }

        public override void ComputePart2()
        {
            this.Output = CountXmas(CountAroundA, 'A').ToString();
        }

        private int CountXmas(Func<int, int, int> countAround, char baseChar)
        {
            int sum = 0;
            for (int row = 0; row < this.InputLines.Count; row++)
            {
                for (int column = 0; column < this.InputLines[0].Length; column++)
                {
                    if (this.InputLines[row][column] != baseChar)
                        continue;

                    sum += countAround(row, column);
                }
            }
            return sum;
        }

        private int CountAroundX(int row, int column)
        {
            int sum = 0;
            int maxRowIndex = this.InputLines.Count - 1;
            int maxColumnIndex = this.InputLines[0].Length - 1;
            foreach (var cood in COOD_AROUND_SQUARE_8)
            {
                if ((row + 3 * cood.x) > maxRowIndex
                    || (row + 3 * cood.x) < 0
                    || (column + 3 * cood.y) > maxColumnIndex
                    || (column + 3 * cood.y) < 0
                    )
                    continue;

                if (this.InputLines[row + 1 * cood.x][column + 1 * cood.y] == 'M'
                    && this.InputLines[row + 2 * cood.x][column + 2 * cood.y] == 'A'
                    && this.InputLines[row + 3 * cood.x][column + 3 * cood.y] == 'S')
                {
                    sum++;
                }
            }

            return sum;
        }

        private int CountAroundA(int row, int column)
        {
            int masCount = 0;
            int maxRowIndex = this.InputLines.Count - 1;
            int maxColumnIndex = this.InputLines[0].Length - 1;
            foreach (var cood in COOD_AROUND_DIAGONAL)
            {
                if ((row + cood.x) > maxRowIndex
                    || (row + cood.x) < 0
                    || (row - cood.x) > maxRowIndex
                    || (row - cood.x) < 0
                    || (column + cood.y) > maxColumnIndex
                    || (column + cood.y) < 0
                    || (column - cood.y) > maxColumnIndex
                    || (column - cood.y) < 0
                    )
                    continue;

                if (this.InputLines[row + cood.x][column + cood.y] == 'M'
                    && this.InputLines[row - cood.x][column - cood.y] == 'S')
                {
                    masCount++;
                }
            }
            return masCount == 2 ? 1 : 0;
        }
    }
}
