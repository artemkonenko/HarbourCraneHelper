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
        private double maxDeviationSpeed = 4.0;
        private double maxHeightSpeed = 2.0;

        /* Состояния */
        private enum DeviationFuzzyTypes { UnderControl, OutControl };
        private enum HeightFuzzyTypes { Dangerous, Close, Far };
        private enum SpeedFuzzyTypes { Up, DownSlow, DownFast };

        /* Нечеткие правила */
        private FuzzyGraph deviationGraph, heightGraph, speedGraph;
        /* Правила перехода */
        private int[,] rules = { 
                           { 0, 1, 2 },         //UnderControl
                           { 0, 0, 1 }          //OutControl
                           };

        public FuzzyLogic()
        {
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
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.Up, new FuzzyTrapeze(-100, -100, -1, 0));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownSlow, new FuzzyTrapeze(-1, 0, 1, 2));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownFast, new FuzzyTrapeze(1, 2, 100, 100));
        }

        public double getDeviationCompensation(double d, double h)
        {
            if (Math.Abs(d) < maxDeviationSpeed)
            {
                return -d;
            }

            return d < 0 ? maxDeviationSpeed : -maxDeviationSpeed;
        }

        public double getHeightCompensation(double d, double h)
        {
            if (h <= maxHeightSpeed)
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
            PointX p = Expert.centerOfMass(polygon);

            return p.x;
        }
    }
}
