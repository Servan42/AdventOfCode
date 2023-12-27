using AdventOfCode2023.Core.Daily.Day25;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Tests
{
    internal class Day25Tests
    {
        Day25Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day25Ex();
        }

        [Test]
        [Ignore("Comment the statistic MagicRandom in the 3 edge finding")]
        public void Should_part1()
        {
            // Given
            sut.InputLines = new List<string>
            {
                "jqt: rhn xhk nvd",
                "rsh: frs pzl lsr",
                "xhk: hfx",
                "cmg: qnr nvd lhk bvb",
                "rhn: xhk bvb hfx",
                "bvb: xhk hfx",
                "pzl: lsr hfx nvd",
                "qnr: nvd",
                "ntq: jqt hfx bvb xhk",
                "nvd: lhk",
                "lsr: lhk",
                "rzs: qnr cmg lsr rsh",
                "frs: qnr lhk lsr"
            };

            // When
            sut.ComputePart1();

            // Then
            Assert.That(sut.Output, Is.EqualTo("54"));
        }
    }
}
