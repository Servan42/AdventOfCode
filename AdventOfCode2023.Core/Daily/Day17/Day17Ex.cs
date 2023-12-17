using PathFinder.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Core.Daily.Day17
{
    public class Day17Ex : Exercise
    {
        public override void ComputePart1()
        {
            // 839 too high

            Output = City.ComputeOptimalHeat(0, 0, InputLines.Count - 1, InputLines[0].Length - 1, InputLines).ToString();

            //var city = City.Parse(InputLines);
            //var path = city.FindOptimalPathWithMovementConstraint(city.GetNode("0,0"), city.GetNode($"{InputLines.Count - 1},{InputLines[0].Length - 1}"));
            ////path.ForEach(n => Console.WriteLine($"{n.GetUniqueIdentifier()}  {((CityBlock)n).Heat}"));
            //Console.WriteLine(path.Skip(1).Sum(n => ((CityBlock)n).Heat));
            
            //for (int i = 0; i < InputLines.Count; i++)
            //{
            //    for (int j = 0; j < InputLines[0].Length; j++)
            //    {
            //        if (path.Select(n => n.GetUniqueIdentifier()).Contains($"{i},{j}"))
            //        { 
            //            Console.ForegroundColor = ConsoleColor.Red;
            //            Console.Write(InputLines[i][j]);
            //            Console.ForegroundColor = ConsoleColor.White;
            //        }
            //        else
            //            Console.Write(InputLines[i][j]);
            //    }
            //    Console.WriteLine();
            //}
        }

        public override void ComputePart2()
        {
            Output = City.ComputeOptimalHeat_Part2(0, 0, InputLines.Count - 1, InputLines[0].Length - 1, InputLines).ToString();

        }
    }
}
