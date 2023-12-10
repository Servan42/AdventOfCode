using AdventOfCode2023.Core.Daily.Day10.Nodes;
using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10
{
    public class PipeMaze : NodeGraph
    {
        // "line,column" -> "0,0" on top left

        private Node startNode;

        public static PipeMaze Parse(List<string> inputLines)
        {
            var pipeMaze = new PipeMaze();

            // Add nodes
            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int column = 0; column < inputLines[row].Length; column++)
                {
                    char currentCase = inputLines[row][column];
                    if (currentCase == '.')
                        continue;

                    var node = PipeNodeFactory.BuildPipeNode(row, column, currentCase, inputLines);
                    pipeMaze.AddNode(node);

                    if (currentCase == 'S')
                        pipeMaze.startNode = node;
                }
            }

            // Add edges
            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int column = 0; column < inputLines[row].Length; column++)
                {
                    char currentCase = inputLines[row][column];
                    if (currentCase == '.')
                        continue;

                    var sourceNode = (PipeNode) pipeMaze.GetNode($"{row},{column}");
                    var destinationNodes = sourceNode.GetDestinationsNodesIdentifiers(inputLines);
                    destinationNodes.ForEach(id =>
                    {
                        pipeMaze.AddBidirectionalEdge(sourceNode, pipeMaze.GetNode(id), 0);
                    });
                }
            }

            return pipeMaze;
        }

        public int GetNbStepsToNavigateToFarthestPoint()
        {
            int nbSteps = 0;
            INode leftNode = this.GetNeighbors(startNode).First();
            INode rightNode = this.GetNeighbors(startNode).Last();
            INode lastLeftNode = startNode;
            INode lastRightNode = startNode;

            while(leftNode.GetUniqueIdentifier() != rightNode.GetUniqueIdentifier())
            {
                INode newLeftNode = this.GetNeighbors(leftNode).First(n => n.GetUniqueIdentifier() != lastLeftNode.GetUniqueIdentifier());
                lastLeftNode = leftNode;
                leftNode = newLeftNode;

                INode newRightNode = this.GetNeighbors(rightNode).First(n => n.GetUniqueIdentifier() != lastRightNode.GetUniqueIdentifier());
                lastRightNode = rightNode;
                rightNode = newRightNode;

                nbSteps++;
            }

            return nbSteps + 1;
        }
    }
}
