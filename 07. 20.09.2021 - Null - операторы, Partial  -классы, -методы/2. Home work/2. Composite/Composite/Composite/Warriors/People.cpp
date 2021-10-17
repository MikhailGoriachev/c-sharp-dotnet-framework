#include "People.h"

// ����������� �� ���������
People::People() : id_(generID(Unit::N_ID)), name_("�������") { }

#pragma region ������ 

// �������� ����� ��� �����
void People::addUnit(Unit* unit) { throw exception("��� �������� �� �������������! �������� ���� ����� ������ � �����"); }

// ������� ����� ��� �����
void People::removeWarrior(string id) { throw exception("��� �������� �� �������������! ������� ���� ����� ������ �� ������"); }

// ���� ����� ��� ������
int People::power() { return 15; }

// �������� ����� 
int People::health() { return 80; }

// �������� ID ����� ��� ������
string People::getID() { return id_; }

// �������� �������� �����
string People::getName() { return name_; }

// ����� � �������
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

	// ��������� ����� �� ���������
	setColor(mainColor);
}

#pragma endregion
