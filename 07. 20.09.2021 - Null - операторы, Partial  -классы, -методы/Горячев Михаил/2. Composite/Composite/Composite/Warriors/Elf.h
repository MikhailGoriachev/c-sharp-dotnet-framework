#pragma once
#include "../pch.h"
#include "../Utils.h"

#include "Unit.h"

class Elf : public Unit
{
	// id
	string id_;

	// название юнита 
	string name_;

public:

#pragma region Конструкторы, деструктор и операция присваивания

	// конструктор по умолчанию
	Elf();

	// конструктор копирующий
	Elf(const Elf& elf) = default;

	// детсруктор 
	virtual ~Elf() override = default;

	// перегрузка операции рисваивания
	Elf& operator=(const Elf & elf) = default;

#pragma endregion

#pragma region Методы 

	// добавить воина или отряд
	virtual void addUnit(Unit* unit) override;

	// удалить воина или отряд
	virtual void removeWarrior(string id) override;

	// сила воина или отряда
	virtual int power() override;

	// здоровье юнита 
	virtual int health() override;

	// получить ID воина или отряда
	virtual string getID() override;

	// получить название юнита
	virtual string getName() override;

	// вывод в таблицу
	virtual void showElem(int num) override;

};

