#pragma once
#include "BaseExpression.h"
#include <iostream>
using namespace std;

// ������������ ���������, ��������� ����� Interpret() ��� 
// ������������ �������� ����������. ��� ������� 
// ������� ���������� ��������� ���� ������ TerminalExpression
class TerminalExpression : public BaseExpression
{
public:
	TerminalExpression() {}
	virtual ~TerminalExpression() {}


	void Interpret(Context* context){
		cout << "\n���������������� ������������ ���������\n";
	}
};

