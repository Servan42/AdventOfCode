using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10.Nodes
{
    public class PipeNodeNE : PipeNode
    {

        private char pipeChar => 'L';

        public PipeNodeNE(string identifier, int row, int column) : base(identifier, row, column)
        {
        }

        public override List<string> GetDestinationsNodesIdentifiers(List<string> inputLines)
        {
            var destinations = new List<string>();

            var north = base.GetNorthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(north)) destinations.Add(north);
            var east = base.GetEastDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(east)) destinations.Add(east);

            return destinations;
        }
    }
}
