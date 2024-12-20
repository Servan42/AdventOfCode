using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public abstract class DiskFragmenter
    {
        private string diskmap;
        protected const int EMPTY_BLOCK = -1;

        public DiskFragmenter(string inputLine)
        {
            this.diskmap = inputLine;
        }

        public void UnwrapDiskmap()
        {
            int fileId = 0;
            bool isFileBlock = true;

            foreach (char blocksize in this.diskmap)
            {
                if (isFileBlock)
                {
                    AddBlock(fileId, blocksize - '0');
                    fileId++;
                }
                else
                {
                    AddBlock(EMPTY_BLOCK, blocksize - '0');
                }

                isFileBlock = !isFileBlock;
            }
        }

        protected abstract void AddBlock(int fileId, int size);
        public abstract void CompactBlocks();
        public abstract double CalculateChecksum();
    }
}
