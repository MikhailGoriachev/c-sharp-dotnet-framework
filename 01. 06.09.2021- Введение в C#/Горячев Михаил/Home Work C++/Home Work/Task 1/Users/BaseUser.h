//#pragma once

#ifndef BASEUSER
#define BASEUSER

#include "../../pch.h"
#include "../../Utils.h"

#include "../Message.h"

class Interface;

// ������� ����� ������������
class BaseUser
{
public:

	// ������ �������������� 
	static const int N_ID = 10;

protected:

	// �������������
	string id_;

	// ��������� ��� ������ �����������
	Interface* interface_;

	// ������� � ��� ������������
	string name_;

	// ���������� � ������������
	string info_;

	// ���������� ��������� 
	vector<Message> messages_;

public:

#pragma region ������������, ���������� � �������� �������������

	// ����������� �� ���������
	BaseUser();

	// ����������� ���������� 
	BaseUser(const BaseUser& baseUser) = default;

	// ���������� 
	~BaseUser() = default;

	// ���������� �������� ������������
	BaseUser& operator=(const BaseUser & baseUser) = default;

#pragma endregion

#pragma region ������� � �������

	// ������ id_
	const string& getId() const;

	// ������ interface_
	void setInterface(Interface* value);

	// ������ interface_
	Interface* getInterface() const;

	// ������ name_
	void setName(string value);

	// ������ name_
	const string& getName() const;

	// ������ info_
	const string& getInfo() const;

	// ������ messages_
	vector<Message>& getMessages() { return messages_; }

#pragma endregion 

#pragma region ������ 

private:

	// ��������� ID
	static string genID();

public:

	// �����������
	void reg();

	// �������� ����������� 
	void delReg();

	// ��������� ���������
	virtual void send(string idDest, string message) = 0;

	// �������� ���������
	virtual void receive(Message message) = 0;


#pragma region ����� � ������� 

	// ����� ������������� 
	static void showTable(string name, string info, const vector<BaseUser*>& users);

	// ����� ������������� 
	static void showTable(string name, string info, const map<string, BaseUser*>& users);

	// ����� ������� ������������ � ��� ��������� 
	void showTableMessage(string name, string info);

	// ����� ����� �������
	static void showHead(string name, string info);

	// ����� �������� 
	void showElemMessage(int num) const;

	// ����� �������� 
	void showElem(int num) const;

	// ����� �����-�����������
	static void showLine();

	// ����� ��������� �� ���������� ������
	static void showEmpty();

#pragma endregion

#pragma endregion 
};

#endif // !1