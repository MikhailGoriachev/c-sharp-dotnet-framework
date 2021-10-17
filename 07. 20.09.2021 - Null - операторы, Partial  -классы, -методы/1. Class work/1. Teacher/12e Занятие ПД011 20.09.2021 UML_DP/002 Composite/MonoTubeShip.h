#pragma once
#include "Unit.h"

// однотрубный
class MonoTubeShip :public Unit
{
public:

	MonoTubeShip() {}
	virtual ~MonoTubeShip() {}
	
	int GetPower() const { return 1; }

	void AddUnit(Unit* p) {
		throw "Ёта операци€ не поддерживаетс€!";
	}
};

