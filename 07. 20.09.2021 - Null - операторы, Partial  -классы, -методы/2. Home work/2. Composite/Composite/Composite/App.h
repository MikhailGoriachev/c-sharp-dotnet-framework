#pragma once
#include "pch.h"
#include "Utils.h"

#include "./Warriors/FactoryMethod.h"
#include "./Warriors/Unit.h"

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

// TODO: ���������� ����� - �������� ������ ���������� - ������-������ ����������
class App
{
	// ��������� �����
	// FactoryMethod factory_;

	// ����� ������
	Unit* army_;

public:

	// ����������� �� ���������
	App();

	// ���������� 
	~App();

#pragma region  

	// 1. ������������ ������
	void fillWarrior();

	// �������� ������
	Unit* createSquad(int n);

	// 2. ����� ������
	void demoShowWarrior();

	// 3. ���������� ����� 
	void addWarrior();

	// 4. �������� ����� 
	void delWarrior();

	// 5. ���������� ������
	void addSquad();

	// 6. �������� ������
	void delSquad();

	// ����� �����
	void showArmy(Unit* units);

	// ����� ����� �������
	void showHead();

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

