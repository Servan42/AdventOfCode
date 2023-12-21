using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day20
{
    public class FlipFlopModule : Module
    {
        public FlipFlopModule(string name) : base(name)
        {
        }

        public bool StatusOn { get; set; } = false;

        public override List<(Pulse pulse, Module destModule)> ProcessIncomingPulse(Pulse pulse)
        {
            var result = new List<(Pulse pulse, Module destModule)>();

            if (pulse.IsHigh)
                return result;

            StatusOn = !StatusOn;
            DestinationModules.ForEach(m => result.Add((new Pulse(StatusOn, this), m)));

            return result;
        }
    }
}
