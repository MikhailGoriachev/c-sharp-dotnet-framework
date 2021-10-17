#include "Elf.h"

// конструктор по умолчанию
Elf::Elf() : id_(generID(Unit::N_ID)), name_("Эльф") { }

#pragma region Методы 

// добавить воина или отряд
void Elf::addUnit(Unit* unit) { throw exception("Эта операция не поддерживется! Добавить Юнит можно только в отряд"); }

// удалить воина или отряд
void Elf::removeWarrior(string id) { throw exception("Эта операция не поддерживется! Удалить Юнит можно только из отряда"); }

// сила воина или отряда
int Elf::power() { return 7; }

// здоровье юнита 
int Elf::health() { return 20; }

// получить ID воина или отряда
string Elf::getID() { return id_; }

// получить название юнита
string Elf::getName() { return name_; }

// вывод в таблицу
void Elf::showElem(int num)
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