#pragma once
#include <map>
#include <string>
// #include "Trainee.h"

class Trainee;
using namespace std;

// класс Mediator
class AbstractClassroom
{
public:
	// регистрация для работы с посредником
	virtual void Register(Trainee* trainee) = 0;

	// отправка сообщения
	virtual void Send(string from, string to, string message) = 0;
};

// Это реализация ConcreteMediator
class Classroom :public AbstractClassroom
{
	map<string, Trainee*> trainees;
public:

	void Register(Trainee* trainee);
	void Send(string from, string to, string message);
};
