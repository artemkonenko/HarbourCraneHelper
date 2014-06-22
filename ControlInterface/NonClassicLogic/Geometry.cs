using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace NonClassicLogic
{
    class PointX
    {
        public double x, y;

        public PointX(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public static PointX getPointXByTwoPointXsAndY(PointX p1, PointX p2, double y) // нахождение координаты точки на прямой по У
        {
            return new PointX((y - p1.y) * (p2.x - p1.x) / (p2.y - p1.y) - p1.x, y);
        }

        public static PointX getIntersection(PointX p11, PointX p12, PointX p21, PointX p22) // нахождение точки пересечения прямых заданных точками
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
                return new PointX(-(c1 * b2 - c2 * b1) / (a1 * b2 - a2 * b1), -(a1 * c2 - a2 * c1) / (a1 * b2 - a2 * b1));
            }
            else
            {
                return null;
            }
        }
    }

    class Trapeze
    {
        public PointX bottomLeft, bottomRight;
        public PointX topLeft, topRight;

        public Trapeze(PointX bottomLeft, PointX topLeft, PointX topRight, PointX bottomRight)
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
                new PointX(this.bottomLeft, 0),
                new PointX(this.bottomLeft + (this.topLeft - this.bottomLeft) * level, level),
                new PointX(this.topRight + (this.bottomRight - this.topRight) * level, level),
                new PointX(this.bottomRight, 0)
                );
        }
    }
}
