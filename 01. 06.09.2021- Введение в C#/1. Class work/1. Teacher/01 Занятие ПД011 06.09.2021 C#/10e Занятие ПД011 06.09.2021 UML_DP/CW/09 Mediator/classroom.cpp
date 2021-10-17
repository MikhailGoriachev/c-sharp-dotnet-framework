#include "Classroom.h"
#include "Trainee.h"


// регистрация в посреднике для обмена сообщениями
void Classroom::Register(Trainee* trainee)
{
	if (trainees.find(trainee->GetName()) == trainees.end())	{
		trainees[trainee->GetName()] = trainee;
	} // if
	trainee->SetClassroom(this);
} // Classroom::Register

// реализация отправки сообщения
void Classroom::Send(string from, string to, string message)
{
	auto ptrTrainee = trainees.find(to);

	if (ptrTrainee != trainees.end()) {
		(*ptrTrainee).second->Receive(from, message);
	}
	else {
		cout << "\nПолучателя \"" << to << "\" нет среди зарегистрированных учеников\n";
	}// if
} // Classroom::Send
