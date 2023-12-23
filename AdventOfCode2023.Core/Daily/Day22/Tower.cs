using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day22
{
    public class Tower
    {
        List<Block> blocks = new List<Block>();
        int maxX;
        int maxY;

        public static Tower Parse(List<string> inputLines)
        {
            Tower result = new Tower();
            result.blocks = inputLines
                .Select(l => Block.Parse(l))
                .OrderBy(b => b.Extremity1.z)
                .ToList();

            result.maxX = result.blocks.Max(b => b.MaxX());
            result.maxY = result.blocks.Max(b => b.MaxY());

            return result;
        }

        public void MakeBlocksFall()
        {
            foreach (var block in blocks)
            {
                var nb = GetByHowMuchLayersTheBlockCanFall(block);
                block.FallBy(nb);
            }
            //for (int i = 0; i < blocks.Max(x => x.GetCurrentLayers().Max()) + 2; i++)
            //{
            //    Console.WriteLine($"Layer {i}");
            //    DebugPrintGrid(GetLayerAsGrid(i));
            //}
        }

        private int GetByHowMuchLayersTheBlockCanFall(Block block)
        {
            int lowestLayer = block.Extremity1.z;
            int fallLengh = 0;

            while(CanBlockFallOnLayer(lowestLayer - fallLengh - 1, block))
            {
                fallLengh++;
            };
             
            return fallLengh;
        }

        private bool CanBlockFallOnLayer(int layer, Block block)
        {
            if (layer <= 0) 
                return false;
            
            var blocksOnLayer = blocks.Where(b => b.GetCurrentLayers().Contains(layer));
            if (!blocksOnLayer.Any()) return true;

            var layerGrid = GetLayerAsGrid(layer);

            foreach (int i in block.GetXs())
            {
                foreach (int j in block.GetYs())
                {
                    if (layerGrid[i, j]) return false;
                }
            }

            return true;
        }

        private bool[,] GetLayerAsGrid(int layer)
        {
            var blocksOnLayer = blocks.Where(b => b.GetCurrentLayers().Contains(layer));

            bool[,] layerGrid = new bool[maxX + 1, maxY + 1];
            foreach (var blockOnLayer in blocksOnLayer)
            {
                foreach (int i in blockOnLayer.GetXs())
                {
                    foreach (int j in blockOnLayer.GetYs())
                    {
                        layerGrid[i, j] = true;
                    }
                }
            }
            return layerGrid;
        }

        private void DebugPrintGrid(bool[,] grid)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    Console.Write(grid[i,j] ? '#' : '.');
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        internal int CountBricksThatAreSafeToDesintegrate()
        {
            int count = 0;
            foreach(var block in blocks)
            {
                if(CanBeDesintegrated(block))
                    count++;
            }
            return count;
        }

        private bool CanBeDesintegrated(Block blockToDesintegrate)
        {
            var blocksOnLayerAbove = blocks.Where(b => b.GetCurrentLayers().Contains(blockToDesintegrate.Extremity2.z + 1));
            if (!blocksOnLayerAbove.Any())
                return true;

            List<Block> supportedBlocks = new List<Block>();
            foreach(var blockAbove in blocksOnLayerAbove)
            {
                if (blockToDesintegrate.IsSupporting(blockAbove))
                    supportedBlocks.Add(blockAbove);
            }

            var backupExt1 = blockToDesintegrate.Extremity1;
            var backupExt2 = blockToDesintegrate.Extremity2;
            blockToDesintegrate.Extremity1 = (-1, -1, -1);
            blockToDesintegrate.Extremity2 = (-1, -1, -1);

            bool canBeDesintegrated = !supportedBlocks.Any(b => CanBlockFallOnLayer(backupExt2.z, b));

            blockToDesintegrate.Extremity1 = backupExt1;
            blockToDesintegrate.Extremity2 = backupExt2;

            return canBeDesintegrated;
        }
    }
}
