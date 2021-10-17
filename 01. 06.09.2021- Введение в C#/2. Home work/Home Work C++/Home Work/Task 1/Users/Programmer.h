#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

// class BaseUser;
// class Interface;


// ����� �����������
class Programmer : public BaseUser
{
public:

	// ����������� �� ���������
	Programmer();

	// ����������� ���������������� 
	Programmer(Interface* iface, string name);

	// ��������� ���������
	virtual void send(string idDest, string message) override;

	// �������� ���������
	virtual void receive(Message message) override;
};

