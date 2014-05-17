#ifndef __EXPERTSYSTEM_H_
#define __EXPERTSYSTEM_H_

// Наиболее наивный эксперт
class DummyExpert
{

public:
	std::pair<double, double> resolution(double wind, double wave, double distance, double hSpeed);
};

#endif