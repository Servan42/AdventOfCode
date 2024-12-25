using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day10
{
    public class TrailMap : NodeGraph
    {
        List<Node> trailStarters = new List<Node>();

        public static TrailMap Build(List<string> inputLines)
        {
            var trailMap = new TrailMap();

            var maxRow = inputLines.Count - 1;
            var maxCol = inputLines[0].Length - 1;

            for (int row = 0; row <= maxRow; row++)
            {
                for (int col = 0; col <= maxCol; col++)
                {
                    var node = new Node($"{row};{col};{inputLines[row][col]}");
                    trailMap.AddNode(node);

                    if (inputLines[row][col] == '0')
                        trailMap.trailStarters.Add(node);

                    foreach (var direction in new (int alongRow, int alongCol)[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
                    {
                        var nRow = row + direction.alongRow;
                        var nCol = col + direction.alongCol;
                        if (nRow < 0 || nRow > maxRow || nCol < 0 || nCol > maxCol)
                            continue;

                        if (inputLines[row][col] - '0' != inputLines[nRow][nCol] - '0' - 1)
                            continue;

                        var neighbor = new Node($"{nRow};{nCol};{inputLines[nRow][nCol]}");
                        trailMap.AddNode(neighbor);
                        trailMap.AddUnidirectionalEdge(node, neighbor, 1);
                    }
                }
            }

            return trailMap;
        }

        public void SearchTrailEndsAndCountThem(INode trailStarter, List<string> trailEnds)
        {
            var neighboors = GetNeighbors(trailStarter);
            if (!neighboors.Any() && trailStarter.GetUniqueIdentifier().Split(';')[2] == "9")
            {
                trailEnds.Add(trailStarter.GetUniqueIdentifier());
            }
            else
            {
                foreach (var neighbor in neighboors) SearchTrailEndsAndCountThem(neighbor, trailEnds);
            }

            return;
        }

        public int GetTrailScores(bool isPart1)
        {
            int trailScore = 0;
            foreach (var s in trailStarters)
            {
                var trailEnds = new List<string>();
                SearchTrailEndsAndCountThem(s, trailEnds);
                if (isPart1)
                    trailScore += Part1Count(trailEnds);
                else
                    trailScore += Part2Count(trailEnds);
            }
            return trailScore;
        }

        private static int Part1Count(List<string> trailEnds)
        {
            return trailEnds.Distinct().Count();
        }

        private static int Part2Count(List<string> trailEnds)
        {
            return trailEnds.Count;
        }
    }
}
