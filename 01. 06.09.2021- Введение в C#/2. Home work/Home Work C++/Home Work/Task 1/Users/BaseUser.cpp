#include "BaseUser.h"
#include "../Interface.h"

#pragma region ������������, ���������� � �������� �������������

	// ����������� �� ���������
	BaseUser::BaseUser() : id_(genID()), interface_() {}

#pragma endregion

#pragma region ������� � �������

	// ������ id_
	const string& BaseUser::getId() const { return id_; }

	// ������ interface_
	void BaseUser::setInterface(Interface* value) { interface_ = value; }

	// ������ interface_
	Interface* BaseUser::getInterface() const { return interface_; }

	// ������ name_
	void BaseUser::setName(string value) { name_ = value; }

	// ������ name_
	const string& BaseUser::getName() const { return name_; }

	// ������ info_
	const string& BaseUser::getInfo() const { return info_; }

#pragma endregion 

#pragma region ������ 

	// ��������� ID
	string BaseUser::genID()
	{
		string res;

		for (int i = 0; i < N_ID; i++)
		{
			res += getRand('0', '9');
		}

		return res;
	}

	// �����������
	void BaseUser::reg()
	{
		// ���� �� ������ ���������
		if (interface_ == nullptr)
			throw exception("App: ��������� �� ������!");

		// ����������� 
		interface_->regUser(this);
	}

	// �������� ����������� 
	void BaseUser::delReg()
	{
		// ���� �� ������ ���������
		if (interface_ == nullptr)
			throw exception("App: ��������� �� ������!");

		// �������� �����������
		interface_->deleteUser(id_);
	}

#pragma region ����� � ������� 

	// ����� ������������� 
	void BaseUser::showTable(string name, string info, const vector<BaseUser*>& users)
	{
		// ����� ����� �������
		showHead(name, info);

		// ����� �������� 
		int i = 1;

		// ����� ��������� 
		for_each(users.begin(), users.end(), [i](BaseUser* u) mutable { u->showElem(i++); });

		// ����� ����� �����������
		showLine();
	}

	// ����� ������������� 
	void BaseUser::showTable(string name, string info, const map<string, BaseUser*>& users)
	{
		// ����� ����� �������
		showHead(name, info);

		// ����� �������� 
		int i = 1;

		// ����� ��������� 
		for_each(users.begin(), users.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		// ����� ����� �����������
		showLine();
	}

	// ����� ������� ������������ � ��� ��������� 
	void BaseUser::showTableMessage(string name, string info) 
	{
		
		cout << color(lineColor)
			<< "  +��������������������������������������������������������+��������������������������������������������������������+\n"
			<< "  | " << left
			<< color(textColorG) << "��������: "
			<< color(textColorM) << setw(44) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "����������: "
			<< color(textColorM) << setw(42) << info
			<< color(lineColor) << " |\n"
			<< "  +�����������������������������+��������������������������+��������������������������+�����������������������������+\n"
			<< "  | "
			<< color(textColorY) << "    ID: "
			<< color(textColorG) << setw(19) << id_
			<< color(lineColor) << " | "
			<< color(textColorY) << "��: "
			<< color(textColorG) << setw(20) << name_
			<< color(lineColor) << " | "
			<< color(textColorY) << "����: "
			<< color(textColorG) << setw(18) << info_
			<< color(lineColor) << " | " << right
			<< color(textColorY) << "���������� ���������: "
			<< color(textColorG) << setw(5) << messages_.size()
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		// ����� ����� ����������� 
		showLine();

		cout << color(lineColor) << "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "    ID �����������    "
			<< color(lineColor) << " | "
			<< color(textColorY) << "     �� �����������     "
			<< color(lineColor) << " | "
			<< color(textColorY) << " ���������� ����������� "
			<< color(lineColor) << " | "
			<< color(textColorY) << "        ���������          "
			<< color(lineColor) << " |\n"
			<< color(mainColor);


		// ����� ����� ����������� 
		showLine();

		// ����� ��������� ������������ 
		showElemMessage(1);
	}

	// ����� ����� �������
	void BaseUser::showHead(string name, string info)
	{
		cout << color(lineColor)
			<< "  +��������������������������������������������������������+��������������������������������������������������������+\n"
			<< "  | " << left
			<< color(textColorG) << "��������: "
			<< color(textColorM) << setw(44) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "����: "
			<< color(textColorM) << setw(48) << info
			<< color(lineColor) << " |\n"
			<< "  +����+������������������������+��������������������������+��������������������������+�����������������������������+\n"
			<< "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "         ID           "
			<< color(lineColor) << " | "
			<< color(textColorY) << "     ������� � ���      "
			<< color(lineColor) << " | "
			<< color(textColorY) << "       ����������       "
			<< color(lineColor) << " | " << right
			<< color(textColorY) << " ����� �������� ��������� "
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		// ����� ����� ����������� 
		showLine();
	}

	// ����� �������� � �����������
	void BaseUser::showElemMessage(int num) const
	{
		// ���� ��� ������
		if (messages_.empty())
			showEmpty();

		else
		{
			// ����� �������� 
			int i = 1;

			// ����� ������ ����������� � ���������
			auto lambda = [&i](Message message)
			{
				cout << color(lineColor) << "  | "
					<< color(LTBLACK_ON_BLACK) << setw(2) << i++
					<< color(lineColor) << " | " << left
					<< color(textColorG) << setw(22) << message.getSenderID()
					<< color(lineColor) << " | "
					<< color(textColorG) << setw(24) << message.getSenderName()
					<< color(lineColor) << " | "
					<< color(textColorM) << setw(24) << message.getSenderInfo()
					<< color(lineColor) << " | " 
					<< color(textColorY) << setw(27) << message.getMessage()
					<< color(lineColor) << " |\n" << right
					<< color(mainColor);
			};

			// ����� ��������� 
			for_each(messages_.begin(), messages_.end(), [&lambda](Message message) { lambda(message); });
		}

		// ����� ����� ����������
		showLine();
	}

	// ����� �������� 
	void BaseUser::showElem(int num) const
	{
		cout << color(lineColor) << "  | "
			<< color(LTBLACK_ON_BLACK) << setw(2) << num
			<< color(lineColor) << " | " << left
			<< color(textColorG) << setw(22) << id_
			<< color(lineColor) << " | "
			<< color(textColorG) << setw(24) << name_
			<< color(lineColor) << " | "
			<< color(textColorM) << setw(24) << info_
			<< color(lineColor) << " | " << right
			<< color(textColorG) << setw(27) << messages_.size()
			<< color(lineColor) << " |\n"
			<< color(mainColor);
	}

	// ����� �����-�����������
	void BaseUser::showLine()
	{
		cout << color(lineColor)
			<< "  +����+������������������������+��������������������������+��������������������������+�����������������������������+\n"
			<< color(mainColor);
	}

	// ����� ��������� �� ���������� ������
	void BaseUser::showEmpty()
	{
		cout << color(lineColor)
			<< "  |                                                   "
			<< color(RED_ON_BLACK) << " ��� ������ "
			<< color(lineColor)
			<< "                                                  |\n"
			<< color(mainColor);
	}

#pragma endregion

#pragma endregion 