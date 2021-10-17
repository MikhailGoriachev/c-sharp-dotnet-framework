#pragma once
#include <string>
#include<iostream>
using namespace std;
#include "Classroom.h"

class Classroom;

class Trainee
{
	string name;
	Classroom* classroom;
public:
	Trainee(string pName)
	{
		name = pName;
	}

    string GetName() const	   { return name;	}
	void SetName(string pName) { name = pName;	}

	Classroom* GetClasroom() const           { return classroom;	}
	void SetClassroom(Classroom* pClassroom) {	classroom = pClassroom;	}

	// Отсылка сообщения
	void Send(string to, string message);
	virtual void Receive(string from, string message)
	{
		cout << "Сообщение от " << from << " к " << name << " : " << message << endl;
	}
};

class MathClass : public Trainee
{
public:
	MathClass(string name) :Trainee(name) {} // MathClass

	void Receive(string from, string message)
	{
		cout << "\nСообшение в Математическом классе\n";
		Trainee::Receive(from, message);
	} // Receive
};
