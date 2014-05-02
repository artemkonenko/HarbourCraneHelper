#include <cstdlib>
#include <cmath>

#include "outerworld.h"

using namespace std;

double Wind::operator()()
{
	++tick;
	return state += 4 * cos(tick) - ( rand() % 12 > 7 ? 3 : 1 ) * sin(tick);
}


double Wave::operator()()
{
	++tick;
	return state += 9 * sin(tick) + ( rand() % 31 > 28 ? 4 : 1 ) * cos(tick);
}
