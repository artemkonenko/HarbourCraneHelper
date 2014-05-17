#include <cstdlib>

#ifndef __OUTERWORLD__H_
#define __OUTERWORLD__H_

/*
* Везде размерность это метры, метры в секунду и радианы.
 */

class Wind
{
	double state = 0;
	long tick = 0;
	double maxStrength = 1;
public:
	double operator() ();
};

class Wave
{
	long tick = 0;
	double state = 0;
	double maxHeight = 0.20;
public:
	double operator() ();
};

#endif