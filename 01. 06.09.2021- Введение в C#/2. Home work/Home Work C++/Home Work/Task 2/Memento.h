#pragma once

#include "../pch.h"

#include "Object.h"

// Класс Хранитель данных о денежном переводе
class Memento : public Object
{
	// ФИ отправителя
	string nameSend_;

	// код отправителя 
	string codeSend_;

	// код получателя 
	string codeDest_;

	// сумма перевода 
	int sum_;

public:

#pragma region Конструкторы, деструктор и операция присваивания 

	// конструктор по умолчанию
	Memento() = default;

	// конструктор инициализирующий 
	Memento(string nameSend, string codeSend, string codeDest, int sum);

	// конструктор копирующий 
	Memento(const Memento& memento) = default;

	// деструктор 
	~Memento() = default;

	// перегрузка операции присваивания
	Memento& operator=(const Memento& memento) = default;

#pragma endregion

#pragma region Аксессоры

	// сеттер nameSend_
	void setNameSend(string value);

	// геттер nameSend_
	const string& getNameSend() const;

	// сеттер codeSend_
	void setCodeSend(string value);

	// геттер codeSand_
	const string& getCodeSend() const;

	// сеттер codeDest_
	void setCodeDest(string value);

	// геттер codeDest_
	const string& getCodeDest() const;

	// сеттер sum_
	void setSum(int value);

	// геттер sum_
	int getSum() const;

#pragma endregion 


};

