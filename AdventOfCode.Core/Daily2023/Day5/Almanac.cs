using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day5
{
    public class Almanac
    {
        public List<double> Seeds { get; set; } = new();
        public List<MapRange>[] Maps { get; set; } = new List<MapRange>[] { new(), new(), new(), new(), new(), new(), new() };

        public static Almanac Parse(List<string> inputLines)
        {
            var alamanc = new Almanac();

            alamanc.Seeds = inputLines[0].Split(':')[1].GetSpacesSeparatedDoubles();

            int currentMapToFill = -1;
            foreach (var line in inputLines)
            {
                if (string.IsNullOrEmpty(line) || line.Contains("seeds"))
                    continue;

                if (line.Contains("map"))
                {
                    currentMapToFill++;
                    continue;
                }

                var ranges = line.GetSpacesSeparatedDoubles();
                alamanc.Maps[currentMapToFill].Add(new MapRange(ranges[0], ranges[1], ranges[2]));
            }

            return alamanc;
        }

        public double GetSmallestMappingForSeeds()
        {
            double smallest = double.MaxValue;

            foreach (var seed in Seeds)
            {
                smallest = ComputeSeedThroughMappingsAndUpdateSmallest(smallest, seed);
            }

            return smallest;
        }

        public double GetSeedCount()
        {
            double count = 0; 
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                count += Seeds[i + 1];
            }
            return count;
        }

        public double GetSmallestMappingForSeedsRangeMultiThread()
        {
            if (Seeds.Count % 2 != 0)
                throw new Exception("Seeds count must be an even number for Part2 to work");

            List<Task<double>> tasks = new List<Task<double>>();
            
            for (int i = 0; i < Seeds.Count; i += 2)
            {
                double originalSeed = Seeds[i];
                double rangeLengh = Seeds[i + 1];

                tasks.Add(new Task<double>(() =>
                {
                    Console.WriteLine($"Task Id:{Thread.CurrentThread.ManagedThreadId} running. {rangeLengh} seeds to process");
                    double smallest = double.MaxValue;
                    for (double currentSeed = originalSeed; currentSeed < originalSeed + rangeLengh; currentSeed++)
                    {
                        smallest = ComputeSeedThroughMappingsAndUpdateSmallest(smallest, currentSeed);
                    }
                    Console.WriteLine($"Task Id:{Thread.CurrentThread.ManagedThreadId} SUCCESS smallest:{smallest}");
                    return smallest;
                }));
            }

            Console.WriteLine($"Starting {tasks.Count} Tasks");
            tasks.ForEach(t => t.Start());
            tasks.ForEach(t => t.Wait());
            return tasks.Min(t => t.Result);
        }

        public double GetSmallestMappingForSeedsRange()
        {
            var seedCount = GetSeedCount();
            double sumAlreadyDone = 0;

            if (Seeds.Count % 2 != 0)
                throw new Exception("Seeds count must be an even number for Part2 to work");

            double smallest = double.MaxValue;

            for (int i = 0; i < Seeds.Count; i += 2)
            {
                double originalSeed = Seeds[i];
                double rangeLengh = Seeds[i + 1];
                for (double currentSeed = originalSeed; currentSeed < originalSeed + rangeLengh; currentSeed++)
                {
                    smallest = ComputeSeedThroughMappingsAndUpdateSmallest(smallest, currentSeed);
                }
                sumAlreadyDone += rangeLengh;
                Console.WriteLine($"{((sumAlreadyDone / seedCount) * 100.0).ToString("0.##")}%");
            }

            return smallest;
        }

        private double ComputeSeedThroughMappingsAndUpdateSmallest(double smallest, double seed)
        {
            double currentNumberToMap = seed;
            foreach (var map in Maps)
            {
                foreach (var mapRange in map)
                {
                    var oldNumber = currentNumberToMap;
                    currentNumberToMap = mapRange.Map(currentNumberToMap);
                    if (oldNumber != currentNumberToMap)
                        break;
                }
            }
            smallest = currentNumberToMap < smallest ? currentNumberToMap : smallest;
            return smallest;
        }
    }
}
