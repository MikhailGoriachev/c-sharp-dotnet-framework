#pragma once
#include "pch.h"
#include "Utils.h"

#include "./Warriors/FactoryMethod.h"
#include "./Warriors/Unit.h"

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

// TODO: прикладная часть - полезная работа приложения - бизнес-логика приложения
class App
{
	// фабричный метод
	// FactoryMethod factory_;

	// армия юнитов
	Unit* army_;

public:

	// конструктор по умолчанию
	App();

	// деструктор 
	~App();

#pragma region  

	// 1. Формирование данных
	void fillWarrior();

	// создание отряда
	Unit* createSquad(int n);

	// 2. Вывод данных
	void demoShowWarrior();

	// 3. Добавление воина 
	void addWarrior();

	// 4. Удаление воина 
	void delWarrior();

	// 5. Добавление отряда
	void addSquad();

	// 6. Удаление отряда
	void delSquad();

	// вывод армии
	void showArmy(Unit* units);

	// вывод шапки таблицы
	void showHead();

#pragma endregion

#pragma region Превью запуска приложения 

	// Превью запуска приложения
	static void preview();

	// заполнение заднего фона 
	static void fillBackground(int row, int col, short color, int time);

	// анимация вывода текста 
	static void outText(string message, int time, short color, int x, int y);

	// анимация полосы загрузки 
	static void loadingLine(int size, int time, int x, int y, short colorLoading = GREEN_ON_BLACK, short colorBackground = mainColor, short colorComplete = BLACK_ON_GREEN);

	// вывод рамки
	static void outFrame(int hight, int width, int x, int y, short colorFrame = mainColor, short colorBackground = infoColor);


#pragma endregion 

};

