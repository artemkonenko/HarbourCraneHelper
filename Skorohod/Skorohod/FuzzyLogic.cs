using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skorohod
{
    class FuzzyGraph
    {
        private List<FuzzyTrapeze> _list;

        public FuzzyGraph(int count)
        {
            this._list = new List<FuzzyTrapeze>(new FuzzyTrapeze[count]);
        }

        public void addFuzzyTrapeze(int type, FuzzyTrapeze ft)
        {
            this._list[type] = ft;
        }

        public List<double> getFuzzyDistribution(double x)
        {
            List<double> res = new List<double>(new double[this._list.Count]);
            for (int i = 0; i < this._list.Count; ++i) 
            {
                FuzzyTrapeze c = this._list[i];
                if (x <= c.bottomLeft || c.bottomRight <= x)
                {
                    res[i] = 0;
                    continue;
                }

                if (c.topLeft <= x && x <= c.topRight)
                {
                    res[i] = 1;
                    continue;
                }

                if (c.bottomLeft < x && x < c.topLeft)
                {
                    res[i] = (x - c.bottomLeft) / (c.topLeft - c.bottomLeft);
                    continue;
                }

                res[i] = 1 - (x - c.topRight) / (c.bottomRight - c.topRight); 
            }
            
            return res;
        }
    }
}
