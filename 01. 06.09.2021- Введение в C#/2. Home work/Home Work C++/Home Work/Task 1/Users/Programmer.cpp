#include "Programmer.h"

// конструктор по умолчанию
Programmer::Programmer() : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Программист";
}

// конструктор инициализирующий 
Programmer::Programmer(Interface* iface, string name) : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Программист";

	// установка значений 
	setInterface(iface);
	setName(name);
}

// отправить сообщение
void Programmer::send(string idDest, string message) 
{
	// если не указан интерфейс
	if (interface_ == nullptr)
		throw exception("App: Интерфейс не указан!");

	// отправка сообщения 
	interface_->send(this->id_, idDest, message);
}

// получить сообщение
void Programmer::receive(Message message) 
{
	// сохранение сообщения в базу данных
	messages_.push_back(message);
}
