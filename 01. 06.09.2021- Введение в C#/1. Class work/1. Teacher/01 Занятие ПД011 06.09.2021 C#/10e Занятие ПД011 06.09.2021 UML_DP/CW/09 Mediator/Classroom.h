#pragma once
#include <map>
#include <string>
// #include "Trainee.h"

class Trainee;
using namespace std;

// ����� Mediator
class AbstractClassroom
{
public:
	// ����������� ��� ������ � �����������
	virtual void Register(Trainee* trainee) = 0;

	// �������� ���������
	virtual void Send(string from, string to, string message) = 0;
};

// ��� ���������� ConcreteMediator
class Classroom :public AbstractClassroom
{
	map<string, Trainee*> trainees;
public:

	void Register(Trainee* trainee);
	void Send(string from, string to, string message);
};
