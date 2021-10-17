#pragma once
#include "Colors.h"
#include "Palette.h"

#include "App.h"

// ���� �������������� ������
const int K_F1 = 59, K_F2 = 60, K_F3 = 61, K_F4 = 62;
const int K_F5 = 63, K_F6 = 64, K_F7 = 65, K_F8 = 66;
const int K_F9 = 67, K_F10 = 68, K_F11 = 133, K_F12 = 134;
const int K_UP = 72, K_DOWN = 80, K_ENTER = 13, K_ESC = 27;

const int MAX_SECONDS = 24 * 60 * 60;

// ��������� ���������� ������� � ������ ����������
void init(const wchar_t title[] = L"��������� ����������");

// ��������� ���� ������� �������
int getKey(const char* prompt = "\n������� ����� ������� ��� �����������. . . ");

// ��������� ���������� �����
int    getRand(int low, int high);
double getRand(double low, double high);

// ������� ����� �������
void setColor(short color);

// ���� ������ �����
int getInt(const char prompt[], int from = INT_MIN, int to = INT_MAX);

// ���� ������������� �����
double getDouble(const char* prompt, double from = -DBL_MAX, double to = DBL_MAX);

// ����� ����������� �� �����, ������������� ������ �����, ���� �������������
// � �������� color
void showInputLine(const char* prompt, int n, short color);

// ����� ��������� msg � ������� ������, ������� � ������� x, y
// ������ ���� ������ width, ���� ���������� ������ - msgColor
// ����� ����� �� ������, ������ nullptr
void showMessage(short x, short y, short width, const char* msg[], short msgColor);

// c ����������� �������� WinAPI -----------------------------------------
void gotoXY(short x, short y);
void setCursorVisible(bool mode);
void cls();

//-------------------------------------------

ostream& tab(ostream& os);
ostream& cls(ostream& os);
ostream& cursor_off(ostream& os);
ostream& cursor_on(ostream& os);

// ����������� � ����������
// ��������� ��� ������ �������� 
// ������� - ��������� ��� ����� � ������������ �������������
class endlm
{
    int n_;

public: // TODO: �������� ������������ ���������� - ��������� ����������
    // endlm(int n) {this->n_ = n;}
    endlm(int n) : n_(n) {}

    //ostream &operator(int n) {
    //    for (int i = 0; i < n; i++) {
    //        cout << "\n";
    //    }
    //    return cout;
    //}

    // ��� ����������� �������� ������ ������� ���� endlm 
    // ����������� �������� ������������
    friend ostream& operator<<(ostream& os, const endlm& object);
};

class color
{
    short color_;

public:
    color(short color) : color_(color) {}

    // ��� ����������� �������� ������ ������� ���� color 
    // ����������� �������� ������������
    friend ostream& operator<<(ostream& os, const color& color);
};

class pos
{
    short x_;
    short y_;

public:
    pos(short x, short y) : x_(x), y_(y) {}

    friend ostream& operator<<(ostream& os, const pos& object);
};

// ����� ������ � �������� �����
void cputs(const char* str, short color = mainColor);

// �������� ������� ���� ������ � �������
short getColor();

/// ����� ��������� � ������� ������ ���� - ������ ��������� ��� ���������� �����
void showNavBarMessage(short hintColor, const char* message);