#include "Squard.h"

// ����������� �� ���������
Squard::Squard() : id_(generID(Unit::N_ID)), name_("�����") { }

// ���������� 
Squard::~Squard() 
{
	for_each(units_.begin(), units_.end(), [](pair<string, Unit*> p) { delete p.second; });
}

#pragma region ������ 

// �������� ����� ��� �����
void Squard::addUnit(Unit* unit) 
{
	if (!units_.insert(pair<string, Unit*>(unit->getID(), unit)).second) throw exception("���� ���� ��� ��������!");
}

// ������� ����� ��� �����
void Squard::removeWarrior(string id) 
{
	if (units_.erase(id) == 0) throw exception("���� ���� �� ������!");
}

// ���� ����� ��� ������
int Squard::power() 
{
	// ����� 
	int sum = 0;

	for_each(units_.begin(), units_.end(), [&sum](pair<string, Unit*> p) {sum += p.second->power(); });

	return sum;
}

// �������� ����� 
int Squard::health() { throw exception("������ ����������!"); }

// �������� ID ����� ��� ������
string Squard::getID()  { return id_; }

// �������� �������� �����
string Squard::getName()  { return name_; }

// ����� � �������
void Squard::showElem(int num) 
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
		<< color(RED_ON_BLACK) << setw(10) << "����������"
		<< color(LTCYAN_ON_BLACK) << " |\n"
		<< color(MAGENTA_ON_BLACK) << "          +����+����������������������+������������+������������+������������+\n";

	int i = 1;

	for_each(units_.begin(), units_.end(), [i](pair<string, Unit*> p) mutable {p.second->showElem(i++); });

	cout << color(RED_ON_BLACK) << "          +����+����������������������+������������+������������+������������+\n";

	// ��������� ����� �� ���������
	setColor(mainColor);
}