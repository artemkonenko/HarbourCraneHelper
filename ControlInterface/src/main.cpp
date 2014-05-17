#include <cstdlib>
#include <iostream>

#include "outerworld.h"
#include "expertsystem.h"

using namespace std;

int main() {
	srand(time(NULL));

	Wind wind;
	Wave wave;
	DummyExpert expert;
	double hSpeed = 1;

	double dist = 100;

	int i = 0;
	//for ( int i=0; i < 200; ++i )
	while (true) {
		cout << "Step: " << i++ << ": ";
		double wi = wind();
		double wv = wave();

		pair<double, double> res = expert.resolution(wi, wv, dist - wv, hSpeed);
		cout << "Distance: " << dist-wv << " Wind: " << wi << " Wave: " << wv << " => +" << res.first << "m/s wS, " << res.second << "m/s hS";
		dist -= hSpeed + res.second;
		cout << " => next distance: " << dist;

		if (dist - wv >= 0 && dist - wv <= 0.01) {
			cout << "Yes! We done." << endl;
			break;
		}

		if (dist - wv < 0) {
			cout << " Fuck, we destroy our ship! ";
		}

		cout << endl;
	}

	return 0;
}
