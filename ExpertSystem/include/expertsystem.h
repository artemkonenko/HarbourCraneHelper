#ifndef __EXPERTSYSTEM_H_
#define __EXPERTSYSTEM_H_

// Наиболее наивный эксперт
class DummyExpert
{

public:
	std::pair<double, double> resolutution( double wind, double wave, double distance );
};

#endif