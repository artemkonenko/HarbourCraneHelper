using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class Expert
    {
        private FuzzyLogic logic = new FuzzyLogic(
            OuterWorld.maxHorizontalCraneSpeed * OuterWorld.timeDimension,
            OuterWorld.maxRobeDownSpeed * OuterWorld.timeDimension);
        public double getCranePos( double cargoHorizontalMove, double distance ) // Сопротивление ветру
        {            
            return this.logic.getDeviationCompensation(cargoHorizontalMove, distance); //ветер
            //return -1 * cargoHorizontalMove;
        }

        public double getMaxCargoSpeed( double cargoHorizontalMove, double distance )
        {            
            return this.logic.getHeightCompensation(cargoHorizontalMove, distance); //спуск
            //return distance > 5 ? 5 : distance;
        }

        public bool isTimeToRelease( double nextDistance )
        {
            if (nextDistance < 0.1)
            {
                return true;
            }
            return false;
        }
    }
}
