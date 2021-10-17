#pragma once

#include "../pch.h"
#include "../Utils.h"

#include "Memento.h"

// ����� �������� �������
class Transfer
{
public:

	// ������ ���� 
	static const int N_CODE = 10;

private:

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
	Transfer() = default;

	// ����������� ���������������� 
	Transfer(string nameSend, string codeSend, string codeDest, int sum);

	// ����������� ���������� 
	Transfer(const Transfer& transfer) = default;

	// ���������� 
	~Transfer() = default;

	// ���������� �������� ������������
	Transfer& operator=(const Transfer& transfer) = default;

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

#pragma region ������ 

	// ���������� ������� ������������
	Memento* save() const;

	// �������� ������������
	void load(const Memento* memento);

	// ����� ������� 
	static void showTable(string name, string info, vector<Transfer>& transfers);

	// ����� ����� �������
	static void showHead(string name, string info);

	// ����� �������� 
	void showElem(int num);

	// ����� ����� ����������� 
	static void showLine();

#pragma endregion 
};

