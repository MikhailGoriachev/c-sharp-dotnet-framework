#pragma once
#include <string>

#include "Memento.h"

using namespace std;

// класс Originator
// ¬ нашем примере мы будем работать с информацией о человеке
// и сохран€ть его состо€ние
class Human
{
	string name_;      // им€
	string surname_;   // фамили€
	int age_;          // возраст

public:
	Human(string name, string surname, int age)
	{
		name_ = name;
		surname_ = surname;
		age_ = age;
	} // Human

	Human() :Human("ќлег", " укушкин", 25) {}

	string GetName() const     { return name_;}
	void SetName(string pName) { name_ = pName;	}

	string GetSurname() const {	return surname_;	}
	void SetSurname(string pSurname) { surname_ = pSurname;	}

	int GetAge() const	  { return age_; }
	void SetAge(int pAge) { age_ = pAge;	}

    // получаем слепок состо€ни€
	Memento* SaveMemento() const
	{
		cout << "\nhuman: —охран€ю состо€ние\n";
		return new Memento(name_, surname_, age_);
	}

	// восстанавливаем состо€ние
	void RestoreMemento(Memento* pMemento)
	{
		cout << "\nhuman: ¬осстанавливаю состо€ние\n";
		name_ = pMemento->GetName();
		surname_ = pMemento->GetSurname();
		age_ = pMemento->GetAge();
	}
};

