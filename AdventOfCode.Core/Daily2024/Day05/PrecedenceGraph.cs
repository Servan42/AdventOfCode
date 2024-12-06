using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day05
{
    public class PrecedenceGraph : NodeGraph
    {
        private const int PARENT_TO_CHILD = 0;
        private const int CHILD_TO_PARENT = 1;

        private Dictionary<int, List<int>> cachedParents = new();
        private Dictionary<int, List<int>> cachedChildren = new();

        public static PrecedenceGraph Build(List<string> input)
        {
            var graph = new PrecedenceGraph();

            foreach(var line in input)
            {
                var sourceNode = new Node(line.Split('|')[0]);
                var destinationNode = new Node(line.Split('|')[1]);
                graph.AddNode(sourceNode);
                graph.AddNode(destinationNode);
                graph.AddUnidirectionalEdge(sourceNode, destinationNode, PARENT_TO_CHILD);
                graph.AddUnidirectionalEdge(destinationNode, sourceNode, CHILD_TO_PARENT);
            }

            return graph;
        }

        public List<int> GetDistinctChildren(int primaryNodeId)
        {
            if(cachedChildren.ContainsKey(primaryNodeId))
                return cachedChildren[primaryNodeId];

            var result = GetDistinctLeaf(primaryNodeId.ToString(), PARENT_TO_CHILD).Select(int.Parse).ToList();
            cachedChildren[primaryNodeId] = result;

            return result;
        }

        public List<int> GetDistinctParent(int primaryNodeId)
        {
            if (cachedParents.ContainsKey(primaryNodeId))
                return cachedParents[primaryNodeId];

            var result = GetDistinctLeaf(primaryNodeId.ToString(), CHILD_TO_PARENT).Select(int.Parse).ToList();
            cachedParents[primaryNodeId] = result;
            
            return result;
        }

        public IEnumerable<string> GetDistinctLeaf(string primaryNodeId, int direction)
        {
            var children = new List<string>();
            var queue = new Queue<KeyValuePair<string, int>>(this.weightedAdjacencyList[primaryNodeId]);
            
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (node.Value != direction)
                    continue;

                children.Add(node.Key);
                foreach (var childrenChildren in this.weightedAdjacencyList[node.Key])
                {
                    queue.Append(childrenChildren);
                }
            }

            return children.Distinct();
        }
    }
}
