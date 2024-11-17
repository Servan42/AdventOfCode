using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day9
{
    public class HistoryLine
    {
        public List<LinkedList<double>> HistoryExtrapolations { get; set; } = new();

        public static HistoryLine Parse(string line)
        {
            var historyLine = new HistoryLine();
            var linkedList = new LinkedList<double>();
            line.GetSpacesSeparatedDoubles().ForEach(d => linkedList.AddLast(d));
            historyLine.HistoryExtrapolations.Add(linkedList);
            return historyLine;
        }

        public double GetLastFinalExtrapolationValue(bool extrapolateBackwards = false)
        {
            LinkedList<double> newLine = HistoryExtrapolations[0];
            int i = 0;
            while (!newLine.All(n => n == 0))
            {
                newLine = GenerateNextLine(HistoryExtrapolations[i].ToList());
                HistoryExtrapolations.Add(newLine);
                i++;
            }
            return extrapolateBackwards ? ExtrapolateHistoryBackwards() : ExtrapolateHistory();
        }

        private double ExtrapolateHistoryBackwards()
        {
            HistoryExtrapolations.Last().AddFirst(0);
            for (int i = HistoryExtrapolations.Count - 2; i >= 0; i--)
            {
                HistoryExtrapolations[i].AddFirst(HistoryExtrapolations[i].First() - HistoryExtrapolations[i + 1].First());
            }
            return HistoryExtrapolations[0].First();
        }

        private double ExtrapolateHistory()
        {
            HistoryExtrapolations.Last().AddLast(0);
            for(int i = HistoryExtrapolations.Count - 2; i >= 0; i--)
            {
                HistoryExtrapolations[i].AddLast(HistoryExtrapolations[i].Last() + HistoryExtrapolations[i + 1].Last());
            }
            return HistoryExtrapolations[0].Last();
        }

        private LinkedList<double> GenerateNextLine(List<double> line)
        {
            var newLine = new LinkedList<double>();
            for(int i = 1; i < line.Count; i++)
            {
                newLine.AddLast(line[i] - line[i - 1]);
            }
            return newLine;
        }
    }
}
