#include "pch.h"
#include "Utils.h"
#include "Colors.h"

// ��������� ���������� ���������� - ����������� ����������
// ��������� � ������������ ���������� (�������� - singleton),
// ������� ��������� - ������ ���� ��������� ����
static HANDLE h = GetStdHandle(STD_OUTPUT_HANDLE);

void init(const wchar_t title[])
{
	SetConsoleTitle(title);

	SetConsoleOutputCP(CODE_PAGE);
	SetConsoleCP(CODE_PAGE);
	srand(GetTickCount());
	cout << fixed << setprecision(5);

	setColor(mainColor);
	cls();
} // init

// ��������� ���� ������� �������
int getKey(const char* prompt)
{
	cout << prompt;

	int key = _getch();
	if (key == 0 || key == 224) key = _getch();

	return key;
} // getKey

// ��������� ���������� �����
int getRand(int low, int high)
{
	return low + rand() % (high - low + 1);
} // getRand

// ��������� ���������� ������������� �����  
double getRand(double low, double high)
{
	double x = low + (high - low) * rand() / RAND_MAX;
	// ��� ��������� 0
	// return abs(x) < 0.8?0:x;
	return x;
} // getRand

// ������� ����� �������
void setColor(short color)
{
	SetConsoleTextAttribute(h, color);
} // setColor

// ���� ������ �����, ��������� propmt[],
// �������� ���������� �������� from � to
int getInt(const char prompt[], int from, int to)
{
	int value;
	do {
		// ���������� ����
		cout << prompt;
		cin >> value;

		// ���� ����� �����, ����� �� ����� � �� �������
		if (!cin.fail()) break;

		// ���� ��� �� ����� - ����� ��������� ������,
		// ������ ������ �����
		cin.clear();
		cin.ignore(cin.rdbuf()->in_avail(), '\n');
	} while (value < from || value > to);

	return value;
} // getInt

// ���� ������������� �����, ��������� propmt[],
// �������� ���������� �������� from � to
double getDouble(const char* prompt, double from, double to)
{
	double value;
	do {
		// ���������� ����
		cout << prompt;
		cin >> value;

		// ���� ����� �� ����� - ����� ��������� ������,
		// ������� ������ ����� 
		if (cin.fail()) {
			cin.clear();
			cin.ignore(cin.rdbuf()->in_avail(), '\n');
			value = from - 1; // ����� �������� � �����
		} // if
	} while (value < from || value > to);

	return value;
} // getDouble

/// ����� ��������� � ������� ������ ���� - ������ ��������� ��� ���������� �����
void showNavBarMessage(short hintColor, const char* message)
{
	// ��������� ���� �������
	short oldColor = getColor();

	// ����� ���� � ������� ������ ���������
	setColor(hintColor);
	gotoXY(0, 0);

	// ����� ��������� � ����������� �������������
	// 121 - ������ ���� �������
	cout << setw(121) << left << message << right;

	// �������������� ����� 
	setColor(oldColor);
} // showNavBarMessage


// ����� ��������� "������� � ����������"
void showUnderConstruction(short width, short infoColor)
{
	const char* msg[] = {
		"�", // ��� ������ � ����� 255, ��� ���� ����� ������������ ������� �� ������ �����������...
		"    [����������]",
		"    ������� � ����������",
		"�", // ��� ������ � ����� 255, ��� ���� ����� ������������ ������� �� ������ �����������...
		"    ������� ����� ������� ��� �����������...",
		"�", // ��� ������ � ����� 255, ��� ���� ����� ������������ ������� �� ������ �����������...
		"�", // ��� ������ � ����� 255, ��� ���� ����� ������������ ������� �� ������ �����������...
		nullptr // ������� ����� ������
	};
	showMessage(8, 4, width, msg, infoColor);
	gotoXY(8, 30);
} // showUnderConstruction



// ����� ��������� msg � ������� ������, ������� � ������� x, y
// ������ ���� ������ width, ���� ���������� ������ - msgColor
// ����� ����� �� ������, ������ nullptr
void showMessage(short x, short y, short width, const char* msg[], short msgColor)
{
	// ��������� ������� ���� �������
	short oldColor = getColor();
	setColor(msgColor);

	// ������� ������ ��������� � ���� ������� width ��������
	// ������ ��������� �� ����������� ������, ������ nullptr 
	// ������ ��������� ����� ��� ��������������� ���������� �������������� ������
	cout << left;
	for (short i = 0, row = y; msg[i] != nullptr; i++, row++) {
		cout << pos(x, row) << setw(width) << msg[i];
	} // for i

	// ������������ ������������ ������ �� ���������, ���� ����� �
	cout << right;
	setColor(oldColor);
} // showMessage

// ����� ����������� �� �����, ������������� ������ �����, ���� �������������
// � �������� color
void showInputLine(const char* prompt, int n, short color)
{
	cout << prompt;
	setColor(color);

	setCursorVisible(true);

	// ������� ������ ���������� ������, ����������
	// ������ � ������ ������, �� 1 ������ �� ������
	for (int i = 0; i < n; ++i) cout << " ";
	for (int i = 0; i < n - 1; ++i) cout << "\b";
} // showInputLine

// c ����������� �������� WinAPI -----------------------------------------

// ���������������� ������� � �������� ������� �������
void gotoXY(short x, short y) {
	SetConsoleCursorPosition(h, COORD{ x, y });
} // gotoXY

// ��������� ��� ���������� ������� �������
// mode: true  - �������� ������
//       false - ��������� ������
void setCursorVisible(bool mode)
{
	// ��� ���� ��������� winAPI
	CONSOLE_CURSOR_INFO info;

	// ��������� ������ � ��� ���������
	GetConsoleCursorInfo(h, &info);

	info.bVisible = mode;
	SetConsoleCursorInfo(h, &info);
} // void setCursorVisible

// ������� ������ �������
void cls()
{
	COORD coordScreen = { 0, 0 }; // �������� ������� ��� �������
	DWORD cCharsWritten;
	CONSOLE_SCREEN_BUFFER_INFO csbi;
	DWORD dwConSize;
	// ������� ����� ���������� ����� � ������� ������.

	if (!GetConsoleScreenBufferInfo(h, &csbi)) return;

	// ������ ���� ������� � ��������
	dwConSize = csbi.dwSize.X * csbi.dwSize.Y;

	// �������� ��������� ����� ��������� - ��� � ���� �������
	// cCharsWritten - ������� ���������� ��������
	if (!FillConsoleOutputCharacter(h, (TCHAR)' ', dwConSize, coordScreen, &cCharsWritten))
		return;

	// ��������� ��������������� �������� ������ �� ������� ���������.
	if (!FillConsoleOutputAttribute(h, csbi.wAttributes,
		dwConSize, coordScreen, &cCharsWritten))
		return;

	// �������� ������ � ��������� ������� ����� ������� ������ - ������� ����� ����
	SetConsoleCursorPosition(h, coordScreen);
} // cls

// ����� ������ � �������� �����
void cputs(const char* str, short color)
{
	// ��������� ������� ���� ������ 
	short oldColor = getColor();

	// ���������� �������� ���� ������ � ������� ������
	setColor(color);
	cout << str;

	// ������������ ���� ������
	setColor(oldColor);
} // cputs

// ����� ������ � �������� ����������� ���� ������� �������� ������
void writeXY(short x, short y, const char* str, short color)
{
	// ���������� �������� ���� ������ � ������� ������
	// � �������� ������� ������
	gotoXY(x, y);
	cputs(str, color);
} // writeXY

// �������� ������� ���� ������ � �������
short getColor()
{
	// ��������� ��������� - ���������� � ������ �������, � �.�. ���� 
	// ���������� ������
	CONSOLE_SCREEN_BUFFER_INFO csbi;

	// ������� �������� ������ � �������, ���� �� ���������� - ������
	// ����������� ��������� ������ (����� �� ������)
	if (!GetConsoleScreenBufferInfo(h, &csbi)) return GRAY_ON_BLACK;

	// ������� ������� �����, ���������� �� ���������� ������ �������
	return csbi.wAttributes;
} // getColor


// -------------------------------------------

// ���������� ���������� ������������ ��� ����������
ostream& tab(ostream& os)
{
	os << "\t";
	return os;
} // tab

ostream& cls(ostream& os)
{
	cls();
	return os;
} // cls

// ���������� ������������ ��� ���������� �������
ostream& cursor_off(ostream& os)
{
	setCursorVisible(false);
	return os;
} // cursor_off

// ���������� ������������ ��� ��������� �������
ostream& cursor_on(ostream& os)
{
	setCursorVisible(true);
	return os;
} // cursor_on

// ���������� ���������� ������������ � ���������� endlm(n)
ostream& operator<<(ostream& os, const endlm& object)
{
	for (int i = 0; i < object.n_; ++i)
		os << endl;
	return os;
} // operator<<

// ���������� ���������� ������������ � ���������� color(c)
ostream& operator<<(ostream& os, const color& color)
{
	setColor(color.color_);
	return os;
} // operator<<

ostream& operator<<(ostream& os, const pos& object)
{
	SetConsoleCursorPosition(h, COORD{ object.x_, object.y_ });
	return os;
}
