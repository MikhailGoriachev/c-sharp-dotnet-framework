#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

// class BaseUser;
// class Interface;


// ����� ������ (��������)
class Client : public BaseUser
{
public:

	// ����������� �� ���������
	Client();

	// ����������� ���������������� 
	Client(Interface* iface, string name);

	// ��������� ���������
	virtual void send(string idDest, string message) override;

	// �������� ���������
	virtual void receive(Message message) override;
};

