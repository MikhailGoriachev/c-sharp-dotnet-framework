// #pragma once

#ifndef MANAGER
#define MANAGER

#include "../pch.h"
#include "../Utils.h"

#include "Interface.h"
#include "./Users/BaseUser.h"

// class BaseUser;

class Manager : public Interface
{
	// ������������ (���� - ID ������������)
	map<string, BaseUser*> users_;

public:

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Manager() = default;

	// ����������� ���������� 
	Manager(const Manager& manager) = default;

	// ���������� 
	~Manager() = default;

	// ���������� �������� ������������
	Manager& operator=(const Manager& manager) = default;

#pragma endregion

#pragma region ���������

	// ������ users_
	void setUsers(map<string, BaseUser*> value);

	// ������ users_
	map<string, BaseUser*>& getUsers();

#pragma endregion 

#pragma region ������ 

	// �������� ��������� 
	virtual void send(string idSender, string idDest, string message) override;

	// ����������� ������������
	virtual void regUser(BaseUser* user) override;

	// �������� ������������
	virtual void deleteUser(string id) override;

#pragma endregion 

};

#endif // !1