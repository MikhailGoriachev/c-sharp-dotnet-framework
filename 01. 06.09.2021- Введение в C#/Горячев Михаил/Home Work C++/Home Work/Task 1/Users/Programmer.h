#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

// class BaseUser;
// class Interface;


// Класс Программист
class Programmer : public BaseUser
{
public:

	// конструктор по умолчанию
	Programmer();

	// конструктор инициализирующий 
	Programmer(Interface* iface, string name);

	// отправить сообщение
	virtual void send(string idDest, string message) override;

	// получить сообщение
	virtual void receive(Message message) override;
};

