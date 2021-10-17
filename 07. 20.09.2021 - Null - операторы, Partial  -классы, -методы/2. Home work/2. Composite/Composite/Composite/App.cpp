#include "App.h"

/*
 * Разработайте консольное приложение на C++ для иллюстрации паттерна Компоновщик.
 * 
 * Для некоторой игры требуется реализовать организацию армии. Армия может состоять
 * из отрядов и одиночных воинов. Отряд может состоять из других отрядов и одиночных 
 * воинов.
 * 
 * Для армии, отряда, воина требуется вычисление силы. Для воина также требуется 
 * вычислять уровень здоровья. В армию или отряд можно добавлять/удалять воина или 
 * другие отряды, для воина такая операция невозможна.
 * 
 * В игре участвуют расы: эльфы, орки, люди, гномы, великаны.
*/

// конструктор по умолчанию
App::App() : army_(FactoryMethod::getUnit(FactoryMethod::CODE_SQUAD)) {}

// деструктор 
App::~App() { delete army_; }

// 1. Формирование данных
void App::fillWarrior()
{
	showNavBarMessage(hintColor, "1. Формирование данных");

	cout << "\n\n";

	// количество юнитов
	const int N = 5;

	// добавление отряда с воинами
	army_->addUnit(createSquad(N));

	// вывод армии
	showArmy(army_);
}

// создание отряда
Unit* App::createSquad(int n)
{
	// отряд
	Unit* squad = FactoryMethod::getUnit(FactoryMethod::CODE_SQUAD);

	// заполнение отряда
	for (int i = 0; i < n; i++)
		squad->addUnit(FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF)));

	return squad;
}

// 2. Вывод данных
void App::demoShowWarrior()
{
	showNavBarMessage(hintColor, "2. Вывод данных");

	// вывод армии
	showArmy(army_);

	cout << "\n\n";
}

// 3. Добавление воина 
void App::addWarrior()
{
	showNavBarMessage(hintColor, "3. Добавление воина");

	cout << "\n\n";

	// юниит для добавления
	Unit* unit = FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF));

	// добавление юнита 
	army_->addUnit(unit);

	// вывод армии
	showArmy(army_);

	cputs("\n  +—————————————————————————————————————————— Добавленный юнит ——————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод удалённого воина 
	showArmy(unit);
}

// 4. Удаление воина 
void App::delWarrior()
{
	showNavBarMessage(hintColor, "4. Удаление воина");

	cout << "\n\n";

	// воин 
	Unit* unit = FactoryMethod::getUnit(getRand(FactoryMethod::CODE_ORC, FactoryMethod::CODE_ELF));

	// добавление воина 
	army_->addUnit(unit);

	// вывод армии
	showArmy(army_);

	// удаление воина 
	army_->removeWarrior(unit->getID());

	cputs("\n  +——————————————————————————————————————————— После удаления ———————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод армии
	showArmy(army_);

	cputs("\n  +——————————————————————————————————————————— Удаленный юнит ———————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод удалённого воина 
	showArmy(unit);
}

// 5. Добавление отряда
void App::addSquad()
{
	showNavBarMessage(hintColor, "5. Добавление отряда");

	cout << "\n\n";

	cout << "\n\n";

	// количество юнитов в отряде
	int n = getRand(3, 5);

	// юнит для добавления
	Unit* unit = createSquad(n);

	// добавление юнита 
	army_->addUnit(unit);

	// вывод армии
	showArmy(army_);

	cputs("\n  +—————————————————————————————————————————— Добавленный юнит ——————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод добаленного юнита 
	showArmy(unit);
}

// 6. Удаление отряда
void App::delSquad()
{
	showNavBarMessage(hintColor, "6. Удаление отряда");

	cout << "\n\n";

	// количество юнитов в отряде
	int n = getRand(3, 5);

	// отряд 
	Unit* unit = createSquad(n);

	// добавление воина 
	army_->addUnit(unit);

	// вывод армии
	showArmy(army_);

	// удаление отряда 
	army_->removeWarrior(unit->getID());

	cputs("\n  +——————————————————————————————————————————— После удаления ———————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод армии
	showArmy(army_);

	cputs("\n  +——————————————————————————————————————————— Удаленный юнит ———————————————————————————————————————————————————————+  \n\n", LTMAGENTA_ON_BLACK);

	// вывод удалённого воина 
	showArmy(unit);
}

// вывод армии
void App::showArmy(Unit* units)
{
	// вывод шапки таблицы
	showHead();

	// вывод юнита
	units->showElem(1);

	cout << color(LTCYAN_ON_BLACK) << "          +————+——————————————————————+————————————+————————————+————————————+\n";
}


// вывод шапки таблицы
void App::showHead()
{
	cout << color(LTCYAN_ON_BLACK) << "          +————+——————————————————————+————————————+————————————+————————————+\n"
		<< color(LTCYAN_ON_BLACK) << "          | "
		<< color(YELLOW_ON_BLACK) << "N "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "      Название      "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "    ID    "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << "   Сила   "
		<< color(LTCYAN_ON_BLACK) << " | "
		<< color(YELLOW_ON_BLACK) << " Здоровье "
		<< color(LTCYAN_ON_BLACK) << " |\n"
		<< color(mainColor)
		<< color(LTCYAN_ON_BLACK) << "          +————+——————————————————————+————————————+————————————+————————————+\n";
}