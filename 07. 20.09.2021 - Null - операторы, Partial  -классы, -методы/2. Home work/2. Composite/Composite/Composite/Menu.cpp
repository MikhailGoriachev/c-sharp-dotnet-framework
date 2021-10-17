#include "pch.h"
#include "MenuItem.h"
#include "menu.h"

// ����� ����, ��� �������������� �������� �� ������� �����, ������
// ����� ������� � �������������� "�������������" ������ ������, ��
// ������� ����� �������� ������ - ������ ������ �����������
// �������������
void Menu::Show()
{
    // ����� ��������� � ������ ������ ������� ������������� � 4 �������
    cout<< cursor_off 
        << pos(position.X + 4, position.Y) << color(palette[PAL_TITLE]) << title;
    ostringstream oss;

    for (int i = 0; i < nItems; ++i) {
        // ������������ �������������
        oss.str("");
        oss << "    " << left << setw(maxLengthItemText) << items[i].text << "    ";

        // ����� ������ ����, ������� ����� �������� ������
        cout<< pos(position.X, position.Y + i + 1) 
            << color(palette[items[i].current?PAL_CURRENT:PAL_ORDINAL])
            << oss.str();
    } // for i
    cout<<color(palette[PAL_CONSOLE]);
} // Menu::Show

// ��������� �� ���� - ��������� ������� ������, ����� �������
int Menu::Navigate()
{
    while(true) {
        // ������� ����
        Show();

        // ������ ��� �������
        int key = _getch();
        if (key == 0 || key == 224) key = _getch();

        // ���������� �������
        switch (key)
        {
        case K_UP: // ������� ������� �����
            items[currentItem].current = false;
            --currentItem;
            if (currentItem < 0) currentItem = nItems - 1;
            items[currentItem].current = true;
            break;

        case K_DOWN: // ������� ������� ����
            items[currentItem].current = false;
            ++currentItem;
            if (currentItem >= nItems) currentItem = 0;
            items[currentItem].current = true;
            break;

        case K_ENTER: // ������� ���� ��������� �������
            return items[currentItem].command; 

        case K_ESC: // ������� ���� ����������� ������� - �����
            return CMD_QUIT;
        } // switch
    } // while
} // Menu::Navigate
