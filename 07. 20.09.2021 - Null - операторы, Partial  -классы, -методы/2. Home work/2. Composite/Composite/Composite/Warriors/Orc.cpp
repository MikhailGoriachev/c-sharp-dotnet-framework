#include "Orc.h"

// ����������� �� ���������
Orc::Orc() : id_(generID(Unit::N_ID)), name_("���") { }

#pragma region ������ 

// �������� ����� ��� �����
void Orc::addUnit(Unit* unit) { throw exception("��� �������� �� �������������! �������� ���� ����� ������ � �����"); }

// ������� ����� ��� �����
void Orc::removeWarrior(string id) { throw exception("��� �������� �� �������������! ������� ���� ����� ������ �� ������"); }

// ���� ����� ��� ������
int Orc::power() { return 4; }

// �������� ����� 
int Orc::health() { return 30; }

// �������� ID ����� ��� ������
string Orc::getID() { return id_; }

// �������� �������� �����
string Orc::getName() { return name_; }

// ����� � �������
void Orc::showElem(int num)
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
