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

        double cargoSquare = 31.589472; // м^2
        double cargoWeight = 30.400;      // кг

        double robeLenght = 0; // м

        double maxRobeDownSpeed = 3; // м/c
        double maxRobeUpSpeed = 1;   // м/c

        double craneHeight = 30; // м

        double timeDimension = 0.1; // Разрешение системы/частота опроса

        // ---
        public double getWind()
        {
            return maxStrength * Math.Cos(tick);// -maxStrength * Math.Tan(tick / 2);
        }

        public double windStrenght()
        {
            return getWind() * getWind() * 0.61 * cargoSquare;
        }

        public double cargoHorizontalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return Math.Sign(getWind()) * getRobeLenght() * Math.Sin(alpha);
        }

        public double cargoVerticalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return getRobeLenght() * ( 1 - Math.Cos(alpha));
        }

        // ---
        public double getWave()
        {
            return maxHeight * Math.Sin(tick);// -maxHeight * Math.Cos(tick / 2);
        }

        // ---
        public void setTick( long t )
        {
            tick = t;
        }


        // ---
        public double getRobeLenght()
        {
            return robeLenght;
        }

        public void moveRobe( double diff )
        {
            if (diff > maxRobeDownSpeed * timeDimension)
                diff = maxRobeDownSpeed * timeDimension;
            else if (diff < maxRobeUpSpeed * timeDimension)
                diff = maxRobeUpSpeed * timeDimension;

            robeLenght += diff;
        }

        public double getDistance()
        {
            return craneHeight - cargoVerticalMove() - getRobeLenght();
        }

        public void release() // Отпустить груз на палубу.
        {
            // todo: check, that we don't crash our niggas.
            if (Math.Sqrt(2*10*getDistance()) > 2)
            {
                throw new Exception("Мы продолбали груз.");
            }
        }

        // ---
        public double getCraneHeight()
        {
            return craneHeight;
        }
    }
}
