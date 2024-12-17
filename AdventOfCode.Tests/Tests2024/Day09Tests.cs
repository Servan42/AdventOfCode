using AdventOfCode.Core.Daily2024.Day09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Tests.Tests2024
{
    internal class Day09Tests
    {
        Day09Ex sut;

        [SetUp]
        public void Setup()
        {
            sut = new Day09Ex();
        }

        [Test]
        public void Should_do_part_one_from_exmaple()
        {
            // GIVEN
            sut.InputLines = [ "2333133121414131402" ];

            // WHEN
            sut.ComputePart1();

            // THEN
            Assert.That(sut.Output, Is.EqualTo("1928"));
        }

        [TestCase("12345", "0..111....22222")]
        [TestCase("2333133121414131402", "00...111...2...333.44.5555.6666.777.888899")]
        [TestCase("233313312141413140234", "00...111...2...333.44.5555.6666.777.888899...10101010")]
        public void Should_unwrap_diskmap_to_blocks(string diskmap, string expectedBlocks)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter(diskmap);

            // WHEN
            diskFragmenter.Unwrap();

            // THEN
            Assert.That(diskFragmenter.Blocks, Is.EqualTo(expectedBlocks));
        }

        [TestCase("0..111....22222", "022111222......")]
        [TestCase("00...111...2...333.44.5555.6666.777.888899", "0099811188827773336446555566..............")]
        public void Should_compact_blocks(string blocks, string expectedCompactedBlocks)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter("");
            diskFragmenter.Blocks = blocks;

            // WHEN
            diskFragmenter.Compact();

            // THEN
            Assert.That(diskFragmenter.CompactedBlocks, Is.EqualTo(expectedCompactedBlocks));
        }

        [TestCase("0099811188827773336446555566..............", "1928")]
        public void Should_calculate_checksum(string compactedBlocks, string expectedChecksum)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter("");
            diskFragmenter.CompactedBlocks = compactedBlocks;

            // WHEN
            double checksum = diskFragmenter.CalculateChecksum();

            // THEN
            Assert.That(checksum.ToString(), Is.EqualTo(expectedChecksum));
        }
    }
}
