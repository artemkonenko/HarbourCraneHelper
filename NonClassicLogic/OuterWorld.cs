using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NonClassicLogic
{
    class OuterWorld
    {
        /* Параметры крана */
        public static readonly double maxRopeDownSpeed = 3.0;           // м/c
        public static readonly double maxRopeUpSpeed = 1.0;             // м/c
        public static readonly double maxHorizontalCraneSpeed = 4.0;    // м/c
        public static readonly double craneHeight = 30;     // м

        /* Параметры корябля */
        public static readonly double shipWidth = 32;       // м

        /* Параметры внешнего мира */
        public static readonly double maxStrength = 15;     // м/c
        public static readonly double maxHeight = 8;        // м

        /* Параметры системы */
        public static readonly double timeDimension = 0.1; // Разрешение системы/частота опроса
        public static readonly bool isLoggingEnable = false; // Включение логгирования

        /* Получение данных о среде */
        public double cargoHorizontalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return Math.Sign(getWind()) * getRopeLenght() * Math.Sin(alpha);
        }

        public double getDistance()
        {
            return craneHeight + cargoVerticalMove() - getRopeLenght() - getWave();
        }

        public bool release() // Отпустить груз на палубу.
        {
            saveLog("Release");
            // todo: check, that we don't crash our niggas.
            if (Math.Abs(Math.Sqrt(2 * 10 * getDistance())) > 0.1 || Math.Abs(cargoHorizontalMove() + getCraneHorizontalPos()) > shipWidth/2)
            {
                return false;
            }
            return true;
        }

        /* Управления системой */
        public void moveRope(double diff)
        {
            if (diff > maxRopeDownSpeed * timeDimension)
                diff = maxRopeDownSpeed * timeDimension;
            else if (diff < -1 * maxRopeUpSpeed * timeDimension)
                diff = -1 * maxRopeUpSpeed * timeDimension;

            ropeLenght += diff;
            saveLog("Move Robe");
        }

        public void moveCraneHorizontal(double diff)
        {
            if (Math.Abs(diff) > maxHorizontalCraneSpeed * timeDimension)
                diff = Math.Sign(diff) * maxHorizontalCraneSpeed * timeDimension;

            craneHorizontalPos += diff;
            saveLog("Move Crane Horizontal");
        }

        /* Физические расчеты */
        double cargoSquare = 31.589472; // м^2
        double cargoWeight = 30400;      // кг

        public double windStrenght()
        {
            return getWind() * getWind() * 0.61 * cargoSquare;
        }

        public double getWind()
        {
            return maxStrength * Math.Cos(Math.Sqrt(tick * timeDimension * 10));// -maxStrength * Math.Tan(tick / 2);
        }

        public double getWave()
        {
            return maxHeight * Math.Sin(Math.Sqrt(tick * timeDimension * 10));// -maxHeight * Math.Cos(tick / 2);
        }

        public double cargoVerticalMove()
        {
            double alpha = Math.Atan(windStrenght() / (cargoWeight * 10));
            return getRopeLenght() * (1 - Math.Cos(alpha));
        }

        //сохранение лога данных в файле
        private void saveLog(String message)
        {
            if (!isLoggingEnable)
                return;
            FileStream file = new FileStream("log.txt", FileMode.Append);
            StreamWriter fileWriter = new StreamWriter(file);
            fileWriter.WriteLine("**********************************************************************");
            fileWriter.WriteLine(message);
            fileWriter.WriteLine("current tick = " + this.tick);
            fileWriter.WriteLine("current wind = " + this.getWind());
            fileWriter.WriteLine("current wave = " + this.getWave());
            fileWriter.WriteLine("current distance = " + this.getDistance());
            fileWriter.WriteLine("current ropeLength = " + this.getRopeLenght());
            fileWriter.WriteLine("current Crane Horizontal Position = " + this.getCraneHorizontalPos());
            fileWriter.WriteLine("**********************************************************************");
            fileWriter.Close();
            file.Close();
        }

        /* Мусор */
        public void setTick( long t )
        {
            tick = t;
        }

        public double getRopeLenght()
        {
            return ropeLenght;
        }

        public double getCraneHorizontalPos()
        {
            return craneHorizontalPos;
        }

        public double getCraneHeight()
        {
            return craneHeight;
        }

        double ropeLenght = 0;
        double craneHorizontalPos = 0;
        long tick = 0;
    }
}
