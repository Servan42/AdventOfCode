using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day19
{
    internal class ProductionLine
    {
        public List<Part> Parts { get; set; } = new();
        public Dictionary<string, WorkFlow> Workflows { get; set; } = new();

        public static ProductionLine Parse(List<string> inputLines)
        {
            ProductionLine productionLine = new();
            bool parseWorkflow = true;
            foreach (var line in inputLines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    parseWorkflow = false;
                    continue;
                }

                if (parseWorkflow)
                {
                    var workflow = WorkFlow.Parse(line);
                    productionLine.Workflows.Add(workflow.Name, workflow);
                }
                else
                {
                    productionLine.Parts.Add(Part.Parse(line));
                }
            }
            return productionLine;
        }

        public int ProcessParts()
        {
            return Parts.Sum(p => ProcessOnePart(p));
        }

        public int ProcessOnePart(Part part)
        {
            string nextWorkFlowKey = "in";
            while (nextWorkFlowKey != "A")
            {
                var workflow = Workflows[nextWorkFlowKey];
                nextWorkFlowKey = workflow.ProcessPart(part);
                if (nextWorkFlowKey == "R") return 0;
            }
            return part.SumFeilds();
        }

        public double GetTotalWorkflowsNbCombinations()
        {
            var boundsForXMAS = new Dictionary<string, (int lb, int ub)>
            {
                { "x", (1, 4000) },
                { "m", (1, 4000) },
                { "a", (1, 4000) },
                { "s", (1, 4000) }
            };

            return ProcessBoundThroughWorkflow(boundsForXMAS, "in");
        }

        private double ProcessBoundThroughWorkflow(Dictionary<string, (int lb, int ub)> bounds, string workflowKey)
        {
            if (workflowKey == "R") return 0;
            if (workflowKey == "A")
            {
                double mult = 1;
                foreach(var (lb, ub) in bounds.Values)
                {
                    mult *= (ub - lb + 1);
                }
                return mult;
            }

            var workflow = Workflows[workflowKey];
            double total = 0.0;
            foreach(var step in workflow.WorkflowSteps) 
            {
                if (!string.IsNullOrEmpty(step.FallbackDestinationWorkFlowKey))
                {
                    total += ProcessBoundThroughWorkflow(bounds, step.FallbackDestinationWorkFlowKey);
                    break;
                }

                (int lb, int ub) = bounds[step.ProcessedSubPart];
                (int lb, int ub) validInterval;
                (int lb, int ub) invalidInterval;

                if (step.IsComparatorGreaterThan)
                {
                    validInterval = (step.NumberToCompare + 1, ub);
                    invalidInterval = (lb, step.NumberToCompare);
                }
                else
                {
                    validInterval = (lb, step.NumberToCompare - 1);
                    invalidInterval = (step.NumberToCompare, ub);
                }

                if (validInterval.lb <= validInterval.ub)
                {
                    var copy = new Dictionary<string, (int lb, int ub)>(bounds);
                    copy[step.ProcessedSubPart] = validInterval;
                    total += ProcessBoundThroughWorkflow(copy, step.DestinationWorkFlowKey);
                }
                
                if (invalidInterval.lb <= invalidInterval.ub)
                {
                    bounds[step.ProcessedSubPart] = invalidInterval;
                }
            }

            return total;
        }
    }
}
