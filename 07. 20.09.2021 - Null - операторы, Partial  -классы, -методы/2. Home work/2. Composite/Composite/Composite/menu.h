#pragma once
#include "pch.h"
#include "MenuItem.h"
#include "Utils.h"

// ���� ����������
class  Menu
{
public:
    static const int MAX_LEN_TITLE = 71;

	// ����������� ���� �����, ������ ���������::��������
    static const int N_PALETTE = 4;
    static const int PAL_TITLE   = 0;
    static const int PAL_ORDINAL = 1;
    static const int PAL_CURRENT = 2;
    static const int PAL_CONSOLE = 3;

    // ����������� �������
    static const int CMD_QUIT = 100; 

private:
    char     *title;      // ��������� ����
    MenuItem *items;      // ������ ������� ����
    int      nItems;      // ���������� ��������� �������
    short    *palette;    // ������� ������ ����
    COORD    position;    // ��������� ������� ������ ����
    int      currentItem; // ������ �������� �������� ���� - ��� ���������� �������
    int      maxLengthItemText; // ������������ ����� ������ - ��� ������������ �������������

public:
    explicit Menu(): title(), items(), nItems(), palette(), position(COORD{0, 0}), currentItem() {  }
    explicit Menu(const char *title, MenuItem *items, int nItems, short *palette, COORD position):
       title(), items(), nItems(nItems), palette(), position(position), currentItem()
    {
        // ������ ��������� ����
        this->title = new char[MAX_LEN_TITLE];
        strcpy(this->title, title);

        // ������ ������ ����, ���������� ����� ������ �������� �������� ������ ����
        // ������ ���� "������������", ���������� ���� - �� ������ ����, �������
        // ������������� ���������� ����� ����� ������� ����� ��� �� � �����
        // ������ ����� ����������
        this->items = new MenuItem[nItems];
        maxLengthItemText = -1;
        for(int i = 0; i < nItems; ++i) {
            this->items[i].command = items[i].command;
            this->items[i].current = items[i].current;

            this->items[i].text = new char[MenuItem::MAX_ITEM_TEXT];
            strcpy(this->items[i].text, items[i].text);

            int lenItem = (int)strlen(items[i].text);
            if (lenItem > maxLengthItemText) maxLengthItemText = lenItem;
        } // for i

        // ���������� 0-� ������� �������
        this->items[currentItem].current = true;

        // ������ ������� ����
        this->palette = new short[N_PALETTE];
        memcpy(this->palette, palette, N_PALETTE * sizeof(short));
    } // Menu

    // ����� ����
    void Show();

    // ��������� �� ����, ����� �������
    int Navigate();
};
