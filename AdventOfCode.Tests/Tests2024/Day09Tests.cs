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
            Assert.That(string.Concat(diskFragmenter.Blocks), Is.EqualTo(expectedBlocks));
        }

        // "0..111....22222"
        [TestCase("12345", "022111222......")]
        // 00...111...2...333.44.5555.6666.777.888899
        [TestCase("2333133121414131402", "0099811188827773336446555566..............")]
        // 00...111...2...333.44.5555.6666.777.888899...10101010

        // 00...111...2...333.44.5555.6666.777.888899...10101010
        // 0010.111...2...333.44.5555.6666.777.888899...101010..
        // 0010.11110.2...333.44.5555.6666.777.888899...1010....
        // 0010.11110.210.333.44.5555.6666.777.888899...10......
        // 0010.11110.210.333.44.5555.6666.777.88889910.........
        // 0010911110.210.333.44.5555.6666.777.88889.10.........
        // 00109111109210.333.44.5555.6666.777.8888..10.........
        // 00109111109210.333.44.5555.6666.777.888810...........
        // 001091111092108333.44.5555.6666.777.888.10...........
        // 001091111092108333844.5555.6666.777.88..10...........
        // 00109111109210833384485555.6666.777.8.10.............
        // 0010911110921083338448555586666.777...10.............
        // 0010911110921083338448555586666.77710................
        // 0010911110921083338448555586666777.10................

        [TestCase("233313312141413140234", "0010911110921083338448555586666777.10................")]
        public void Should_compact_blocks(string diskmap, string expectedCompactedBlocks)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter(diskmap);
            diskFragmenter.Unwrap();

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
