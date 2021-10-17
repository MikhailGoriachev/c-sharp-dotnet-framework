#pragma once

#include "../pch.h"
#include "../Utils.h"

#include <map>

#include "Unit.h"

//  ласс отр€д
class Squard : public Unit
{
	// id
	string id_;

	// название юнита 
	string name_;

	// коллекци€ юнитов
	map<string, Unit*> units_;

public:

#pragma region  онструкторы, деструктор и операци€ присваивани€

	// конструктор по умолчанию
	Squard();

	// конструктор копирующий
	Squard(const Squard& Squard) = default;

	// детсруктор 
	virtual ~Squard() override;

	// перегрузка операции рисваивани€
	Squard& operator=(const Squard & Squard) = default;

#pragma endregion

#pragma region ћетоды 

	// добавить воина или отр€д
	virtual void addUnit(Unit* unit) override;

	// удалить воина или отр€д
	virtual void removeWarrior(string id) override;

	// сила воина или отр€да
	virtual int power() override;

	// здоровье юнита 
	virtual int health() override;

	// получить ID воина или отр€да
	virtual string getID() override;

	// получить название юнита
	virtual string getName() override;

	// вывод в таблицу
	virtual void showElem(int num) override;
};

