using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public class MemoryBlock
    {
        public int FileId { get; internal set; }
        public int Size { get; internal set; }

        public MemoryBlock(int fileId, int size)
        {
            FileId = fileId;
            Size = size;
        }
    }
}
