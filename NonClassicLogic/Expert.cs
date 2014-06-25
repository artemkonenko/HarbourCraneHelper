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
            OuterWorld.maxRopeDownSpeed * OuterWorld.timeDimension);

        public double getCraneDeviationCompensation( double cargoHorizontalMove, double distance ) // Сопротивление ветру
        {            
            return this.logic.getDeviationCompensation(cargoHorizontalMove, distance); //ветер
        }

        public double getMaxCargoSpeed( double cargoHorizontalMove, double distance )
        {            
            return this.logic.getHeightCompensation(cargoHorizontalMove, distance); //спуск
        }
    }
}
