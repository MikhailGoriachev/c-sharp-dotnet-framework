#pragma once
#include "BaseExpression.h"
#include <iostream>
using namespace std;

// терминальное выражение, реализует метод Interpret() для 
// терминальных символов грамматики. Для каждого 
// символа грамматики создается свой объект TerminalExpression
class TerminalExpression : public BaseExpression
{
public:
	TerminalExpression() {}
	virtual ~TerminalExpression() {}


	void Interpret(Context* context){
		cout << "\nИнтерпретировано терминальное выражение\n";
	}
};

