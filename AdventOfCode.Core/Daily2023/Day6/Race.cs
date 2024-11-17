using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Core.Daily2023.Day6
{
    public class Race
    {
        public Race(double time, double distance)
        {
            Time = time;
            Distance = distance;
        }

        public double Time { get; set; }
        public double Distance { get; set; }

        public int ComputeNumberOfWaysToBeatTheRecord()
        {
            int nbOfWays = 0;

            for(double holdTime = 0; holdTime < Time; holdTime++)
            {
                var distanceTraveled = holdTime * (Time - holdTime);
                if(distanceTraveled > Distance) nbOfWays++;
            }

            return nbOfWays;
        }
    }
}
