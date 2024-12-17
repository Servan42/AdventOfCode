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
        public string Blocks {get; set; }
        public string CompactedBlocks { get; set; }

        public DiskFragmenter(string inputLine) 
        {
            this.Diskmap = inputLine;
        }

        // Intuition: We might need to keep track fo repeated fileids as individuals ids rather than just printing them
        // Ex: For file id 34, repeated 3 times, maybe "343434" is differement from [ "34", "34", "34" ]
        // 88217448737 too low
        public void Unwrap()
        {
            StringBuilder blocks = new();
            int fileId = 0;
            bool isFileBlock = true;

            foreach (char blocksize in this.Diskmap)
            {
                if (isFileBlock)
                {
                    blocks.Append(string.Concat(Enumerable.Repeat(fileId.ToString(), blocksize - '0')));
                    fileId++;
                }
                else
                {
                    blocks.Append(new string('.', blocksize - '0'));
                }

                isFileBlock = !isFileBlock;
            }
            this.Blocks = blocks.ToString();
        }

        public void Compact()
        {
            char[] compactedBlocks = this.Blocks.ToCharArray();
            int lastFileIdIndex = GetLastFileIdIndex(compactedBlocks, Blocks.Length - 1);
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
