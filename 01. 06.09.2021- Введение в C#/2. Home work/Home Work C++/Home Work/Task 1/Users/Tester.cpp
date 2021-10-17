#include "Tester.h"

// ����������� �� ���������
Tester::Tester() : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�����������";
}

// ����������� ���������������� 
Tester::Tester(Interface* iface, string name) : BaseUser()
{
	// ��������� ���������� �� ���������
	info_ = "�����������";

	// ��������� �������� 
	setInterface(iface);
	setName(name);
}

// ��������� ���������
void Tester::send(string idDest, string message) 
{
	// ���� �� ������ ���������
	if (interface_ == nullptr)
		throw exception("App: ��������� �� ������!");

	// �������� ���������
	interface_->send(this->id_, idDest, message);
}

// �������� ���������
void Tester::receive(Message message) 
{
	// ���������� ��������� � ���� ������
	messages_.push_back(message);
}
