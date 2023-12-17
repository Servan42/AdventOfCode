using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day17
{
    internal class Crucible
    {
        public int TotalHeat { get; set; }
        public int CurrentRow { get; set; }
        public int CurrentCol { get; set; }
        public int MovementRow { get; set; }
        public int MovementCol { get; set; }
        public int NbStepsInSameDirection { get; set; }

        private int potentialNextRow;
        private int potentialNextCol;

        public Crucible(int totalHeat, int currentRow, int currentCol, int movementRow, int movementCol, int nbStepsInSameDirection)
        {
            TotalHeat = totalHeat;
            CurrentRow = currentRow;
            CurrentCol = currentCol;
            MovementRow = movementRow;
            MovementCol = movementCol;
            NbStepsInSameDirection = nbStepsInSameDirection;
            potentialNextRow = CurrentRow + MovementRow;
            potentialNextCol = CurrentCol + MovementCol;
        }

        internal bool HasArrivedToDestination(int endRow, int endCol)
        {
            return CurrentRow == endRow && CurrentCol == endCol;
        }

        internal bool IsMoving()
        {
            return (MovementRow, MovementCol) != (0, 0);
        }

        internal bool IsNextPositionInBounds(List<string> inputLines)
        {
            return potentialNextRow >= 0 
                && potentialNextRow < inputLines.Count 
                && potentialNextCol >= 0 
                && potentialNextCol < inputLines[0].Length;
        }

        internal string UniqueKey()
        {
            return new StringBuilder()
                .Append(CurrentRow)
                .Append(CurrentCol)
                .Append(MovementRow)
                .Append(MovementCol)
                .Append(NbStepsInSameDirection)
                .ToString();
        }

        private int ComputeNextHeat(List<string> inputLines, int nextRow, int nextCol)
        {
            return TotalHeat + int.Parse(inputLines[nextRow][nextCol].ToString());
        }

        internal Crucible GetNextStepCrucibleMovingForward(List<string> inputLines)
        {
            var nextHeat = ComputeNextHeat(inputLines, potentialNextRow, potentialNextCol);
            return new Crucible(nextHeat, potentialNextRow, potentialNextCol, MovementRow, MovementCol, NbStepsInSameDirection + 1);
        }

        internal bool WillSteerIfThisDirectionIsApplied((int alongRow, int alongCol) direction)
        {
            return (direction.alongRow, direction.alongCol) != (MovementRow, MovementCol) // Goes forward
                       && (direction.alongRow, direction.alongCol) != (-MovementRow, -MovementCol); // Goes backwards
        }

        internal bool IsNextPositionInBoundsAfterSteering(List<string> inputLines, (int alongRow, int alongCol) direction)
        {
            int rowAfterSteering = CurrentRow + direction.alongRow;
            int colAfterSteering = CurrentCol + direction.alongCol;

            return rowAfterSteering >= 0
                && rowAfterSteering < inputLines.Count
                && colAfterSteering >= 0
                && colAfterSteering < inputLines[0].Length;
        }

        internal Crucible GetNextStepCrucibleSteering(List<string> inputLines, (int alongRow, int alongCol) direction)
        {
            int rowAfterSteering = CurrentRow + direction.alongRow;
            int colAfterSteering = CurrentCol + direction.alongCol;

            var nextHeat = ComputeNextHeat(inputLines, rowAfterSteering, colAfterSteering);
            return new Crucible(nextHeat, rowAfterSteering, colAfterSteering, direction.alongRow, direction.alongCol, 1);
        }

        internal bool IsAllowedToStopOrSteer()
        {
            return NbStepsInSameDirection >= 4;
        }

        internal bool CanContinueMovingForward(bool isPart2)
        {
            return NbStepsInSameDirection < (isPart2 ? 10 : 3);
        }
    }
}
