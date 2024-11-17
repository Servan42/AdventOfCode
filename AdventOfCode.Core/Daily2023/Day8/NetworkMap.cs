using AdventOfCode.Core.Daily2023.Day3;
using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day8
{
    public class NetworkMap : NodeGraph
    {
        public string PathInstructions { get; set; }

        public NetworkMap(string pathInstructions)
        {
            PathInstructions = pathInstructions;
        }

        public static NetworkMap Parse(List<string> input)
        {
            NetworkMap networkMap = new(input[0]);

            foreach (var line in input)
            {
                if (!line.Contains('='))
                    continue;

                var nodesToAdd = Regex.Matches(line, "[A-Z]{3}").Select(x => new Node(x.Value)).ToList();
                networkMap.AddNode(nodesToAdd[0]);
                networkMap.AddNode(nodesToAdd[1]);
                networkMap.AddNode(nodesToAdd[2]);
                networkMap.AddUnidirectionalEdge(nodesToAdd[0], nodesToAdd[1], 1);
                networkMap.AddUnidirectionalEdge(nodesToAdd[0], nodesToAdd[2], 1);
            }

            return networkMap;
        }

        public int FollowPathFromAAAToZZZ()
        {
            return FollowPathFromNodeTo(this.GetNode("AAA"), "ZZZ");
        }

        public double ComputeNumberOfStepsToSyncForPart2()
        {
            return this.nodes
                .Where(n => n.Key.EndsWith('A'))
                .Select(n => FollowPathFromNodeTo(n.Value, "Z"))
                .LeastCommonMultiple();
        }

        private int FollowPathFromNodeTo(INode currentNode, string destinationIdentifierEndWith)
        {
            int numberOfSteps = 0;

            while (!currentNode.GetUniqueIdentifier().EndsWith(destinationIdentifierEndWith))
            {
                int currentInstruction = PathInstructions[numberOfSteps % PathInstructions.Length] == 'L' ? 0 : 1;
                var neighbors = this.GetNeighbors(currentNode);
                currentNode = neighbors.ElementAt(neighbors.Count() == 1 ? 0 : currentInstruction);
                numberOfSteps++;
            }

            return numberOfSteps;
        }
    }
}
