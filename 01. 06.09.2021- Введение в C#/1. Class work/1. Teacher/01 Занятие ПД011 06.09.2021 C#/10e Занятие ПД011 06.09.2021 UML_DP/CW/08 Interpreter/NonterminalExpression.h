#pragma once
#include "BaseExpression.h"
#include <iostream>
using namespace std;

// Нетерминальное выражение, представляет правило грамматики. Для каждого отдельного 
// правила грамматики создается свой объект NonterminalExpression.
class NonterminalExpression : public BaseExpression
{
public:
	NonterminalExpression() {}
	virtual ~NonterminalExpression() {}

	void Interpret(Context* context) {
		cout << "\nИнтерпретировано не терминальное выражение\n";
	}
};

