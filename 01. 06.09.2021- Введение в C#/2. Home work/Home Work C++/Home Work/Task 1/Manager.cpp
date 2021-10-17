#include "Manager.h"

#pragma region јксессоры

	// сеттер users_
	void Manager::setUsers(map<string, BaseUser*> value) { users_ = value; }

	// геттер users_
	map<string, BaseUser*>& Manager::getUsers() { return users_; }

#pragma endregion 

#pragma region ћетоды 

	// отправка сообщени€ 
	void Manager::send(string idSender, string idDest, string message)
	{
		// поиск отправител€ в базе данных
		auto it = users_.find(idSender);

		// если отправитель не зарегистрирован
		if (it == users_.end())
			throw exception("App: ќтправитель не зарегистрирован!");

		// отправитель 
		auto sender = it->second;

		// поиск получател€ в базе данных
		it = users_.find(idDest);

		// если получатель не зарегистрирован
		if (it == users_.end())
			throw exception("App: ѕолучатель не зарегистрирован!");

		// получатель
		auto dest = it->second;
		
		// создание и отправка сообщени€ 
		dest->receive(Message(sender->getId(), sender->getName(), sender->getInfo(),
			dest->getId(), dest->getName(), dest->getInfo(), message));
	}

	// регистраци€ пользовател€
	void Manager::regUser(BaseUser* user)
	{
		// если пользователь уже зарегистрирован
		if (users_.find(user->getId()) != users_.end())
			throw exception("App: ѕользователь уже зарегистрирован!");

		// регистраци€ пользовател€
		users_.insert(pair<string, BaseUser*>(user->getId(), user));
	}

	// удаление пользовател€
	void Manager::deleteUser(string id)
	{
		// удаление пользовател€ / если пользователь не зарегистрирован
		if (users_.erase(id) == 0)
			throw exception("App: ѕользователь не зарегистрирован!");
	}

#pragma endregion 
