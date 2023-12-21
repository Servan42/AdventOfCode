using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day20
{
    public class Network
    {
        Dictionary<string, Module> modules = new Dictionary<string, Module>();
        Dictionary<string, bool> moduleSentHighDuringLastPress = new();

        public static Network Parse(List<string> inputLines)
        {
            Network network = new Network();

            foreach (var line in inputLines)
            {
                var module = line.Split(' ')[0];
                var moduleType = module[0];
                var moduleName = module.Substring(1);
                switch (moduleType)
                {
                    case '%':
                        network.modules.Add(moduleName, new FlipFlopModule(moduleName));
                        break;
                    case '&':
                        network.modules.Add(moduleName, new ConjunctionModule(moduleName));
                        break;
                    case 'b':
                        network.modules.Add(moduleName, new BroadcastModule(moduleName));
                        break;
                }
            }

            network.modules.Add("rx", new OutputModule("rx"));

            foreach (var line in inputLines)
            {
                var moduleName = line.Split(" ")[0].Substring(1);
                var destinationModules = line.Split('>')[1].Split(',', StringSplitOptions.TrimEntries);

                network.modules[moduleName].DestinationModules = destinationModules
                    .Select(x => network.modules[x]).ToList();
            }

            network.InitConjunctionModules();

            return network;
        }

        private void InitConjunctionModules()
        {
            foreach (var conjunctionModule in modules.Values.Where(m => m.GetType() == typeof(ConjunctionModule)))
            {
                var inputModules = new List<Module>();
                foreach (var modules in modules)
                {
                    if (modules.Value.DestinationModules.Any(dm => dm.Name == conjunctionModule.Name))
                    {
                        inputModules.Add(modules.Value);
                    }
                }
                ((ConjunctionModule)conjunctionModule).AddConnectedInputModules(inputModules);
            }
        }

        public (double low, double high) PushTheButton()
        {
            var pulseQueue = new Queue<(Pulse pulse, Module destModule)>();
            pulseQueue.Enqueue((new Pulse(false, null), modules["roadcaster"]));

            int lowPulseCount = 0;
            int highPulseCount = 0;

            while (pulseQueue.Count > 0)
            {
                (Pulse pulse, Module destModule) = pulseQueue.Dequeue();


                if (pulse.IsHigh) highPulseCount++;
                else lowPulseCount++;

                var newPulses = destModule.ProcessIncomingPulse(pulse);
                newPulses.ForEach(x => pulseQueue.Enqueue(x));

                if (moduleSentHighDuringLastPress.ContainsKey(destModule.Name)
                    && newPulses.First().pulse.IsHigh)
                {
                    moduleSentHighDuringLastPress[destModule.Name] = true;
                }
            }

            return (lowPulseCount, highPulseCount);
        }

        public double PushTheButtonXTimes(int times)
        {
            double lowPulseCount = 0;
            double highPulseCount = 0;

            for (int i = 0; i < times; i++)
            {
                var counts = PushTheButton();
                lowPulseCount += counts.low;
                highPulseCount += counts.high;
            }

            return lowPulseCount * highPulseCount;
        }

        public double PushTheButtonUntilRxIsReachedWithLowPulse()
        {
            // Module that feed to rx:
            var feedsRx = modules
                .Where(m => m.Value.DestinationModules.Any(dm => dm.Name == "rx"))
                .Select(x => x.Value.Name)
                .First();

            // Modules that feed to module that feed to rx:
            var modsToSync = modules
                .Where(m => m.Value.DestinationModules.Any(dm => dm.Name == feedsRx))
                .Select(m => m.Value.Name);

            // Adding their name to a high pulse track list and cycle counters
            Dictionary<string, Cycle> moduleCycles = new();
            foreach (var moduleToTrack in modsToSync)
            {
                moduleSentHighDuringLastPress.Add(moduleToTrack, false);
                moduleCycles.Add(moduleToTrack, new Cycle { LastCycle = int.MinValue, CurrentCycle = 0 });
            }

            // searches how many presses after each module to track cycles
            while (!moduleCycles.All(x => x.Value.LastWasEqualToCurrent))
            {
                PushTheButton();
                foreach (var moduleToTrack in moduleSentHighDuringLastPress)
                {
                    if (moduleToTrack.Value) // Sent a high pulse
                    {
                        moduleCycles[moduleToTrack.Key].LastWasEqualToCurrent = moduleCycles[moduleToTrack.Key].LastCycle == moduleCycles[moduleToTrack.Key].CurrentCycle;
                        moduleCycles[moduleToTrack.Key].LastCycle = moduleCycles[moduleToTrack.Key].CurrentCycle;
                        moduleCycles[moduleToTrack.Key].CurrentCycle = 0;
                        moduleSentHighDuringLastPress[moduleToTrack.Key] = false;
                    }
                }
                // Increment all cycle counters
                foreach (var moduleCycle in moduleCycles)
                {
                    moduleCycle.Value.CurrentCycle++;
                }
            }

            return moduleCycles.Select(m => m.Value.LastCycle).LeastCommonMultiple();
        }
    }
}
