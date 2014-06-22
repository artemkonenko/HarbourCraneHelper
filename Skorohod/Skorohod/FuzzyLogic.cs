using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skorohod
{
    class FuzzyGraph
    {
        private Dictionary<int, FuzzyTrapeze> _list;

        public FuzzyGraph()
        {
            this._list = new Dictionary<int, FuzzyTrapeze>();
        }

        public void addFuzzyTrapeze(int type, FuzzyTrapeze ft)
        {
            this._list.Add(type, ft);
        }

        public Dictionary<int, double> getFuzzyDistribution(double x)
        {
            Dictionary<int, double> res = new Dictionary<int, double>(this._list.Count);
            foreach (KeyValuePair<int, FuzzyTrapeze> entry in this._list) 
            {
                FuzzyTrapeze c = entry.Value;
                if (x <= c.bottomLeft || c.bottomRight <= x)
                {
                    res.Add(entry.Key, 0);
                    continue;
                }

                if (c.topLeft <= x && x <= c.topRight)
                {
                    res.Add(entry.Key, 1);
                    continue;
                }

                if (c.bottomLeft < x && x < c.topLeft)
                {
                    res.Add(entry.Key, (x - c.bottomLeft) / (c.topLeft - c.bottomLeft));
                    continue;
                }

                res.Add(entry.Key, 1 - (x - c.topRight) / (c.bottomRight - c.topRight)); 
            }
            
            return res;
        }
    }

    class FuzzyLogic
    {
    }
}
