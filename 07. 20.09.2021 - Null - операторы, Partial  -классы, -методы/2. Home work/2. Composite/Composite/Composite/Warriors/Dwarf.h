#pragma once
#include "../pch.h"
#include "../Utils.h"

#include "Unit.h"

// ����� ����
class Dwarf : public Unit
{
	// id
	string id_;

	// �������� ����� 
	string name_;

public:

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Dwarf();

	// ����������� ����������
	Dwarf(const Dwarf& dwarf) = default;

	// ���������� 
	virtual ~Dwarf() override = default;

	// ���������� �������� �����������
	Dwarf& operator=(const Dwarf & dwarf) = default;

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

