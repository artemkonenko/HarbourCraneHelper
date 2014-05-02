#include <iostream>
#include "expertsystem.h"

using namespace std;

/**
* return <корректировка продольной скорости груза, корректировка вертикальной скорости груза>
*/
pair<double, double> DummyExpert::resolutution(double wind, double wave, double distance)
{
	if ( distance > 3 )
		return make_pair( -wind, 0);
	else
		return make_pair( -wind, -distance / 10);
}
