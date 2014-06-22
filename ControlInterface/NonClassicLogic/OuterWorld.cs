using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class OuterWorld
    {
        /* Параметры крана */
        public static readonly double maxRobeDownSpeed = 3.0;           // м/c
        public static readonly double maxRobeUpSpeed = 1.0;             // м/c
        public static readonly double maxHorizontalCraneSpeed = 4.0;    // м/c


        /* Параметры внешнего мира */
        public static readonly double maxStrength = 15;     // м/c
        public static readonly double maxHeight = 8;        // м
        public static readonly double craneHeight = 30;     // м


        /* Параметры системы */
        const double timeDimension = 0.1; // Разрешение системы/частота опроса





        /* Получение данных о среде */
        public double cargoHorizontalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return Math.Sign(getWind()) * getRobeLenght() * Math.Sin(alpha);
        }

        public double getDistance()
        {
            return craneHeight + cargoVerticalMove() - getRobeLenght();
        }

        public void release() // Отпустить груз на палубу.
        {
            // todo: check, that we don't crash our niggas.
            if (Math.Sqrt(2 * 10 * getDistance()) > 2)
            {
                throw new Exception("Мы продолбали груз.");
            }
        }


        /* Управления системой */
        public void moveRobe(double diff)
        {
            if (diff > maxRobeDownSpeed * timeDimension)
                diff = maxRobeDownSpeed * timeDimension;
            else if (diff < maxRobeUpSpeed * timeDimension)
                diff = maxRobeUpSpeed * timeDimension;

            robeLenght += diff;
        }





        /* Физические расчеты */
        double cargoSquare = 31.589472; // м^2
        double cargoWeight = 30.400;      // кг

        public double windStrenght()
        {
            return getWind() * getWind() * 0.61 * cargoSquare;
        }

        public double getWind()
        {
            return maxStrength * Math.Cos(Math.Sqrt(tick));// -maxStrength * Math.Tan(tick / 2);
        }

        public double getWave()
        {
            return maxHeight * Math.Sin(Math.Sqrt(tick));// -maxHeight * Math.Cos(tick / 2);
        }

        public double cargoVerticalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return getRobeLenght() * (1 - Math.Cos(alpha));
        }


        /* Мусор */
        public void setTick( long t )
        {
            tick = t;
        }

        public double getRobeLenght()
        {
            return robeLenght;
        }

        public double getCraneHeight()
        {
            return craneHeight;
        }

        double windState = 0;
        double waveState = 0;

        double robeLenght = 0;
        long tick = 0;
    }
}
