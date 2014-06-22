using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class Expert
    {
        private static double signSquare(PointX p1, PointX p2, PointX p3) //знаковая площадь треугольника
        {
            return ((p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x)) / 2;
        }

        private static PointX centroid(PointX p1, PointX p2, PointX p3) // центроид треугольника
        {
            return new PointX((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3);
        }

        public static PointX centerOfMass(List<PointX> PointXs) // нахождение центра массы
        {
            PointX p = new PointX(0, 0); // произвольная точка для подсчета
            double x = 0;
            double y = 0;
            double s = 0;
            for (int i = 0; i < PointXs.Count - 1; i++)
            {
                double s1 = signSquare(p, PointXs[i], PointXs[i + 1]);
                PointX r = centroid(p, PointXs[i], PointXs[i + 1]);
                x += r.x * s1;
                y += r.y * s1;
                s += s1;
            }
            if (s != 0)
            {
                return new PointX(x / s, y / s);
            }
            else
            {
                return new PointX(0, 0);
            }
        }



        private FuzzyLogic logic = new FuzzyLogic(
            OuterWorld.maxHorizontalCraneSpeed * OuterWorld.timeDimension,
            OuterWorld.maxRobeDownSpeed * OuterWorld.timeDimension);
        public double getCranePos( double cargoHorizontalMove, double distance ) // Сопротивление ветру
        {            
            return this.logic.getDeviationCompensation(cargoHorizontalMove, distance); //ветер
            //return -1 * cargoHorizontalMove;
        }

        public double getMaxCargoSpeed( double cargoHorizontalMove, double distance )
        {            
            return this.logic.getHeightCompensation(cargoHorizontalMove, distance); //спуск
            //return distance > 5 ? 5 : distance;
        }

        public bool isTimeToRelease( double nextDistance )
        {
            if (nextDistance < 0.1)
            {
                return true;
            }
            return false;
        }
    }
}
