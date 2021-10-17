#include "Programmer.h"

// ����������� �� ���������
Programmer::Programmer() : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�����������";
}

// ����������� ���������������� 
Programmer::Programmer(Interface* iface, string name) : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�����������";

	// ��������� �������� 
	setInterface(iface);
	setName(name);
}

// ��������� ���������
void Programmer::send(string idDest, string message) 
{
	// ���� �� ������ ���������
	if (interface_ == nullptr)
		throw exception("App: ��������� �� ������!");

	// �������� ��������� 
	interface_->send(this->id_, idDest, message);
}

// �������� ���������
void Programmer::receive(Message message) 
{
	// ���������� ��������� � ���� ������
	messages_.push_back(message);
}
