#pragma once

#include "Object.h"

// ����� ��������� ��� �������� �������
class CareTaker
{
	// �������� ������
	Object* obj_;

public:

	// ������ obj_
	void setObj(Object* value);

	// ������ obj_
	Object* getObj() const;
};

