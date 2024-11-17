using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day21
{
    public class Garden : NodeGraph
    {
        private Node startNode;

        public static Garden Parse(List<string> inputLines)
        {
            var garden = new Garden();

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    if (inputLines[row][col] == '#')
                        continue;

                    var node = new Node($"{row},{col}");
                    garden.AddNode(node);

                    if (inputLines[row][col] == 'S')
                    {
                        garden.startNode = node;
                    }
                }
            }

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    if (inputLines[row][col] == '.' || inputLines[row][col] == 'S')
                    {
                        garden.CreateLocalEdges(row, col, inputLines);
                    }
                }
            }

            return garden;
        }

        private void CreateLocalEdges(int row, int col, List<string> inputLines)
        {
            var currentNode = this.GetNode($"{row},{col}");
            var maxRow = inputLines.Count;
            var maxCol = inputLines[0].Length;
            foreach (var direction in new (int row, int col)[] { (-1, 0), (1, 0), (0, -1), (0, 1) })
            {
                var newRow = row + direction.row;
                var newCol = col + direction.col;
                if (newRow < 0 || newCol < 0 || newRow >= maxRow || newCol >= maxCol)
                    continue;

                if (inputLines[newRow][newCol] == '#')
                    continue;

                var destinationNode = this.GetNode($"{newRow},{newCol}");
                this.AddUnidirectionalEdge(currentNode, destinationNode, 1);
            }
        }

        public int Walk(int totalNbSteps, string startNodeItendifier = "")
        {
            var fronteir = new Queue<(INode, int)>();
            var seen = new List<string>();
            List<string> reached = new();

            if (string.IsNullOrEmpty(startNodeItendifier))
                fronteir.Enqueue((this.startNode, totalNbSteps));
            else
                fronteir.Enqueue((this.GetNode(startNodeItendifier), totalNbSteps));

            while (fronteir.Count > 0)
            {
                (INode currentNode, int distance) = fronteir.Dequeue();

                string key = $"{currentNode.GetUniqueIdentifier()}";
                if (seen.Contains(key))
                    continue;

                seen.Add(key);

                if (distance % 2 == 0) reached.Add(currentNode.ToString());
                if (distance == 0) continue;

                foreach (var neighbor in this.GetNeighbors(currentNode))
                {
                    fronteir.Enqueue((neighbor, distance - 1));
                }
            }

            return reached.Count;
        }
    }
}
