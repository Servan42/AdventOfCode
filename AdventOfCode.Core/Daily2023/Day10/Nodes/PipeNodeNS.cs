using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day10.Nodes
{
    public class PipeNodeNS : PipeNode
    {
        private char pipeChar => '|';

        public PipeNodeNS(string identifier, int row, int column) : base(identifier, row, column)
        {
        }

        public override List<string> GetDestinationsNodesIdentifiers(List<string> inputLines)
        {
            var destinations = new List<string>();

            var north = base.GetNorthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(north)) destinations.Add(north);
            var south = base.GetSouthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(south)) destinations.Add(south);

            return destinations;
        }
    }
}
