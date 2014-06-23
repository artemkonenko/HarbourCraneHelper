using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
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

        public List<PointX> getPolygon(List<double> distribution)
        {
            List<PointX> res = new List<PointX>();
            if (distribution.Count != this._list.Count)
            {
                return null;
            }

            //добавил Вадик
            int j = 0;
            while (distribution[j] == 0) { j++; }

            Trapeze t1 = _list[j].Cut(distribution[j]);
            res.Add(t1.bottomLeft);
            res.Add(t1.topLeft);

            for (int i = j + 1; i < _list.Count; i++)
            {
                if (distribution[i] == 0)
                    continue;

                Trapeze t2 = _list[i].Cut(distribution[i]);
                PointX intersection = PointX.getIntersection(t1.topRight, t1.bottomRight, t2.bottomLeft, t2.topLeft);
                if (intersection != null)
                {
                    if (t1.topRight.y >= intersection.y)
                    {
                        res.Add(t1.topRight);
                        if (t2.topLeft.y > intersection.y)
                        {
                            res.Add(t2.topLeft);
                            res.Add(intersection);
                        }
                        else
                        {
                            res.Add(PointX.getPointXByTwoPointXsAndY(t1.topRight, t1.bottomRight, distribution[i]));
                        }
                    }
                    else
                    {
                        if (t2.topLeft.y > intersection.y)
                        {
                            res.Add(PointX.getPointXByTwoPointXsAndY(t2.bottomLeft, t2.topLeft, distribution[i - 1]));
                            res.Add(t2.topLeft);
                        }
                        else
                        {
                            if (t1.topRight.y > t2.topLeft.y)
                            {
                                res.Add(t1.topRight);
                                res.Add(PointX.getPointXByTwoPointXsAndY(t1.topRight, t1.bottomRight, distribution[i]));
                            }
                            else if (t1.topRight.y < t2.topLeft.y)
                            {
                                res.Add(t2.topLeft);
                                res.Add(PointX.getPointXByTwoPointXsAndY(t2.bottomLeft, t2.topLeft, distribution[i - 1]));
                            }
                        }
                    }
                }
                t1 = t2;
            }
            res.Add(t1.topRight);
            res.Add(t1.bottomRight);
            return res;
        }
    }
}
