#include "Dwarf.h"

// ����������� �� ���������
Dwarf::Dwarf() : id_(generID(Unit::N_ID)), name_("����") { }

#pragma region ������ 

// �������� ����� ��� �����
void Dwarf::addUnit(Unit* unit) { throw exception("��� �������� �� �������������! �������� ���� ����� ������ � �����"); }

// ������� ����� ��� �����
void Dwarf::removeWarrior(string id) { throw exception("��� �������� �� �������������! ������� ���� ����� ������ �� ������"); }

// ���� ����� ��� ������
int Dwarf::power() { return 8; }

// �������� ����� 
int Dwarf::health() { return 16; }

// �������� ID ����� ��� ������
string Dwarf::getID() { return id_; }

// �������� �������� �����
string Dwarf::getName() { return name_; }

// ����� � �������
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

	// ��������� ����� �� ���������
	setColor(mainColor);
}
