#include "Client.h"

// ����������� �� ���������
Client::Client() : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "��������";
}

// ����������� ���������������� 
Client::Client(Interface* iface, string name) : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "��������";

	// ��������� �������� 
	setInterface(iface);
	setName(name);
}

// ��������� ���������
void Client::send(string idDest, string message)
{
	// ���� �� ������ ���������
	if (interface_ == nullptr)
		throw exception("App: ��������� �� ������!");

	// �������� ��������� 
	interface_->send(this->id_, idDest, message);
}

// �������� ���������
void Client::receive(Message message)
{
	// ���������� ��������� � ���� ������
	messages_.push_back(message);
}
