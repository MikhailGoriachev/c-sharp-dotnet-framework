#pragma once
#include "Context.h"

// ������� �����
class BaseExpression
{
public:
	BaseExpression() {}
	virtual ~BaseExpression() {}

	virtual void Interpret(Context* context) = 0;
};

