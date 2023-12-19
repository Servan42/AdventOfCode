using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day18
{
    internal class DigPlanLine
    {
        public DigPlanLine(string direction, int nbOfMetersToDig, string hexColor)
        {
            Direction = direction;
            NbOfMetersToDig = nbOfMetersToDig;
            HexColor = hexColor;

            switch (Direction)
            {
                case "U":
                    DirectionCood = (-1, 0);
                    break;
                case "D":
                    DirectionCood = (1, 0);
                    break;
                case "L":
                    DirectionCood = (0, -1);
                    break;
                default:
                    DirectionCood = (0, 1);
                    break;
            }
        }

        public static DigPlanLine Parse(string line, bool IsPart2 = false)
        {
            var splitedData = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var hex = splitedData[2].Substring(1, 7);
            string direction = splitedData[0];
            int nbdig = int.Parse(splitedData[1]);
            if (IsPart2)
            {
                nbdig = Int32.Parse(hex.Substring(1, 5), System.Globalization.NumberStyles.HexNumber);
                switch (hex[^1])
                {
                    case '0':
                        direction = "R";
                        break;
                    case '1':
                        direction = "D";
                        break;
                    case '2':
                        direction = "L";
                        break;
                    default:
                        direction = "U";
                        break;
                }

            }

            return new DigPlanLine(direction, nbdig, hex);
        }

        public string Direction { get; set; }
        public (int alongRow, int alongCol) DirectionCood { get; set; }
        public int NbOfMetersToDig { get; set; }
        public string HexColor { get; set; }
    }
}
