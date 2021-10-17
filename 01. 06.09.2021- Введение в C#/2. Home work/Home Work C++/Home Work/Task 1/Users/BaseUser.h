//#pragma once

#ifndef BASEUSER
#define BASEUSER

#include "../../pch.h"
#include "../../Utils.h"

#include "../Message.h"

class Interface;

// Базовый Класс Пользователь
class BaseUser
{
public:

	// размер идентификатора 
	static const int N_ID = 10;

protected:

	// идентификатор
	string id_;

	// интерфейс для обмена сообщениями
	Interface* interface_;

	// фамилия и имя пользователя
	string name_;

	// информация о пользователе
	string info_;

	// полученные сообщения 
	vector<Message> messages_;

public:

#pragma region Конструкторы, деструктор и операция присванивания

	// конструктор по умолчанию
	BaseUser();

	// конструктор копирующий 
	BaseUser(const BaseUser& baseUser) = default;

	// деструктор 
	~BaseUser() = default;

	// перегрузка операции присваивания
	BaseUser& operator=(const BaseUser & baseUser) = default;

#pragma endregion

#pragma region Сеттеры и геттеры

	// геттер id_
	const string& getId() const;

	// сеттер interface_
	void setInterface(Interface* value);

	// геттер interface_
	Interface* getInterface() const;

	// сеттер name_
	void setName(string value);

	// геттер name_
	const string& getName() const;

	// геттер info_
	const string& getInfo() const;

	// геттер messages_
	vector<Message>& getMessages() { return messages_; }

#pragma endregion 

#pragma region Методы 

private:

	// генерация ID
	static string genID();

public:

	// регистрация
	void reg();

	// удаление регистрации 
	void delReg();

	// отправить сообщение
	virtual void send(string idDest, string message) = 0;

	// получить сообщение
	virtual void receive(Message message) = 0;


#pragma region Вывод в таблицу 

	// вывод пользователей 
	static void showTable(string name, string info, const vector<BaseUser*>& users);

	// вывод пользователей 
	static void showTable(string name, string info, const map<string, BaseUser*>& users);

	// вывод таблицы пользователя и его сообщений 
	void showTableMessage(string name, string info);

	// вывод шапки таблицы
	static void showHead(string name, string info);

	// вывод элемента 
	void showElemMessage(int num) const;

	// вывод элемента 
	void showElem(int num) const;

	// вывод линии-разделителя
	static void showLine();

	// вывод сообщения об отсутствии данных
	static void showEmpty();

#pragma endregion

#pragma endregion 
};

#endif // !1