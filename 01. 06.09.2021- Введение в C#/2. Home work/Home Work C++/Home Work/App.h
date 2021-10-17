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

// TODO: ���������� ����� - �������� ������ ���������� - ������-������ ����������
class App
{
	// �������� (1 �������)
	Manager* manager_;

	// ������������ 
	vector<BaseUser*> users_;

public:

	// ����������� �� ���������
	App();

	// ���������� 
	~App();

#pragma region ������� 

#pragma region ������� 1. ��������

	// ������� 1. ��������
	void task1();

	// 1. ���������������� ������������� 
	void regUser();

	// 2. ������� ������������������ ������������� 
	void deleteUser();

	// 3. ��������� ��������� 
	void sendMessage();

	// 4. �������� ���� ������������� 
	void showUsers();

	// 5. ����������� ��������� ���� �������������
	void showMessages();


#pragma endregion 

#pragma region ������� 2. �������� �������

	// ������� 2. �������� �������
	void task2();

#pragma endregion

#pragma endregion


#pragma region ������ ������� ���������� 

	// ������ ������� ����������
	static void preview();

	// ���������� ������� ���� 
	static void fillBackground(int row, int col, short color, int time);

	// �������� ������ ������ 
	static void outText(string message, int time, short color, int x, int y);

	// �������� ������ �������� 
	static void loadingLine(int size, int time, int x, int y, short colorLoading = GREEN_ON_BLACK, short colorBackground = mainColor, short colorComplete = BLACK_ON_GREEN);

	// ����� �����
	static void outFrame(int hight, int width, int x, int y, short colorFrame = mainColor, short colorBackground = infoColor);


#pragma endregion 

};

