using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day12
{
    public class SpringGroup
    {
        public string Springs { get; set; }
        public string DamagedSpringSizes { get; set; }

        private Dictionary<string, double> recursiveCache = new Dictionary<string, double>();

        public SpringGroup(string springs, string damagedSpringSizes)
        {
            Springs = springs;
            DamagedSpringSizes = damagedSpringSizes;
        }

        public static SpringGroup Parse(string inputLine, bool shouldUnfold = false)
        {
            var springGroup = new SpringGroup(inputLine.Split(' ')[0], inputLine.Split(' ')[1]);
            if (shouldUnfold) springGroup.Unfold();
            return springGroup;
        }

        public void Unfold()
        {
            List<string> newSprings = new();
            List<string> newSizes = new();
            for (int i = 0; i < 5; i++)
            {
                newSprings.Add(Springs);
                newSizes.Add(DamagedSpringSizes);
            }
            Springs = string.Join('?', newSprings);
            DamagedSpringSizes = string.Join(',', newSizes);
        }

        public double GetNbArrangementsRecursive(string? springs = null, List<int>? sizes = null)
        {
            // On the first run, load with instance data
            if (springs == null || sizes == null)
            {
                springs = Springs;
                sizes = DamagedSpringSizes.Split(',').Select(x => int.Parse(x)).ToList();
                recursiveCache.Clear();
            }

            // Using a cache for performance
            string cacheKey = springs + string.Concat(sizes);
            if (recursiveCache.ContainsKey(cacheKey))
                return recursiveCache[cacheKey];

            // No springs left, and all sizes have been consumed
            if (springs == "" && sizes.Count == 0)
                return 1; // +1 valid configuration

            // But if there is still expected blocks of #
            if (springs == "" && sizes.Count > 0)
                return 0; // +0 it's not a valid configuration

            // If sizes are consumed but there is still at least a block left, invalid configuration
            if (sizes.Count == 0 && springs.Contains('#'))
                return 0;

            // If sizes are consumed and all the remaining springs are . or ?, we're good.
            if (sizes.Count == 0 && !springs.Contains('#'))
                return 1;

            double result = 0;

            // If the first element in springs is . or ?, we cannot tell if it's a valid solution or no so we just go forward.
            if (".?".Contains(springs[0]))
            {
                result += GetNbArrangementsRecursive(string.Concat(springs.Skip(1)), sizes);
            }

            // If the first element is a # or ? (again), then we need to check the integrity of the block
            if ("#?".Contains(springs[0]))
            {
                // There must be enough springs left, so if the first size must not ask for a bigger number of the remaining lengh of the springs
                if (sizes[0] <= springs.Length
                // We're currently on a #, so the following chars in the spring string must be # or ? for as long as sizes[0] tells it
                    && !springs.Substring(0, sizes[0]).Any(c => c == '.')
                // And the next char after the # blocks must be a . (or the end of the springs) because we cannot have two adjecent blocks of #
                    && (sizes[0] == springs.Length // # until the end of the sequence
                    || springs[sizes[0]] != '#')) // either the block must finish with . or ?
                {
                    // So we can get rid of the first sizes, and of all the springs tested here + the separator if it exists (because if it's a question mark not to consider it as a # later because two blocks of # can't follow each others)
                    // and go on
                    result += GetNbArrangementsRecursive(string.Concat(springs.Skip(sizes[0] + 1)), sizes.Skip(1).ToList());
                }
            }

            recursiveCache.Add(cacheKey, result);

            return result;
        }

        #region Old bruteforce solution for archives
        public double GetNbArrangements()
        {
            double sum = 0;
            int nbQuestionMarks = Springs.Count(x => x == '?');
            if (nbQuestionMarks > 63) throw new NotImplementedException($"{nbQuestionMarks} More than 63 bits, increase data type size");
            long maxBinary = (long)Math.Pow(2, nbQuestionMarks);
            for (long i = 0; i < maxBinary; i++)
            {
                var binaryRepresentation = Convert.ToString(i, 2).PadLeft(nbQuestionMarks, '0');
                binaryRepresentation = binaryRepresentation.Replace('1', '#').Replace('0', '.');
                int binaryIndex = 0;
                StringBuilder newSprings = new();
                foreach (var c in Springs)
                {
                    if (c != '?')
                        newSprings.Append(c);
                    else
                    {
                        newSprings.Append(binaryRepresentation[binaryIndex]);
                        binaryIndex++;
                    }
                }

                if (EvaluateSprings(newSprings.ToString()) == DamagedSpringSizes)
                    sum++;
            }

            return sum;
        }

        public string EvaluateSprings(string springs)
        {
            var lengths = springs
                .Split('.')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Length);
            return string.Join(',', lengths);
        } 
        #endregion
    }
}
