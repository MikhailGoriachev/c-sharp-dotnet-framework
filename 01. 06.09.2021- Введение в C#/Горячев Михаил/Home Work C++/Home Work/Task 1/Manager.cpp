#include "Manager.h"

#pragma region ���������

	// ������ users_
	void Manager::setUsers(map<string, BaseUser*> value) { users_ = value; }

	// ������ users_
	map<string, BaseUser*>& Manager::getUsers() { return users_; }

#pragma endregion 

#pragma region ������ 

	// �������� ��������� 
	void Manager::send(string idSender, string idDest, string message)
	{
		// ����� ����������� � ���� ������
		auto it = users_.find(idSender);

		// ���� ����������� �� ���������������
		if (it == users_.end())
			throw exception("App: ����������� �� ���������������!");

		// ����������� 
		auto sender = it->second;

		// ����� ���������� � ���� ������
		it = users_.find(idDest);

		// ���� ���������� �� ���������������
		if (it == users_.end())
			throw exception("App: ���������� �� ���������������!");

		// ����������
		auto dest = it->second;
		
		// �������� � �������� ��������� 
		dest->receive(Message(sender->getId(), sender->getName(), sender->getInfo(),
			dest->getId(), dest->getName(), dest->getInfo(), message));
	}

	// ����������� ������������
	void Manager::regUser(BaseUser* user)
	{
		// ���� ������������ ��� ���������������
		if (users_.find(user->getId()) != users_.end())
			throw exception("App: ������������ ��� ���������������!");

		// ����������� ������������
		users_.insert(pair<string, BaseUser*>(user->getId(), user));
	}

	// �������� ������������
	void Manager::deleteUser(string id)
	{
		// �������� ������������ / ���� ������������ �� ���������������
		if (users_.erase(id) == 0)
			throw exception("App: ������������ �� ���������������!");
	}

#pragma endregion 
