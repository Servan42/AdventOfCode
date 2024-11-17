using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day20
{
    public class ConjunctionModule : Module
    {
        public Dictionary<Module, bool> ConnectedInputModulesMostRecentPulse;

        public ConjunctionModule(string name) : base(name) 
        {
        }

        public void AddConnectedInputModules(List<Module> inputModules)
        {
            ConnectedInputModulesMostRecentPulse = new Dictionary<Module, bool>();
            inputModules.ForEach(m => ConnectedInputModulesMostRecentPulse.Add(m, false));
        }

        public override List<(Pulse pulse, Module destModule)> ProcessIncomingPulse(Pulse pulse)
        {
            ConnectedInputModulesMostRecentPulse[pulse.Emmiter] = pulse.IsHigh;

            bool allInputsSentHighPulse = ConnectedInputModulesMostRecentPulse.All(x => x.Value);

            var result = new List<(Pulse pulse, Module destModule)>();
            DestinationModules.ForEach(m => result.Add((new Pulse(!allInputsSentHighPulse, this), m)));
            return result;
        }
    }
}
