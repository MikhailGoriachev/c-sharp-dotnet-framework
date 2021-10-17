#pragma once

// ������� ����������� ����� ����
class Unit
{
public:

	// ������ ID
	static const int N_ID = 10;

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Unit() = default;

	// ����������� ���������� 
	Unit(const Unit& unit) = default;

	// ���������� 
	virtual ~Unit() = default;

	// ���������� �������� ������������
	Unit& operator=(const Unit& unit) = default;

#pragma endregion

#pragma region ������ 

	// �������� ����� ��� �����
	virtual void addUnit(Unit* unit) = 0;

	// ������� ����� ��� �����
	virtual void removeWarrior(string id) = 0;

	// ���� ����� ��� ������
	virtual int power() = 0;

	// �������� ����� 
	virtual int health() = 0;

	// �������� ID ����� ��� ������
	virtual string getID() = 0;

	// �������� �������� �����
	virtual string getName() = 0;

	// ����� � �������
	virtual void showElem(int num) = 0;

#pragma endregion
};

