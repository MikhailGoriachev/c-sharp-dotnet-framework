#pragma once

#include "../pch.h"

#include "Object.h"

// ����� ��������� ������ � �������� ��������
class Memento : public Object
{
	// �� �����������
	string nameSend_;

	// ��� ����������� 
	string codeSend_;

	// ��� ���������� 
	string codeDest_;

	// ����� �������� 
	int sum_;

public:

#pragma region ������������, ���������� � �������� ������������ 

	// ����������� �� ���������
	Memento() = default;

	// ����������� ���������������� 
	Memento(string nameSend, string codeSend, string codeDest, int sum);

	// ����������� ���������� 
	Memento(const Memento& memento) = default;

	// ���������� 
	~Memento() = default;

	// ���������� �������� ������������
	Memento& operator=(const Memento& memento) = default;

#pragma endregion

#pragma region ���������

	// ������ nameSend_
	void setNameSend(string value);

	// ������ nameSend_
	const string& getNameSend() const;

	// ������ codeSend_
	void setCodeSend(string value);

	// ������ codeSand_
	const string& getCodeSend() const;

	// ������ codeDest_
	void setCodeDest(string value);

	// ������ codeDest_
	const string& getCodeDest() const;

	// ������ sum_
	void setSum(int value);

	// ������ sum_
	int getSum() const;

#pragma endregion 


};

