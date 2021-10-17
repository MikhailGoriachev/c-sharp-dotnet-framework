#pragma once
#include "Unit.h"
class TripleTubeShip :	public Unit
{
public:

	TripleTubeShip() {}
	virtual ~TripleTubeShip() {}
	
	int GetPower() const { return 3; }

	void AddUnit(Unit* p) {
		throw "Эта операция не поддерживается!";
	}
};

