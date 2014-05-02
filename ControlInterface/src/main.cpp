#include <cstdlib>
#include <iostream>

#include "outerworld.h"
#include "expertsystem.h"

using namespace std;

int main()
{
	srand( time(NULL) );

	Wind wind;
	Wave wave;
	DummyExpert expert;
	double hSpeed = 1;

	double dist = 100;

	for ( int i=0; i < 100; ++i )
	{
		double wi = wind();
		double wv = wave();
		pair<double, double> res = expert.resolutution(wi, wv, dist - wv);
		cout << "Distance: " << dist-wv << " Wind: " << wi << " Wave: " << wv << " => " << res.first << ", " << res.second;
		dist -= hSpeed + res.second;

		if ( dist < 0 )
		{
			cout << " Fuck, we destroy our ship! ";
		}

		cout << endl;
	}

	return 0;
}
