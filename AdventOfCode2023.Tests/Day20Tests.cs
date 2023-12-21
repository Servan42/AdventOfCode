using AdventOfCode2023.Core.Daily.Day20;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day20Tests
    {
        Day20Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day20Ex();
        }

        [Test]
        public void FlipFlop_should_ignore_high_pulses()
        {
            // Given
            var module_sut = new FlipFlopModule("a");
            module_sut.DestinationModules.Add(new FlipFlopModule("b"));
            module_sut.DestinationModules.Add(new FlipFlopModule("c"));

            // When
            var result = module_sut.ProcessIncomingPulse(new Pulse(true, null));

            // Then
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void FlipFlop_should_act_on_low_pulses(bool initialStatus)
        {
            // Given
            var module_sut = new FlipFlopModule("a");
            module_sut.StatusOn = initialStatus;
            module_sut.DestinationModules.Add(new FlipFlopModule("b"));
            module_sut.DestinationModules.Add(new FlipFlopModule("c"));

            // When
            var result = module_sut.ProcessIncomingPulse(new Pulse(false, null));

            // Then
            Assert.That(result.Count, Is.EqualTo(2));
            Assert.That(result.All(x => x.pulse.IsHigh != initialStatus));
        }

        [Test]
        public void Conjunction_should_remember_last_pulse_of_each_senders()
        {
            // Given
            var sender1 = new FlipFlopModule("a");
            var sender2 = new FlipFlopModule("b");
            var sender3 = new FlipFlopModule("c");
            var module_sut = new ConjunctionModule("d");
            module_sut.AddConnectedInputModules(new List<Module> { sender1, sender2, sender3 });

            // When
            module_sut.ProcessIncomingPulse(new Pulse(true, sender1));
            module_sut.ProcessIncomingPulse(new Pulse(false, sender2));

            // Then
            Assert.That(module_sut.ConnectedInputModulesMostRecentPulse[sender1], Is.EqualTo(true));
            Assert.That(module_sut.ConnectedInputModulesMostRecentPulse[sender2], Is.EqualTo(false));
            Assert.That(module_sut.ConnectedInputModulesMostRecentPulse[sender3], Is.EqualTo(false));
        }

        [Test] 
        public void Conjunction_should_act_according_to_its_memory()
        {
            // Given
            var sender1 = new FlipFlopModule("a");
            var sender2 = new FlipFlopModule("b");
            var module_sut = new ConjunctionModule("c");
            module_sut.AddConnectedInputModules(new List<Module> { sender1, sender2 });
            module_sut.DestinationModules = new List<Module> { new FlipFlopModule("d") };

            // When 
            var result = module_sut.ProcessIncomingPulse(new Pulse(true, sender1));

            // Then
            Assert.That(result.First().pulse.IsHigh, Is.EqualTo(true));

            // When2
            var result2 = module_sut.ProcessIncomingPulse(new Pulse(true, sender2));

            // Then2
            Assert.That(result2.First().pulse.IsHigh, Is.EqualTo(false));
        }

        [Test]
        public void Should_part1_1() 
        {
            // Given
            sut.InputLines = new List<string>
            {
                "broadcaster -> a, b, c",
                "%a -> b",
                "%b -> c",
                "%c -> inv",
                "&inv -> a"
            };

            // When
            sut.ComputePart1();

            Assert.That(sut.Output, Is.EqualTo((8000*4000).ToString()));
        }

        [Test]
        public void Should_part1_2()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "broadcaster -> a",
                "%a -> inv, con",
                "&inv -> b",
                "%b -> con",
                "&con -> rx"
            };

            // When
            sut.ComputePart1();

            Assert.That(sut.Output, Is.EqualTo((4250 * 2750).ToString()));
        }
    }
}
