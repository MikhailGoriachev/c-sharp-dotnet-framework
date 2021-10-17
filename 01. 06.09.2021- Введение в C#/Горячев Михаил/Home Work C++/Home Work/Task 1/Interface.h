#pragma once

#include "../pch.h"
#include "../Utils.h"

//#include "./Users/BaseUser.h"

class BaseUser;

// Класс Интерфейс (для обмена информацией)
class Interface
{
public:

	// отправка сообщения 
	virtual void send(string idSender, string idDest, string message) = 0;

	// регистрация пользователя
	virtual void regUser(BaseUser* user) = 0;

	// удаление пользователя
	virtual void deleteUser(string id) = 0;
};