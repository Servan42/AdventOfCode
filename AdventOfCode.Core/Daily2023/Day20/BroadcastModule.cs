using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day20
{
    internal class BroadcastModule : Module
    {
        public BroadcastModule(string name) : base(name)
        {
        }

        public override List<(Pulse pulse, Module destModule)> ProcessIncomingPulse(Pulse pulse)
        {
            var result = new List<(Pulse pulse, Module destModule)>();
            DestinationModules.ForEach(m => result.Add((new Pulse(pulse.IsHigh, this), m)));
            return result;
        }
    }
}
