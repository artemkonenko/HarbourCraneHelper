#include <cstdlib>

#ifndef __OUTERWORLD__H_
#define __OUTERWORLD__H_

class Wind
{
	double state = 0;
	long tick = 0;
public:
	double operator() ();
};

class Wave
{
	long tick = 0;
	double state = 0;
public:
	double operator() ();
};

#endif