using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day20
{
    public abstract class Module
    {
        protected Module(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<Module> DestinationModules { get; set; } = new();
        public abstract List<(Pulse pulse, Module destModule)> ProcessIncomingPulse(Pulse pulse);
    }
}
