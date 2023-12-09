using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day6
{
    public class RaceData
    {
        public List<Race> Races { get; set; } = new();

        public static RaceData Parse(List<string> inputLines)
        {
            RaceData output = new();

            var times = inputLines[0].Split(':')[1].GetSpacesSeparatedInts();
            var distances = inputLines[1].Split(':')[1].GetSpacesSeparatedInts();

            for(int i = 0; i < times.Count; i++)
            {
                output.Races.Add(new Race(times[i], distances[i]));
            }

            return output;
        }

        public static RaceData ParsePart2(List<string> inputLines)
        {
            RaceData output = new();

            var times = inputLines[0].Split(':')[1].GetSpacesSeparatedDoubles();
            var distances = inputLines[1].Split(':')[1].GetSpacesSeparatedDoubles();

            var bigTime = double.Parse(string.Join("", times.Select(t => t.ToString())));
            var bigDistance = double.Parse(string.Join("", distances.Select(t => t.ToString())));

            output.Races.Add(new Race(bigTime, bigDistance));

            return output;
        }

        public string ComputeNumbersOfWayToBeatTheRecordMultiplied()
        {
            return Races
                .Select(race => race.ComputeNumberOfWaysToBeatTheRecord())
                .Mult()
                .ToString();
        }
    }
}
