using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class ExpertPoint //точки на графике
    {
        public double x, y;
        public ExpertPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Expert
    {
        private static double signSquare(ExpertPoint p1, ExpertPoint p2, ExpertPoint p3) //знаковая площадь треугольника
        {
            return ((p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x)) / 2;
        }

        private static ExpertPoint centroid(ExpertPoint p1, ExpertPoint p2, ExpertPoint p3) // центроид треугольника
        {
            return new ExpertPoint((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3);
        }

        public static ExpertPoint centerOfMass(List<ExpertPoint> points) // нахождение центра массы
        {
            ExpertPoint p = new ExpertPoint(0, 0); // произвольная точка для подсчета
            double x = 0;
            double y = 0;
            double s = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                double s1 = signSquare(p, points[i], points[i + 1]);
                ExpertPoint r = centroid(p, points[i], points[i + 1]);
                x += r.x * s1;
                y += r.y * s1;
                s += s1;
            }
            if (s != 0)
            {
                return new ExpertPoint(x / s, y / s);
            }
            else
            {
                return new ExpertPoint(0, 0);
            }
        }

        

        // -----
        public double getCranePos( double cargoHorizontalMove )
        {
            return -1 * cargoHorizontalMove;
        }

        public double getMaxCargoSpeed( double lenght, double distance )
        {
            return distance - lenght > 5 ? 5 : distance - lenght;
        }
    }
}
