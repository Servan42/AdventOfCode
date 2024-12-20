using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public class DiskFragmenterPart1 : DiskFragmenter
    {
        private List<int> blocks;

        public DiskFragmenterPart1(string inputLine) : base(inputLine)
        {
            this.blocks = new();
        }

        protected override void AddBlock(int fileId, int blocksize)
        {
            for (int i = 0; i < blocksize; i++)
            {
                blocks.Add(fileId);
            }
        }

        public override void CompactBlocks()
        {
            int lastFileIdIndex = GetLastFileIdIndex(blocks, blocks.Count - 1);
            int firstDotIndex = GetFirstEmptyBlockIndex(blocks, 0);

            while (firstDotIndex < lastFileIdIndex)
            {
                blocks[firstDotIndex] = blocks[lastFileIdIndex];
                blocks[lastFileIdIndex] = EMPTY_BLOCK;
                firstDotIndex = GetFirstEmptyBlockIndex(blocks, firstDotIndex);
                lastFileIdIndex = GetLastFileIdIndex(blocks, lastFileIdIndex);
            }
        }

        private int GetLastFileIdIndex(List<int> blocks, int startAtIndex)
        {
            int resultIndex = startAtIndex;
            while (blocks[resultIndex] == EMPTY_BLOCK)
                resultIndex--;
            return resultIndex;
        }

        private int GetFirstEmptyBlockIndex(List<int> blocks, int startAtIndex)
        {
            int resultIndex = startAtIndex;
            while (blocks[resultIndex] != EMPTY_BLOCK)
                resultIndex++;
            return resultIndex;
        }

        public override double CalculateChecksum()
        {
            double checksum = 0;
            for (int i = 0; blocks[i] != EMPTY_BLOCK; i++)
            {
                checksum += blocks[i] * i;
            }
            return checksum;
        }
    }
}
