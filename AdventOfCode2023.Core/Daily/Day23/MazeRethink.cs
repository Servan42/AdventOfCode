using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day23
{
    public class MazeRethink : NodeGraph
    {
        public List<string> InputLines { get; private set; }
        private List<string> seen = new();
        private INode startNode;
        private INode destinationNode;

        public static MazeRethink Parse_with_edge_contraction(List<string> inputLines, bool isPart2 = false)
        {
            MazeRethink maze = new MazeRethink();
            maze.InputLines = inputLines;
            List<(int row, int col)> intersections = new();

            maze.startNode = new Node("0,1");
            maze.AddNode(maze.startNode);
            intersections.Add((0, 1));
            maze.destinationNode = new Node($"{maze.GetDestinationCoods().row},{maze.GetDestinationCoods().col}");
            maze.AddNode(maze.destinationNode);
            intersections.Add(maze.GetDestinationCoods());

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    if (inputLines[row][col] == '#')
                        continue;

                    int neigbors = 0;
                    foreach ((int dr, int dc) in new List<(int, int)> { (row - 1, col), (row + 1, col), (row, col + 1), (row, col - 1) })
                    {
                        if (dr >= 0 && dr < inputLines.Count && dc >= 0 && dc < inputLines[0].Length && inputLines[dr][dc] != '#')
                            neigbors++;
                    }

                    if (neigbors >= 3)
                    {
                        maze.AddNode(new Node($"{row},{col}"));
                        intersections.Add((row, col));
                    }
                }
            }

            foreach (var intersection in intersections)
            {
                List<(int row, int col)> seen = new();
                seen.Add((intersection.row, intersection.col));
                var fronteir = new Queue<(int row, int column, int distance)>();
                fronteir.Enqueue((intersection.row, intersection.col, 0));

                while (fronteir.Count > 0)
                {
                    (int currentRow, int currentCol, int distance) = fronteir.Dequeue();

                    if (distance != 0 && intersections.Contains((currentRow, currentCol)))
                    {
                        var startNode = maze.GetNode($"{intersection.row},{intersection.col}");
                        var endNode = maze.GetNode($"{currentRow},{currentCol}");
                        maze.AddUnidirectionalEdge(startNode, endNode, distance);
                        continue;
                    }

                    foreach ((int dr, int dc) in maze.GetDirectionForChar(inputLines[currentRow][currentCol], currentRow, currentCol, isPart2))
                    {
                        if (dr >= 0 && dr < inputLines.Count && dc >= 0 && dc < inputLines[0].Length
                            && inputLines[dr][dc] != '#'
                            && !seen.Contains((dr, dc)))
                        {
                            fronteir.Enqueue((dr, dc, distance + 1));
                            seen.Add((dr, dc));
                        }
                    }
                }
            }
            return maze;
        }

        public int BuildPathsAndReturnLongest()
        {
            foreach(var adj in this.weightedAdjacencyList)
            {
                Console.Write($"({adj.Key}): ");
                Console.Write("{");
                Console.Write(string.Join(", ", adj.Value.Select(dest => $"({dest.Key}): {dest.Value}")));
                Console.Write("}\n");
            }

            seen.Clear();
            return DFS(startNode);
        }

        private int DFS(INode node)
        {
            if (node == destinationNode)
                return 0;

            int max = int.MinValue;

            seen.Add(node.GetUniqueIdentifier());
            foreach(var neighbor in GetNeighbors(node))
            {
                if (seen.Contains(neighbor.GetUniqueIdentifier()))
                    continue;

                max = Math.Max(max, DFS(neighbor) + this.GetEdgeWeight(node, neighbor));
            }
            seen.Remove(node.GetUniqueIdentifier());
            return max;
        }

        private (int row, int col) GetDestinationCoods()
        {
            var row = InputLines.Count - 1;
            var col = InputLines[row].IndexOf('.');
            return (row, col);
        }

        private List<(int, int)> GetDirectionForChar(char c, int currentRow, int currentCol, bool isPart2 = false)
        {
            if (!isPart2)
            {
                switch (c)
                {
                    case 'v':
                        return new List<(int, int)> { (currentRow + 1, currentCol) };
                    case '>':
                        return new List<(int, int)> { (currentRow, currentCol + 1) };
                }
            }

            return new List<(int, int)> { (currentRow - 1, currentCol), (currentRow + 1, currentCol), (currentRow, currentCol + 1), (currentRow, currentCol - 1) };
        }
    }
}
