#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

// class BaseUser;
// class Interface;

// ����� �������������
class Admin : public BaseUser
{
public:

	// ����������� �� ���������
	Admin();

	// ����������� ���������������� 
	Admin(Interface* iface, string name);

	// ��������� ���������
	virtual void send(string idDest, string message) override;

	// �������� ���������
	virtual void receive(Message message) override;
};

