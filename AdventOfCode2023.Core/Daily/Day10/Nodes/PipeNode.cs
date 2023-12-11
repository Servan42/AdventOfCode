using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10.Nodes
{
    public abstract class PipeNode : Node
    {
        private readonly int row;
        private readonly int column;
        public bool IsPartOfMainLoop { get; set; }

        public PipeNode(string identifier, int row, int column) : base(identifier)
        {
            this.row = row;
            this.column = column;
        }

        public abstract List<string> GetDestinationsNodesIdentifiers(List<string> inputLines);

        protected string GetNorthDestinationIfConnected(List<string> inputLines)
        {
            if (row > 0)
            {
                char adjacentCase = inputLines[row - 1][column];
                if ("|F7S".Contains(adjacentCase))
                    return $"{row - 1},{column}";
            }
            return "";
        }

        protected string GetSouthDestinationIfConnected(List<string> inputLines)
        {
            if (row < inputLines.Count - 1)
            {
                char adjacentCase = inputLines[row + 1][column];
                if ("|LJS".Contains(adjacentCase))
                    return $"{row + 1},{column}";
            }
            return "";
        }

        protected string GetEastDestinationIfConnected(List<string> inputLines)
        {
            if (column < inputLines[0].Length - 1)
            {
                char adjacentCase = inputLines[row][column + 1];
                if ("-J7S".Contains(adjacentCase))
                    return $"{row},{column + 1}";
            }
            return "";
        }

        protected string GetWestDestinationIfConnected(List<string> inputLines)
        {
            if (column > 0)
            {
                char adjacentCase = inputLines[row][column - 1];
                if ("-FLS".Contains(adjacentCase))
                    return $"{row},{column - 1}";
            }
            return "";
        }
    }
}
