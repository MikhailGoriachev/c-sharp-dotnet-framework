#pragma once

#include "../../pch.h"
#include "../../Utils.h"

//#include "../Interface.h"
#include "../Message.h"

#include "BaseUser.h"

//class BaseUser;
//class Interface;


// ����� �����������
class Tester : public BaseUser
{
public:

	// ����������� �� ���������
	Tester();

	// ����������� ���������������� 
	Tester(Interface* iface, string name);

	// ��������� ���������
	void send(string idDest, string message);

	// �������� ���������
	void receive(Message message);
};

