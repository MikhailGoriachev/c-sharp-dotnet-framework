#include "People.h"

// конструктор по умолчанию
People::People() : id_(generID(Unit::N_ID)), name_("Человек") { }

#pragma region Методы 

// добавить воина или отряд
void People::addUnit(Unit* unit) { throw exception("Эта операция не поддерживется! Добавить Юнит можно только в отряд"); }

// удалить воина или отряд
void People::removeWarrior(string id) { throw exception("Эта операция не поддерживется! Удалить Юнит можно только из отряда"); }

// сила воина или отряда
int People::power() { return 15; }

// здоровье юнита 
int People::health() { return 80; }

// получить ID воина или отряда
string People::getID() { return id_; }

// получить название юнита
string People::getName() { return name_; }

// вывод в таблицу
void People::showElem(int num) 
{
	cout << color(LTCYAN_ON_BLACK) << "          | "
		<< color(LTBLACK_ON_BLACK) << setw(2) << num
		<< color(LTCYAN_ON_BLACK) << " | " << left
		<< color(LTGREEN_ON_BLACK) << setw(20) << name_
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(LTGREEN_ON_BLACK) << setw(10) << id_
		<< color(LTCYAN_ON_BLACK) << " | " << right
		<< color(LTGREEN_ON_BLACK) << setw(10) << power()
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(LTGREEN_ON_BLACK) << setw(10) << health()
		<< color(LTCYAN_ON_BLACK) << " |\n";

	// установка цвета по умолчанию
	setColor(mainColor);
}

#pragma endregion
