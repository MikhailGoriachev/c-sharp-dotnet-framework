#include "Client.h"

// конструктор по умолчанию
Client::Client() : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Заказчик";
}

// конструктор инициализирующий 
Client::Client(Interface* iface, string name) : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Заказчик";

	// установка значений 
	setInterface(iface);
	setName(name);
}

// отправить сообщение
void Client::send(string idDest, string message)
{
	// если не указан интерфейс
	if (interface_ == nullptr)
		throw exception("App: Интерфейс не указан!");

	// отправка сообщения 
	interface_->send(this->id_, idDest, message);
}

// получить сообщение
void Client::receive(Message message)
{
	// сохранение сообщения в базу данных
	messages_.push_back(message);
}
