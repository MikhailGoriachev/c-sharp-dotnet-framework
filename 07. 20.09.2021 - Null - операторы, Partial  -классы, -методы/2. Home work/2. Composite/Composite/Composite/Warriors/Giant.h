#pragma once
#include "../pch.h"
#include "../Utils.h"

#include "Unit.h"

//  ласс ¬еликан
class Giant : public Unit
{
	// id
	string id_;

	// название юнита 
	string name_;

public:

#pragma region  онструкторы, деструктор и операци€ присваивани€

	// конструктор по умолчанию
	Giant();

	// конструктор копирующий
	Giant(const Giant& giant) = default;

	// детсруктор 
	virtual ~Giant() override = default;

	// перегрузка операции рисваивани€
	Giant& operator=(const Giant & giant) = default;

#pragma endregion

#pragma region ћетоды 

	// добавить воина или отр€д
	virtual void addUnit(Unit * unit) override;

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

