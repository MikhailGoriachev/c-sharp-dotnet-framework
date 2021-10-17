#pragma once
#include "../pch.h"
#include "../Utils.h"

#include "Unit.h"

class Elf : public Unit
{
	// id
	string id_;

	// �������� ����� 
	string name_;

public:

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Elf();

	// ����������� ����������
	Elf(const Elf& elf) = default;

	// ���������� 
	virtual ~Elf() override = default;

	// ���������� �������� �����������
	Elf& operator=(const Elf & elf) = default;

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

