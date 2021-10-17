#include "App.h"

/*
 * ������������ ���������� ���������� �� C++ ��� ����������� �������� �����������.
 * 
 * ��� ��������� ���� ��������� ����������� ����������� �����. ����� ����� ��������
 * �� ������� � ��������� ������. ����� ����� �������� �� ������ ������� � ��������� 
 * ������.
 * 
 * ��� �����, ������, ����� ��������� ���������� ����. ��� ����� ����� ��������� 
 * ��������� ������� ��������. � ����� ��� ����� ����� ���������/������� ����� ��� 
 * ������ ������, ��� ����� ����� �������� ����������.
 * 
 * � ���� ��������� ����: �����, ����, ����, �����, ��������.
*/

// ����������� �� ���������
App::App() : army_(FactoryMethod::getUnit(FactoryMethod::CODE_SQUAD)) {}

// ���������� 
App::~App() { delete army_; }

// 1. ������������ ������
void App::fillWarrior()
{
	showNavBarMessage(hintColor, "1. ������������ ������");

	cout << "\n\n";

	// ���������� ������
	const int N = 5;

	// ���������� ������ � �������
	army_->addUnit(createSquad(N));

	// ����� �����
	showArmy(army_);
}

// �������� ������
Unit* App::createSquad(int n)
{
	// �����
	Unit* squad = FactoryMethod::getUnit(FactoryMethod::CODE_SQUAD);

	// ���������� ������
	for (int i = 0; i < n; i++)
		squad->addUnit(FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF)));

	return squad;
}

// 2. ����� ������
void App::demoShowWarrior()
{
	showNavBarMessage(hintColor, "2. ����� ������");

	// ����� �����
	showArmy(army_);

	cout << "\n\n";
}

// 3. ���������� ����� 
void App::addWarrior()
{
	showNavBarMessage(hintColor, "3. ���������� �����");

	cout << "\n\n";

	// ����� ��� ����������
	Unit* unit = FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF));

	// ���������� ����� 
	army_->addUnit(unit);

	// ����� �����
	showArmy(army_);

	cputs("\n  +������������������������������������������ ����������� ���� ������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� ��������� ����� 
	showArmy(unit);
}

// 4. �������� ����� 
void App::delWarrior()
{
	showNavBarMessage(hintColor, "4. �������� �����");

	cout << "\n\n";

	// ���� 
	Unit* unit = FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF));

	// ���������� ����� 
	army_->addUnit(unit);

	// ����� �����
	showArmy(army_);

	// �������� ����� 
	army_->removeWarrior(unit->getID());

	cputs("\n  +������������������������������������������� ����� �������� �������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� �����
	showArmy(army_);

	cputs("\n  +������������������������������������������� ��������� ���� �������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� ��������� ����� 
	showArmy(unit);
}

// 5. ���������� ������
void App::addSquad()
{
	showNavBarMessage(hintColor, "5. ���������� ������");

	cout << "\n\n";

	cout << "\n\n";

	// ���������� ������ � ������
	int n = getRand(3, 5);

	// ���� ��� ����������
	Unit* unit = createSquad(n);

	// ���������� ����� 
	army_->addUnit(unit);

	// ����� �����
	showArmy(army_);

	cputs("\n  +������������������������������������������ ����������� ���� ������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� ����������� ����� 
	showArmy(unit);
}

// 6. �������� ������
void App::delSquad()
{
	showNavBarMessage(hintColor, "6. �������� ������");

	cout << "\n\n";

	// ���������� ������ � ������
	int n = getRand(3, 5);

	// ����� 
	Unit* unit = createSquad(n);

	// ���������� ����� 
	army_->addUnit(unit);

	// ����� �����
	showArmy(army_);

	// �������� ������ 
	army_->removeWarrior(unit->getID());

	cputs("\n  +������������������������������������������� ����� �������� �������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� �����
	showArmy(army_);

	cputs("\n  +������������������������������������������� ��������� ���� �������������������������������������������������������+  \n\n", LTMAGENTA_ON_BLACK);

	// ����� ��������� ����� 
	showArmy(unit);
}

// ����� �����
void App::showArmy(Unit* units)
{
	// ����� ����� �������
	showHead();

	// ����� �����
	units->showElem(1);

	cout << color(LTCYAN_ON_BLACK) << "          +����+����������������������+������������+������������+������������+\n";
}


// ����� ����� �������
void App::showHead()
{
	cout << color(LTCYAN_ON_BLACK) << "          +����+����������������������+������������+������������+������������+\n"
		<< color(LTCYAN_ON_BLACK) << "          | "
		<< color(YELLOW_ON_BLACK) << "N "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "      ��������      "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "    ID    "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "   ����   "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << " �������� "
		<< color(LTCYAN_ON_BLACK) << " |\n"
		<< color(mainColor)
		<< color(LTCYAN_ON_BLACK) << "          +����+����������������������+������������+������������+������������+\n";
}