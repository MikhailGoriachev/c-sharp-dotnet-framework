#pragma once

// Базовый абстрактный класс Юнит
class Unit
{
public:

	// размер ID
	static const int N_ID = 10;

#pragma region Конструкторы, деструктор и операция присваивания

	// конструктор по умолчанию
	Unit() = default;

	// конструктор копирующий 
	Unit(const Unit& unit) = default;

	// деструктор 
	virtual ~Unit() = default;

	// перегрузка операции присваивания
	Unit& operator=(const Unit& unit) = default;

#pragma endregion

#pragma region Методы 

	// добавить воина или отряд
	virtual void addUnit(Unit* unit) = 0;

	// удалить воина или отряд
	virtual void removeWarrior(string id) = 0;

	// сила воина или отряда
	virtual int power() = 0;

	// здоровье юнита 
	virtual int health() = 0;

	// получить ID воина или отряда
	virtual string getID() = 0;

	// получить название юнита
	virtual string getName() = 0;

	// вывод в таблицу
	virtual void showElem(int num) = 0;

#pragma endregion
};

