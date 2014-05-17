#include <iostream>
#include "expertsystem.h"

using namespace std;

/**
* return <корректировка продольной скорости груза, корректировка вертикальной скорости груза>
*/
std::pair<double, double> DummyExpert::resolution(double wind, double wave, double distance, double hSpeed)
{
	if ( distance > 3 )
		return make_pair( -wind, 0);
	else
		return make_pair( -wind, -hSpeed + distance / 10);
}
