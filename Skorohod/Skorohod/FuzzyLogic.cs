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
    }

    class FuzzyLogic
    {
    }
}
