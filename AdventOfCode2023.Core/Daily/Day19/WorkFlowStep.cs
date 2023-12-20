using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day19
{
    internal class WorkFlowStep
    {
        public string ProcessedSubPart { get; set; }
        public bool IsComparatorGreaterThan { get; set; }
        public int NumberToCompare { get; set; }
        public string DestinationWorkFlowKey { get; set; }
        public string FallbackDestinationWorkFlowKey { get; set; }

        internal static WorkFlowStep Parse(string step)
        {
            WorkFlowStep workFlowStep = new();
            if(!step.Contains(':'))
            {
                workFlowStep.FallbackDestinationWorkFlowKey = step;
                return workFlowStep;
            }

            workFlowStep.ProcessedSubPart = step[0].ToString();
            workFlowStep.IsComparatorGreaterThan = step[1] == '>';
            workFlowStep.NumberToCompare = int.Parse(Regex.Match(step, "[0-9]+").Value);
            workFlowStep.DestinationWorkFlowKey = step.Split(':')[1];

            return workFlowStep;
        }

        public double GetNbPossibleOutcomes()
        {
            if(string.IsNullOrEmpty(DestinationWorkFlowKey))
                return 1;

            if (IsComparatorGreaterThan)
                return 4000.0 - NumberToCompare;
            else return NumberToCompare - 1;
        }
    }
}
