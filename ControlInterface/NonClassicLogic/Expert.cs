using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class Expert
    {
        private static double signSquare(Point p1, Point p2, Point p3) //знаковая площадь треугольника
        {
            return ((p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x)) / 2;
        }

        private static Point centroid(Point p1, Point p2, Point p3) // центроид треугольника
        {
            return new Point((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3);
        }

        public static Point centerOfMass(List<Point> points) // нахождение центра массы
        {
            Point p = new Point(0, 0); // произвольная точка для подсчета
            double x = 0;
            double y = 0;
            double s = 0;
            for (int i = 0; i < points.Count - 1; i++)
            {
                double s1 = signSquare(p, points[i], points[i + 1]);
                Point r = centroid(p, points[i], points[i + 1]);
                x += r.x * s1;
                y += r.y * s1;
                s += s1;
            }
            if (s != 0)
            {
                return new Point(x / s, y / s);
            }
            else
            {
                return new Point(0, 0);
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
