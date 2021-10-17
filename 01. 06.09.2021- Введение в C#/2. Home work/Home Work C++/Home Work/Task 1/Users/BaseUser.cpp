#include "BaseUser.h"
#include "../Interface.h"

#pragma region Конструкторы, деструктор и операция присванивания

	// конструктор по умолчанию
	BaseUser::BaseUser() : id_(genID()), interface_() {}

#pragma endregion

#pragma region Сеттеры и геттеры

	// геттер id_
	const string& BaseUser::getId() const { return id_; }

	// сеттер interface_
	void BaseUser::setInterface(Interface* value) { interface_ = value; }

	// геттер interface_
	Interface* BaseUser::getInterface() const { return interface_; }

	// сеттер name_
	void BaseUser::setName(string value) { name_ = value; }

	// геттер name_
	const string& BaseUser::getName() const { return name_; }

	// геттер info_
	const string& BaseUser::getInfo() const { return info_; }

#pragma endregion 

#pragma region Методы 

	// генерация ID
	string BaseUser::genID()
	{
		string res;

		for (int i = 0; i < N_ID; i++)
		{
			res += getRand('0', '9');
		}

		return res;
	}

	// регистрация
	void BaseUser::reg()
	{
		// если не указан интерфейс
		if (interface_ == nullptr)
			throw exception("App: Интерфейс не указан!");

		// регистрация 
		interface_->regUser(this);
	}

	// удаление регистрации 
	void BaseUser::delReg()
	{
		// если не указан интерфейс
		if (interface_ == nullptr)
			throw exception("App: Интерфейс не указан!");

		// удаление регистрации
		interface_->deleteUser(id_);
	}

#pragma region Вывод в таблицу 

	// вывод пользователей 
	void BaseUser::showTable(string name, string info, const vector<BaseUser*>& users)
	{
		// вывод шапки таблицы
		showHead(name, info);

		// номер элемента 
		int i = 1;

		// вывод элементов 
		for_each(users.begin(), users.end(), [i](BaseUser* u) mutable { u->showElem(i++); });

		// вывод линии разделителя
		showLine();
	}

	// вывод пользователей 
	void BaseUser::showTable(string name, string info, const map<string, BaseUser*>& users)
	{
		// вывод шапки таблицы
		showHead(name, info);

		// номер элемента 
		int i = 1;

		// вывод элементов 
		for_each(users.begin(), users.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		// вывод линии разделителя
		showLine();
	}

	// вывод таблицы пользователя и его сообщений 
	void BaseUser::showTableMessage(string name, string info) 
	{
		
		cout << color(lineColor)
			<< "  +————————————————————————————————————————————————————————+————————————————————————————————————————————————————————+\n"
			<< "  | " << left
			<< color(textColorG) << "Название: "
			<< color(textColorM) << setw(44) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "Информация: "
			<< color(textColorM) << setw(42) << info
			<< color(lineColor) << " |\n"
			<< "  +—————————————————————————————+——————————————————————————+——————————————————————————+—————————————————————————————+\n"
			<< "  | "
			<< color(textColorY) << "    ID: "
			<< color(textColorG) << setw(19) << id_
			<< color(lineColor) << " | "
			<< color(textColorY) << "ФИ: "
			<< color(textColorG) << setw(20) << name_
			<< color(lineColor) << " | "
			<< color(textColorY) << "Инфо: "
			<< color(textColorG) << setw(18) << info_
			<< color(lineColor) << " | " << right
			<< color(textColorY) << "Количество сообщений: "
			<< color(textColorG) << setw(5) << messages_.size()
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		// вывод линии разделителя 
		showLine();

		cout << color(lineColor) << "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "    ID отправителя    "
			<< color(lineColor) << " | "
			<< color(textColorY) << "     ФИ отправителя     "
			<< color(lineColor) << " | "
			<< color(textColorY) << " Информация отправителя "
			<< color(lineColor) << " | "
			<< color(textColorY) << "        Сообщение          "
			<< color(lineColor) << " |\n"
			<< color(mainColor);


		// вывод линии разделителя 
		showLine();

		// вывод сообщений пользователя 
		showElemMessage(1);
	}

	// вывод шапки таблицы
	void BaseUser::showHead(string name, string info)
	{
		cout << color(lineColor)
			<< "  +————————————————————————————————————————————————————————+————————————————————————————————————————————————————————+\n"
			<< "  | " << left
			<< color(textColorG) << "Название: "
			<< color(textColorM) << setw(44) << name
			<< color(lineColor) << " | "
			<< color(textColorG) << "Инфо: "
			<< color(textColorM) << setw(48) << info
			<< color(lineColor) << " |\n"
			<< "  +————+————————————————————————+——————————————————————————+——————————————————————————+—————————————————————————————+\n"
			<< "  | "
			<< color(textColorY) << "N "
			<< color(lineColor) << " | "
			<< color(textColorY) << "         ID           "
			<< color(lineColor) << " | "
			<< color(textColorY) << "     Фамилия и имя      "
			<< color(lineColor) << " | "
			<< color(textColorY) << "       Информация       "
			<< color(lineColor) << " | " << right
			<< color(textColorY) << " Кол—во принятых сообщений "
			<< color(lineColor) << " |\n"
			<< color(mainColor);

		// вывод линии разделителя 
		showLine();
	}

	// вывод элемента с сообщениями
	void BaseUser::showElemMessage(int num) const
	{
		// если нет данных
		if (messages_.empty())
			showEmpty();

		else
		{
			// номер элемента 
			int i = 1;

			// вывод данных отправителя и сообщения
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

			// вывод сообщений 
			for_each(messages_.begin(), messages_.end(), [&lambda](Message message) { lambda(message); });
		}

		// вывод линии раздлителя
		showLine();
	}

	// вывод элемента 
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

	// вывод линии-разделителя
	void BaseUser::showLine()
	{
		cout << color(lineColor)
			<< "  +————+————————————————————————+——————————————————————————+——————————————————————————+—————————————————————————————+\n"
			<< color(mainColor);
	}

	// вывод сообщения об отсутствии данных
	void BaseUser::showEmpty()
	{
		cout << color(lineColor)
			<< "  |                                                   "
			<< color(RED_ON_BLACK) << " НЕТ ДАННЫХ "
			<< color(lineColor)
			<< "                                                  |\n"
			<< color(mainColor);
	}

#pragma endregion

#pragma endregion 