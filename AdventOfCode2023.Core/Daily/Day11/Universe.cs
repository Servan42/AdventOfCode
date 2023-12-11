using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day11
{
    public class Universe : NodeGraphWithPathFinding
    {
        public List<string> Grid { get; set; }
        public List<(INode, INode)> GalaxyPairs { get; set; } = new List<(INode, INode)>();
        public List<INode> Galaxies { get; set; } = new List<INode>();

        public Universe(List<string> grid)
        {
            Grid = grid;
        }

        public static Universe Parse(List<string> input)
        {
            var universe = new Universe(input);
            universe.Expand();
            universe.FillNodeGraph();
            return universe;
        }

        public double GetSumOfShortestPathForAllPairsOfGalaxies()
        {
            double sum = 0;
            foreach (var galaxyA in Galaxies)
            {
                foreach (var galaxyB in Galaxies)
                {
                    if (!GalaxyPairs.Contains((galaxyB, galaxyA)) && galaxyB != galaxyA)
                    {
                        GalaxyPairs.Add((galaxyA, galaxyB));
                        sum += this.HeuristicSearch(galaxyA, galaxyB).Count - 1;
                    }
                }
            }

            return sum;
        }

        private void FillNodeGraph()
        {
            for (int row = 0; row < Grid.Count; row++)
            {
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    var node = new Node($"{row},{column}");
                    if (Grid[row][column] == '#') Galaxies.Add(node);
                    this.AddNode(node);
                }
            }

            for (int row = 0; row < Grid.Count; row++)
            {
                for (int column = 0; column < Grid[row].Length; column++)
                {
                    AddEdgeInCross(row, column);
                }
            }
        }

        private void AddEdgeInCross(int row, int column)
        {
            var centerNode = this.GetNode($"{row},{column}");
            var north = this.GetNode($"{row - 1},{column}");
            var south = this.GetNode($"{row + 1},{column}");
            var west = this.GetNode($"{row},{column - 1}");
            var east = this.GetNode($"{row},{column + 1}");

            if (north != null) this.AddBidirectionalEdge(centerNode, north, 1);
            if (south != null) this.AddBidirectionalEdge(centerNode, south, 1);
            if (west != null) this.AddBidirectionalEdge(centerNode, west, 1);
            if (east != null) this.AddBidirectionalEdge(centerNode, east, 1);
        }

        private void Expand()
        {
            var expandedInRows = new List<string>();
            foreach (var row in Grid)
            {
                expandedInRows.Add(row);
                if (!row.Contains('#')) expandedInRows.Add(row);
            }
            Grid = expandedInRows;
            var expandedInColumns = new List<string>();
            foreach (var row in Grid)
            {
                var newRow = new StringBuilder();
                for (int column = 0; column < row.Length; column++)
                {
                    newRow.Append(row[column]);
                    if (ColumnMustBeExpanded(column)) newRow.Append(row[column]);
                }
                expandedInColumns.Add(newRow.ToString());
            }
            Grid = expandedInColumns;
        }

        private bool ColumnMustBeExpanded(int column)
        {
            return Grid.Count(row => row[column] == '#') == 0;
        }

        public override int GetHeuristicDistanceToGoal(INode startNode, INode destinationNode)
        {
            int startNodeX = int.Parse(startNode.GetUniqueIdentifier().Split(',')[0]);
            int startNodeY = int.Parse(startNode.GetUniqueIdentifier().Split(',')[1]);
            int destinationNodeX = int.Parse(destinationNode.GetUniqueIdentifier().Split(',')[0]);
            int destinationNodeY = int.Parse(destinationNode.GetUniqueIdentifier().Split(',')[1]);
            return Math.Abs(startNodeX - destinationNodeX) + Math.Abs(startNodeY - destinationNodeY);
        }
    }
}
