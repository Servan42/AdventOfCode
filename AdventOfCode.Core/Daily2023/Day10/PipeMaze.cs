using AdventOfCode.Core.Daily2023.Day10.Nodes;
using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day10
{
    public class PipeMaze : NodeGraph
    {
        // "line,column" -> "0,0" on top left

        private Node startNode;
        private List<string> pipeGrid;

        public static PipeMaze Parse(List<string> inputLines)
        {
            var pipeMaze = new PipeMaze();
            pipeMaze.pipeGrid = inputLines;

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

                    var sourceNode = (PipeNode)pipeMaze.GetNode($"{row},{column}");
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

            while (leftNode.GetUniqueIdentifier() != rightNode.GetUniqueIdentifier())
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

        public int GetNbTilesThatAreInsideTheLoop()
        {
            FlagNodesThatArePartOfTheLoop();

            int nbTilesInsideLoop = 0;
            for (int row = 0; row < pipeGrid.Count; row++)
            {
                bool isCurrentlyInsideLoop = false;
                char chainStarter = '.';
                for (int column = 0; column < pipeGrid[row].Length; column++)
                {
                    char currentChar = pipeGrid[row][column];
                    if (IsNodePartOfMainLoop(row, column))
                    {
                        bool isCurrentlyOnTheLastNodeOfTheChain = IsCurrentlyOnTheLastNodeOfTheChain(row, column);
                        bool isCurrentlyOnTheFirstNodeOfTheChain = IsCurrentlyOnTheFirstNodeOfTheChain(row, column);

                        if (currentChar == '|')
                            isCurrentlyInsideLoop = !isCurrentlyInsideLoop;
                        else if (isCurrentlyOnTheLastNodeOfTheChain)
                        {
                            if (chainStarter == 'L'  && currentChar == '7'
                                || chainStarter == 'F' && currentChar == 'J')
                                isCurrentlyInsideLoop = !isCurrentlyInsideLoop;
                        }
                        else if (isCurrentlyOnTheFirstNodeOfTheChain)
                        {
                            chainStarter = currentChar;
                        }
                    }
                    else
                    {
                        if (isCurrentlyInsideLoop) nbTilesInsideLoop++;
                    }
                }
            }

            return nbTilesInsideLoop;
        }

        private bool IsCurrentlyOnTheFirstNodeOfTheChain(int row, int column)
        {
            if (column <= 0)
                return true;

            var previousNode = this.GetNode($"{row},{column - 1}");
            if (previousNode == null)
                return true;

            var currentNode = this.GetNode($"{row},{column}");
            var neighbors = this.GetNeighbors(currentNode);
            return !neighbors.Any(n => n.GetUniqueIdentifier() == previousNode.GetUniqueIdentifier());
        }

        private bool IsCurrentlyOnTheLastNodeOfTheChain(int row, int column)
        {
            if (column >= pipeGrid[0].Length - 1)
                return true;

            var nextNode = this.GetNode($"{row},{column + 1}");
            if (nextNode == null)
                return true;

            var currentNode = this.GetNode($"{row},{column}");
            var neighbors = this.GetNeighbors(currentNode);
            return !neighbors.Any(n => n.GetUniqueIdentifier() == nextNode.GetUniqueIdentifier());
        }

        private bool IsNodePartOfMainLoop(int row, int column)
        {
            var node = this.GetNode($"{row},{column}");
            if (node == null) return false;
            return ((PipeNode)node).IsPartOfMainLoop;
        }

        private void FlagNodesThatArePartOfTheLoop()
        {
            ((PipeNode)startNode).IsPartOfMainLoop = true;
            INode lastNode = startNode;
            INode currentNode = this.GetNeighbors(startNode).First();

            while (currentNode.GetUniqueIdentifier() != startNode.GetUniqueIdentifier())
            {
                ((PipeNode)currentNode).IsPartOfMainLoop = true;
                INode newNode = this.GetNeighbors(currentNode).First(n => n.GetUniqueIdentifier() != lastNode.GetUniqueIdentifier());
                lastNode = currentNode;
                currentNode = newNode;
            }
        }
    }
}
