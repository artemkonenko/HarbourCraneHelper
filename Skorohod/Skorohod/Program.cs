using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skorohod
{
    using FuzzyDistribution = List<double>;

    class Program
    {
        enum DeviationFuzzyTypes { StronglyLeft, UnderControl, StronglyRight };
        enum HeightFuzzyTypes { Dangerous, Close, Far };
        enum SpeedFuzzyTypes { Up, DownSlow, DownFast };

        static void Main(string[] args)
        {
            /* Нечеткие правила для параметра ОТКЛОНЕНИЕ от конечной вертикали */
            FuzzyGraph deviationGraph = new FuzzyGraph(Enum.GetNames(typeof(DeviationFuzzyTypes)).Length);
            deviationGraph.addFuzzyTrapeze((int)DeviationFuzzyTypes.StronglyLeft, new FuzzyTrapeze(-100, -100, -5, -3));
            deviationGraph.addFuzzyTrapeze((int)DeviationFuzzyTypes.UnderControl, new FuzzyTrapeze(-5, -3, 3, 5));
            deviationGraph.addFuzzyTrapeze((int)DeviationFuzzyTypes.StronglyRight, new FuzzyTrapeze(3, 5, 100, 100));

            /* Нечеткие правила для параметра РАССТОЯНИЕ до палубы */
            FuzzyGraph heightGraph = new FuzzyGraph(Enum.GetNames(typeof(HeightFuzzyTypes)).Length);
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Dangerous, new FuzzyTrapeze(-100, -100, 2, 3));
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Close, new FuzzyTrapeze(2, 3, 5, 6));
            heightGraph.addFuzzyTrapeze((int)HeightFuzzyTypes.Far, new FuzzyTrapeze(5, 6, 100, 100));

            /* Нечеткие правила для параметра СКОРОСТЬ подъема */
            FuzzyGraph speedGraph = new FuzzyGraph(Enum.GetNames(typeof(SpeedFuzzyTypes)).Length);
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.Up, new FuzzyTrapeze(-100, -100, 1, 0));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownSlow, new FuzzyTrapeze(-1, 0, 1, 2));
            speedGraph.addFuzzyTrapeze((int)SpeedFuzzyTypes.DownFast, new FuzzyTrapeze(1, 2, 100, 100));

            /* Правила */
            int[,] rules = { 
                           { 0, 0, 1 },         //StronglyLeft
                           { 0, 1, 2 },         //UnderControl
                           { 0, 0, 1 }          //StronglyRight
                           };

            /* Параметры */
            double d = 4.5, h = 2.5;
            FuzzyDistribution deviationDistribution = deviationGraph.getFuzzyDistribution(d);
            FuzzyDistribution heightDistribution = heightGraph.getFuzzyDistribution(h);

            /* Вычисление распределение методов возможного поведения */
            FuzzyDistribution speedDistribution = new FuzzyDistribution(new double[Enum.GetNames(typeof(SpeedFuzzyTypes)).Length]);
            for (int i = 0; i < deviationDistribution.Count; ++i )
            {
                for (int j = 0; j < heightDistribution.Count; ++j )
                {
                    speedDistribution[rules[i, j]] =
                        Math.Max(speedDistribution[rules[i, j]], Math.Min(deviationDistribution[i], heightDistribution[j]));
                }
            }
            
            /* и тут появляется Янушка */
            
            
            System.Console.ReadLine();
        }
    }
}
