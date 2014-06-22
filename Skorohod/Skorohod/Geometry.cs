using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Skorohod
{
    class Point
    {
        public double x, y;

        public Point(double x, double y)
        {
            this.x = x;
            this.y = y;
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
}
