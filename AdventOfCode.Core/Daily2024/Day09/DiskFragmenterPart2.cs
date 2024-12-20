using AdventOfCode.Core.Daily2023.Day22;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day09
{
    public class DiskFragmenterPart2 : DiskFragmenter
    {
        private LinkedList<MemoryBlock> blocks;

        public DiskFragmenterPart2(string inputLine) : base(inputLine)
        {
            this.blocks = new();
        }

        protected override void AddBlock(int fileId, int blocksize)
        {
            blocks.AddLast(new MemoryBlock(fileId, blocksize));
        }

        public override void CompactBlocks()
        {
            for (int currentFileId = blocks.Max(m => m.FileId); currentFileId >= 0; currentFileId--)
            {
                (int currentFileNodeIndex, var currentFileNode) = GetCurrentFileNode(currentFileId);
                var firstEmptyOfRightSizeNode = GetFirstEmptyNodeOfRightSize(currentFileNode!.Value.Size, currentFileNodeIndex);
                if (firstEmptyOfRightSizeNode == null)
                    continue;

                blocks.AddAfter(currentFileNode, new MemoryBlock(EMPTY_BLOCK, currentFileNode.Value.Size));
                blocks.Remove(currentFileNode);
                blocks.AddBefore(firstEmptyOfRightSizeNode, currentFileNode);

                firstEmptyOfRightSizeNode.Value.Size -= currentFileNode.Value.Size;
                if (firstEmptyOfRightSizeNode.Value.Size == 0)
                    blocks.Remove(firstEmptyOfRightSizeNode);

                MergeEmptyBlocks();
            }
        }

        private LinkedListNode<MemoryBlock>? GetFirstEmptyNodeOfRightSize(int currentFileNodeSize, int currentFileNodeIndex)
        {
            int index = 0;
            foreach (var block in blocks)
            {
                if (index >= currentFileNodeIndex)
                    return null;

                if (block.FileId == EMPTY_BLOCK && block.Size >= currentFileNodeSize)
                    return blocks.Find(block);

                index++;
            }
            return null;
        }

        private (int index, LinkedListNode<MemoryBlock>? node) GetCurrentFileNode(int currentFileId)
        {
            int index = 0;
            foreach (var block in blocks)
            {
                if (block.FileId == currentFileId)
                    return (index, blocks.Find(block));

                index++;
            }
            return (index, null);
        }

        private void MergeEmptyBlocks()
        {
            LinkedListNode<MemoryBlock> currentBlockNode = blocks.First;
            LinkedListNode<MemoryBlock> lastBlockNode = null;

            while (currentBlockNode != null)
            {
                if (currentBlockNode.Value.FileId == EMPTY_BLOCK && lastBlockNode != null && lastBlockNode.Value.FileId == EMPTY_BLOCK)
                {
                    currentBlockNode.Value.Size += lastBlockNode.Value.Size;
                    blocks.Remove(lastBlockNode);
                }
                lastBlockNode = currentBlockNode;
                currentBlockNode = currentBlockNode.Next;
            }
        }

        public override double CalculateChecksum()
        {
            double checksum = 0;
            int blockVirtualIndex = 0;
            foreach (var block in blocks)
            {
                for (int i = 0; i < block.Size; i++)
                {
                    if (block.FileId != EMPTY_BLOCK)
                        checksum += block.FileId * blockVirtualIndex;
                    blockVirtualIndex++;
                }
            }
            return checksum;
        }
    }
}
