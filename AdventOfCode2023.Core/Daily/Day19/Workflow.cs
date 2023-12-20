using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day19
{
    internal class WorkFlow
    {
        public string Name { get; set; }
        public List<WorkFlowStep> WorkflowSteps { get; set; } = new();

        internal static WorkFlow Parse(string line)
        {
            WorkFlow workFlow = new WorkFlow();
            workFlow.Name = line.Substring(0, line.IndexOf('{'));
            var steps = line.Substring(line.IndexOf('{') + 1).Replace("}", "").Split(',');
            foreach(var step in steps)
            {
                workFlow.WorkflowSteps.Add(WorkFlowStep.Parse(step));
            }
            return workFlow;
        }

        internal string ProcessPart(Part part)
        {
            string destinationKey = string.Empty;
            foreach(var step in WorkflowSteps)
            {
                if (!string.IsNullOrEmpty(step.FallbackDestinationWorkFlowKey))
                {
                    destinationKey = step.FallbackDestinationWorkFlowKey;
                    break;
                }

                if (step.IsComparatorGreaterThan && part.SubPartValue[step.ProcessedSubPart] > step.NumberToCompare)
                    return step.DestinationWorkFlowKey;

                if (!step.IsComparatorGreaterThan && part.SubPartValue[step.ProcessedSubPart] < step.NumberToCompare)
                    return step.DestinationWorkFlowKey;
            }
            return destinationKey;
        }
    }
}
