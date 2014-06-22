using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NonClassicLogic
{
    class Expert
    {
        double cargoSquare = 31.589472; // м^2
        double cargoWeight = 30.4;      // кг

        private double windStrenght ( double windSpeed )
        {
            return windSpeed * windSpeed * 0.61 * cargoSquare;
        }

        // -----

        public double getCranePos( double windSpeed, double lenght )
        {
            return lenght * windStrenght(windSpeed) / (cargoWeight * 10);
        }

        public double getMaxCargoSpeed( double lenght, double distance )
        {
            return distance - lenght;
        }
    }
}
