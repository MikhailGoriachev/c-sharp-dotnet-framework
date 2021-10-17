#pragma once
#include <string>

#include "Memento.h"

using namespace std;

// ����� Originator
// � ����� ������� �� ����� �������� � ����������� � ��������
// � ��������� ��� ���������
class Human
{
	string name_;      // ���
	string surname_;   // �������
	int age_;          // �������

public:
	Human(string name, string surname, int age)
	{
		name_ = name;
		surname_ = surname;
		age_ = age;
	} // Human

	Human() :Human("����", "��������", 25) {}

	string GetName() const     { return name_;}
	void SetName(string pName) { name_ = pName;	}

	string GetSurname() const {	return surname_;	}
	void SetSurname(string pSurname) { surname_ = pSurname;	}

	int GetAge() const	  { return age_; }
	void SetAge(int pAge) { age_ = pAge;	}

    // �������� ������ ���������
	Memento* SaveMemento() const
	{
		cout << "\nhuman: �������� ���������\n";
		return new Memento(name_, surname_, age_);
	}

	// ��������������� ���������
	void RestoreMemento(Memento* pMemento)
	{
		cout << "\nhuman: �������������� ���������\n";
		name_ = pMemento->GetName();
		surname_ = pMemento->GetSurname();
		age_ = pMemento->GetAge();
	}
};

