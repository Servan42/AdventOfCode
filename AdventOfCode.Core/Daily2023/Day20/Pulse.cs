﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day20
{
    public class Pulse
    {
        public Pulse(bool isHigh, Module emmiter)
        {
            IsHigh = isHigh;
            Emmiter = emmiter;
        }

        public bool IsHigh { get; set; } = false;
        public Module Emmiter { get; set; }
    }
}
