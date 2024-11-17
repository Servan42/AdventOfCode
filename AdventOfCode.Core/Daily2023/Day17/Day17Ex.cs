using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day17
{
    public class Day17Ex : Exercise
    {
        public override void ComputePart1()
        {
            Output = ComputeOptimalHeat(0, 0, InputLines.Count - 1, InputLines[0].Length - 1, InputLines, false).ToString();
        }

        public override void ComputePart2()
        {
            Output = ComputeOptimalHeat(0, 0, InputLines.Count - 1, InputLines[0].Length - 1, InputLines, true).ToString();
        }

        public int ComputeOptimalHeat(int startRow, int startCol, int endRow, int endCol, List<string> inputLines, bool isPart2)
        {
            var seen = new List<string>();
            var priorityQueue = new PriorityQueue<Crucible, int>();

            priorityQueue.Enqueue(new Crucible(
                totalHeat: 0,
                currentRow: startRow,
                currentCol: startCol,
                movementCol: 0,
                movementRow: 0,
                nbStepsInSameDirection: 0
            ), 0);

            while (priorityQueue.Count > 0)
            {
                var crucible = priorityQueue.Dequeue();

                if (crucible.HasArrivedToDestination(endRow, endCol) 
                    && (!isPart2 || isPart2 && crucible.IsAllowedToStopOrSteer()))
                    return crucible.TotalHeat;

                if (seen.Contains(crucible.UniqueKey()))
                    continue;

                seen.Add(crucible.UniqueKey());

                if (crucible.CanContinueMovingForward(isPart2) && crucible.IsMoving())
                {
                    if (crucible.IsNextPositionInBounds(inputLines))
                    {
                        var nextStep = crucible.GetNextStepCrucibleMovingForward(inputLines);
                        priorityQueue.Enqueue(nextStep, nextStep.TotalHeat);
                    }
                }

                if (isPart2 && !crucible.IsAllowedToStopOrSteer() && crucible.IsMoving())
                    continue;

                foreach (var direction in new List<(int alongRow, int alongCol)> { (-1, 0), (1, 0), (0, -1), (0, 1) })
                {
                    if (!crucible.WillSteerIfThisDirectionIsApplied(direction))
                        continue;

                    if (crucible.IsNextPositionInBoundsAfterSteering(inputLines, direction))
                    {
                        var nextStep = crucible.GetNextStepCrucibleSteering(inputLines, direction);
                        priorityQueue.Enqueue(nextStep, nextStep.TotalHeat);
                    }
                }
            }

            throw new Exception("Crucible did not reach the destination");
        }
    }
}
