#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

// class BaseUser;
// class Interface;


// Класс Клиент (заказчик)
class Client : public BaseUser
{
public:

	// конструктор по умолчанию
	Client();

	// конструктор инициализирующий 
	Client(Interface* iface, string name);

	// отправить сообщение
	virtual void send(string idDest, string message) override;

	// получить сообщение
	virtual void receive(Message message) override;
};

