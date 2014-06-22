using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class OuterWorld
    {
        double windState = 0;
        double waveState = 0;

	    long tick = 0;
	    double maxStrength = 15; // м/c
        double maxHeight = 8;    // м

        public double getWind()
        {
            return maxStrength * Math.Cos(tick);// -maxStrength * Math.Tan(tick / 2);
        }

        public double getWave()
        {
            return maxHeight * Math.Sin(tick);// -maxHeight * Math.Cos(tick / 2);
        }

        public void setTick( long t )
        {
            tick = t;
        }

    }
}
