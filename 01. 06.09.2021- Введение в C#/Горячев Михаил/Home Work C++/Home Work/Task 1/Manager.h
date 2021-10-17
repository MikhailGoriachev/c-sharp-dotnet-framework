// #pragma once

#ifndef MANAGER
#define MANAGER

#include "../pch.h"
#include "../Utils.h"

#include "Interface.h"
#include "./Users/BaseUser.h"

// class BaseUser;

class Manager : public Interface
{
	// пользователи (ключ - ID пользовател€)
	map<string, BaseUser*> users_;

public:

#pragma region  онструкторы, деструктор и операци€ присваивани€

	// конструктор по умолчанию
	Manager() = default;

	// конструктор копирующий 
	Manager(const Manager& manager) = default;

	// деструктор 
	~Manager() = default;

	// перегрузка операции присваивани€
	Manager& operator=(const Manager& manager) = default;

#pragma endregion

#pragma region јксессоры

	// сеттер users_
	void setUsers(map<string, BaseUser*> value);

	// геттер users_
	map<string, BaseUser*>& getUsers();

#pragma endregion 

#pragma region ћетоды 

	// отправка сообщени€ 
	virtual void send(string idSender, string idDest, string message) override;

	// регистраци€ пользовател€
	virtual void regUser(BaseUser* user) override;

	// удаление пользовател€
	virtual void deleteUser(string id) override;

#pragma endregion 

};

#endif // !1