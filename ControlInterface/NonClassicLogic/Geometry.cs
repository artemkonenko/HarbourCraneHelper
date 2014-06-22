using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NonClassicLogic
{
    class Point
    {
        public double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point getPointByTwoPointsAndY(Point p1, Point p2, double y) // нахождение координаты точки на прямой по У
        {
            return new Point((y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) - p1.x, y);
        }

        public static Point getIntersection(Point p11, Point p12, Point p21, Point p22) // нахождение точки пересечения прямых заданных точками
        {
            double a1, b1, c1, a2, b2, c2;
            a1 = p12.y - p11.y;
            b1 = p11.x - p12.x;
            c1 = -a1 * p11.x - b1 * p11.y;
            a2 = p22.y - p21.y;
            b2 = p21.x - p22.x;
            c2 = -a2 * p21.x - b2 * p21.y;
            double z1 = a1 * b2 - a2 * b1;
            double z2 = a1 * b2 - a2 * b1;
            if (z1 != 0 && z2 != 0)
            {
                return new Point(-(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1), -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1));
            }
            else
            {
                return null;
            }
        }
    }

    class Trapeze
    {
        public Point bottomLeft, bottomRight;
        public Point topLeft, topRight;

        public Trapeze(Point bottomLeft, Point topLeft, Point topRight, Point bottomRight)
        {
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
            this.topLeft = topLeft;
            this.topRight = topRight;
        }
    }

    class FuzzyTrapeze
    {
        public double bottomLeft, bottomRight;
        public double topLeft, topRight;

        public FuzzyTrapeze(double bottomLeft, double topLeft, double topRight, double bottomRight)
        {
            this.bottomLeft = bottomLeft;
            this.bottomRight = bottomRight;
            this.topLeft = topLeft;
            this.topRight = topRight;
        }

        public Trapeze Cut(double level)        //level [0.0..1.0]
        {
            return new Trapeze(
                new Point(this.bottomLeft, 0),
                new Point(this.bottomLeft + (this.topLeft - this.bottomLeft) * level, level),
                new Point(this.topRight + (this.bottomRight - this.topRight) * level, level),
                new Point(this.bottomRight, 0)
                );
        }
    }
}
