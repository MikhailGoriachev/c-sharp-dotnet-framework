#pragma once

#include "../pch.h"
#include "../Utils.h"

// ����� ��������� 
class Message
{
	// ID ����������� 
	string senderID_;

	// ������� � ��� ����������� 
	string senderName_;

	// ���������� �� �����������
	string senderInfo_;

	// ID ���������� 
	string destID_;

	// ������� � ��� ����������� 
	string destName_;

	// ���������� � ����������
	string destInfo_;

	// ����� ��������� 
	string message_;

public:

#pragma region ������������, ���������� � �������� ������������

	// ����������� �� ���������
	Message() = default;

	// ����������� ���������������� (������ ������ ����������� � ����� ��������� )
	Message(string senderID, string senderName, string senderInfo, string destID, string destName, string destInfo, string message)
	{
		// ��������� �������� 
		setSenderID(senderID);
		setSenderName(senderName);
		setSenderInfo(senderInfo);
		setDestID(destID);
		setDestName(destName);
		setDestInfo(destInfo);
		setMessage(message);
	}

	// ����������� ���������� 
	Message(const Message& message) = default;

	// ���������� 
	~Message() = default;

	// ���������� �������� ������������
	Message& operator=(const Message& message) = default;

#pragma endregion 

#pragma region ��������� 

	// ������ senderID_
	void setSenderID(string value) { senderID_ = value; }

	// ������ senderID_
	const string& getSenderID() const { return senderID_; }

	// ������ senderName_
	void setSenderName(string value) { senderName_ = value; }

	// ������ senderName_
	const string& getSenderName() const { return senderName_; }

	// ������ senderInfo_
	void setSenderInfo(string value) { senderInfo_ = value; }

	// ������ senderInfo_
	const string& getSenderInfo() const { return senderInfo_; }

	// ������ destID_
	void setDestID(string value) { destID_ = value; }

	// ������ destID_
	const string& getDestID() const { return destID_; }

	// ������ destName_
	void setDestName(string value) { destName_ = value; }

	// ������ destName_
	const string& getDestName() const { return destName_; }

	// ������ destInfo_
	void setDestInfo(string value) { destInfo_ = value; }

	// ������ destInfo_
	const string& getDestInfo() const { return destInfo_; }

	// ������ message_
	void setMessage(string value) { message_ = value; }

	// ������ message_
	const string& getMessage() const { return message_; }

#pragma endregion 

};

