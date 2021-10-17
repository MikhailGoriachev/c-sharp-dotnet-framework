#pragma once
#include "Context.h"

// Базовый класс
class BaseExpression
{
public:
	BaseExpression() {}
	virtual ~BaseExpression() {}

	virtual void Interpret(Context* context) = 0;
};

