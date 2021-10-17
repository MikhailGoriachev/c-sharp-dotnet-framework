using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;  // ��� Interaction

/*
 * ������������ ���������� ���������� ��� ������� ��������� �����. ������ ������
 * ���������� � ��������� ����������� ������ ������ Program. 
 * 
 * ������ 1. ��������� ���� � ����� ��� ������ ������� ������ Interaction. 
 * ����������� ������� ������ � ����������� �����, ����� �� ����� � ����� �����
 * 0. ������� ����������� ������������� ����� (100, �, 999). ��� ������ ��������
 * ������� � ������ ������� �������� ����� ����� (������� = ����� % 10, ����� = 
 * ����� / 100, ������� = ����� % 100 / 10). ����������:
 * a)	������ �� � ����� ����� 4 ��� 7
 * b)	������ �� � ���� ����� 3, 6, ��� 9
 * 
 * ������ 2. ��������� ���� � ����� ��� ������ ������� ������ Interaction. ������� 
 * ������ ������ ��������� ����, ������������� ������. ������ ������������ �����. 
 * ���� ����� �������������, �� �������� ��� � �������, ����� �������� ���� ����� 
 * �� ���������������.
 * 
 * ������ 3. ����� ������ ������������ � �������, � ��������� ����.
 * ��������� ������ ������� ��������� ��������� ���������� ������ � ����������� �� 
 * �� �����������: ������ � 11, ����� -�12, �������� � 13, ���� � 14. ���������� 
 * ������ ��������� ���� ������������� �� ��������� (���������, ��������, �). 
 * � ����� ����������� 10 ��������� ����� � ��������� �� 6 �� 14, �.�. ����� �����. 
 * �� ����� ������ ���������� ����������� �����.     
 */

namespace Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            // ��������� ����
            Console.Title = "�������� ������� �� 09.09.2021";

            // ������ ����
            Console.SetWindowSize(120, 29);

            // ����
            Menu();
        }

        // ��������� ������� �������
        public enum CMD
        {
            CMD_POINT_ONE = 1,
            CMD_POINT_TWO,
            CMD_POINT_THREE,
        };

        // ���� �������
        static void Menu()
        {
            // ����� ����
            while (true)
            {
                // �������� �������
                Console.Clear();

                // ���� 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // ����� ����
                Console.SetCursorPosition(5, 5); Console.WriteLine("1. �������. �������� ����������� �����");
                Console.SetCursorPosition(5, 6); Console.WriteLine("2. �������. �������� ������������� �����");
                Console.SetCursorPosition(5, 7); Console.WriteLine("3. �������. �����");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. �����");

                // ���� ������ �������
                Console.SetCursorPosition(5, 15); Console.Write("������� ����� �������: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // ��������� ����� 
                switch(n)
                {
                    // �����
                    case 0:
                        // ���������������� ������� 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // ������� 1. �������� ����������� �����
                    case (int)CMD.CMD_POINT_ONE:
                        // ������ ������� 
                        Task1();
                        break;

                    // ������� 2. �������� ������������� �����
                    case (int)CMD.CMD_POINT_TWO:
                        // ������ ������� 
                        Task2();
                        break;

                    // ������� 3. �����
                    case (int)CMD.CMD_POINT_THREE:
                        // ������ ������� 
                        Task3();
                        break;

                    // ���� ����� ������� ���������
                    default:

                        // ��������� �����
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // ���������������� �������
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         ����� ������� ���������!         ");

                        // ���������� �������
                        Console.CursorVisible = false;

                        // �������� �������
                        Thread.Sleep(1000);

                        // ����������� �����
                        Console.ResetColor();

                        // ��������� �������
                        Console.CursorVisible = true;

                        break;
                }
            }
        }

        // ������� 1. �������� ����������� �����
        static void Task1()
        {

            /*
             * ������ 1. ��������� ���� � ����� ��� ������ ������� ������ Interaction. 
             * ����������� ������� ������ � ����������� �����, ����� �� ����� � ����� �����
             * 0. ������� ����������� ������������� ����� (100, �, 999). ��� ������ ��������
             * ������� � ������ ������� �������� ����� ����� (������� = ����� % 10, ����� = 
             * ����� / 100, ������� = ����� % 100 / 10). ����������:
             * a)	������ �� � ����� ����� 4 ��� 7
             * b)	������ �� � ���� ����� 3, 6, ��� 9
             */

            // �����
            int num;

            while (true)
            {
                // ���� ����������� �����
                string line = Interaction.InputBox("������� ���������� �����(100, �, 999): ",
                    "������� 1. �������� ����������� �����");

                // ���� ���� ������ ������ "������"
                if (line.Length == 0)
                    return;

                // �������������� ����� �� ������
                if (!int.TryParse(line, out num))
                    Interaction.MsgBox("�������� ������ �����������!", MsgBoxStyle.Critical, "���� ������");
                // ���� ����� ���������
                else if (num < 100 || num > 999)
                    Interaction.MsgBox("����� " + num + " ���������!", MsgBoxStyle.Critical, "���� ������");
                else break;
            }

            // ��������� �� ������� 

            // ���� ��������� ���� 4 ��� 7
            bool flagA = false;
            bool tempFlagA;

            // ���� ��������� ���� 3, 6, ��� 9
            bool flagB = false;
            bool tempFlagB;

            // �������� ������
            CheckNumeral(num % 10, out tempFlagA, out tempFlagB);

            // ������������ �������� 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // �������� ��������
            CheckNumeral(num % 100 / 10, out tempFlagA, out tempFlagB);

            // ������������ �������� 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // �������� �����
            CheckNumeral(num / 100, out tempFlagA, out tempFlagB);

            // ������������ �������� 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // ����� ����������
            Interaction.MsgBox("a)	������ �� � ����� ����� 4 ��� 7: " + flagA
                + "\nb)	������ �� � ���� ����� 3, 6, ��� 9: " + flagB, MsgBoxStyle.OkOnly, "���������� ����������");
        }

        // �������� �����
        static void CheckNumeral(int num, out bool flagA, out bool flagB)
        {
            flagA = false;
            flagB = false;

            // ��������
            switch (num)
            {
                // ��������� ���� 4 ��� 7
                case 4:
                    flagA = true;
                    break;
                case 7:
                    goto case 4;

                // ��������� ���� 3, 6, ��� 9
                case 3:
                    flagB = true;
                    break;
                case 6:
                    goto case 3;
                case 9:
                    goto case 3;

                default:
                    break;
            }
        }

        // ������� 2. �������� ������������� �����
        static void Task2()
        {
            /*
             * ������ 2.��������� ���� � ����� ��� ������ ������� ������ Interaction. �������
             * ������ ������ ��������� ����, ������������� ������. ������ ������������ �����.
             *
             * ���� ����� �������������, �� �������� ��� � �������, ����� �������� ���� �����
             * �� ���������������.
             */

            // ������������ �����
            double num;

            // ���������� ��� ����� 
            const int N_PUT = 3;

            // ���� � ��������� ������
            for (int i = 0; i < N_PUT; i++)
            {
                // ���� ����� 
                while (true)
                {
                    // ���� ����� 
                    string line = Interaction.InputBox("������� ������������ �����: ", "���� ������");

                    // ���� ������ ������ "������"
                    if (line.Length == 0)
                        return;

                    // �������������� ������ � �����
                    if (!double.TryParse(line, out num))
                        Interaction.MsgBox("������ �����������!", MsgBoxStyle.Critical, "���� ������");
                    else break;
                }

                // ��������� ����� 

                // ����� ����� 
                double temp = num;

                // ���� ����� ������������� 
                if (num < 0)
                    // ���������� ����� � �������
                    num *= num;

                else
                    // ��������� ����� �� ��������������� 
                    num = -num;

                // ����� ����������
                Interaction.MsgBox("�������� �����: " + temp + "\n ���������: " + num, 
                    MsgBoxStyle.OkOnly, "�������� ����������");
            }
        }

        // ������� 3. �����
        static void Task3()
        {
            /*
             * ������ 3. ����� ������ ������������ � �������, � ��������� ����.
             * ��������� ������ ������� ��������� ��������� ���������� ������ � ����������� �� 
             * �� �����������: ������ � 11, ����� � 12, �������� � 13, ���� � 14. ���������� 
             * ������ ��������� ���� ������������� �� ��������� (���������, ��������, �). 
             * � ����� ����������� 10 ��������� ����� � ��������� �� 6 �� 14, �.�. ����� �����. 
             * �� ����� ������ ���������� ����������� �����.     
             */

            // �������� ������
            Console.Clear();

            ShowNavBarMessage("������� 3. �����");

            // ������ Random ��� ��������� �����
            Random rand = new Random();

            // ����� ����� ������� 
            ShowHead();

            // ����������� �������� ���� �����
            const int LO_CODE = 6;

            // ������������ �������� ���� ����� 
            const int HI_CODE = 14;

            // ���������� ������������ �����
            const int N_NUM = 10;

            // ��������� ����� � ����� ����� � �������
            for (int i = 0; i < N_NUM; i++)
            {
                // ����� �������� ������� 
                ShowElem(i + 1, rand.Next(LO_CODE, HI_CODE + 1));
            }

            // ����� �����-�����������
            ShowLine();

            // ��������� �����
            Console.ForegroundColor = ConsoleColor.Cyan;

            // ����� ��������� 
            Console.Write("\n\n\t������� ����� �������...");

            // �������� ������� ����� �������
            Console.ReadKey(true);

            // ����������� ��������� �����
            Console.ResetColor();
        }

        // ����������� ����������� ����� 
        static string CheckCard(int code)
        {
            // ��������� ����������� ����� 
            string line;

            // ������������ ����������� �����
            switch(code)
            {
                // �������
                case 6:
                    line = "�������";
                    break;

                // ������
                case 7:
                    line = "������";
                    break;

                // ��������
                case 8:
                    line = "��������";
                    break;

                // �������
                case 9:
                    line = "�������";
                    break;
                    
                // �������
                case 10:
                    line = "�������";
                    break;

                // �����
                case 11:
                    line = "�����";
                    break;

                // ����
                case 12:
                    line = "����";
                    break;

                // ������
                case 13:
                    line = "������";
                    break;

                // ���
                case 14:
                    line = "���";
                    break;

                default:
                    line = "������";
                    break;
            }

            return line;
        }

        // ����� ����� ������� 
        static void ShowHead()
        {
            // ���������������� �������
            Console.SetCursorPosition(0, 3);

            // ����� �����-�����������
            ShowLine();

            // ����� ���������
            SetColor(ConsoleColor.DarkCyan);    Console.Write("        | ");
            SetColor(ConsoleColor.Green);   Console.Write("N ");
            SetColor(ConsoleColor.DarkCyan);    Console.Write(" | ");
            SetColor(ConsoleColor.Green);   Console.Write("����������� ");
            SetColor(ConsoleColor.DarkCyan);    Console.Write(" | ");
            SetColor(ConsoleColor.Green);   Console.Write("���");
            SetColor(ConsoleColor.DarkCyan);    Console.WriteLine(" |");
            Console.ResetColor();

            // ����� �����-�����������
            ShowLine();
        }

        // ����� �������� ������� 
        static void ShowElem(int numElem, int code)
        {
            SetColor(ConsoleColor.DarkCyan);        Console.Write("        | ");
            SetColor(ConsoleColor.DarkGray);        Console.Write($"{numElem,2}");
            SetColor(ConsoleColor.DarkCyan);        Console.Write(" | ");
            SetColor(ConsoleColor.DarkYellow);      Console.Write($"{CheckCard(code), -12}");
            SetColor(ConsoleColor.DarkCyan);            Console.Write(" | ");
            SetColor(ConsoleColor.Magenta);         Console.Write($"{code, 3}");
            SetColor(ConsoleColor.DarkCyan);        Console.WriteLine(" |");
            Console.ResetColor();
        }

        // ����� �����-�����������
        static void ShowLine()
        {
            SetColor(ConsoleColor.DarkCyan); Console.WriteLine("        +����+��������������+�����+");
        }

        // ��������� ����� ������ 
        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        // ����� ��������� � ������ ������ �������
        static void ShowNavBarMessage(string msg)
        {
            // ��������� �����
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // ���������������� �������
            Console.SetCursorPosition(0, 0);

            // ����������� ������ ������ ������ 
            Console.WriteLine($"{' ', 120}");

            // ���������������� �������
            Console.SetCursorPosition(2, 0);

            // ����� ��������� 
            Console.WriteLine(msg);

            // ���������������� �������
            Console.SetCursorPosition(0, 1);

            Console.ResetColor();
        }
    }
}
