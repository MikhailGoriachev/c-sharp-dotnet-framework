#include "Memento.h"

#pragma region Конструкторы, деструктор и операция присваивания 

	// конструктор инициализирующий 
	Memento::Memento(string nameSend, string codeSend, string codeDest, int sum)
	{
		// установка значений 
		setNameSend(nameSend);
		setCodeSend(codeSend);
		setCodeDest(codeDest);
		setSum(sum);
	}

#pragma endregion

#pragma region Аксессоры

	// сеттер nameSend_
	void Memento::setNameSend(string value) { nameSend_ = value; }

	// геттер nameSend_
	const string& Memento::getNameSend() const { return nameSend_; }

	// сеттер codeSend_
	void Memento::setCodeSend(string value) { codeSend_ = value; }

	// геттер codeSand_
	const string& Memento::getCodeSend() const { return codeSend_; }

	// сеттер codeDest_
	void Memento::setCodeDest(string value) { codeDest_ = value; }

	// геттер codeDest_
	const string& Memento::getCodeDest() const { return codeDest_; }

	// сеттер sum_
	void Memento::setSum(int value) { sum_ = value; }

	// геттер sum_
	int Memento::getSum() const { return sum_; }

#pragma endregion 
