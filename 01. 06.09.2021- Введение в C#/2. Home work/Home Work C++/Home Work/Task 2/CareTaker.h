#pragma once

#include "Object.h"

// Класс Контейнер для хранения объекта
class CareTaker
{
	// хранимый объект
	Object* obj_;

public:

	// сеттер obj_
	void setObj(Object* value);

	// геттер obj_
	Object* getObj() const;
};

