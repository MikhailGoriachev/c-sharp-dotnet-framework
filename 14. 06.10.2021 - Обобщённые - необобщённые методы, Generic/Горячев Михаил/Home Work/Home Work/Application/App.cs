using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

/*
 * Условия заданий
*/

namespace Home_Work.Application
{
    // константы для меню
    internal enum Cmd
    {
        pointExit,
        pointOne,
        pointTwo,
        pointThree,
        pointFour,
        pointFive,
        pointSix
    }

    public partial class App
    {

        #region Меню заданий 

        // номер задания 
        int numberTask = 0;

        // меню заданий
        public void Menu()
        {
            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Обработка массива int");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Обработка массива double");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Обработка массива Person");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case (int)Cmd.pointExit:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // 1. Обработка массива int
                    case (int)Cmd.pointOne:
                        // запуск задания 
                        Task1();
                        break;

                    // 2. Обработка массива double
                    case (int)Cmd.pointTwo:
                        // запуск задания 
                        Task2();
                        break;

                    // 3. Обработка массива Person
                    case (int)Cmd.pointThree:
                        // запуск задания 
                        Task3();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(x, y); Console.WriteLine("         Номер задания невалиден!         ");

                        // выключение курсора
                        Console.CursorVisible = false;

                        // задержка времени
                        Thread.Sleep(1000);

                        // возвращение цвета
                        Console.ResetColor();

                        // включение курсора
                        Console.CursorVisible = true;

                        break;
                } // switch
            }
        } // Menu

        #endregion

        #region Общие методы

        // вывод количества максимальных элементов
        public static void ShowCountMaxElem(int countElem)
        {
            WriteColorXY("     ╔════════════════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("      Название      ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Значение ", 40, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"Кол-во максимальных элементов", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countElem,10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚════════════════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

    }
}
