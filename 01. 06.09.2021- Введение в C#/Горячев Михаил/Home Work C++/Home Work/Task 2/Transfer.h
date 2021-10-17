#pragma once

#include "../pch.h"
#include "../Utils.h"

#include "Memento.h"

// Класс Денежный перевод
class Transfer
{
public:

	// размер кода 
	static const int N_CODE = 10;

private:

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
	Transfer() = default;

	// конструктор инициализирующий 
	Transfer(string nameSend, string codeSend, string codeDest, int sum);

	// конструктор копирующий 
	Transfer(const Transfer& transfer) = default;

	// деструктор 
	~Transfer() = default;

	// перегрузка операции присваивания
	Transfer& operator=(const Transfer& transfer) = default;

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

#pragma region Методы 

	// сохранение текущей конфигурации
	Memento* save() const;

	// загрузка конфигурации
	void load(const Memento* memento);

	// вывод таблицы 
	static void showTable(string name, string info, vector<Transfer>& transfers);

	// вывод шапки таблциы
	static void showHead(string name, string info);

	// вывод элемента 
	void showElem(int num);

	// вывод линии разделителя 
	static void showLine();

#pragma endregion 
};

