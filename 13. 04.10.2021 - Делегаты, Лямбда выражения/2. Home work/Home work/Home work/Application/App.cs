using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

/*
         * Задача 1. Разработайте классы для обработки массивов, при этом 
         * предикаты и компараторы реализовать при помощи делегатов. 
         * Реализация компараторов анонимными методами, предикатов – 
         * именованными делегатами (сохраненными в переменных).
         * 
         * В одномерном массиве, состоящем из п целых элементов:
         * •	вычислить количество элементов, равных минимальному 
         *      элементу массива;
         * •	вычислить сумму элементов массива, расположенных между 
         *      первым и последним положительными элементами;
         * •	преобразовать массив таким образом, чтобы сначала 
         *      располагались все   элементы, равные нулю, а потом — все 
         *      остальные.
         * Все три обработки запускать одним делегатом.
         * 
         * В одномерном массиве, состоящем из п целых элементов:
         * •	вычислить количество отрицательных элементов массива;
         * •	вычислить сумму элементов массива, расположенных между 
         *      первым и вторым отрицательными элементами;
         * •	преобразовать массив таким образом, чтобы сначала 
         *      располагались все элементы, модуль которых не превышает 
         *      3, а потом — все остальные.
         * Все три обработки запускать одним делегатом.

*/

namespace Home_work.Application
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
        pointSix,
        pointSeven
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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Обработка массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Электроприбор");
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

                    // Задание 1. Название задания
                    case (int)Cmd.pointOne:
                        // запуск задания 
                        Task1();
                        break;

                    // Задание 2. Название задания
                    case (int)Cmd.pointTwo:
                        // запуск задания 
                        Task2();
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

    }
}
