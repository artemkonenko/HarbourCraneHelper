#include <cstdlib>
#include <cmath>

#include "outerworld.h"

using namespace std;

double Wind::operator()()
{
	++tick;
	return state += maxStrength * cos(tick) - maxStrength * tan(tick/2);
}


double Wave::operator()()
{
	++tick;
	return state += maxHeight * sin(tick) - maxHeight * cos(tick/2);
}
