using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day16
{
    public class Day16Ex : Exercise
    {
        private Stack<(int row, int col, char direction)> myOwnStack = new();
        private List<(int row, int col, char direction)> stackHistory = new();
        private Dictionary<string, bool> energizedTiles = new();
        private Dictionary<string, bool> directionVisited = new();

        public override void ComputePart1()
        {
            Output = ComputeBeamForOneStartingPoint((0, 0, 'E')).ToString();
        }

        private int ComputeBeamForOneStartingPoint((int row, int col, char direction) startingPoint)
        {
            myOwnStack.Clear();
            stackHistory.Clear();
            energizedTiles.Clear();
            directionVisited.Clear();

            for (int i = 0; i < InputLines.Count; i++)
            {
                for (int j = 0; j < InputLines[0].Length; j++)
                {
                    energizedTiles.Add($"{i},{j}", false);
                    directionVisited.Add($"{i},{j},N", false);
                    directionVisited.Add($"{i},{j},S", false);
                    directionVisited.Add($"{i},{j},E", false);
                    directionVisited.Add($"{i},{j},W", false);
                }
            }

            myOwnStack.Push(startingPoint);
            stackHistory.Add(startingPoint);
            while (myOwnStack.Count > 0)
            {
                var (row, col, direction) = myOwnStack.Pop();
                //SaveEnegizedTilesForOneBeam(row, col, direction);
                SaveEnegizedTilesForOneBeamFullyRecursive(row, col, direction);
            }

            return energizedTiles.Count(t => t.Value);
        }

        public override void ComputePart2()
        {
            int maxEnergizedTiles = 0;

            for (int row = 0; row < InputLines.Count; row++)
            {
                maxEnergizedTiles = Math.Max(maxEnergizedTiles, ComputeBeamForOneStartingPoint((row, 0, 'E')));
                maxEnergizedTiles = Math.Max(maxEnergizedTiles, ComputeBeamForOneStartingPoint((row, InputLines[row].Length - 1, 'W')));
            }

            for (int col = 0; col < InputLines[0].Length; col++)
            {
                maxEnergizedTiles = Math.Max(maxEnergizedTiles, ComputeBeamForOneStartingPoint((0, col, 'S')));
                maxEnergizedTiles = Math.Max(maxEnergizedTiles, ComputeBeamForOneStartingPoint((InputLines.Count - 1, col, 'N')));
            }

            Output = maxEnergizedTiles.ToString();
        }

        /// <summary>
        /// Uses recursivity for movement and splits
        /// </summary>
        private void SaveEnegizedTilesForOneBeamFullyRecursive(int row, int col, char direction)
        {
            if (row >= InputLines.Count || row < 0 || col >= InputLines[0].Length || col < 0)
                return;

            if (directionVisited[$"{row},{col},{direction}"])
                return;

            directionVisited[$"{row},{col},{direction}"] = true;
            energizedTiles[$"{row},{col}"] = true;

            var currentChar = InputLines[row][col];

            if (currentChar == '\\' && direction == 'N'
                || currentChar == '/' && direction == 'S'
                || currentChar == '.' && direction == 'W'
                || currentChar == '-' && (direction == 'N' || direction == 'S' || direction == 'W'))
            {
                myOwnStack.Push((row, col - 1, 'W'));
            }

            if (currentChar == '\\' && direction == 'S'
                || currentChar == '/' && direction == 'N'
                || currentChar == '.' && direction == 'E'
                || currentChar == '-' && (direction == 'N' || direction == 'S' || direction == 'E'))
            {
                myOwnStack.Push((row, col + 1, 'E'));
            }

            if (currentChar == '\\' && direction == 'E'
                || currentChar == '/' && direction == 'W'
                || currentChar == '.' && direction == 'S'
                || currentChar == '|' && (direction == 'S' || direction == 'W' || direction == 'E'))
            {
                myOwnStack.Push((row + 1, col, 'S'));
            }

            if (currentChar == '\\' && direction == 'W'
                || currentChar == '/' && direction == 'E'
                || currentChar == '.' && direction == 'N'
                || currentChar == '|' && (direction == 'N' || direction == 'W' || direction == 'E'))
            {
                myOwnStack.Push((row - 1, col, 'N'));
            }
        }

        /// <summary>
        /// Does the movement with loops and only uses recursivity for splits
        /// </summary>
        private void SaveEnegizedTilesForOneBeam(int row, int col, char direction)
        {
            var maxRow = InputLines.Count;
            var maxCol = InputLines[0].Length;

            while (!(row >= maxRow || row < 0 || col >= maxCol || col < 0))
            {
                if (directionVisited[$"{row},{col},{direction}"])
                    return;

                directionVisited[$"{row},{col},{direction}"] = true;
                energizedTiles[$"{row},{col}"] = true;

                switch (InputLines[row][col])
                {
                    case '\\':
                        direction = ChangeDirectionForAntiSlash(direction);
                        break;
                    case '/':
                        direction = ChangeDirectionForSlash(direction);
                        break;
                    case '-':
                        if (direction == 'N' || direction == 'S')
                        {
                            myOwnStack.Push((row, col - 1, 'W'));
                            direction = 'E';
                        }
                        break;
                    case '|':
                        if (direction == 'E' || direction == 'W')
                        {
                            myOwnStack.Push((row - 1, col, 'N'));
                            direction = 'S';
                        }
                        break;
                }

                switch (direction)
                {
                    case 'N': row--; break;
                    case 'S': row++; break;
                    case 'E': col++; break;
                    default: col--; break;
                }
            }
        }

        private char ChangeDirectionForSlash(char direction) => direction switch
        {
            'N' => 'E',
            'S' => 'W',
            'E' => 'N',
            _ => 'S',
        };

        private char ChangeDirectionForAntiSlash(char direction) => direction switch
        {
            'N' => 'W',
            'S' => 'E',
            'E' => 'S',
            _ => 'N',
        };
    }
}
