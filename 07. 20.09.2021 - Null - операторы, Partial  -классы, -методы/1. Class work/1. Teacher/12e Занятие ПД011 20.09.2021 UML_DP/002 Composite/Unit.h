#pragma once
// ������� ������� ����������� ���������
// �������� ��� "�����-�����"
class Unit
{
public:

	Unit()=default;
	virtual ~Unit()=default;

	virtual int GetPower() const = 0;
	virtual void AddUnit(Unit* p) = 0;
};



