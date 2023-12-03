using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day3
{
    public class EngineSchematic
    {
        private char[,] grid;
        private readonly int nbColumns;
        private readonly int nbLines;

        public List<Number> Numbers { get; set; }
        public List<Gear> Gears { get; set; }

        public EngineSchematic(int nbLines, int nbColumns)
        {
            grid = new char[nbLines, nbColumns];
            Numbers = new List<Number>();
            Gears = new List<Gear>();
            this.nbLines = nbLines;
            this.nbColumns = nbColumns;
        }

        public void LoadFromInputLines(List<string> inputLines)
        {
            for(int y = 0; y < inputLines.Count; y++)
            {
                for (int x = 0; x < inputLines[y].Length; x++)
                {
                    grid[y, x] = inputLines[y][x];
                }
            }
        }

        public void LookForPartNumbersInGrid()
        {
            bool appendToLastNumber = false;
            for (int y = 0; y < nbLines; y++)
            {
                for (int x = 0; x < nbColumns; x++)
                {
                    char current = grid[y, x];
                    if (IsCharADigit(current))
                    {
                        bool hasASymbolNearby = HasASymbolNearby(y, x);
                        if(appendToLastNumber)
                        {
                            var lastNumber = Numbers.Last();
                            lastNumber.Value += current;
                            lastNumber.IsPartNumber = lastNumber.IsPartNumber || hasASymbolNearby;
                        }
                        else
                        {
                            Numbers.Add(new Number() { Value = current.ToString(), IsPartNumber = hasASymbolNearby });
                        }
                        appendToLastNumber = true;
                    }
                    else
                    {
                        appendToLastNumber = false;
                    }
                }
                appendToLastNumber = false;
            }
        }

        public string GetPartNumbersSum()
        {
            return Numbers
                .Where(n => n.IsPartNumber)
                .Select(n => int.Parse(n.Value))
                .Sum()
                .ToString();
        }

        private bool HasASymbolNearby(int y, int x)
        {
            for(int i = NoOOBLines(y - 1); i <= NoOOBLines(y + 1); i++)
            {
                for(int j = NoOOBColumns(x - 1); j <= NoOOBColumns(x + 1); j++)
                {
                    if (IsASymbol(grid[i, j])) return true;
                }
            }
            return false;
        }

        private int NoOOBLines(int y)
        {
            if (y < 0) return 0;
            if (y >= nbLines) return nbLines - 1;
            return y;
        }

        private int NoOOBColumns(int x)
        {
            if (x < 0) return 0;
            if (x >= nbColumns) return nbColumns - 1;
            return x;
        }

        private bool IsASymbol(char c)
        {
            return !IsCharADigit(c) && c != '.';
        }

        private bool IsCharADigit(char c)
        {
            return c >= '0' && c <= '9';
        }

        public void LookForGearsInGrid()
        {
            for (int y = 0; y < nbLines; y++)
            {
                for (int x = 0; x < nbColumns; x++)
                {
                    if (grid[y, x] == '*')
                    {
                        Gears.Add(new Gear
                        {
                            NumbersAround = LookForNumbersAroundGearAt(y, x)
                        });
                    }
                }
            }
        }

        public string GetGearPowersSum()
        {
            return Gears
                .Select(g => g.Power)
                .Sum()
                .ToString();
        }

        private List<int> LookForNumbersAroundGearAt(int y, int x)
        {
            var numbersAround = new List<Number>();
            for (int i = NoOOBLines(y - 1); i <= NoOOBLines(y + 1); i++)
            {
                for (int j = NoOOBColumns(x - 1); j <= NoOOBColumns(x + 1); j++)
                {
                    if (IsCharADigit(grid[i, j])) numbersAround.Add(GetFullNumberFromDigitAt(i, j));
                }
            }
            return numbersAround
                .DistinctBy(n => n.ColumnIndexConcatStartIndex)
                .Select(n => int.Parse(n.Value))
                .ToList();
        }

        private Number GetFullNumberFromDigitAt(int y, int x)
        {
            int startIndex = LookForNumberStartIndex(y, x);
            x = startIndex;
            var numberSb = new StringBuilder();
            
            while(x < nbColumns && IsCharADigit(grid[y, x]))
            {
                numberSb.Append(grid[y, x]);
                x++;
            }

            return new Number
            {
                Value = numberSb.ToString(),
                ColumnIndexConcatStartIndex = $"col:{y};startIndex:{startIndex}"
            };
        }

        private int LookForNumberStartIndex(int y, int x)
        {
            int startIndex = x;
            while(x >= 0 && IsCharADigit(grid[y, x]))
            {
                startIndex = x;
                x--;
            }
            return startIndex;
        }
    }
}
