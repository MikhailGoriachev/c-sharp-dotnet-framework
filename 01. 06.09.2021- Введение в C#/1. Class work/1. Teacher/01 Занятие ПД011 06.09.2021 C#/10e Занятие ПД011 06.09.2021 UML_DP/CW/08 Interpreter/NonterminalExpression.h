#pragma once
#include "BaseExpression.h"
#include <iostream>
using namespace std;

// �������������� ���������, ������������ ������� ����������. ��� ������� ���������� 
// ������� ���������� ��������� ���� ������ NonterminalExpression.
class NonterminalExpression : public BaseExpression
{
public:
	NonterminalExpression() {}
	virtual ~NonterminalExpression() {}

	void Interpret(Context* context) {
		cout << "\n���������������� �� ������������ ���������\n";
	}
};

