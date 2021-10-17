#pragma once
#include "Unit.h"
#include <vector>
using namespace std;

// целое
class CompositeUnit : public Unit
{
	vector<Unit*> fleet;

public:
	CompositeUnit() {}
	virtual ~CompositeUnit() {
		for (size_t i = 0; i<fleet.size(); ++i)
			delete fleet[i];
	} // ~CompositeUnit

	// вычислить "мощность" флота
	int GetPower() const {
		int amount = 0;
		for (size_t i = 0; i < fleet.size(); i++) 
			amount += fleet[i]->GetPower();
		
		return amount;
	} // GetPower

	void AddUnit(Unit* p) { fleet.push_back(p); }
};


