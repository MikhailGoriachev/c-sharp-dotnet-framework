#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

//class BaseUser;
//class Interface;


// Класс Тестировщик
class Tester : public BaseUser
{
public:

	// конструктор по умолчанию
	Tester();

	// конструктор инициализирующий 
	Tester(Interface* iface, string name);

	// отправить сообщение
	void send(string idDest, string message);

	// получить сообщение
	void receive(Message message);
};

