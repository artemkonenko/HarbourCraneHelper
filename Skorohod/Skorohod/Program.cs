using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skorohod
{
    using FuzzyDistribution = Dictionary<int, double>;

    class Program
    {
        enum DeviationFuzzyTypes { StronglyLeft, Left, Right, StronglyRight };

        static void Main(string[] args)
        {
            /* Нечеткие правила для параметра ОТКЛОНЕНИЕ от конечной вертикали */
            FuzzyGraph deviationGraph = new FuzzyGraph();
            deviationGraph.addFuzzyTrapeze((int) DeviationFuzzyTypes.StronglyLeft, new FuzzyTrapeze(-100, -100, -5, -3));
            deviationGraph.addFuzzyTrapeze((int) DeviationFuzzyTypes.Left, new FuzzyTrapeze(-5, -3, -1, 1));
            deviationGraph.addFuzzyTrapeze((int) DeviationFuzzyTypes.Right, new FuzzyTrapeze(-1, 1, 3, 5));
            deviationGraph.addFuzzyTrapeze((int) DeviationFuzzyTypes.StronglyRight, new FuzzyTrapeze(3, 5, 100, 100));

            FuzzyDistribution deviationDistribution = deviationGraph.getFuzzyDistribution(0);

            System.Console.ReadLine();
        }
    }
}
