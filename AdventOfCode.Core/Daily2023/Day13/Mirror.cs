using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day13
{
    public class Mirror
    {
        private List<string> mirror = new();
        private List<string> transposedMirror = new();

        public int VerticalCount { get; private set; } = 0;
        public int HorizontalCount { get; private set; } = 0;

        public static Mirror Parse(List<string> inputLines, bool IsPart1)
        {
            var mirror = new Mirror();

            int nbRows = inputLines.Count;
            int nbCols = inputLines[0].Length;

            mirror.mirror = new List<string>(inputLines);
            for (int j = 0; j < nbCols; j++)
            {
                mirror.transposedMirror.Add("");
            }
            for (int i = 0; i < nbRows; i++)
            {
                for (int j = 0; j < nbCols; j++)
                {
                    mirror.transposedMirror[j] += inputLines[i][j];
                }
            }

            mirror.ComputePart1Numbers();
            if (!IsPart1)
                mirror.ComputePart2Numbers();

            return mirror;
        }

        private void ComputePart2Numbers()
        {
            for (int i = 0; i < mirror.Count; i++)
            {
                string originalLine = mirror[i];
                for (int j = 0; j < mirror[i].Length; j++)
                {
                    mirror[i] = SwapFigureAt(originalLine, j);

                    int horizontal = GetReflecionLine(true);
                    if (horizontal != -1)
                    {
                        VerticalCount = 0;
                        HorizontalCount = horizontal + 1;
                        return;
                    }
                }
                mirror[i] = originalLine;
            }

            for (int i = 0; i < transposedMirror.Count; i++)
            {
                string originalLine = transposedMirror[i];
                for (int j = 0; j < transposedMirror[i].Length; j++)
                {
                    transposedMirror[i] = SwapFigureAt(originalLine, j);

                    int vertical = GetReflecionLine(false);
                    if (vertical != -1)
                    {
                        HorizontalCount = 0;
                        VerticalCount = vertical + 1;
                        return;
                    }
                }
                transposedMirror[i] = originalLine;
            }

            throw new Exception("No reflection line found");
        }

        private string SwapFigureAt(string line, int indexToSwap)
        {
            StringBuilder sb = new StringBuilder(line);
            sb[indexToSwap] = line[indexToSwap] == '#' ? '.' : '#';
            return sb.ToString();
        }

        public void ComputePart1Numbers()
        {
            int vertical = GetReflecionLine(false);
            if (vertical != -1)
            {
                VerticalCount = vertical + 1;
                return;
            }

            int horizontal = GetReflecionLine(true);
            if (horizontal != -1)
            {
                HorizontalCount = horizontal + 1;
                return;
            }

            throw new Exception("No reflection line found");
        }

        private int GetReflecionLine(bool isHorizontal)
        {
            List<string> mirrorToTest;
            int oldReflectionLineForbiddenToUse;
            if (isHorizontal)
            {
                mirrorToTest = mirror;
                oldReflectionLineForbiddenToUse = HorizontalCount - 1;
            }
            else
            {
                mirrorToTest = transposedMirror;
                oldReflectionLineForbiddenToUse = VerticalCount - 1;
            }

            for (int reflectionLine = 0; reflectionLine < mirrorToTest.Count - 1; reflectionLine++)
            {
                if (oldReflectionLineForbiddenToUse == reflectionLine)
                    continue;

                if (IsReflectionLine(reflectionLine, mirrorToTest))
                    return reflectionLine;
            }
            return -1;
        }

        private bool IsReflectionLine(int reflectionLine, List<string> mirrorToTest)
        {
            int forwardIndex = reflectionLine + 1;
            int bacwardIndex = reflectionLine;
            while (bacwardIndex >= 0 && forwardIndex < mirrorToTest.Count)
            {
                if (mirrorToTest[bacwardIndex] != mirrorToTest[forwardIndex])
                    return false;
                forwardIndex++;
                bacwardIndex--;
            }
            return true;
        }
    }
}
