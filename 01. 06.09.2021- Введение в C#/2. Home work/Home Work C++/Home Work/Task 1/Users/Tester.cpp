#include "Tester.h"

// конструктор по умолчанию
Tester::Tester() : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Тестировщик";
}

// конструктор инициализирующий 
Tester::Tester(Interface* iface, string name) : BaseUser()
{
	// установка информации по умолчанию
	info_ = "Тестировщик";

	// установка значений 
	setInterface(iface);
	setName(name);
}

// отправить сообщение
void Tester::send(string idDest, string message) 
{
	// если не указан интерфейс
	if (interface_ == nullptr)
		throw exception("App: Интерфейс не указан!");

	// отправка сообщения
	interface_->send(this->id_, idDest, message);
}

// получить сообщение
void Tester::receive(Message message) 
{
	// сохранение сообщения в базу данных
	messages_.push_back(message);
}
