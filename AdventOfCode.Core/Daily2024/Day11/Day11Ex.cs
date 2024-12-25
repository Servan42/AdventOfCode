using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace AdventOfCode.Core.Daily2024.Day11
{
    public class Day11Ex : Exercise
    {
        LinkedList<double> stones;

        public override void ComputePart1()
        {
            stones = new(this.InputLines[0].GetSpacesSeparatedDoubles());
            for (int i = 0; i < 25; i++)
            {
                Blink();
            }
            this.Output = stones.Count.ToString();
        }

        private void Blink()
        {
            var stone = stones.First;
            while (stone != null)
            {
                if (stone.Value == 0)
                {
                    stone.Value = 1;
                }
                else if (stone.Value.ToString().Length % 2 == 0)
                {
                    int newStonesLength = stone.Value.ToString().Length / 2;
                    var leftStone = stone.Value.ToString().Substring(0, newStonesLength);
                    var rightStone = stone.Value.ToString().Substring(newStonesLength, newStonesLength);

                    stone.Value = double.Parse(leftStone);

                    stones.AddAfter(stone, double.Parse(rightStone));
                    stone = stone.Next; // Skip right stone
                }
                else
                {
                    stone.Value *= 2024;
                }
                stone = stone.Next;
            }
        }

        public override void ComputePart2()
        {
            var stoneDict = new Dictionary<double, double>();
            foreach (var stone in this.InputLines[0].GetSpacesSeparatedDoubles())
            {
                stoneDict.Add(stone, 1);
            }

            for (int i = 0; i < 75; i++)
            {
                var newStoneDict = new Dictionary<double, double>();
                foreach (var kvp in stoneDict)
                {
                    if (kvp.Key == 0)
                    {
                        AddOrInsert(newStoneDict, 1, kvp.Value);
                    }
                    else if (kvp.Key.ToString().Length % 2 == 0)
                    {
                        int newStonesLength = kvp.Key.ToString().Length / 2;
                        var leftStone = double.Parse(kvp.Key.ToString().Substring(0, newStonesLength));
                        var rightStone = double.Parse(kvp.Key.ToString().Substring(newStonesLength, newStonesLength));

                        AddOrInsert(newStoneDict, leftStone, kvp.Value);
                        AddOrInsert(newStoneDict, rightStone, kvp.Value);
                    }
                    else
                    {
                        AddOrInsert(newStoneDict, kvp.Key * 2024, kvp.Value);
                    }
                }
                stoneDict = newStoneDict;
            }
            this.Output = (stoneDict.Sum(kvp => kvp.Value)).ToString();
        }

        private void AddOrInsert(Dictionary<double, double> dict, double key, double value)
        {
            if (!dict.ContainsKey(key))
                dict[key] = 0;

            dict[key] += value;
        }
    }
}
