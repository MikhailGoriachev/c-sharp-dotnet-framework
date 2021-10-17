#pragma once

#include "../pch.h"
#include "../Utils.h"

//#include "./Users/BaseUser.h"

class BaseUser;

// ����� ��������� (��� ������ �����������)
class Interface
{
public:

	// �������� ��������� 
	virtual void send(string idSender, string idDest, string message) = 0;

	// ����������� ������������
	virtual void regUser(BaseUser* user) = 0;

	// �������� ������������
	virtual void deleteUser(string id) = 0;
};