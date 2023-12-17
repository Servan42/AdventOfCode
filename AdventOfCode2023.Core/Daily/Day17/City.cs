using AdventOfCode2023.Core.Daily.Day11;
using PathFinder.API.Interfaces;
using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day17
{
    public class City : NodeGraphWithPathFinding
    {
        public static City Parse(List<string> inputLines)
        {
            var city = new City();

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    var weight = int.Parse(inputLines[row][col].ToString());
                    city.AddNode(new CityBlock(row, col, weight));
                }
            }

            for (int row = 0; row < inputLines.Count; row++)
            {
                for (int col = 0; col < inputLines[0].Length; col++)
                {
                    //var weight = int.Parse(inputLines[row][col].ToString());
                    var currentNode = city.GetNode($"{row},{col}");
                    var upNode = city.GetNode($"{row - 1},{col}");
                    var downNode = city.GetNode($"{row + 1},{col}");
                    var leftNode = city.GetNode($"{row},{col - 1}");
                    var rightNode = city.GetNode($"{row},{col + 1}");
                    if (upNode != null) city.AddUnidirectionalEdge(currentNode, upNode, int.Parse(inputLines[row - 1][col].ToString()));
                    if (downNode != null) city.AddUnidirectionalEdge(currentNode, downNode, int.Parse(inputLines[row + 1][col].ToString()));
                    if (leftNode != null) city.AddUnidirectionalEdge(currentNode, leftNode, int.Parse(inputLines[row][col - 1].ToString()));
                    if (rightNode != null) city.AddUnidirectionalEdge(currentNode, rightNode, int.Parse(inputLines[row][col + 1].ToString()));
                }
            }

            return city;
        }

        public override int GetHeuristicDistanceToGoal(INode startNode, INode destinationNode)
        {
            CityBlock startNodeCityBlock = (CityBlock)startNode;
            CityBlock destinationNodeCityBlock = (CityBlock)destinationNode;
            return Math.Abs(startNodeCityBlock.Row - destinationNodeCityBlock.Row) + Math.Abs(startNodeCityBlock.Col - destinationNodeCityBlock.Col);
        }

        internal List<INode> FindOptimalPathWithMovementConstraint(INode firstNode, INode goalNode)
        {
            List<INode> path = new();
            bool isPathCorrect = false;
            int retry = 0;
            while (!isPathCorrect)
            {
                path = this.DijkstrasAlgorithmCustom(firstNode, goalNode);
                isPathCorrect = VerifyPathAndChangeWeightsIfIncorrect(path);
                Console.WriteLine("retry " + retry);
                retry++;
            }

            foreach (var kvp in weightedAdjacencyList)
            {
                Console.Write(kvp.Key + " -> ");
                Console.WriteLine(string.Join(" ", kvp.Value.ToList().Select(n => $"{n.Key}-{n.Value}")));
            }

            return path;
        }

        public static int ComputeOptimalHeat(int startRow, int startCol, int endRow, int EndCol, List<string> inputLines)
        {
            var seen = new List<(int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection)>();

            var priorityQueue = new PriorityQueue<(int totalHeat, int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection), int>();

            priorityQueue.Enqueue((0, startRow, startCol, 0, 0, 0), 0);

            while (priorityQueue.Count > 0)
            {
                (int totalHeat, int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection) = priorityQueue.Dequeue();

                if (currentRow == endRow && currentCol == EndCol)
                    return totalHeat;

                if (seen.Contains((currentRow, currentCol, movementRow, movementCol, nbStepsInSameDirection)))
                    continue;

                seen.Add((currentRow, currentCol, movementRow, movementCol, nbStepsInSameDirection));

                if (nbStepsInSameDirection < 3 && (movementRow, movementCol) != (0, 0))
                {
                    var newRow = currentRow + movementRow;
                    var newCol = currentCol + movementCol;
                    if (newRow >= 0 && newRow < inputLines.Count && newCol >= 0 && newCol < inputLines[0].Length)
                    {
                        var newHeat = totalHeat + int.Parse(inputLines[newRow][newCol].ToString());
                        priorityQueue.Enqueue((newHeat, newRow, newCol, movementRow, movementCol, nbStepsInSameDirection + 1), newHeat);
                    }
                }

                foreach (var direction in new List<(int alongRow, int alongCol)> { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    if ((direction.alongRow, direction.alongCol) == (movementRow, movementCol)
                        || (direction.alongRow, direction.alongCol) == (-movementRow, -movementCol))
                        continue;

                    var newRow = currentRow + direction.alongRow;
                    var newCol = currentCol + direction.alongCol;
                    if (newRow >= 0 && newRow < inputLines.Count && newCol >= 0 && newCol < inputLines[0].Length)
                    {
                        var newHeat = totalHeat + int.Parse(inputLines[newRow][newCol].ToString());
                        priorityQueue.Enqueue((newHeat, newRow, newCol, direction.alongRow, direction.alongCol, 1), newHeat);
                    }
                }
            }
            return 0;
        }

        public static int ComputeOptimalHeat_Part2(int startRow, int startCol, int endRow, int EndCol, List<string> inputLines)
        {
            var seen = new List<(int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection)>();

            var priorityQueue = new PriorityQueue<(int totalHeat, int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection), int>();

            priorityQueue.Enqueue((0, startRow, startCol, 0, 0, 0), 0);

            while (priorityQueue.Count > 0)
            {
                (int totalHeat, int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection) = priorityQueue.Dequeue();

                if (currentRow == endRow && currentCol == EndCol && nbStepsInSameDirection >= 4)
                    return totalHeat;

                if (seen.Contains((currentRow, currentCol, movementRow, movementCol, nbStepsInSameDirection)))
                    continue;

                seen.Add((currentRow, currentCol, movementRow, movementCol, nbStepsInSameDirection));

                if (nbStepsInSameDirection < 10 && (movementRow, movementCol) != (0, 0))
                {
                    var newRow = currentRow + movementRow;
                    var newCol = currentCol + movementCol;
                    if (newRow >= 0 && newRow < inputLines.Count && newCol >= 0 && newCol < inputLines[0].Length)
                    {
                        var newHeat = totalHeat + int.Parse(inputLines[newRow][newCol].ToString());
                        priorityQueue.Enqueue((newHeat, newRow, newCol, movementRow, movementCol, nbStepsInSameDirection + 1), newHeat);
                    }
                }

                if (nbStepsInSameDirection < 4 && (movementRow, movementCol) != (0, 0))
                    continue;

                foreach (var direction in new List<(int alongRow, int alongCol)> { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    if ((direction.alongRow, direction.alongCol) == (movementRow, movementCol)
                        || (direction.alongRow, direction.alongCol) == (-movementRow, -movementCol))
                        continue;

                    var newRow = currentRow + direction.alongRow;
                    var newCol = currentCol + direction.alongCol;
                    if (newRow >= 0 && newRow < inputLines.Count && newCol >= 0 && newCol < inputLines[0].Length)
                    {
                        var newHeat = totalHeat + int.Parse(inputLines[newRow][newCol].ToString());
                        priorityQueue.Enqueue((newHeat, newRow, newCol, direction.alongRow, direction.alongCol, 1), newHeat);
                    }
                }
            }
            return 0;
        }

        public List<INode> DijkstrasAlgorithmCustom(INode firstNode, INode goalNode)
        {
            PriorityQueue<INode, int> fronteir = new PriorityQueue<INode, int>();
            fronteir.Enqueue(firstNode, 0);

            Dictionary<string, INode> keyCameFromValue = new Dictionary<string, INode>();
            keyCameFromValue.Add(firstNode.GetUniqueIdentifier(), null);

            Dictionary<string, int> costSoFar = new Dictionary<string, int>();
            costSoFar.Add(firstNode.GetUniqueIdentifier(), 0);

            while (fronteir.Count > 0)
            {
                INode currentNode = fronteir.Dequeue();
                if (currentNode.GetUniqueIdentifier() == goalNode.GetUniqueIdentifier()) { break; }

                foreach (INode neighboor in GetNeighbors(currentNode))
                {
                    string neigboorId = neighboor.GetUniqueIdentifier();
                    int newCost = costSoFar[currentNode.GetUniqueIdentifier()] + GetEdgeWeight(currentNode, neighboor);
                    if (keyCameFromValue.ContainsKey(neigboorId)
                        && newCost >= costSoFar[neigboorId])
                        continue;

                    if (costSoFar.ContainsKey(neigboorId))
                    {
                        keyCameFromValue[neigboorId] = currentNode;
                        costSoFar[neigboorId] = newCost;
                    }
                    else
                    {
                        keyCameFromValue.Add(neigboorId, currentNode);
                        costSoFar.Add(neigboorId, newCost);
                    }

                    var priority = newCost;
                    fronteir.Enqueue(neighboor, priority);
                }
            }

            return GetPath(keyCameFromValue, firstNode, goalNode);
        }

        private bool VerifyPathAndChangeWeightsIfIncorrect(List<INode> path)
        {
            string lastDirection = "";
            int nbStepsInThatDirection = 1;
            for (int i = 1; i < path.Count; i++)
            {
                var last = path[i - 1].GetUniqueIdentifier();
                var current = path[i].GetUniqueIdentifier();
                string direction = GetDirection(path[i - 1], path[i]);
                if (direction == lastDirection)
                {
                    nbStepsInThatDirection++;
                }
                else
                {
                    lastDirection = direction;
                    nbStepsInThatDirection = 1;
                }
                //Console.WriteLine($"{path[i].GetUniqueIdentifier()} {nbStepsInThatDirection}");

                if (nbStepsInThatDirection > 3)
                {
                    this.weightedAdjacencyList[path[i - 1].GetUniqueIdentifier()][path[i].GetUniqueIdentifier()] = 1000;
                    return false;
                }
            }
            return true;
        }

        private string GetDirection(INode sourceNode, INode destinationNode)
        {
            if (destinationNode == null)
                return "";

            CityBlock sourceNodeCityBlock = (CityBlock)sourceNode;
            CityBlock destinationNodeCityBlock = (CityBlock)destinationNode;

            if (sourceNodeCityBlock.Row > destinationNodeCityBlock.Row)
                return "N";
            if (sourceNodeCityBlock.Row < destinationNodeCityBlock.Row)
                return "S";
            if (sourceNodeCityBlock.Col > destinationNodeCityBlock.Col)
                return "W";
            if (sourceNodeCityBlock.Col < destinationNodeCityBlock.Col)
                return "E";

            throw new Exception("We didn't move");
        }

        private List<INode> GetPath(Dictionary<string, INode> keyCameFromValue, INode startNode, INode goalNode)
        {
            var path = new List<INode>();
            INode current = goalNode;
            while (current.GetUniqueIdentifier() != startNode.GetUniqueIdentifier())
            {
                path.Add(current);
                current = keyCameFromValue[current.GetUniqueIdentifier()];
            }

            path.Add(startNode);
            path.Reverse();

            return path;
        }
    }
}
