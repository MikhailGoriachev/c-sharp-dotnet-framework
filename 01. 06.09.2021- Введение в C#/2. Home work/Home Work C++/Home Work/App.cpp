#include "App.h"
#include "./Task 1/Manager.h"
#include "./Task 1/Users/Admin.h"
#include "./Task 1/Users/Client.h"
#include "./Task 1/Users/Programmer.h"
#include "./Task 1/Users/Tester.h"

/*
	������� �� UML_DP. ������������ ���������� ���������� (��� ������, ����� ����������) 
	�� C++ ��� ������������ ��������� ��������� � ���������.

	������� 1. ���������. ������� ���������� ����������� ��������� � ����� �� �������� �������� ��� 
	�������: ���������, ������������, ������������, ��������������. ��� ������ ������ 
	����������������� ����� ����� � ������������ �����������. ��� ��������� ��������������
	����� �������� ���������� ����� ��������� ����� ��������� ��������, ������������ ���� 
	����������.

	������� 2. ���������. ������ � �������� �������� �������� ������� � ��� �����������, ��� ����� 
	�����������, ��� ����� ����������, ����� ��������. ����������� �������� ������ � 
	�������� ��� ������ �������� ���������, ������������������ ����������� ���������� � 
	�������������� ������ � ��������.

*/

// ����������� �� ���������
App::App() : manager_(new Manager)
{
	// ������������� ������� users_
	users_ = vector<BaseUser*>{
		new Admin(manager_, "���������� ����"),
		new Client(manager_, "�������� ������"),
		new Programmer(manager_, "����� ������"),
		new Tester(manager_, "�������� �����"),
	};
}

// ���������� 
App::~App()
{
	delete manager_;

	for (auto u : users_) delete u;
}

#pragma region ������� 

#pragma region ������� 1. ��������

	// ������� 1. ��������
	void App::task1()
	{
		// ��� ������ � ������ ���������� C++
		ostringstream oss;

		// TODO: ���� ����������
		App app;

		// ��������� ��� swith ����
		enum Commands {
			// 1. ���������������� ������������� 
			CMD_POINT_ONE,
			// 2. ������� ������������������ ������������� 
			CMD_POINT_TWO,
			// 3. ��������� ��������� 
			CMD_POINT_THREE,
			// 4. �������� ���� ������������� 
			CMD_POINT_FOUR,
			// 5. ����������� ��������� ���� �������������
			CMD_POINT_FIVE
		};

		// ���������� ������� ����
		const int N_MENU = 6;

		MenuItem items[N_MENU] = {
			MenuItem("1. ���������������� �������������", CMD_POINT_ONE),
			MenuItem("2. ������� ������������������ �������������", CMD_POINT_TWO),
			MenuItem("3. ��������� ���������", CMD_POINT_THREE),
			MenuItem("4. �������� ���� �������������", CMD_POINT_FOUR),
			MenuItem("5. ����������� ��������� ���� �������������", CMD_POINT_FIVE),

			// ����� �� ���������
			MenuItem("�����",  Menu::CMD_QUIT)
		};

		// ���������� ������ 
		const int N_PALETTE = 5;

		// ������ ������
		short palette[N_PALETTE] = { WHITE_ON_BLACK, LTCYAN_ON_BLACK, BLACK_ON_LTCYAN, GRAY_ON_BLACK };

		// ������ ����
		Menu mainMenu("������� 2. �������� �������", items, N_MENU, palette, COORD{ 5, 5 });

		while (true)
		{
			try {
				cout << color(palette[Menu::PAL_CONSOLE]) << cls;
				int cmd = mainMenu.Navigate();
				cout << color(palette[Menu::PAL_CONSOLE]) << cls;
				if (cmd == Menu::CMD_QUIT) return;

				// �������� �������
				cls();

				switch (cmd)
				{
					// 1. ���������������� ������������� 
				case CMD_POINT_ONE:
					app.regUser();
					break;

					// 2. ������� ������������������ ������������� 
				case CMD_POINT_TWO:
					app.deleteUser();
					break;

					// 3. ��������� ��������� 
				case CMD_POINT_THREE:
					app.sendMessage();
					break;

					// 4. �������� ���� ������������� 
				case CMD_POINT_FOUR:
					app.showUsers();
					break;

					// 5. ����������� ��������� ���� �������������
				case CMD_POINT_FIVE:
					app.showMessages();
					break;
				}

				cout << "\n\n";

				// �������� ������� �������
				getKey();
			}
			catch (exception& ex) {
				oss.str("");  // ������� ������ - ������ ������
				oss << "\n\t" << ex.what() << "\n";

				// ����� ������ � ���������� �� ������ � �����
				cputs(oss.str().c_str(), errColor);

				getKey();
			} // try-catch
		}
	}

	// 1. ���������������� ������������� 
	void App::regUser()
	{
		showNavBarMessage(hintColor, "  1. ���������������� ������������� ");

		cout << "\n\n\n";
		
		// ������ �� ������������������ ������������� 
		auto& regUs = manager_->getUsers();
		
		// ����������� �������������
		for_each(users_.begin(), users_.end(), [&regUs](BaseUser* us) {
		
			// ���� ������� ������������ ��� ���������������
			if (regUs.find(us->getId()) != regUs.end())
				return;
		
			// ����������� ������������
			us->reg();
		
			});
		
		// ����� ����� ������� 
		BaseUser::showHead("������������", "������������������");

		int i = 1;

		// ����� �������������
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		BaseUser::showLine();
	}

	// 2. ������� ������������������ ������������� 
	void App::deleteUser()
	{
		showNavBarMessage(hintColor, "  2. ������� ������������������ ������������� ");

		cout << "\n\n\n";

		// ������ �� ������������������ ������������� 
		auto& regUs = manager_->getUsers();

		// ����� ������������������ �������������
		BaseUser::showTable("������������", "������������������", regUs);

		cout << "\n\n\n";

		// ���� ��� ������������������ �������������
		if (regUs.empty())
			throw exception("App: ��� ������������������ �������������!");

		// ���������� �������� ������������� 
		int countDel = getRand(1, regUs.size());

		// �������� ��������� �������������
		for (int i = 0; i < countDel; i++)
		{
			// ������ ������������ 
			int index = getRand(0, regUs.size() - 1);

			// �������� 
			auto it = regUs.begin();

			// ����� �������� �� �������
			for (int i = 0; i < index; i++, it++);
			
			// �������� �������� �� ID
			regUs[it->second->getId()]->delReg();
		}

		// ����� ����� ������� 
		BaseUser::showHead("������������", "������������������");

		int i = 1;

		// ����� �������������
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable { p.second->showElem(i++); });

		BaseUser::showLine();
	}

	// 3. ��������� ���������
	void App::sendMessage()
	{
		showNavBarMessage(hintColor, "  3. ��������� ���������");

		// ������ �� ������������������ ������������� 
		auto& regUs = manager_->getUsers();

		// ���� ������ ��������������� ������ ���� ������������
		if (regUs.size() <= 1)
			throw exception("App: ������������ ������������� ��� �������� ���������!");

		// ������ 
		int size = regUs.size();

		// ������ ����������
		for (int iDest = 0; iDest < size; iDest++)
		{
			// ���������� ��������� 
			int countMess = getRand(3, 6);

			// ��������� ��������� 
			for (int i = 0; i < countMess; i++)
			{
				// ������ �����������
				int iSender;

				// ��������� ������� ����������
				do { iSender = getRand(0, regUs.size() - 1); } while (iSender == iDest);

				// �������� �����������
				auto itSender = regUs.begin();
				auto itDest = regUs.begin();

				// ������������ ������� 
				int iMax = max(iSender, iDest);

				// �������� �� ������ �������������
				auto it = regUs.begin();

				// ����� ��������� �� �������
				for (int i = 0; i <= iMax; i++, it++)
				{
					// ���� i == ������� ����������� 
					if (i == iSender)
						itSender = it;

					// ���� i == ������� ���������� 
					if (i == iDest)
						itDest = it;
				}

				// �����������
				auto sender = itSender->second;

				// ����������
				auto dest = itDest->second;

				// �������� ��������� 
				manager_->send(sender->getId(), dest->getId(), "������, ��� "s + sender->getName());
			}
		}

		// ����� ������������� � �� ��������� 
		int i = 1;

		// ����� �������������
		for_each(regUs.begin(), regUs.end(), [i](pair<string, BaseUser*> p) mutable
			{ p.second->showTableMessage("������������", "��� ���������"); 
				cputs("\n\n ����������������������������������������������������������������������������������������������������������������������� \n\n", textColorM); });
	}

	// 4. �������� ���� ������������� 
	void App::showUsers()
	{
		showNavBarMessage(hintColor, "  4. �������� ���� �������������");

		cout << "\n\n\n";

		// ������ �� ������������������ ������������� 
		auto regUs = manager_->getUsers();

		// ����� ������������������ �������������
		BaseUser::showTable("������������", "������������������", regUs);
	}

	// 5. ����������� ��������� ���� �������������
	void App::showMessages()
	{
		showNavBarMessage(hintColor, "  5. ����������� ��������� ���� �������������");

		cout << "\n\n";

		// ������ �� ������������������ ������������� 
		auto& regUs = manager_->getUsers();

		// ����� ������������� � �� ��������� 
		for_each(regUs.begin(), regUs.end(), [](pair<string, BaseUser*> p) mutable
			{ p.second->showTableMessage("������������", "��� ���������");
		cputs("\n\n ����������������������������������������������������������������������������������������������������������������������� \n\n", textColorM); });
	}

#pragma endregion 

#pragma region ������� 2. �������� �������

	// ������� 2. �������� �������
	void App::task2()
	{
		showNavBarMessage(hintColor, "������� 2. �������� �������");

		cout << "\n\n";

		// ������ �������� ���������
		vector<Transfer> transfers
		{
			Transfer("�������� �������",	"7498156242", "9874213214", 16'000),
			Transfer("�������� �����",		"9840965461", "2165645132", 45'000),
			Transfer("����������� Ը���",	"5406546897", "4531245365", 88'000),
			Transfer("�������� ����",		"7485345745", "3424523543", 96'000),
		};

		// ������ ����������� ��� �������� ���������� ������������
		vector<CareTaker> careTakers(4);

		// ����� ������ � ���������
		Transfer::showTable("��������", "�������� ������", transfers);

		cout << "\n\n";

		int i = 0;
	
		// �������� � ���������� ����� 
		for_each(transfers.begin(), transfers.end(), [i, &careTakers](Transfer& t) mutable 
			{ careTakers[i++].setObj(t.save()); });

		// �������� ������ � ���������
		transfers[0] = Transfer("���������� �����", "6549842154", "2411526161", 180'000);
		transfers[1] = Transfer("�������� ����",	"8734747564", "2837464548", 240'000);
		transfers[2] = Transfer("�������� ����",	"2349034894", "6748547347", 360'000);
		transfers[3] = Transfer("������� ��������",	"09568y5676", "3453452323", 480'000);

		// ����� ������ � ���������
		Transfer::showTable("��������", "���������� ������", transfers);

		cout << "\n\n";

		// �������� ���������� ������
		for_each(transfers.begin(), transfers.end(), [i, &careTakers](Transfer& t) mutable
			{ t.load((const Memento*)careTakers[i++].getObj()); });

		// ����� ������ � ���������
		Transfer::showTable("��������", "����������� ������", transfers);

		cout << "\n\n";

		getKey();
	}

#pragma endregion 

#pragma endregion


#pragma region ������ ������� ���������� 

// ������ ������� ����������
void App::preview()
{
	// ���������� �������
	setCursorVisible(false);

	// ����������� ���� 
	fillBackground(35, 121, BLACK_ON_CYAN, 20);

	// ����� �����
	outFrame(10, 50, 35, 10, BLACK_ON_LTCYAN, BLACK_ON_CYAN);

	// ����� ������ 
	outText("�������� ������� �� 08.09.2021", 30, BLACK_ON_CYAN, 45, 13);
	outText("������� ������", 30, BLACK_ON_CYAN, 53, 15);

	// ����� ������ �������� 
	loadingLine(61, 900, 30, 30);

	cout << "\n";

	Sleep(500);
}

// ���������� ������� ���� 
void App::fillBackground(int row, int col, short color, int time)
{
	// ������� ���� 
	short cl = getColor();

	// ��������� ��������� ����� 
	setColor(color);

	ostringstream os;

	os << setw(col) << " ";

	string str = os.str();

	// ���������� 
	for (int i = 0; i < row; i++)
	{
		cout << pos(0, i) << str;
		Sleep(time);
	}

	// ������������ ����� �� �������� 
	setColor(cl);
}

// �������� ������ ������ 
void App::outText(string message, int time, short color = mainColor, int x = -1, int y = -1)
{
	// ��������� ������� �������, ���� ��������� ��������
	if (x != -1 and y != -1)
	{
		// ��������� ������� 
		cout << pos(x, y);
	}

	// ���� ��������� �����������
	if (x < -1 and y < -1)
	{
		throw exception(("App: ���������"s + "x - " + to_string(x) + "y - " + to_string(y) + " �����������").c_str());
	}

	// ������� ����
	short cl = getColor();

	// ��������� ����� 
	setColor(color);

	// ����� ������
	size_t size = message.size();

	// ����� ������
	for (size_t i = 0; i < size; i++)
	{
		cout << message[i];
		Sleep(time);
	}
}

// �������� ������ �������� 
void App::loadingLine(int size, int time, int x, int y, short colorLoading, short colorBackground, short colorComplete)
{

#pragma region ��������� ������� � �������� ���������� 

	// ���� ��������� ������������ ���������
	if (size < 10 and time <= 0)
		throw exception("App: �������� ������������ ��������� � �������� ������ ��������");

	// ���� ��������� �����������
	if (x < 10 and y < 1)
	{
		throw exception(("App: ���������"s + "x - " + to_string(x) + "y - " + to_string(y) + " �����������").c_str());
	}

	// ���� �� ��������� 
	short cl = getColor();

	// ��������� ������� 
	// cout << pos(x + (size / 2) - 7, y - 3) << color(colorLoading) << setw(18) << " "
	// 	<< pos(x + (size / 2) - 7, y - 2) << " �������� ";

	// ������� ������ ������ ��������� 
	int posX = size / 2 - 8 + x;

	cout << pos(posX, y - 3) << color(BLACK_ON_BLACK) << setw(19) << left << " a" << color(colorLoading)
		<< pos(posX, y - 2) << " �������� " << right;

#pragma endregion 

#pragma region ���������� ��� ������ 

	// ���������� ����� 
	int countPercent = (size / 100 > 0 ? size / 100 : size % 100 / 10);

	// ����� ������
	int sizePercent = size / countPercent;

	// ����� �� ���� ������� ���������
	int timePercent = time / countPercent;

	// ����� ������ ������ ������� 
	int timeOne = timePercent / sizePercent;

	// ���������� ����� ������ 
	int timeRem = timePercent % sizePercent;

	// ��������� � ����� ������
	double percentCell = 100. / countPercent;

	// ��������� �� ���� ������
	double percentCymb = 100. / size;

	// ������� �������� �� ������ ������� 
	int sizeRem = size % countPercent;

	// ������� ������ ��������� 
	int xPosPercent = posX + 10; // x + (size / 2) + 2;

	// �������� 
	double percent = 0.;

#pragma endregion

#pragma region ����� 

	// ����� ������ ���� 
	cout << pos(x - 1, y - 1) << color(colorBackground) << setw(size + 2) << " "
		<< pos(x - 1, y) << color(colorBackground) << setw(size + 2) << " "
		<< pos(x - 1, y + 1) << color(colorBackground) << setw(size + 2) << " " << color(colorComplete);

	// ����������� � ������ ������ �������� 
	for (int i = 0; i < size; i++)	cout << "\b";


	cout.precision(2);

	// ����� ����������� 
	for (int i = 0; i < countPercent; i++)
	{
		// ����� ������ ������� 
		for (int k = 0; k < sizePercent; k++)
		{
			percent += percentCymb;
			cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% "
				<< color(colorComplete) << pos(x++, y) << " ";

			Sleep(timeOne);
		}

		cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% ";

		// �������� �� �������
		Sleep(timeRem);
	}

	// ���� ������� �� ���� ������� ��������� ����� ����
	if (timePercent == 0)
		Sleep(time);

	// ���� ����� ������ �������� �� ������� ������ �� 100
	if (sizeRem != 0)
	{
		// ����� ������ �������
		for (int k = 0; k < sizeRem; k++)
		{
			percent += percentCymb;

			cout << color(colorLoading) << pos(xPosPercent, y - 2) << setw(7) << percent << "% "
				<< color(colorComplete) << pos(x++, y) << " ";

			Sleep(timeOne);
		}
	}

	// ����������� ����� �� ���������
	setColor(cl);

#pragma endregion

}

// ����� �����
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