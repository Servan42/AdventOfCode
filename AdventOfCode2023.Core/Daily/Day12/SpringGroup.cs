using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day12
{
    public class SpringGroup
    {
        public string Springs { get; set; }
        public string DamagedSpringSizes { get; set; }
        
        public static SpringGroup Parse(string inputLine, bool shouldUnfold = false)
        {
            var springGroup = new SpringGroup(inputLine.Split(' ')[0], inputLine.Split(' ')[1]);
            if(shouldUnfold) springGroup.Unfold();
            return springGroup;
        }

        public string EvaluateSprings(string springs)
        {
            var lengths = springs
                .Split('.')
                .Where(x => !string.IsNullOrEmpty(x))
                .Select(x => x.Length);
            return string.Join(',', lengths);
        }

        //public List<string> GetAllPossibilitiesWhenReplacingQuestionMarks()
        //{
        //    var possibilities = new List<string>();
        //    int nbQuestionMarks = Springs.Count(x => x == '?');
        //    int maxBinary = (int)Math.Pow(2, nbQuestionMarks);
        //    for(int i = 0; i < maxBinary; i++)
        //    {
        //        var binaryRepresentation = Convert.ToString(i, 2).PadLeft(nbQuestionMarks, '0');
        //        binaryRepresentation = binaryRepresentation.Replace('1', '#').Replace('0', '.');
        //        int binaryIndex = 0;
        //        StringBuilder newSprings = new();
        //        foreach(var c in Springs)
        //        {
        //            if (c != '?')
        //                newSprings.Append(c);
        //            else
        //            {
        //                newSprings.Append(binaryRepresentation[binaryIndex]);
        //                binaryIndex++;
        //            }
        //        }
        //        possibilities.Add(newSprings.ToString());
        //    }

        //    return possibilities;
        //}

        //public int GetNbArrangements()
        //{
        //    return GetAllPossibilitiesWhenReplacingQuestionMarks()
        //        .Count(p => EvaluateSprings(p) == DamagedSpringSizes);
        //}

        public double GetNbArrangements()
        {
            double sum = 0;
            int nbQuestionMarks = Springs.Count(x => x == '?');
            if (nbQuestionMarks > 63) throw new NotImplementedException($"{nbQuestionMarks} More than 63 bits, increase data type size");
            long maxBinary = (long) Math.Pow(2, nbQuestionMarks);
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

        public void Unfold()
        {
            List<string> newSprings = new();
            List<string> newSizes = new();
            for(int i = 0; i < 5; i++)
            {
                newSprings.Add(Springs);
                newSizes.Add(DamagedSpringSizes);
            }
            Springs = string.Join('?', newSprings);
            DamagedSpringSizes = string.Join(',', newSizes);
        }

        public SpringGroup(string springs, string damagedSpringSizes)
        {
            Springs = springs;
            DamagedSpringSizes = damagedSpringSizes;
        }
    }
}
