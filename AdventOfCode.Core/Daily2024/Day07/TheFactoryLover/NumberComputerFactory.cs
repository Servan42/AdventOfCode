using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2024.Day07.TheFactoryLover
{
    internal class NumberComputerFactory
    {
        public NumberComputer BuildNumberComputer(int part)
        {
            switch(part)
            {
                case 1:
                    return new NumberComputerPart1();
                case 2:
                    return new NumberComputerPart2();
                default:
                    throw new ArgumentException(nameof(part));
            }
        }
    }
}
