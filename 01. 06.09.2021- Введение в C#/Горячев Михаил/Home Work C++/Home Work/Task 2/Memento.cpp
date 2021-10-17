#include "Memento.h"

#pragma region ������������, ���������� � �������� ������������ 

	// ����������� ���������������� 
	Memento::Memento(string nameSend, string codeSend, string codeDest, int sum)
	{
		// ��������� �������� 
		setNameSend(nameSend);
		setCodeSend(codeSend);
		setCodeDest(codeDest);
		setSum(sum);
	}

#pragma endregion

#pragma region ���������

	// ������ nameSend_
	void Memento::setNameSend(string value) { nameSend_ = value; }

	// ������ nameSend_
	const string& Memento::getNameSend() const { return nameSend_; }

	// ������ codeSend_
	void Memento::setCodeSend(string value) { codeSend_ = value; }

	// ������ codeSand_
	const string& Memento::getCodeSend() const { return codeSend_; }

	// ������ codeDest_
	void Memento::setCodeDest(string value) { codeDest_ = value; }

	// ������ codeDest_
	const string& Memento::getCodeDest() const { return codeDest_; }

	// ������ sum_
	void Memento::setSum(int value) { sum_ = value; }

	// ������ sum_
	int Memento::getSum() const { return sum_; }

#pragma endregion 
