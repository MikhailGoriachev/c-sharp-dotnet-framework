#pragma once
#include "Unit.h"

class FourTubeShip:public Unit
{
public:

	FourTubeShip()	{}
	virtual ~FourTubeShip() {}

	int GetPower() const { return 4; }
	
	void AddUnit(Unit* p) {
		throw "Эта операция не поддерживается!";
	}
};

