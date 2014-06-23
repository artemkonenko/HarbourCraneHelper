using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    using FuzzyDistribution = List<double>;

    class FuzzyLogic
    {
        /* Характеристические показатели крана */
        private double maxDeviationSpeedPerTick, maxHeightSpeedPerTick;

        /* Состояния */
        private enum DeviationFuzzyTypes { UnderControl, OutControl };
        private enum HeightFuzzyTypes { Dangerous, Close, Far };
        private enum SpeedFuzzyTypes { Up, DownSlow, DownFast };

        /* Правила перехода */
        private int[,] rules = { 
                           { 0, 1, 2 },         //UnderControl
                           { 0, 0, 1 }          //OutControl
                           };
        
        private FuzzyGraph deviationGraph, heightGraph, speedGraph;

        public FuzzyLogic(double maxDeviationSpeedPerTick, double maxHeightSpeedPerTick)
        {
            this.maxDeviationSpeedPerTick = maxDeviationSpeedPerTick;
            this.maxHeightSpeedPerTick = maxHeightSpeedPerTick;

            /* Нечеткие правила для параметра ОТКЛОНЕНИЕ от конечной вертикали */
            this.deviationGraph = new FuzzyGraph(Enum.GetNames(typeof(DeviationFuzzyTypes)).Length);
            deviationGraph.addFuzzyTrapeze((int)DeviationFuzzyTypes.UnderControl, new FuzzyTrapeze(0, 0, 3, 5));
            deviationGraph.addFuzzyTrapeze((int)DeviationFuzzyTypes.OutControl, new FuzzyTrapeze(3, 5, 100, 100));

            /* Нечеткие правила для параметра РАССТОЯНИЕ до палубы */
            this.heightGraph = new FuzzyGraph(Enum.GetNames(typeof(HeightFuzzyTypes)).Length);
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Dangerous, new FuzzyTrapeze(-100, -100, 2, 3));
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Close, new FuzzyTrapeze(2, 3, 5, 6));
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Far, new FuzzyTrapeze(5, 6, 100, 100));

            /* Нечеткие правила для параметра СКОРОСТЬ подъема */
            this.speedGraph = new FuzzyGraph(Enum.GetNames(typeof(SpeedFuzzyTypes)).Length);
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.Up, new FuzzyTrapeze(-1, -1, -1, 0));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownSlow, new FuzzyTrapeze(-1, 0, 1, 2));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownFast, new FuzzyTrapeze(1, 2, 2, 2));
        }

        public double getDeviationCompensation(double d, double h)
        {
            if (Math.Abs(d) < maxDeviationSpeedPerTick)
            {
                return -d;
            }

            return d < 0 ? maxDeviationSpeedPerTick : -maxDeviationSpeedPerTick;
        }

        public double getHeightCompensation(double d, double h)
        {
            if (h <= maxHeightSpeedPerTick)
            {
                return h;
            }

            /* Вычисляем распределение для входных данных */
            FuzzyDistribution deviationDistribution = this.deviationGraph.getFuzzyDistribution(Math.Abs(d));
            FuzzyDistribution heightDistribution = this.heightGraph.getFuzzyDistribution(h);

            /* Вычисление распределение методов возможной реакции */
            FuzzyDistribution speedDistribution = new FuzzyDistribution(new double[Enum.GetNames(typeof(SpeedFuzzyTypes)).Length]);
            for (int i = 0; i < deviationDistribution.Count; ++i)
            {
                for (int j = 0; j < heightDistribution.Count; ++j)
                {
                    speedDistribution[rules[i, j]] =
                        Math.Max(speedDistribution[rules[i, j]], Math.Min(deviationDistribution[i], heightDistribution[j]));
                }
            }

            /* и тут появляется Янушка */
            List<PointX> polygon = speedGraph.getPolygon(speedDistribution);
            PointX p = this.centerOfMass(polygon);

            return p.x;
        }

        private double signSquare(PointX p1, PointX p2, PointX p3) //знаковая площадь треугольника
        {
            return ((p2.x - p1.x) * (p3.y - p1.y) - (p2.y - p1.y) * (p3.x - p1.x)) / 2;
        }

        private PointX centroid(PointX p1, PointX p2, PointX p3) // центроид треугольника
        {
            return new PointX((p1.x + p2.x + p3.x) / 3, (p1.y + p2.y + p3.y) / 3);
        }

        private PointX centerOfMass(List<PointX> PointXs) // нахождение центра массы
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
                // если у нас прямая, то мы берем среднее по Х
                x = 0;
                for (int i = 0; i < PointXs.Count; i++)
                {
                    x += PointXs[i].x;
                }
                return new PointX(x / PointXs.Count, 0);
            }
        }
    }
}
