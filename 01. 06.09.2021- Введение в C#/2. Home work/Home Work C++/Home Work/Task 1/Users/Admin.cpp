#include "Admin.h"

// конструктор по умолчанию
Admin::Admin() : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Администратор";
}

// конструктор инициализирующий 
Admin::Admin::Admin(Interface* iface, string name) : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Администратор";

	// установка значений 
	setInterface(iface);
	setName(name);
}

// отправить сообщение
void Admin::send(string idDest, string message) 
{
	// если не указан интерфейс
	if (interface_ == nullptr)
		throw exception("App: Интерфейс не указан!");

	// отправка сообщения 
	interface_->send(this->id_, idDest, message);
}

// получить сообщение
void Admin::receive(Message message) 
{
	// сохранение сообщения в базу данных
	messages_.push_back(message);
}
