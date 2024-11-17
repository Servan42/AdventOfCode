using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day25
{
    public class WeatherMachine : NodeGraphWithPathFinding
    {
        private List<string> seenGraphSize = new();
        private List<string> inputLines;
        private Dictionary<string, int> edgesUtilisation = new();
        private string firstNodeId => inputLines[0].Split(':')[0];
        private Random rng = new Random();

        public static WeatherMachine Parse(List<string> inputLines)
        {
            WeatherMachine result = new WeatherMachine();
            result.inputLines = inputLines;

            foreach (string line in inputLines)
            {
                var componenets = line.Replace(":", "").Split(' ', StringSplitOptions.TrimEntries);
                var node = new Node(componenets[0]);
                result.AddNode(node);
                foreach (string comp in componenets.Skip(1))
                {

                    var node2 = new Node(comp);
                    result.AddNode(node2);
                    result.AddBidirectionalEdge(node, node2, 0);
                }
            }

            //result.CreateEdgesFromInputLines();
            return result;
        }

        //private void CreateEdgesFromInputLines()
        //{
        //    foreach (string line in inputLines)
        //    {
        //        var componenets = line.Replace(":", "").Split(' ', StringSplitOptions.TrimEntries);
        //        var node = GetNode(componenets[0]);
        //        foreach (string comp in componenets.Skip(1))
        //        {
        //            var node2 = GetNode(comp);
        //            AddBidirectionalEdge(node, node2, 0);
        //            //Console.WriteLine($"{GetGraphSizeInit(GetNode(firstNode)),4}: {componenets[0]} <-> {comp}");
        //        }
        //    }
        //}

        public int Part1()
        {
            var edgesToRemove = GetTheThreeEdgesToRemove();
            foreach(var edge in edgesToRemove)
            {
                Console.WriteLine(edge);
                RemoveBidirectionalEdge(edge);
            }

            return GetGraphSizeInit(edgesToRemove[0].node1Id) * GetGraphSizeInit(edgesToRemove[0].node2Id);
        }

        private List<(string node1Id, string node2Id)> GetTheThreeEdgesToRemove()
        {
            var seenCouples = new List<string>();
            foreach(var node1 in nodes)
            {
                foreach(var node2 in nodes)
                {
                    // The input dataset is too big so using the power of statics and hope for the best.
                    if (rng.Next(100) != 0)
                        continue;

                    if (node1.Key == node2.Key) continue;
                    var coupleKey = $"{node1.Key},{node2.Key}";
                    if(seenCouples.Contains(coupleKey)) continue;
                    seenCouples.Add(coupleKey);

                    var path = BreadthFirstSearch(node1.Value, node2.Value);
                    HistorizeEdges(path);
                }
            }

            return edgesUtilisation
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x => (x.Key.Substring(0,3), x.Key.Substring(3)))
                .ToList();
        }

        private void HistorizeEdges(List<INode> path)
        {
            for (int i = 1; i < path.Count; i++)
            {
                var edge = new List<string>
                {
                    path[i - 1].GetUniqueIdentifier(),
                    path[i].GetUniqueIdentifier()
                };
                var key = string.Concat(edge.OrderBy(x => x));

                if (edgesUtilisation.ContainsKey(key))
                    edgesUtilisation[key]++;
                else
                    edgesUtilisation.Add(key, 1);
            }
        }

        private int GetGraphSizeInit(string nodeId)
        {
            seenGraphSize.Clear();
            return GetGraphSize(GetNode(nodeId));
        }

        private int GetGraphSize(INode node)
        {
            seenGraphSize.Add(node.GetUniqueIdentifier());
            int size = 1;
            foreach (var neighbor in GetNeighbors(node))
            {
                if (!seenGraphSize.Contains(neighbor.GetUniqueIdentifier()))
                    size += GetGraphSize(neighbor);
            }
            return size;
        }

        private void RemoveBidirectionalEdge((string node1Id, string node2Id) couple)
        {
            weightedAdjacencyList[couple.node1Id].Remove(couple.node2Id);
            weightedAdjacencyList[couple.node2Id].Remove(couple.node1Id);
        }

        public override int GetHeuristicDistanceToGoal(INode startNode, INode destinationNode)
        {
            throw new NotImplementedException();
        }
    }
}
