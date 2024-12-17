using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public class DiskFragmenter
    {
        public string Diskmap {get; set; }
        public List<MemoryBlock> Blocks {get; set; }
        public string CompactedBlocks { get; set; }

        public DiskFragmenter(string inputLine) 
        {
            this.Diskmap = inputLine;
            this.Blocks = new();
        }

        public void UnwrapDiskmap()
        {
            int fileId = 0;
            bool isFileBlock = true;

            foreach (char blocksize in this.Diskmap)
            {
                if (isFileBlock)
                {
                    Blocks.Add(new MemoryBlock
                    {
                        FileId = fileId,
                        Size = blocksize - '0',
                        IsFileBlock = true
                    });
                    fileId++;
                }
                else
                {
                    Blocks.Add(new MemoryBlock
                    {
                        Size = blocksize - '0',
                        IsFileBlock = false
                    });
                }

                isFileBlock = !isFileBlock;
            }
        }

        [Obsolete("TO REDO WITH NEW HYPOTHESIS")]

        public void CompactBlocks()
        {
            char[] compactedBlocks = string.Concat(Blocks).ToCharArray();
            int lastFileIdIndex = GetLastFileIdIndex(compactedBlocks, string.Concat(Blocks).Length - 1);
            int firstDotIndex = GetFirstDotIndex(compactedBlocks, 0);

            while (firstDotIndex < lastFileIdIndex)
            {
                compactedBlocks[firstDotIndex] = compactedBlocks[lastFileIdIndex];
                compactedBlocks[lastFileIdIndex] = '.';
                firstDotIndex = GetFirstDotIndex(compactedBlocks, firstDotIndex);
                lastFileIdIndex = GetLastFileIdIndex(compactedBlocks, lastFileIdIndex);
            }

            this.CompactedBlocks = string.Concat(compactedBlocks);
        }

        private int GetLastFileIdIndex(char[] blocks, int startAtIndex)
        {
            int resultIndex = startAtIndex;
            while (blocks[resultIndex] == '.')
                resultIndex--;
            return resultIndex;
        }

        private int GetFirstDotIndex(char[] blocks, int startAtIndex)
        {
            int resultIndex = startAtIndex;
            while (blocks[resultIndex] != '.')
                resultIndex++;
            return resultIndex;
        }

        [Obsolete("TO REDO WITH NEW HYPOTHESIS")]
        public double CalculateChecksum()
        {
            double checksum = 0;
            for (int i = 0; CompactedBlocks[i] != '.'; i++)
            {
                checksum += (CompactedBlocks[i] - '0') * i;
            }
            return checksum;
        }
    }
}
