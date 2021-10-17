#include "Admin.h"

// ����������� �� ���������
Admin::Admin() : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�������������";
}

// ����������� ���������������� 
Admin::Admin::Admin(Interface* iface, string name) : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�������������";

	// ��������� �������� 
	setInterface(iface);
	setName(name);
}

// ��������� ���������
void Admin::send(string idDest, string message) 
{
	// ���� �� ������ ���������
	if (interface_ == nullptr)
		throw exception("App: ��������� �� ������!");

	// �������� ��������� 
	interface_->send(this->id_, idDest, message);
}

// �������� ���������
void Admin::receive(Message message) 
{
	// ���������� ��������� � ���� ������
	messages_.push_back(message);
}
