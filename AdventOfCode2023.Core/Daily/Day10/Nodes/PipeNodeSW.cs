using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10.Nodes
{
    public class PipeNodeSW : PipeNode
    {
        private char pipeChar => '7';

        public PipeNodeSW(string identifier, int row, int column) : base(identifier, row, column)
        {
        }

        public override List<string> GetDestinationsNodesIdentifiers(List<string> inputLines)
        {
            var destinations = new List<string>();

            var south = base.GetSouthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(south)) destinations.Add(south);
            var west = base.GetWestDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(west)) destinations.Add(west);

            return destinations;
        }
    }
}
