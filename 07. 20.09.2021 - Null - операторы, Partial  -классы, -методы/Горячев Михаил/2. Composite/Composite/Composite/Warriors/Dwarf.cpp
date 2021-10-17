#include "Dwarf.h"

// конструктор по умолчанию
Dwarf::Dwarf() : id_(generID(Unit::N_ID)), name_("Гном") { }

#pragma region Методы 

// добавить воина или отряд
void Dwarf::addUnit(Unit* unit) { throw exception("Эта операция не поддерживется! Добавить Юнит можно только в отряд"); }

// удалить воина или отряд
void Dwarf::removeWarrior(string id) { throw exception("Эта операция не поддерживется! Удалить Юнит можно только из отряда"); }

// сила воина или отряда
int Dwarf::power() { return 8; }

// здоровье юнита 
int Dwarf::health() { return 16; }

// получить ID воина или отряда
string Dwarf::getID() { return id_; }

// получить название юнита
string Dwarf::getName() { return name_; }

// вывод в таблицу
void Dwarf::showElem(int num) 
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
