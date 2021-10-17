#pragma once

#include "../pch.h"
#include "../Utils.h"

// Класс Сообщение 
class Message
{
	// ID отправителя 
	string senderID_;

	// фамилия и имя отправителя 
	string senderName_;

	// информация об отправителе
	string senderInfo_;

	// ID получателя 
	string destID_;

	// фамилия и имя отправителя 
	string destName_;

	// информация о получателе
	string destInfo_;

	// текст сообщения 
	string message_;

public:

#pragma region Конструкторы, деструктор и операция присваивания

	// конструктор по умолчанию
	Message() = default;

	// конструктор инициализирующий (только данные отправителя и текст сообщения )
	Message(string senderID, string senderName, string senderInfo, string destID, string destName, string destInfo, string message)
	{
		// установка значений 
		setSenderID(senderID);
		setSenderName(senderName);
		setSenderInfo(senderInfo);
		setDestID(destID);
		setDestName(destName);
		setDestInfo(destInfo);
		setMessage(message);
	}

	// конструктор копирующий 
	Message(const Message& message) = default;

	// деструктор 
	~Message() = default;

	// перегрузка операции присваивания
	Message& operator=(const Message& message) = default;

#pragma endregion 

#pragma region Аксессоры 

	// сеттер senderID_
	void setSenderID(string value) { senderID_ = value; }

	// геттер senderID_
	const string& getSenderID() const { return senderID_; }

	// сеттер senderName_
	void setSenderName(string value) { senderName_ = value; }

	// геттер senderName_
	const string& getSenderName() const { return senderName_; }

	// сеттер senderInfo_
	void setSenderInfo(string value) { senderInfo_ = value; }

	// геттер senderInfo_
	const string& getSenderInfo() const { return senderInfo_; }

	// сеттер destID_
	void setDestID(string value) { destID_ = value; }

	// геттер destID_
	const string& getDestID() const { return destID_; }

	// сеттер destName_
	void setDestName(string value) { destName_ = value; }

	// геттер destName_
	const string& getDestName() const { return destName_; }

	// сеттер destInfo_
	void setDestInfo(string value) { destInfo_ = value; }

	// геттер destInfo_
	const string& getDestInfo() const { return destInfo_; }

	// сеттер message_
	void setMessage(string value) { message_ = value; }

	// геттер message_
	const string& getMessage() const { return message_; }

#pragma endregion 

};

