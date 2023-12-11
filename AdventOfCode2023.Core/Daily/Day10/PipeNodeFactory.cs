using AdventOfCode2023.Core.Daily.Day10.Nodes;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day10
{
    public class PipeNodeFactory
    {
        public static PipeNode BuildPipeNode(int row, int column, char pipeChar, List<string> inputLines)
        {
            string identfier = $"{row},{column}";
            switch (pipeChar)
            {
                case '|':
                    return new PipeNodeNS(identfier, row, column);
                case '-':
                    return new PipeNodeWE(identfier, row, column);
                case 'L':
                    return new PipeNodeNE(identfier, row, column);
                case 'J':
                    return new PipeNodeNW(identfier, row, column);
                case 'F':
                    return new PipeNodeSE(identfier, row, column);
                case '7':
                    return new PipeNodeSW(identfier, row, column);
                case 'S':
                    return ResolveStartNode(identfier, row, column, inputLines);
                default:
                    throw new NotImplementedException(pipeChar.ToString());
            }
        }

        private static PipeNode ResolveStartNode(string identfier, int row, int column, List<string> inputLines)
        {
            string connections = "";
            if (row > 0 && "|7F".Contains(inputLines[row - 1][column])) connections += "N";
            if (row < inputLines.Count - 1 && "|JL".Contains(inputLines[row + 1][column])) connections += "S";
            if(column > 0 && "-FL".Contains(inputLines[row][column - 1])) connections += "W";
            if(column < inputLines[0].Length - 1 && "-J7".Contains(inputLines[row][column + 1])) connections += "E";

            var type = Type.GetType("AdventOfCode2023.Core.Daily.Day10.Nodes.PipeNode" + connections);
            return (PipeNode) Activator.CreateInstance(type, identfier, row, column);
        }
    }
}
