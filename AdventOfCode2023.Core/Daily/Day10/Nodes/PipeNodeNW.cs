using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10.Nodes
{
    public class PipeNodeNW : PipeNode
    {
        private char pipeChar => 'J';

        public PipeNodeNW(string identifier, int row, int column) : base(identifier, row, column)
        {
        }

        public override List<string> GetDestinationsNodesIdentifiers(List<string> inputLines)
        {
            var destinations = new List<string>();

            var north = base.GetNorthDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(north)) destinations.Add(north);
            var west = base.GetWestDestinationIfConnected(inputLines);
            if (!string.IsNullOrEmpty(west)) destinations.Add(west);

            return destinations;
        }
    }
}
