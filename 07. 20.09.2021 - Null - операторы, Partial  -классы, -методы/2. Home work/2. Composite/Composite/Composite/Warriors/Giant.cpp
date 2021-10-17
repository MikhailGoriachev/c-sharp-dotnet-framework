#include "Giant.h"

// ����������� �� ���������
Giant::Giant() : id_(generID(Unit::N_ID)), name_("�������") { }

#pragma region ������ 

// �������� ����� ��� �����
void Giant::addUnit(Unit* unit) { throw exception("��� �������� �� �������������! �������� ���� ����� ������ � �����"); }

// ������� ����� ��� �����
void Giant::removeWarrior(string id) { throw exception("��� �������� �� �������������! ������� ���� ����� ������ �� ������"); }

// ���� ����� ��� ������
int Giant::power() { return 20; }

// �������� ����� 
int Giant::health() { return 120; }

// �������� ID ����� ��� ������
string Giant::getID() { return id_; }

// �������� �������� �����
string Giant::getName() { return name_; }

// ����� � �������
void Giant::showElem(int num)
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
