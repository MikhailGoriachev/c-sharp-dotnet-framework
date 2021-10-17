#include "App.h"
#include "./Task 1/Manager.h"
#include "./Task 1/Users/Admin.h"
#include "./Task 1/Users/Client.h"
#include "./Task 1/Users/Programmer.h"
#include "./Task 1/Users/Tester.h"

/*
	Задание по UML_DP. Разработайте консольное приложение (как обычно, макет приложения) 
	на C++ для демонстрации паттернов Хранитель и Посредник.

	Задание 1. Посредник. Процесс разработки программных продуктов в одной из компаний включает ряд 
	экторов: заказчики, программисты, тестировщики, администраторы. Эти экторы должны 
	взаимодействовать между собой – обмениваться сообщениями. Для упрощения взаимодействия
	между экторами реализуйте обмен сообщения через менеджера проектов, выполняющего роль 
	посредника.

	Задание 2. Хранитель. Данные о денежном переводе содержат фамилию и имя отправителя, код счета 
	отправителя, код счета получателя, сумму перевода. Реализовать хранение данных о 
	переводе при помощи паттерна Хранитель, продемонстрировать возможности сохранения и 
	восстановления данных о переводе.

*/

// конструктор по умолчанию
App::App() : manager_(new Manager)
{
	// инициализация вектора users_
	users_ = vector<BaseUser*>{
		new Admin(manager_, "Калашников Марк"),
		new Client(manager_, "Дроздова Полина"),
		new Programmer(manager_, "Орлов Никита"),
		new Tester(manager_, "Никитина Алиса"),
	};
}

// деструктор 
App::~App()
{
	delete manager_;

	for (auto u : users_) delete u;
}

#pragma region Задания 

#pragma region Задание 1. Менеджер

	// Задание 1. Менеджер
	void App::task1()
	{
		// для вывода в строку средствами C++
		ostringstream oss;

		// TODO: Ваше приложение
		App app;

		// константы для swith меню
		enum Commands {
			// 1. Зарегистрировать пользователей 
			CMD_POINT_ONE,
			// 2. Удалить зарегистрированных пользователей 
			CMD_POINT_TWO,
			// 3. Отправить сообщения 
			CMD_POINT_THREE,
			// 4. Просмотр всех пользователей 
			CMD_POINT_FOUR,
			// 5. Просмотреть сообщения всех пользователей
			CMD_POINT_FIVE
		};

		// количество пунктов меню
		const int N_MENU = 6;

		MenuItem items[N_MENU] = {
			MenuItem("1. Зарегистрировать пользователей", CMD_POINT_ONE),
			MenuItem("2. Удалить зарегистрированных пользователей", CMD_POINT_TWO),
			MenuItem("3. Отправить сообщения", CMD_POINT_THREE),
			MenuItem("4. Просмотр всех пользователей", CMD_POINT_FOUR),
			MenuItem("5. Просмотреть сообщения всех пользователей", CMD_POINT_FIVE),

			// выход из программы
			MenuItem("Выход",  Menu::CMD_QUIT)
		};

		// количество цветов 
		const int N_PALETTE = 5;

		// массив цветов
		short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, GRAY_ON_BLACK };

		// объект меню
		Menu mainMenu("Задание 2. Денежный перевод", items, N_MENU, palette, COORD{ 5, 5 });

		while (true)
		{
			try {
				cout << color(palette[Menu::PAL_CONSOLE]) << cls;
				int cmd = mainMenu.Navigate();
				cout << color(palette[Menu::PAL_CONSOLE]) << cls;
				if (cmd == Menu::CMD_QUIT) return;

				// отчистка консоли
				cls();

				switch (cmd)
				{
					// 1. Зарегистрировать пользователей 
				case CMD_POINT_ONE:
					app.regUser();
					break;

					// 2. Удалить зарегистрированных пользователей 
				case CMD_POINT_TWO:
					app.deleteUser();
					break;

					// 3. Отправить сообщения 
				case CMD_POINT_THREE:
					app.sendMessage();
					break;

					// 4. Просмотр всех пользователей 
				case CMD_POINT_FOUR:
					app.showUsers();
					break;

					// 5. Просмотреть сообщения всех пользователей
				case CMD_POINT_FIVE:
					app.showMessages();
					break;
				}

				cout << "\n\n";

				// ожилание нажатия клавиши
				getKey();
			}
			catch (exception& ex) {
				oss.str("");  // очистка строки - буфера вывода
				oss << "\n\t" << ex.what() << "\n";

				// вывод строки с сообщением об ошибке в цвете
				cputs(oss.str().c_str(), errColor);

				getKey();
			} // try-catch
		}
	}

	// 1. Зарегистрировать пользователей 
	void App::regUser()
	{
		showNavBarMessage(hintColor, "  1. Зарегистрировать пользователей ");

		cout << "\n\n\n";
		
		// ссылка на зарегистрированных пользователей 
		auto& regUs = manager_->getUsers();
		
		// регистрация пользователей
		for_each(users_.begin(), users_.end(), [&regUs](BaseUser* us) {
		
			// если текущий пользователь уже зарегистрирован
			if (regUs.find(us->getId()) != regUs.end())
				return;
		
			// регистрация пользователя
			us->reg();
		
			});
		
		// вывод шапки таблицы 
		BaseUser::showHead("Пользователи", "Зарегистрированные");

		int i = 1;

		// вывод пользователей
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		BaseUser::showLine();
	}

	// 2. Удалить зарегистрированных пользователей 
	void App::deleteUser()
	{
		showNavBarMessage(hintColor, "  2. Удалить зарегистрированных пользователей ");

		cout << "\n\n\n";

		// ссылка на зарегистрированных пользователей 
		auto& regUs = manager_->getUsers();

		// вывод зарегистрированных пользователей
		BaseUser::showTable("Пользователи", "Зарегистрированные", regUs);

		cout << "\n\n\n";

		// если нет зарегистрированных пользователей
		if (regUs.empty())
			throw exception("App: Нет зарегистрированных пользователей!");

		// количество удалённых пользователей 
		int countDel = getRand(1, regUs.size());

		// удаление случайных пользователей
		for (int i = 0; i < countDel; i++)
		{
			// индекс пользователя 
			int index = getRand(0, regUs.size() - 1);

			// итератор 
			auto it = regUs.begin();

			// поиск элемента по индексу
			for (int i = 0; i < index; i++, it++);
			
			// удаление элемента по ID
			regUs[it->second->getId()]->delReg();
		}

		// вывод шапки таблицы 
		BaseUser::showHead("Пользователи", "Зарегистрированные");

		int i = 1;

		// вывод пользователей
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		BaseUser::showLine();
	}

	// 3. Отправить сообщения
	void App::sendMessage()
	{
		showNavBarMessage(hintColor, "  3. Отправить сообщения");

		// ссылка на зарегистрированных пользователей 
		auto& regUs = manager_->getUsers();

		// если только зарегистрирован только один пользователь
		if (regUs.size() <= 1)
			throw exception("App: Недостаточно пользователей для отправки сообщения!");

		// размер 
		int size = regUs.size();

		// индекс получателя
		for (int iDest = 0; iDest < size; iDest++)
		{
			// количество сообщений 
			int countMess = getRand(3, 6);

			// генерация сообщений 
			for (int i = 0; i < countMess; i++)
			{
				// индекс отправителя
				int iSender;

				// генерация индекса получателя
				do { iSender = getRand(0, regUs.size() - 1); } while (iSender == iDest);

				// итератор отправителя
				auto itSender = regUs.begin();
				auto itDest = regUs.begin();

				// максимальный инедекс 
				int iMax = max(iSender, iDest);

				// итератор по списку пользователей
				auto it = regUs.begin();

				// поиск элементов по индексу
				for (int i = 0; i <= iMax; i++, it++)
				{
					// если i == индексу отправителя 
					if (i == iSender)
						itSender = it;

					// если i == индексу получателя 
					if (i == iDest)
						itDest = it;
				}

				// отправитель
				auto sender = itSender->second;

				// получатель
				auto dest = itDest->second;

				// отправка сообщения 
				manager_->send(sender->getId(), dest->getId(), "Привет, это "s + sender->getName());
			}
		}

		// вывод пользователей и их сообщений 
		int i = 1;

		// вывод пользователей
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable
			{ p.second->showTableMessage("Пользователь", "Все сообщения"); 
				cputs("\n\n ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— \n\n", textColorM); });
	}

	// 4. Просмотр всех пользователей 
	void App::showUsers()
	{
		showNavBarMessage(hintColor, "  4. Просмотр всех пользователей");

		cout << "\n\n\n";

		// ссылка на зарегистрированных пользователей 
		auto regUs = manager_->getUsers();

		// вывод зарегистрированных пользователей
		BaseUser::showTable("Пользователи", "Зарегистрированные", regUs);
	}

	// 5. Просмотреть сообщения всех пользователей
	void App::showMessages()
	{
		showNavBarMessage(hintColor, "  5. Просмотреть сообщения всех пользователей");

		cout << "\n\n";

		// ссылка на зарегистрированных пользователей 
		auto& regUs = manager_->getUsers();

		// вывод пользователей и их сообщений 
		for_each(regUs.begin(), regUs.end(), [](pair<string, BaseUser*> p) mutable
			{ p.second->showTableMessage("Пользователь", "Все сообщения");
		cputs("\n\n ——————————————————————————————————————————————————————————————————————————————————————————————————————————————————————— \n\n", textColorM); });
	}

#pragma endregion 

#pragma region Задание 2. Денежный перевод

	// Задание 2. Денежный перевод
	void App::task2()
	{
		showNavBarMessage(hintColor, "Задание 2. Денежный перевод");

		cout << "\n\n";

		// вектор денежных переводов
		vector<Transfer> transfers
		{
			Transfer("Майорова Валерия",	"7498156242", "9874213214", 16'000),
			Transfer("Смирнова Мария",		"9840965461", "2165645132", 45'000),
			Transfer("Александров Фёдор",	"5406546897", "4531245365", 88'000),
			Transfer("Воронина Кира",		"7485345745", "3424523543", 96'000),
		};

		// вектор контейнеров для хранения сохранённой конфигурации
		vector<CareTaker> careTakers(4);

		// вывод данных о переводах
		Transfer::showTable("Переводы", "Исходные данные", transfers);

		cout << "\n\n";

		int i = 0;
	
		// создание и сохранение копий 
		for_each(transfers.begin(), transfers.end(), [i, &careTakers](Transfer& t) mutable 
			{ careTakers[i++].setObj(t.save()); });

		// исходных данных о переводах
		transfers[0] = Transfer("Герасимова Амина", "6549842154", "2411526161", 180'000);
		transfers[1] = Transfer("Медведев Глеб",	"8734747564", "2837464548", 240'000);
		transfers[2] = Transfer("Щербаков Марк",	"2349034894", "6748547347", 360'000);
		transfers[3] = Transfer("Петрова Кристина",	"09568y5676", "3453452323", 480'000);

		// вывод данных о переводах
		Transfer::showTable("Переводы", "Измененные данные", transfers);

		cout << "\n\n";

		// загрузка сохранённых данных
		for_each(transfers.begin(), transfers.end(), [i, &careTakers](Transfer& t) mutable
			{ t.load((const Memento*)careTakers[i++].getObj()); });

		// вывод данных о переводах
		Transfer::showTable("Переводы", "Загруженные данные", transfers);

		cout << "\n\n";

		getKey();
	}

#pragma endregion 

#pragma endregion


#pragma region Превью запуска приложения 

// Превью запуска приложения
void App::preview()
{
	// выключение курсора
	setCursorVisible(false);

	// заполенение фона 
	fillBackground(35, 121, BLACK_ON_CYAN, 20);

	// вывод рамки
	outFrame(10, 50, 35, 10, BLACK_ON_LTCYAN, BLACK_ON_CYAN);

	// вывод текста 
	outText("Домашнее задание на 08.09.2021", 30, BLACK_ON_CYAN, 45, 13);
	outText("Горячев Михаил", 30, BLACK_ON_CYAN, 53, 15);

	// вывод полосы загрузки 
	loadingLine(61, 900, 30, 30);

	cout << "\n";

	Sleep(500);
}

// заполнение заднего фона 
void App::fillBackground(int row, int col, short color, int time)
{
	// текущий цвет 
	short cl = getColor();

	// включение заданного цвета 
	setColor(color);

	ostringstream os;

	os << setw(col) << " ";

	string str = os.str();

	// заполнение 
	for (int i = 0; i < row; i++)
	{
		cout << pos(0, i) << str;
		Sleep(time);
	}

	// переключение цвета на исходный 
	setColor(cl);
}

// анимация вывода текста 
void App::outText(string message, int time, short color = mainColor, int x = -1, int y = -1)
{
	// установка позиции курсора, если параметры переданы
	if (x != -1 and y != -1)
	{
		// установка курсора 
		cout << pos(x, y);
	}

	// если параметры некорректны
	if (x < -1 and y < -1)
	{
		throw exception(("App: Параметры"s + "x - " + to_string(x) + "y - " + to_string(y) + " некорректны").c_str());
	}

	// текущий цвет
	short cl = getColor();

	// установка цвета 
	setColor(color);

	// длина строки
	size_t size = message.size();

	// вывод строки
	for (size_t i = 0; i < size; i++)
	{
		cout << message[i];
		Sleep(time);
	}
}

// анимация полосы загрузки 
void App::loadingLine(int size, int time, int x, int y, short colorLoading, short colorBackground, short colorComplete)
{

#pragma region Установка позиции и проверка исключений 

	// если переданны некорректные параметры
	if (size < 10 and time <= 0)
		throw exception("App: Переданы некорректные параметры в анимацию полосы загрузки");

	// если параметры некорректны
	if (x < 10 and y < 1)
	{
		throw exception(("App: Параметры"s + "x - " + to_string(x) + "y - " + to_string(y) + " некорректны").c_str());
	}

	// цвет по умолчанию 
	short cl = getColor();

	// установка курсора 
	// cout << pos(x + (size / 2) - 7, y - 3) << color(colorLoading) << setw(18) << " "
	// 	<< pos(x + (size / 2) - 7, y - 2) << " Загрузка ";

	// позиция начала вывода процентов 
	int posX = size / 2 - 8 + x;

	cout << pos(posX, y - 3) << color(BLACK_ON_BLACK) << setw(19) << left << " a" << color(colorLoading)
		<< pos(posX, y - 2) << " Загрузка " << right;

#pragma endregion 

#pragma region Переменные для вывода 

	// количество ячеек 
	int countPercent = (size / 100 > 0 ? size / 100 : size % 100 / 10);

	// длина ячейки
	int sizePercent = size / countPercent;

	// время на одно деление процентов
	int timePercent = time / countPercent;

	// время вывода одного символа 
	int timeOne = timePercent / sizePercent;

	// остаточное время вывода 
	int timeRem = timePercent % sizePercent;

	// процентов в одной ячейке
	double percentCell = 100. / countPercent;

	// процентов на один символ
	double percentCymb = 100. / size;

	// остаток символов от целого деления 
	int sizeRem = size % countPercent;

	// позиция начала процентов 
	int xPosPercent = posX + 10; // x + (size / 2) + 2;

	// проценты 
	double percent = 0.;

#pragma endregion

#pragma region Вывод 

	// вывод полосы фона 
	cout << pos(x - 1, y - 1) << color(colorBackground) << setw(size + 2) << " "
		<< pos(x - 1, y) << color(colorBackground) << setw(size + 2) << " "
		<< pos(x - 1, y + 1) << color(colorBackground) << setw(size + 2) << " " << color(colorComplete);

	// возвращение в начало полосы загрузки 
	for (int i = 0; i < size; i++)	cout << "\b";


	cout.precision(2);

	// вывод заполенения 
	for (int i = 0; i < countPercent; i++)
	{
		// вывод одного деления 
		for (int k = 0; k < sizePercent; k++)
		{
			percent += percentCymb;
			cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% "
				<< color(colorComplete) << pos(x++, y) << " ";

			Sleep(timeOne);
		}

		cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% ";

		// задержка по времени
		Sleep(timeRem);
	}

	// если времени на одно деление процентов равно нулю
	if (timePercent == 0)
		Sleep(time);

	// если длина строки загрузки не делится нацело на 100
	if (sizeRem != 0)
	{
		// вывод одного деления
		for (int k = 0; k < sizeRem; k++)
		{
			percent += percentCymb;

			cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% "
				<< color(colorComplete) << pos(x++, y) << " ";

			Sleep(timeOne);
		}
	}

	// возвращение цвета по умолчанию
	setColor(cl);

#pragma endregion

}

// вывод рамки
void App::outFrame(int hight, int width, int x, int y, short colorFrame, short colorBackground)
{
	cout << pos(x, y++) << color(colorFrame) << setw(width) << " ";

	for (int i = 0; i < hight - 2; i++, y++)
	{
		cout << pos(x, y) << color(colorFrame) << " "
			<< color(colorBackground) << setw(width - 2) << " "
			<< color(colorFrame) << " ";
	}

	cout << pos(x, y) << color(colorFrame) << setw(width) << " ";
}

#pragma endregion