using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*
 * Задача 1. Работник некоторого предприятия для информационной системы представляется классом с полями:
 *      •	фамилия и инициалы работника;
 *      •	название занимаемой должности;
 *      •	год поступления на работу
 *      •	оклад
 *      
 * Определите свойства в классе, методы для вывода данных о работнике в консоль. Для предприятия, 
 * размещенного в заданном городе и хранящего сведения о 12 работниках реализовать обработки:
 *      •	Начальное формирование массива работников;
 *      •	Вывод данных предприятия в консоль
 *      •	Упорядочивание работников по
 *          o	Алфавиту
 *          o	Должности
 *          o	Убыванию стажа работы
 *      •	Выбрать в массив и вывести в консоль работников, оклад которых, попадает в заданный диапазон
 *      •	Выбрать в массив и вывести в консоль работников с заданной должностью
 * 
 * Задача 2. Пеший туристический маршрут для информационной системы описывается следующим образом:
 *      •	название начального пункта маршрута;
 *      •	название конечного пункта маршрута;
 *      •	буквенно-цифровой код маршрута
 *      •	протяженность маршрута в километрах.
 *      
 * Определите свойства в классе, методы для вывода данных о маршруте в консоль. Для туристической 
 * фирмы, имеющей название и хранящей сведения о 10 маршрутах реализовать обработки:
 *      •	Начальное формирование массива маршрутов;
 *      •	Вывод данных фирмы в консоль
 *      •	Упорядочивание маршрутов по
 *          o	Коду маршрута
 *          o	Начальному пункту маршрута
 *          o	Убыванию протяженности маршрута
 *      •	Выбрать в массив и вывести в консоль маршруты, протяженность которых, попадает в 
 *          заданный диапазон. Диапазон формируйте при помощи генератора случайных чисел
 *      •	Выбрать в массив и вывести в консоль маршруты, начинающиеся или завершающиеся в 
 *          заданном пункте. Название пункта вводить при помощи InputBox из класса Interaction
*/

namespace Application
{

    // константы для меню
    enum Cmd
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

    // главный класс приложения
    internal partial class App
    {

        #region Меню заданий 

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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Работник");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Маршрут");
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

        #region Утилиты

        // объект Random для заполнения массивов
        public static Random rand = new Random();

        // получение случайного вещественного числа в диапазоне (min, max]
        public static double GetDouble(int min, int max) => rand.Next(min, max) + rand.NextDouble();

        // вывод сообщения в цвете 
        public static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            // текущий цвет 
            ConsoleColor tempText = Console.ForegroundColor;
            ConsoleColor tempBack = Console.BackgroundColor;

            // установк цвета
            SetColor(textColor, backColor);

            // вывод сообщения 
            Console.Write(msg);

            // возвращение цвета 
            SetColor(tempText, tempBack);
        }

        // вывод сообщения в цвете и позиционированием 
        public static void WriteColorXY(string msg = "", int posX = -1, int posY = -1, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            // позиционирование курсора
            PosXY(posX == -1 ? Console.CursorLeft : posX, posY == -1 ? Console.CursorTop : posY);

            // вывод сообщения в цвете
            WriteColor(msg, textColor, backColor);
        }

        // вывод сообщения о неправильно введённых данных, с указанием позиции
        public static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
        {
            // вывод сообщения 
            WriteColorXY(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

            // задержка по времени
            Thread.Sleep(500);
        }

        // позиционирование курсора
        public static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

        // установка цвета текста 
        public static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

        // установка цвета текста и фона 
        public static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
        } // SetColor

        // вывод сообщения в первой строке консоли
        public static void ShowNavBarMessage(string msg)
        {
            // установка цвета
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // позиционирование курсора
            Console.SetCursorPosition(0, 0);

            // заполенение первой строки цветом 
            Console.WriteLine($"{' ',120}");

            // позиционирование курсора
            Console.SetCursorPosition(2, 0);

            // вывод сообщения 
            Console.WriteLine(msg);

            // позиционирование курсора
            Console.SetCursorPosition(0, 3);

            Console.ResetColor();
        } // ShowNavBarMessage

        #endregion
    }
}
