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
        public bool IsFileBlock { get; internal set; }

        public override string? ToString()
        {
            if (IsFileBlock)
                return string.Concat(Enumerable.Repeat(FileId.ToString(), Size));

            return new string('.', Size);
        }
    }
}
