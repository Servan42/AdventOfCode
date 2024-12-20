using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public class Day09Ex : Exercise
    {
        public override void ComputePart1()
        {
            var diskFragmenter = new DiskFragmenterPart1(this.InputLines[0]);
            diskFragmenter.UnwrapDiskmap();
            diskFragmenter.CompactBlocks();
            this.Output = diskFragmenter.CalculateChecksum().ToString();
        }

        public override void ComputePart2()
        {
            var diskFragmenter = new DiskFragmenterPart2(this.InputLines[0]);
            diskFragmenter.UnwrapDiskmap();
            diskFragmenter.CompactBlocks();
            this.Output = diskFragmenter.CalculateChecksum().ToString();
        }
    }
}
