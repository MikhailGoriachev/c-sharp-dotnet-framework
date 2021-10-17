#pragma once
#include "pch.h"
#include "Utils.h"

#include "menu.h"
#include "MenuItem.h"

#include "./Task 1/Interface.h"
#include "./Task 1/Users/BaseUser.h"

#include "./Task 2/CareTaker.h"
#include "./Task 2/Transfer.h"

class Manager;

// TODO: прикладная часть - полезная работа приложения - бизнес-логика приложения
class App
{
	// менеджер (1 Задание)
	Manager* manager_;

	// пользователи 
	vector<BaseUser*> users_;

public:

	// конструктор по умолчанию
	App();

	// деструктор 
	~App();

#pragma region Задания 

#pragma region Задание 1. Менеджер

	// Задание 1. Менеджер
	void task1();

	// 1. Зарегистрировать пользователей 
	void regUser();

	// 2. Удалить зарегистрированных пользователей 
	void deleteUser();

	// 3. Отправить сообщения 
	void sendMessage();

	// 4. Просмотр всех пользователей 
	void showUsers();

	// 5. Просмотреть сообщения всех пользователей
	void showMessages();


#pragma endregion 

#pragma region Задание 2. Денежный перевод

	// Задание 2. Денежный перевод
	void task2();

#pragma endregion

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

