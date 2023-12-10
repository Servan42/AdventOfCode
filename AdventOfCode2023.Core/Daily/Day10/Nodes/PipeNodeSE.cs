using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10.Nodes
{
    public class PipeNodeSE : PipeNode
    {
        private char pipeChar => 'F';

        public PipeNodeSE(string identifier, int row, int column) : base(identifier, row, column)
        {
        }

        public override List<string> GetDestinationsNodesIdentifiers(List<string> inputLines)
        {
            var destinations = new List<string>();

            var south = base.GetSouthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(south)) destinations.Add(south);
            var east = base.GetEastDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(east)) destinations.Add(east);

            return destinations;
        }
    }
}
