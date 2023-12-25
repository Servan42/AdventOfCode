﻿using NUnit.Framework;
using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day23
{
    internal class Maze : NodeGraph
    {
        public List<string> InputLines { get; private set; }
        Dictionary<int, List<INode>> paths = new();
        new Dictionary<int, Dictionary<string, INode>> keyCameFromValuesMultiSegments = new();
        List<string> intersectionsSeen = new();

        public static Maze Parse(List<string> inputLines, bool isPart2 = false)
        {
            Maze maze = new Maze();
            maze.InputLines = inputLines;

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    if (inputLines[row][col] != '#')
                        maze.AddNode(new Node($"{row},{col}"));
                }
            }

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    var currentNode = maze.GetNode($"{row},{col}");
                    if (currentNode == null)
                        continue;

                    var currentChar = inputLines[row][col];
                    foreach (var direction in new List<(int row, int col)> { (-1, 0), (1, 0), (0, 1), (0, -1) })
                    {
                        var destinationNode = maze.GetNode($"{row + direction.row},{col + direction.col}");
                        if (destinationNode == null)
                            continue;

                        if (!isPart2)
                        {
                            if (currentChar == '>' && direction != (0, 1))
                                continue;

                            if (currentChar == 'v' && direction != (1, 0))
                                continue;
                        }

                        maze.AddUnidirectionalEdge(currentNode, destinationNode, 0);
                    }
                }
            }

            return maze;
        }

        public void BFS()
        {
            var firstNode = this.GetNode("0,1");
            var fronteir = new Queue<(INode lastNode, INode node, int pathId)>();
            fronteir.Enqueue((null, firstNode, 0));
            keyCameFromValuesMultiSegments.Add(0, new() { { firstNode.GetUniqueIdentifier(), null } });

            while (fronteir.Count > 0)
            {
                (INode lastNode, INode currentNode, int segmentId) = fronteir.Dequeue();

                if (intersectionsSeen.Contains(currentNode.GetUniqueIdentifier()))
                    continue;

                bool isAnIntersection = false;
                foreach (var neighbor in this.GetNeighbors(currentNode))
                {
                    // Prevents going back
                    if (lastNode == neighbor)
                        continue;

                    if (!isAnIntersection && !keyCameFromValuesMultiSegments[segmentId].ContainsKey(neighbor.GetUniqueIdentifier()))
                    {
                        fronteir.Enqueue((currentNode, neighbor, segmentId));
                        keyCameFromValuesMultiSegments[segmentId].Add(neighbor.GetUniqueIdentifier(), currentNode);
                    }

                    // We're at an intersection
                    if (isAnIntersection)
                    {
                        intersectionsSeen.Add(currentNode.GetUniqueIdentifier());
                        int newSegmentId = keyCameFromValuesMultiSegments.Keys.Max() + 1;
                        keyCameFromValuesMultiSegments.Add(newSegmentId, new());
                        keyCameFromValuesMultiSegments[newSegmentId].Add(neighbor.GetUniqueIdentifier(), currentNode);
                        fronteir.Enqueue((currentNode, neighbor, newSegmentId));
                    }

                    isAnIntersection = true;
                }
            }
        }

        private INode GetDestinationNode()
        {
            var row = InputLines.Count - 1;
            var col = InputLines[row].IndexOf('.');
            return this.GetNode($"{row},{col}");
        }

        public int BuildPathsAndReturnLongest()
        {
            INode destinationNode = GetDestinationNode();
            int segementIdOfDestinationNode = keyCameFromValuesMultiSegments
                        .Where(x => x.Value.ContainsKey(destinationNode.GetUniqueIdentifier()))
                        .Select(x => x.Key)
                        .First();
            Fill(destinationNode, 0, segementIdOfDestinationNode, new List<INode>());
            return paths.Select(p => p.Value.Count).Max() - 1;
        }

        private void Fill(INode currentNode, int pathId, int segmentId, List<INode> prefixPath)
        {
            paths.Add(pathId, prefixPath);
            while (currentNode != null)
            {
                if (intersectionsSeen.Contains(currentNode.GetUniqueIdentifier()))
                {
                    var segmentIds = keyCameFromValuesMultiSegments
                        .Where(x => x.Value.ContainsKey(currentNode.GetUniqueIdentifier()))
                        .Select(x => x.Key);

                    var nextNodesAndSegment = segmentIds.Select(id => new { node = keyCameFromValuesMultiSegments[id][currentNode.GetUniqueIdentifier()], segment = id });

                    foreach (var otherBranchNodes in nextNodesAndSegment.Skip(1))
                    {
                        var newPath = new List<INode>(paths[pathId]);
                        newPath.Add(currentNode);
                        Fill(otherBranchNodes.node, paths.Keys.Max() + 1, otherBranchNodes.segment, newPath);
                    }
                    segmentId = nextNodesAndSegment.First().segment;
                    //currentNode = nextNodesAndSegment.First().node;
                }

                while (currentNode != null && keyCameFromValuesMultiSegments[segmentId].ContainsKey(currentNode.GetUniqueIdentifier()))
                {
                    paths[pathId].Add(currentNode);
                    currentNode = keyCameFromValuesMultiSegments[segmentId][currentNode.GetUniqueIdentifier()];
                }
            }
        }
    }
}
