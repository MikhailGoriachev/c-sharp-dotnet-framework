#pragma once

#include "../pch.h"
#include "../Utils.h"

#include <map>

#include "Unit.h"

// ����� �����
class Squard : public Unit
{
	// id
	string id_;

	// �������� ����� 
	string name_;

	// ��������� ������
	map<string, Unit*> units_;

public:

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Squard();

	// ����������� ����������
	Squard(const Squard& Squard) = default;

	// ���������� 
	virtual ~Squard() override;

	// ���������� �������� �����������
	Squard& operator=(const Squard & Squard) = default;

#pragma endregion

#pragma region ������ 

	// �������� ����� ��� �����
	virtual void addUnit(Unit* unit) override;

	// ������� ����� ��� �����
	virtual void removeWarrior(string id) override;

	// ���� ����� ��� ������
	virtual int power() override;

	// �������� ����� 
	virtual int health() override;

	// �������� ID ����� ��� ������
	virtual string getID() override;

	// �������� �������� �����
	virtual string getName() override;

	// ����� � �������
	virtual void showElem(int num) override;
};

