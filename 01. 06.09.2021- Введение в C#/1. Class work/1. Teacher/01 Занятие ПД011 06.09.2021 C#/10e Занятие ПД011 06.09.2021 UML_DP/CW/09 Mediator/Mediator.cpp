#include<iostream>
#include<windows.h>
#include "Classroom.h"
#include "Trainee.h"
using namespace std;

/* 
 * ������� ��������� (Mediator) ������������ ����� ������ ��������������, ������� 
 * ������������ �������������� ��������� �������� ��� ������������� ��������� ���� 
 * �� �����. ��� ����� ����������� ���������������� ����������������� ��������.
 * 
 * ����� ������������ ������� ���������
 *    a) ����� ������� ��������� �������������� ��������, ����� ����� �������� 
 *       ������ � ��������.
 *    b) ����� ���������� �������� ������������ ������, ������ ��������� ������������� 
 *       ���������� � ���� ������� ������ � ������� ���������.
 */
int main()
{
	SetConsoleOutputCP(1251);
	SetConsoleTitle(L"������� Mediator (���������)");

	// ������� ������ �������� ������� - ���������
	Classroom *classroom = new Classroom();

	// ������� ��������������� ������
	Trainee* piter = new MathClass("�����");
	Trainee* tim   = new MathClass("���");
	Trainee* brad  = new MathClass("����");
	Trainee* joana = new MathClass("������");

	// ������������ �� � ������
	classroom->Register(piter);
	classroom->Register(tim);
	classroom->Register(brad);
	classroom->Register(joana);

	// �������� ���������
	piter->Send("����", "3*3+7");
	joana->Send("���", "21-78*3");

	brad->Send("�����", "16");

	// ��������� � �������������� ���������
	tim->Send("�������", ":)");
	
	// �������
	delete piter;
    delete tim;
    delete brad;
    delete joana;

	delete classroom;

	return 0;
}