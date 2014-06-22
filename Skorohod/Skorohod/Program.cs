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
        static void Main(string[] args)
        {
            double d = 4.5, h = 2.5;

            FuzzyLogic logic = new FuzzyLogic();

            logic.getDeviationCompensation(d, h);
            logic.getHeightCompensation(d, h);


            System.Console.ReadLine();
        }
    }
}
