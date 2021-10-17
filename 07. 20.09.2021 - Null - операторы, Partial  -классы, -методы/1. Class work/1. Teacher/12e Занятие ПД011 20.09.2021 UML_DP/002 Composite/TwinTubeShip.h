#pragma once
#include "Unit.h"
class TwinTubeShip :public Unit
{
public:

	TwinTubeShip() {}
	virtual ~TwinTubeShip() {}
	
	int GetPower() const {	return 2; }

	void AddUnit(Unit* p) {
		throw "Эта операция не поддерживается!";
	}
};

