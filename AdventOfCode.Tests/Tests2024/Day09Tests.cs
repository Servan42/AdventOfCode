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
        // 88217448737 too low
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
        [TestCase("233313312141413140235", "00...111...2...333.44.5555.6666.777.888899...1010101010")] // Hypothesis U1 to reject: A fileId that has x digit takes x times more space in memory
        // [TestCase("233313312141413140235", "00...111...2...333.44.5555.6666.777.888899...AAAAA")] // Hypothesis U2 to chose: The fileid does not make the file block vary in size. Non representable in strings
        public void Should_unwrap_diskmap_to_blocks(string diskmap, string expectedBlocks)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter(diskmap);

            // WHEN
            diskFragmenter.UnwrapDiskmap();

            // THEN
            Assert.That(string.Concat(diskFragmenter.Blocks), Is.EqualTo(expectedBlocks));
        }

        // "0..111....22222"
        [TestCase("12345", "022111222......")]
        // 00...111...2...333.44.5555.6666.777.888899
        [TestCase("2333133121414131402", "0099811188827773336446555566..............")]

        // In case I chose hypothesis U2:
        // Hypothesis C0: Follow the original idea from example, but the char[] datatype wont work for 2+ digit fileId. Non representable as strings.

        // In case I chose hypothesis U1:
        // Hypothesis C1 chosen: A block cannot "slide" left. It cannot consider the space it will free by moving makes a free spot large enough for itself
        // 00...111...2...333.44.5555.6666.777.888899...1010101010
        // 0010.111...2...333.44.5555.6666.777.888899...10101010..
        // 0010.11110.2...333.44.5555.6666.777.888899...101010....
        // 0010.11110.210.333.44.5555.6666.777.888899...1010......
        // 0010.11110.210.333.44.5555.6666.777.88889910.10........
        // 0010911110.210.333.44.5555.6666.777.88889.10.10........
        // 00109111109210.333.44.5555.6666.777.8888..10.10........
        // 00109111109210.333.44.5555.6666.777.88881010...........
        // 001091111092108333.44.5555.6666.777.888.1010...........
        // 001091111092108333844.5555.6666.777.88..1010...........
        // 001091111092108333844.5555.6666.777.881010.............
        // 00109111109210833384485555.6666.777.8.1010.............
        // 0010911110921083338448555586666.777...1010.............
        // 0010911110921083338448555586666.77710.10...............
        // 0010911110921083338448555586666777.10.10...............

        // Hypothesis C2 rejected: A block can slide left
        // 00...111...2...333.44.5555.6666.777.888899...1010101010
        // 0010.111...2...333.44.5555.6666.777.888899...10101010..
        // 0010.11110.2...333.44.5555.6666.777.888899...101010....
        // 0010.11110.210.333.44.5555.6666.777.888899...1010......
        // 0010.11110.210.333.44.5555.6666.777.88889910.10........ 
        // 0010.11110.210.333.44.5555.6666.777.8888991010......... <- Slide
        // 0010911110.210.333.44.5555.6666.777.88889.1010.........
        // 00109111109210.333.44.5555.6666.777.8888..1010.........
        // 00109111109210.333.44.5555.6666.777.88881010...........
        // 001091111092108333.44.5555.6666.777.888.1010...........
        // 001091111092108333844.5555.6666.777.88..1010...........
        // 001091111092108333844.5555.6666.777.881010.............
        // 00109111109210833384485555.6666.777.8.1010.............
        // 0010911110921083338448555586666.777...1010.............
        // 0010911110921083338448555586666.77710.10...............
        // 0010911110921083338448555586666.7771010................
        // 0010911110921083338448555586666777.1010................

        [TestCase("233313312141413140235", "0010911110921083338448555586666777.10.10...............")]
        public void Should_compact_blocks(string diskmap, string expectedCompactedBlocks)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter(diskmap);
            diskFragmenter.UnwrapDiskmap();

            // WHEN
            diskFragmenter.CompactBlocks();

            // THEN
            Assert.That(diskFragmenter.CompactedBlocks, Is.EqualTo(expectedCompactedBlocks));
        }

        [TestCase("2333133121414131402", "1928")]
        // In case I chose hypothesis U1 and C1
        [TestCase("233313312141413140235", "3636")] // Hypothesis chosen: Block position only takes filled blocks to increment
        //[TestCase("233313312141413140235", "3666")] // Hypothesis rejected: Block position takes both filled blocks and empty blocks to increment
        //[TestCase("233313312141413140235", "3676")] // Hypothesis rejected: Block position is the index of first left char of the block in the blockList.Tostring()
        public void Should_calculate_checksum(string diskmap, string expectedChecksum)
        {
            // GIVEN
            var diskFragmenter = new DiskFragmenter(diskmap);
            diskFragmenter.UnwrapDiskmap();
            diskFragmenter.CompactBlocks();

            // WHEN
            double checksum = diskFragmenter.CalculateChecksum();

            // THEN
            Assert.That(checksum.ToString(), Is.EqualTo(expectedChecksum));
        }
    }
}
