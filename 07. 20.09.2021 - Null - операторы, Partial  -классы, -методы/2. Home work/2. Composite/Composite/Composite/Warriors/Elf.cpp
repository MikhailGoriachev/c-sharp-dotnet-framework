#include "Elf.h"

// ����������� �� ���������
Elf::Elf() : id_(generID(Unit::N_ID)), name_("����") { }

#pragma region ������ 

// �������� ����� ��� �����
void Elf::addUnit(Unit* unit) { throw exception("��� �������� �� �������������! �������� ���� ����� ������ � �����"); }

// ������� ����� ��� �����
void Elf::removeWarrior(string id) { throw exception("��� �������� �� �������������! ������� ���� ����� ������ �� ������"); }

// ���� ����� ��� ������
int Elf::power() { return 7; }

// �������� ����� 
int Elf::health() { return 20; }

// �������� ID ����� ��� ������
string Elf::getID() { return id_; }

// �������� �������� �����
string Elf::getName() { return name_; }

// ����� � �������
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

	// ��������� ����� �� ���������
	setColor(mainColor);
}