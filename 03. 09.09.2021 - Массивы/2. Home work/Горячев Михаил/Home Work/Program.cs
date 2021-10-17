using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading; // для сипользования Sleep()
using System.Threading.Tasks;
/*
 * Разработайте консольное приложение для решения следующих задач. Каждую задачу размещайте в 
 * отдельном статическом методе класса Program. Используйте возможности консоли по работе с 
 * цветом. Вывод результатов в консоль. Не используйте лямбда-выражения и методы расширения для
 * массивов (отмечены стрелкой вниз в списке методов, выводимых IntelliSense) при решении задач. 
 * 
 * Задача 1. Методы класса Math. Для значений, вводимых с клавиатуры рассчитайте значение 
 *      выражений. (напоминаю, что при правильном кодировании выражений их значения совпадают 
 *      примерно до 10го знака после запятой). Выражения взяты из учебника Павловской Т.А.:
 *      Вариант 9.
 *      z_1 =〖(cosα - cosβ)〗^2 -〖(sinα - sinβ)〗^2; z_2 = -4〖sin〗^2(α - β) / 2∙cos⁡(α + β);
 *      Вариант 11.
 *      z_1 = (1 - 2∙〖sin〗^2 α)/ (1 + sin2α); z_2 = (1 - tgα) / (1 + tgα);
 *  
 * Задача 2.Одномерный массив.В одномерном массиве, состоящем из n целых элементов:
 * 	    Заполнить массив случайными числами
 * 	    Вычислить минимальный элемент массива, вывести массив с выделением таких элементов
 * 	    цветом
 * 	    Вычислить сумму элементов массива, расположенных между первым и последним 
 * 	    положительными элементами, вывести массив с выделением цветом таких элементов
 * 	    Упорядочить массив так, чтобы элементы, равные нулю были в начале массива
 * 	
 * Задача 3. Одномерный массив. В одномерном массиве, состоящем из n вещественных 
 *      элементов:
 * 	    Заполнить массив случайными числами
 * 	    Вычислить индекс минимального по модулю элемента массива, вывести массив с выделением
 * 	    цветом найденного элемента
 * 	    Вычислить сумму модулей элементов массива, расположенных после первого отрицательного 
 * 	    элемента, вывести массив с выделением цветом слагаемых
 * 	    Упорядочить массив так, чтобы переместить в начало массива все элементы, значение 
 * 	    которых находится в диапазоне [a, b]. При помощи метода Array.Resize() удалить все 
 * 	    элементы, не входящие в этот диапазон
 * 	
 * Задача 4. Прямоугольный массив. В матрице целых чисел размера M x N:
 * 	    Заполнить матрицу случайными числами
 * 	    Поменять местами столбец с заданным номером и первый из столбцов, содержащих только 
 * 	    отрицательные элементы. Если требуемых столбцов нет – вывести сообщение, не менять 
 * 	    матрицу
 * 	    Поменять местами строки матрицы так, чтобы первые элементы матрицы были упорядочены по 
 * 	    убыванию 
 */

namespace Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            // заголовок окна 
            Console.Title = "Домашнее задание на 13.09.2021";

            // запуск меню приложения 
            Menu();

            // возврат цвета по умолчанию
            Console.ResetColor();
        } // Main

        #region Меню заданий 

        // константы номеров заданий
        public enum CMD
        {
            // 1. Методы класса Math
            CMD_POINT_ONE = 1,

            // 2. Одномерный массив
            CMD_POINT_TWO,

            // 3. Одномерный массив
            CMD_POINT_THREE,

            // 4. Прямоугольный массив
            CMD_POINT_FOUR
        }; // CMD

        // меню заданий
        static void Menu()
        {
            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // пукты меню
                Console.SetCursorPosition(5,  5); Console.WriteLine("1. Методы класса Math");
                Console.SetCursorPosition(5,  6); Console.WriteLine("2. Одномерный массив");
                Console.SetCursorPosition(5,  7); Console.WriteLine("3. Одномерный массив");
                Console.SetCursorPosition(5,  8); Console.WriteLine("4. Прямоугольный массив");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. Выход");

                // ввод номера задания
                Console.SetCursorPosition(5, 15); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // 1. Методы класса Math
                    case (int)CMD.CMD_POINT_ONE:
                        // запуск задания 
                        Task1();
                        break;

                    // 2. Одномерный массив
                    case (int)CMD.CMD_POINT_TWO:
                        // запуск задания 
                        Task2();
                        break;

                    // 3. Одномерный массив
                    case (int)CMD.CMD_POINT_THREE:
                        // запуск задания 
                        Task3();
                        break;

                    // 4. Прямоугольный массив
                    case (int)CMD.CMD_POINT_FOUR:
                        // запуск задания 
                        Task4();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         Номер задания невалиден!         ");

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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter);
                Console.CursorVisible = true;
            }
        } // Menu

        #endregion

        #region 1. Методы класса Math

        // 1. Методы класса Math
        static void Task1()
        {
            /*
             * Задача 1. Методы класса Math. Для значений, вводимых с клавиатуры рассчитайте значение 
             *      выражений. (напоминаю, что при правильном кодировании выражений их значения совпадают 
             *      примерно до 10го знака после запятой). Выражения взяты из учебника Павловской Т.А.:
             *      Вариант 9.
             *      z_1 =〖(cosα - cosβ)〗^2 -〖(sinα - sinβ)〗^2; z_2 = -4〖sin〗^2(α - β) / 2∙cos⁡(α + β);
             *      Вариант 11.
             *      z_1 = (1 - 2∙〖sin〗^2 α)/ (1 + sin2α); z_2 = (1 - tgα) / (1 + tgα);
             *  
             */

            ShowNavBarMessage("1. Методы класса Math");

            // линия разделитель
            string line = new string('═', 43);

            #region Вариант 9

            // ввод данных и обаботка по заданию
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("1. Методы класса Math. Вариант 9");

                #region Ввод данных Вариант 9

                // позиция по X и Y для вывода 
                int x = 5;
                int y = 3;

                // z_1 =〖(cosα - cosβ)〗^2 -〖(sinα - sinβ)〗^2; z_2 = -4〖sin〗^2(α - β) / 2∙cos⁡(α + β);

                // вывод формулы
                WriteColor($"╔{line,15}╗\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"                  Формулы ",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);

                // вывод формулы z1
                WriteColor($"║{"",-43}║\n", x, y, ConsoleColor.Magenta);
                WriteColor($"{"z1 =〖(cosa - cosb)〗^2 -〖(sina - sinb)〗^2",-41}\n", x + 2, y++, ConsoleColor.DarkYellow);

                // вывод формулы z2
                WriteColor($"║{"",-43}║\n", x, y, ConsoleColor.Magenta);
                WriteColor($"{"z2 = -4〖sin〗^2(a - b) / 2∙cos⁡(a + b)",-41}\n", x + 2, y++, ConsoleColor.DarkYellow);
                WriteColor($"╚{line,15}╝\n", x, y++, ConsoleColor.Magenta);

                // ввод данных 
                WriteColor($"╔{line,15}╗\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"                 Ввод данных", -43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);

                // ввод числа a
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor("a: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                SetColor(ConsoleColor.Green);  
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    // вывод сообщений об ошибке 
                    MsgErrorData(x + 2);
                    continue;
                }

                // ввод числа b
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor("b: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                SetColor(ConsoleColor.Green);
                if (!double.TryParse(Console.ReadLine(), out double b))
                {
                    // вывод сообщений об ошибке 
                    MsgErrorData(x + 2);
                    continue;
                }

                #endregion

                // обработка по заданию

                // z_1 =〖(cosα - cosβ)〗^2 -〖(sinα - sinβ)〗^2; z_2 = -4〖sin〗^2(α - β) / 2∙cos⁡(α + β);

                // вычисление z1
                double z1 = Math.Pow(Math.Cos(a) - Math.Cos(b), 2) - Math.Pow(Math.Sin(a) - Math.Sin(b), 2);

                // вычисление z2 
                double z2 = - 4d * Math.Pow(Math.Sin((a - b) / 2d), 2) * Math.Cos(a + b);

                // вывод результата
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"               Результат",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z1
                WriteColor($"z1: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{z1, -35:N10}", ConsoleColor.Green);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z2
                WriteColor($"z2: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{z2,-35:N10}", ConsoleColor.Green);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z1 == z2
                WriteColor($"z1 = z2: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{(Math.Abs(z1 - z2) < 0.1e-10), -20}", ConsoleColor.Green);
                WriteColor($"╚{line,15}╝\n", x, y++, ConsoleColor.Magenta);

                break;
            } // while

            #endregion

            // ввод клавиши для продолжения 
            WriteColor("\n\n\tНажмите [Enter] для продолжения...", ConsoleColor.Cyan);
            Console.CursorVisible = false;
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
            Console.CursorVisible = true;

            #region Вариант 11

            // ввод данных и обаботка по заданию
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("1. Методы класса Math. Вариант 11");

                #region Ввод данных Вариант 11

                // позиция по X и Y для вывода 
                int x = 5;
                int y = 3;

                //  z_1 = (1 - 2∙〖sin〗^2 α)/ (1 + sin2α); z_2 = (1 - tgα) / (1 + tgα);

                // вывод формулы
                WriteColor($"╔{line,15}╗\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"                  Формулы ",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);

                // вывод формулы z1
                WriteColor($"║{"",-43}║\n", x, y, ConsoleColor.Magenta);
                WriteColor($"{"z1 = (1 - 2∙〖sin〗^2 a)/ (1 + sin2a)",-41}\n", x + 2, y++, ConsoleColor.DarkYellow);

                // вывод формулы z2
                WriteColor($"║{"",-43}║\n", x, y, ConsoleColor.Magenta);
                WriteColor($"{"z2 = (1 - tga) / (1 + tga)",-41}\n", x + 2, y++, ConsoleColor.DarkYellow);
                WriteColor($"╚{line,15}╝\n", x, y++, ConsoleColor.Magenta);

                // ввод данных 
                WriteColor($"╔{line,15}╗\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"                 Ввод данных",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);

                // ввод числа a
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor("a: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                SetColor(ConsoleColor.Green);
                if (!double.TryParse(Console.ReadLine(), out double a))
                {
                    // вывод сообщений об ошибке 
                    MsgErrorData(x + 2);
                    continue;
                }

                #endregion

                // обработка по заданию

                //  z_1 = (1 - 2∙〖sin〗^2 α)/ (1 + sin2α); z_2 = (1 - tgα) / (1 + tgα);

                // вычисление z1
                double z1 = ((1d - 2d * Math.Pow(Math.Sin(a), 2)) / (1 + Math.Sin(2d * a)));

                // вычисление z2 
                double z2 = (1d - Math.Tan(a)) / (1d + Math.Tan(a));

                // вывод результата
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"               Результат",-43}║\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"╠{line,15}╣\n", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z1
                WriteColor($"z1: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{z1,-35:N10}", ConsoleColor.Green);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z2
                WriteColor($"z2: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{z2,-35:N10}", ConsoleColor.Green);
                WriteColor($"║{"",-43}║\n", x, y++, ConsoleColor.Magenta);

                // вывод z1 == z2
                WriteColor($"z1 = z2: ", x + 2, y - 1, ConsoleColor.DarkYellow);
                WriteColor($"{(Math.Abs(z1 - z2) < 0.1e-10),-20}", ConsoleColor.Green);
                WriteColor($"╚{line,15}╝\n", x, y++, ConsoleColor.Magenta);

                break;
            } // while

            #endregion

        } // Task1

        #endregion

        #region 2. Одномерный массив

        // 2. Одномерный массив
        static void Task2()
        {
            /*
             * Задача 2.Одномерный массив.В одномерном массиве, состоящем из n целых элементов:
             * 	    Заполнить массив случайными числами
             * 	    Вычислить минимальный элемент массива, вывести массив с выделением таких элементов
             * 	    цветом
             * 	    Вычислить сумму элементов массива, расположенных между первым и последним 
             * 	    положительными элементами, вывести массив с выделением цветом таких элементов
             * 	    Упорядочить массив так, чтобы элементы, равные нулю были в начале массива
             */

            ShowNavBarMessage("2. Одномерный массив");

            // массив 
            int[] array = new int[0] ;

            #region Меню 

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // пукты меню
                Console.SetCursorPosition(5, 5); Console.WriteLine("1. Заполнение массива");
                Console.SetCursorPosition(5, 6); Console.WriteLine("2. Поиск минимального значения");
                Console.SetCursorPosition(5, 7); Console.WriteLine("3. Сумма между положительными элементами");
                Console.SetCursorPosition(5, 8); Console.WriteLine("4. Сортировка: сначала 0-е элементы");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. Выход");

                // ввод номера задания
                Console.SetCursorPosition(5, 15); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // 1. Заполнение массива
                    case (int)CMD.CMD_POINT_ONE:
                        // запуск задания 
                        Task2FillArray();
                        break;

                    // 2. Поиск минимального значения
                    case (int)CMD.CMD_POINT_TWO:
                        // запуск задания 
                        Task2MinValue();
                        break;

                    // 3. Сумма между положительными элементами
                    case (int)CMD.CMD_POINT_THREE:
                        // запуск задания 
                        Task2SummPositive();
                        break;

                    // 4. Сортировка: сначала 0-е элементы
                    case (int)CMD.CMD_POINT_FOUR:
                        // запуск задания 
                        Task2SortByNull();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         Номер задания невалиден!         ");

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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.CursorVisible = true;
            }

            #endregion

            #region 1. Заполнение массива

            // 1. Заполнение массива
            void Task2FillArray()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("2. Одномерный массив | 1. Заполнение массива");

                // вывод массива 
                ShowArray("Массив", "До заполнения", array);

                // изменение размерности массива 
                Array.Resize(ref array, 20);

                Console.WriteLine("\n\n");

                // заполнение массива случайными значениями 
                for (int i = 0, lo = -2, hi = 3; i < array.Length; i++)
                    array[i] = rand.Next(lo, hi);

                // вывод массива 
                ShowArray("Массив", "После заполнения", array);
            }

            #endregion

            #region 2. Поиск минимального значения

            // 2. Поиск минимального значения
            void Task2MinValue()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("2. Одномерный массив | 2. Поиск минимального значения");

                // вывод исходного массива 
                ShowArray("Массив", "Исходные данные", array);

                Console.WriteLine("\n\n");

                // вывод массива с подсветкой минимальных элементов
                ShowArrayMinElem("Массив", "Минимальные элементы", array, minElemArray(array));
            }

            // поиск минимального значения в массиве
            int minElemArray(int[] arr)
            {
                // минимальное значение 
                int min = arr[0];

                foreach (var v in arr)
                    if (min > v) min = v; 

                return min;
            }

            // вывод элементов с подсветкой минимальных элементов 
            void ShowArrayMinElem(string name, string info, int[] arr, int value)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{arr[i],3}", startX, y, arr[i] == value ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                }

                // позиционирование курсора
                Console.CursorTop++;

            }

            #endregion

            #region 3. Сумма между положительными элементами

            // 3. Сумма между положительными элементами
            void Task2SummPositive()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("2. Одномерный массив | 3. Сумма между положительными элементами");

                // вывод исходного массива 
                ShowArray("Массив", "Исходные данные", array);

                Console.WriteLine("\n\n");

                // поиск индексов первого и последнего положительного элемента
                FindFirstLastPos(array, out int first, out int last);

                // сумма
                int sum = 0;

                // если first != last 
                if (first != last)
                {
                    // сумма элементов между элементами
                    sum = SumFirstLast(array, first + 1, last - 1);
                }
                // вывод массива с подсветкой элементов 
                ShowArrayFirstLastPositive("Массив", "Сумма между элем. >= 0", array, first, last);

                // координаты для позиционирования
                int x = 5;
                int y = Console.CursorTop + 4;

                // разделительная линия 
                string line = new string('═', 42);

                // вывод суммы элементов 
                WriteColor($"╔{line}╗",         x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"",-42}║",       x, y, ConsoleColor.Magenta);
                WriteColor("Сумма элементов: ", x + 2, y, ConsoleColor.DarkYellow);
                WriteColor($"{sum,-10}",            ConsoleColor.Green);
                WriteColor($"╚{line}╝",         x, ++y, ConsoleColor.Magenta);
            }

            // сумма между элементами (first, last]
            int SumFirstLast(int[] arr, int first, int last)
            {
                // сумма элементов 
                int sum = 0;

                for (int i = first; i < last; i++)
                    sum += arr[i];

                return sum;
            }

            // поиск индексов первого и последнего положительного элементов 
            bool FindFirstLastPos(int[] arr, out int first, out int last)
            {
                // начальное значение 
                first = last = -1;

                // поиск первого положительного элемента
                for (int i = 0; i < arr.Length; i++)
                {
                    // если элемент положительный 
                    if (arr[i] >= 0)
                    {
                        first = last = i;

                        // поиск последенего положительного элемента
                        for ( ; i < arr.Length; i++)
                        {
                            if (arr[i] >= 0)
                                last = i;
                        }
                    }
                }

                return first != -1;
            }

            // вывод элементов с подсветкой первого и последнего положительного элемента
            void ShowArrayFirstLastPositive(string name, string info, int[] arr, int first, int last)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],3}", startX, y, i == first || i == last ? ConsoleColor.Cyan : i < first || i > last ? ConsoleColor.DarkGray : ConsoleColor.Green);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            #endregion

            #region 4. Сортировка: сначала 0-е элементы

            // 4. Сортировка: сначала 0-е элементы
            void Task2SortByNull()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("2. Одномерный массив | 4. Сортировка: сначала 0-е элементы");

                // вывод массива 
                ShowArrayNull("Массив", "Массив до сортировки", array);

                Console.WriteLine("\n\n");

                // сортировка 
                Array.Sort(array, compareByNull);

                // компаратор
                int compareByNull(int v1, int v2) => v1 == 0 && v2 != 0 ? -1 : v1 != 0 && v2 == 0 ? 1 : 0;

                // вывод массива
                ShowArrayNull("Массив", "Массив после сортировки", array);
            }

            // вывод элементов с подсветкой элементов с нулевым значением
            void ShowArrayNull(string name, string info, int[] arr)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],3}", startX, y, array[i] == 0 ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            #endregion

            #region Общие методы

            // вывод массива 
            void ShowArray(string name, string info, int[] arr)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++; 

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],3}", startX, y, ConsoleColor.Green);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            // вывод шапки таблицы
            void showHead(string name, string info)
            {
                // координаты для позиционирования курсора
                int x = 5;
                int y = Console.CursorTop;

                // строка с разделительной линией 
                string line = new string('═', 38);

                // вывод заголовка 
                WriteColor($"╔{line, -38}╦═══{line, -38}╗",  x,      y++,            ConsoleColor.Magenta);
                WriteColor($"║{' ', -38}║{" ", -41}║",  x,      y,              ConsoleColor.Magenta);
                WriteColor($"Название: ",               x + 2,  y,              ConsoleColor.DarkYellow);
                WriteColor($"{name, -26}",              x + 12,  y,              ConsoleColor.Green);
                WriteColor($"Информация: ",             x + 42,  y,              ConsoleColor.DarkYellow);
                WriteColor($"{info, -25}",              x + 54, y++,            ConsoleColor.Green);
                WriteColor($"╚{line,-38}╩═══{line,-38}╝",    x,      y++,            ConsoleColor.Magenta);
            }

            // вывод рамки для вывода значений элементов с индексированием 
            void ShowElemFrame(int countElem)
            {
                // разделительная линия между полями заголовка
                string line = new string('═', 80);

                // координаты для позиционирования курсора
                int x = 5;
                int y = Console.CursorTop;

                // если количество элементов равно нулю
                if (countElem == 0)
                {
                    // вывод сообщения 
                    WriteColor($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ', 80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ', 80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ', 80}║", x, y, ConsoleColor.Magenta);
                    WriteColor($"{"Нет данных"}", x + 36, y++, ConsoleColor.Red);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"╚{line}╝", x, y++, ConsoleColor.Magenta);

                    // позиционирование 
                    PosXY(0, y + 1);

                    return;
                }

                // исходная позиция по y
                int yTemp = y;

                // чать разделительной линии 
                string partLine = new string('═', 20);

                // вывод рамки
                for (int i = 0; i < countElem;)
                {
                    // вывод линии разделителя 
                    WriteColor($"╔{partLine,-20}╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗", x, y++, ConsoleColor.Magenta);

                    // позиционирование 
                    PosXY(x, y);

                    // вывод 
                    WriteColor($"║ ", ConsoleColor.Magenta);
                    WriteColor($"      Индекс      ", ConsoleColor.Cyan);
                    WriteColor($" ║ ", ConsoleColor.Magenta);

                    // вывод индексов
                    for (int j = 0; j < 10; j++)
                    {
                        WriteColor($"{i++,3}", ConsoleColor.DarkYellow);
                        WriteColor(" ║ ", ConsoleColor.Magenta);
                    }

                    // вывод линии разделителя 
                    WriteColor($"╠{partLine,-20}╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣",    x, ++y,    ConsoleColor.Magenta);

                    WriteColor($"║ ", x, ++y, ConsoleColor.Magenta);
                    WriteColor($"     Значение    ", ConsoleColor.Cyan);

                    // вывод полей для вывода элементов 
                    WriteColor(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n\n",
                    x + 20, y, ConsoleColor.Magenta);

                    // вывод линии разделителя подвала
                    WriteColor($"╚{partLine,-20}╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝", x, ++y, ConsoleColor.Magenta);

                    y++;
                }

                // установка курсора для вывода значения первого элемента 
                PosXY(x + 23, yTemp + 3);
            }

            #endregion

        } // Task2

        #endregion

        #region 3. Одномерный массив

        // 3. Одномерный массив
        static void Task3()
        {
            /*
             * Задача 3. Одномерный массив. В одномерном массиве, состоящем из n вещественных 
             *      элементов:
             * 	    Заполнить массив случайными числами
             * 	    Вычислить индекс минимального по модулю элемента массива, вывести массив с выделением
             * 	    цветом найденного элемента
             * 	    Вычислить сумму модулей элементов массива, расположенных после первого отрицательного 
             * 	    элемента, вывести массив с выделением цветом слагаемых
             * 	    Упорядочить массив так, чтобы переместить в начало массива все элементы, значение 
             * 	    которых находится в диапазоне [a, b]. При помощи метода Array.Resize() удалить все 
             * 	    элементы, не входящие в этот диапазон
             */

            ShowNavBarMessage("3. Одномерный массив");

            // массив 
            double[] array = new double[0];

            #region Меню 

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // пукты меню
                Console.SetCursorPosition(5, 5); Console.WriteLine("1. Заполнение массива");
                Console.SetCursorPosition(5, 6); Console.WriteLine("2. Поиск минимального элемента");
                Console.SetCursorPosition(5, 7); Console.WriteLine("3. Сумма по модулю после отрицательного элемента");
                Console.SetCursorPosition(5, 8); Console.WriteLine("4. Сортировка и удаление элементов");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. Выход");

                // ввод номера задания
                Console.SetCursorPosition(5, 15); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // 1. Заполнение массива
                    case (int)CMD.CMD_POINT_ONE:
                        // запуск задания 
                        Task3FillArray();
                        break;

                    // 2. Поиск минимального элемента
                    case (int)CMD.CMD_POINT_TWO:
                        // запуск задания 
                        Task3MinElem();
                        break;

                    // 3. Сумма по модулю после отрицательного элемента 
                    case (int)CMD.CMD_POINT_THREE:
                        // запуск задания 
                        Task3SumAfterNeg();
                        break;

                    // 4. Сортировка и удаление элементов 
                    case (int)CMD.CMD_POINT_FOUR:
                        // запуск задания 
                        Task3SortByNull();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         Номер задания невалиден!         ");

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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.CursorVisible = true;
            }

            #endregion

            #region 1. Заполнение массива

            // 1. Заполнение массива
            void Task3FillArray()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("3. Одномерный массив | 1. Заполнение массива");

                // вывод массива 
                ShowArray("Массив", "До заполнения", array);

                // изменение размерности массива 
                Array.Resize(ref array, 20);

                Console.WriteLine("\n\n");

                // минимальное и максимальное целое значение 
                int lo = -5, hi = 5;
                
                // заполнение массива случайными значениями 
                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = rand.Next(lo, hi);
                    array[i] += rand.NextDouble();
                }
                // вывод массива 
                ShowArray("Массив", "После заполнения", array);
            }

            #endregion

            #region 2. Поиск минимального элемента

            // 2. Поиск минимального элемента
            void Task3MinElem()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("3. Одномерный массив | 2. Поиск минимального элемента");

                // вывод исходного массива 
                ShowArray("Массив", "Исходные данные", array);

                Console.WriteLine("\n\n");

                // вывод массива с подсветкой минимальных элементов
                ShowArrayMinElem("Массив", "Минимальный элемент", array, MinElemArray(array));
            }

            // поиск индекса элемента с минимальным значением в массиве
            int MinElemArray(double[] arr)
            {                
                // минимальное значение и индекс
                double min = arr[0];
                int index = 0;

                // размер массива 
                int length = arr.Length;

                // поиск индекса элемента с минимальным значением 
                for (int i = 1; i < length; i++)
                {
                    // если значение меньше найденного минимального
                    if (min > arr[i])
                    {
                        min = arr[i];
                        index = i;  
                    }
                }
                
                return index;
            }

            // вывод элементов с подсветкой минимальных элементов 
            void ShowArrayMinElem(string name, string info, double[] arr, int index)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{arr[i],5:n2}", startX, y, i == index ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                }

                // позиционирование курсора
                Console.CursorTop++;

            }

            #endregion

            #region 3. Сумма по модулю после отрицательного элемента

            // 3. Сумма по модулю после отрицательного элемента
            void Task3SumAfterNeg()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("3. Одномерный массив | 3. Сумма по модулю после отрицательного элемента");

                // вывод исходного массива 
                ShowArray("Массив", "Исходные данные", array);

                Console.WriteLine("\n\n");

                // поиск индекса отрицательного элемента
                int index = FindNegElem(array);

                // сумма 
                double sum = 0;

                // если минимальный элемент не найден 
                if (index != array.Length)
                    // подсчёт суммы элементов 
                    sum = SumPositionEnd(array, index + 1);

                // вывод массива с подсветкой элементов 
                ShowArraySumElem("Массив", "Сумма после элемента < 0", array, index);

                // координаты для позиционирования
                int x = 5;
                int y = Console.CursorTop + 4;

                // разделительная линия 
                string line = new string('═', 42);

                // вывод суммы элементов 
                WriteColor($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"",-42}║", x, y, ConsoleColor.Magenta);
                WriteColor("Сумма элементов: ", x + 2, y, ConsoleColor.DarkYellow);
                WriteColor($"{sum,-10}", ConsoleColor.Green);
                WriteColor($"╚{line}╝", x, ++y, ConsoleColor.Magenta);
            }

            // поиск индекса элемента с отрицательным значением 
            // возвращает индекс отрицательного элемента, иначе Length
            int FindNegElem(double[] arr)
            {
                // размер массива 
                int length = arr.Length;

                // поиск индекса элемента с отрицательным занчением 
                for (int i = 0; i < length; i++)
                {
                    if (arr[i] < 0d)
                        return i;
                }

                return -1;
            }

            // сумма всех элементов по модулю после указанного индекса 
            double SumPositionEnd(double[] arr, int position)
            {
                // размер массива 
                int length = arr.Length;

                // сумма 
                double sum = 0d;

                // сумма элементов 
                for (int i = position; i < length; i++)
                {
                    sum += Math.Abs(arr[i]);
                }

                return sum;
            }

            // вывод элементов с подсветкой первого и последнего положительного элемента
            void ShowArraySumElem(string name, string info, double[] arr, int index)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],5:n}", startX, y, 
                        i == index ? ConsoleColor.DarkRed : i > index ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            #endregion

            #region 4. Сортировка и удаление элементов

            // 4. Сортировка и удаление элементов
            void Task3SortByNull()
            {
                // отчистка консоли
                Console.Clear();

                ShowNavBarMessage("3. Одномерный массив | 4. Сортировка и удаление элементов");

                // диапазон
                double min = -2d, max = 2d;

                // вывод массива 
                ShowArrayElemDiap("Массив", "Массив до сортировки", array, min, max);

                Console.WriteLine("\n\n");

                // компаратор для сортировки 
                int CompareByValue(double v1, double v2)
                    => (v1 >= min && v1 <= max && (v2 < min || v2 > max)) ? -1 :
                    ((v1 < min || v1 > max) && v2 >= min && v2 <= max) ? 1 : 0;

                int res = CompareByValue(7, 7);
                    res = CompareByValue(-3,-3);

                // сортировка 
                Array.Sort(array, CompareByValue);

                // вывод массива
                ShowArrayElemDiap("Массив", "Массив после сортировки", array, min, max);

                Console.WriteLine("\n\n");

                // удаление элементов, которые не входят в диапазон по значению
                Array.Resize(ref array, FindLastElemDiap(array, min, max) + 1);

                // вывод массива 
                ShowArray("Массив", "Данные после удаления", array);

                // разделительная линия 
                string line = new string('═', 42);

                // координаты для позиционирования
                int x = 5;
                int y = Console.CursorTop + 4;

                // вывод суммы элементов 
                WriteColor($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{"",-42}║", x, y, ConsoleColor.Magenta);
                WriteColor("Диапазон: ", x + 2, y, ConsoleColor.DarkYellow);
                WriteColor($"{min,5:n2} {max, 5:n2}", ConsoleColor.Green);
                WriteColor($"╚{line}╝", x, ++y, ConsoleColor.Magenta);

            }

            // поиск индекса последнего элемента, который входит в диапазон по значению
            int FindLastElemDiap(double[] arr, double minV, double maxV)
            {
                // размер массива 
                int length = arr.Length;

                // индекс 
                int index = length;

                // поиск индекса элемента 
                for (int i = 0; i < length; i++)
                {
                    if (arr[i] >= minV && arr[i] <= maxV)
                        index = i;
                }

                return index;
            }

            // вывод элементов с подсветкой элементов входящих в диапазон заданных значений
            void ShowArrayElemDiap(string name, string info, double[] arr, double minV, double maxV)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],5:n2}", startX, y, arr[i] >= minV && arr[i] <= maxV ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            #endregion

            #region Общие методы

            // вывод массива 
            void ShowArray(string name, string info, double[] arr)
            {
                // размер массива 
                int size = arr.Length;

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame(size);

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < size; i++, startX += 6)
                {
                    // если индекс элемента кратен 10
                    if (i != 0 && i % 10 == 0)
                    {
                        // позиционирование для вывода элементов в следующую рамку элементов
                        startX = x;
                        y += 5;
                    }

                    // вывод элемента 
                    WriteColor($"{array[i],5:n2}", startX, y, ConsoleColor.Green);
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            // вывод шапки таблицы
            void showHead(string name, string info)
            {
                // координаты для позиционирования курсора
                int x = 5;
                int y = Console.CursorTop;

                // строка с разделительной линией 
                string line = new string('═', 38);

                // вывод заголовка 
                WriteColor($"╔{line,-38}╦═══{line,-38}╗", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{' ',-38}║{" ",-41}║", x, y, ConsoleColor.Magenta);
                WriteColor($"Название: ", x + 2, y, ConsoleColor.DarkYellow);
                WriteColor($"{name,-26}", x + 12, y, ConsoleColor.Green);
                WriteColor($"Информация: ", x + 42, y, ConsoleColor.DarkYellow);
                WriteColor($"{info,-25}", x + 54, y++, ConsoleColor.Green);
                WriteColor($"╚{line,-38}╩═══{line,-38}╝", x, y++, ConsoleColor.Magenta);
            }

            // вывод рамки для вывода значений элементов с индексированием 
            void ShowElemFrame(int countElem)
            {
                // разделительная линия между полями заголовка
                string line = new string('═', 80);

                // координаты для позиционирования курсора
                int x = 5;
                int y = Console.CursorTop;

                // если количество элементов равно нулю
                if (countElem == 0)
                {
                    // вывод сообщения 
                    WriteColor($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y, ConsoleColor.Magenta);
                    WriteColor($"{"Нет данных"}", x + 36, y++, ConsoleColor.Red);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"╚{line}╝", x, y++, ConsoleColor.Magenta);

                    // позиционирование 
                    PosXY(0, y + 1);

                    return;
                }

                // исходная позиция по y
                int yTemp = y;

                // чать разделительной линии 
                string partLine = new string('═', 20);

                // вывод рамки
                for (int i = 0; i < countElem;)
                {
                    // вывод линии разделителя 
                    WriteColor($"╔{partLine,-20}╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗", x, y++, ConsoleColor.Magenta);

                    // позиционирование 
                    PosXY(x, y);

                    // вывод 
                    WriteColor($"║ ", ConsoleColor.Magenta);
                    WriteColor($"      Индекс      ", ConsoleColor.Cyan);
                    WriteColor($" ║ ", ConsoleColor.Magenta);

                    // вывод индексов
                    for (int j = 0; j < 10; j++)
                    {
                        WriteColor($"{i++,3}", ConsoleColor.DarkYellow);
                        WriteColor(" ║ ", ConsoleColor.Magenta);
                    }

                    // вывод линии разделителя 
                    WriteColor($"╠{partLine,-20}╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣", x, ++y, ConsoleColor.Magenta);

                    WriteColor($"║ ", x, ++y, ConsoleColor.Magenta);
                    WriteColor($"     Значение    ", ConsoleColor.Cyan);

                    // вывод полей для вывода элементов 
                    WriteColor(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n\n",
                    x + 20, y, ConsoleColor.Magenta);

                    // вывод линии разделителя подвала
                    WriteColor($"╚{partLine,-20}╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝", x, ++y, ConsoleColor.Magenta);

                    y++;
                }

                // установка курсора для вывода значения первого элемента 
                PosXY(x + 22, yTemp + 3);
            }

            #endregion

        } // Task3

        #endregion

        #region 4. Прямоугольный массив

        // 4. Прямоугольный массив
        static void Task4()
        {
            /* 
             * Задача 4. Прямоугольный массив. В матрице целых чисел размера M x N:
             * 	    Заполнить матрицу случайными числами
             * 	    Поменять местами столбец с заданным номером и первый из столбцов, содержащих только 
             * 	    отрицательные элементы. Если требуемых столбцов нет – вывести сообщение, не менять 
             * 	    матрицу
             * 	    Поменять местами строки матрицы так, чтобы первые элементы матрицы были упорядочены по 
             * 	    убыванию 
             */            

            ShowNavBarMessage("  4. Прямоугольный массив");

            int[,] matrix = new int[12, 10];

            #region Меню заданий 

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // пукты меню
                Console.SetCursorPosition(5, 5); Console.WriteLine("1. Заполнение матрицы");
                Console.SetCursorPosition(5, 6); Console.WriteLine("2. Перемещение столбцов: заданный номером и с отрицательными элементами");
                Console.SetCursorPosition(5, 7); Console.WriteLine("3. Упорядочивание строк по убыванию первых элементов");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. Выход");

                // ввод номера задания
                Console.SetCursorPosition(5, 15); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // 1. Заполнение матрицы 
                    case (int)CMD.CMD_POINT_ONE:
                        // запуск задания 
                        DemoFillMatrix();
                        break;

                    // 2. Перемещение столбцов: заданный номером и с отрицательными элементами
                    case (int)CMD.CMD_POINT_TWO:
                        // запуск задания 
                        DemoSwapCols();
                        break;

                    // 3. Упорядочивание строк по убыванию первых элементов
                    case (int)CMD.CMD_POINT_THREE:
                        // запуск задания 
                        DemoSwapRows();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         Номер задания невалиден!         ");

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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.CursorVisible = true;
            } // switch

            #endregion

            #region 1. Заполнение матрицы

            // 1. Заполнение матрицы 
            void DemoFillMatrix()
            {
                Console.Clear();

                ShowNavBarMessage("  4. Прямоугольный массив | 1. Заполнение матрицы");

                // размеры матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1); 

                // заполнение матрицы случайными значениями
                for (int i = 0, lo = -3, hi = 2; i < rows; i++)                
                    for (int k = 0; k < cols; k++)                    
                        matrix[i, k] = rand.Next(lo, hi);

                // вывод матрицы
                ShowMatrix("Матрица", "После заполнения");
            } // DemoFillMatrix

            #endregion

            #region 2. Перемещение столбцов: с заданный номером и с отрицательными элементами

            // 2. Перемещение столбцов: с заданный номером и с отрицательными элементами
            void DemoSwapCols()
            {
                Console.Clear();

                ShowNavBarMessage("  4. Прямоугольный массив | 2. Перемещение столбцов: заданный номером и с отрицательными элементами");

                // размеры матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // номер столбца
                int presNum = rand.Next(0, cols);

                // поиск столбца содержащего только отрицательные элементы
                if (!FindNegCol(out int negCol))
                {
                    // вывод сообщения об отсутствии столбца только с отрицательными элементами
                    ShowMessageNoFindCol();

                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tВ матрицу будет добавлен отрицательный столбец! Нажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;

                    // добаление отрицательного столбца в матрицу 
                    InsNegCol();

                    // рекурсивный вызов текущей функции
                    DemoSwapCols();

                    return;
                }

                // если индекс выбранного столбца совпадает с индексом отрицательного столбца 
                while (presNum == negCol)
                    presNum = rand.Next(0, cols);

                // вывод матрицы
                ShowMatrixTwoCols("Матрица", "До перемещения", presNum, negCol);

                Console.WriteLine("\n\n");

                // перемещение столбцов 
                SwapCols(negCol, presNum);

                // вывод матрицы
                ShowMatrixTwoCols("Матрица", "После перемещения", negCol, presNum);

            } // DemoSwapCols

            // поиск столбца содержащего только отрицательные элементы
            // return false - столбец не найден, true - столбец найден
            bool FindNegCol(out int col)
            {
                // размеры матрицы 
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // индекс 
                col = -1;

                // флаг вхождения положительного элемента в столбец
                bool flag = false;

                // поиск столбца по условию 
                for (int i = 0; i < cols; i++)
                {
                    // установка значения флага
                    flag = false;

                    // проверка столбца на вхождение положительных элементов 
                    for (int k = 0; k < rows; k++)
                    {
                        // если элемент положительный 
                        if (matrix[k, i] >= 0)
                        {
                            flag = true;
                            break;
                        } // if 
                    } // for k

                    // если столбец не содержит положительных элементов
                    if (flag == false)
                    {
                        col = i;

                        return true;
                    }
                } // for i

                return false;
            }

            // вывод сообщения об отсутствии столбца только с отрицательными элементами
            void ShowMessageNoFindCol()
            {
                WriteColor("╔═════════════════════════════════╗",   10, 3, ConsoleColor.Magenta);
                WriteColor("║                                 ║",   10, 4, ConsoleColor.Magenta);
                WriteColor("НЕ НАЙДЕН ОТРИЦАТЕЛЬНЫЙ СТОЛБЕЦ",       12, 4, ConsoleColor.Magenta);
                WriteColor("╚═════════════════════════════════╝",   10, 5, ConsoleColor.Magenta);
            }

            // перемещение столбцов 
            void SwapCols(int iOne, int iTwo)
            {
                // количество строк в матрице
                int rows = matrix.GetLength(0);

                // перемещение элментов 
                for (int i = 0, temp; i < rows; i++)
                {
                    // перемещение элемента
                    temp = matrix[i, iOne];
                    matrix[i, iOne] = matrix[i, iTwo];
                    matrix[i, iTwo] = temp;
                }
            }

            // вставка отрицательного столбца
            void InsNegCol()
            {
                // размер матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // генерация индекса столбца 
                int index = rand.Next(0, cols);

                // вставка отрицательных элементов 
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, index] = rand.Next(-5, 0);
                }
            }

            // вывод матрицы с подсветкой двух столбцов
            void ShowMatrixTwoCols(string name, string info, int iOne, int iTwo)
            {
                // размер матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame();

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < rows; i++)
                {
                    for (int k = 0; k < cols; k++, startX += 6)
                    {
                        // вывод элемента 
                        WriteColor($"{matrix[i, k],4}", startX, y, 
                            k == iOne ? ConsoleColor.DarkRed : k == iTwo ? ConsoleColor.Blue : ConsoleColor.Green);
                    }

                    // позиционирование для вывода элементов в следующую рамку элементов
                    startX = x;
                    y += 2;
                }

                // позиционирование курсора
                Console.CursorTop++;

            }

            #endregion

            #region 3. Упорядочивание строк по убыванию первых элементов

            // 3. Упорядочивание строк по убыванию первых элементов
            void DemoSwapRows()
            {
                Console.Clear();

                ShowNavBarMessage("  4. Прямоугольный массив | 3. Упорядочивание строк по убыванию первых элементов");

                // вывод матрицы
                ShowMatrixFirstElem("Матрица", "До сортировки");

                Console.WriteLine("\n\n");

                // сортировка строк матрицы по убыванию первых элемнтов 
                SortByFirstElem();

                // вывод матрицы
                ShowMatrixFirstElem("Матрица", "После сортировки");

            } // DemoSwapRows

            // сортировка строк матрицы по убыванию первых элемнтов 
            void SortByFirstElem()
            {
                // размеры матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // сортировка выбором
                int i, j, k, x;

                for (i = 0; i < rows; i++)
                {       // i - номер текущего шага
                    k = i; x = matrix[i, 0];

                    for (j = i + 1; j < rows; j++)  // цикл выбора наименьшего элемента
                        if (matrix[j, 0] > x)
                        {
                            k = j; x = matrix[j, 0];            // k - индекс наименьшего элемента
                        }

                    Swap(k, i);
                } // for

                // перемещение столбцов
                void Swap(int iOne, int iTwo)
                {
                    // перемещение элментов 
                    for (int w = 0, temp; w < cols; w++)
                    {
                        // перемещение элемента
                        temp = matrix[iOne, w];
                        matrix[iOne, w] = matrix[iTwo, w];
                        matrix[iTwo, w] = temp;
                    } // for
                } // Swap
            }

            // вывод матрицы с подсветкой первых элементов 
            void ShowMatrixFirstElem(string name, string info)
            {
                // размер матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame();

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < rows; i++)
                {
                    for (int k = 0; k < cols; k++, startX += 6)
                    {
                        // вывод элемента 
                        WriteColor($"{matrix[i, k],4}", startX, y, k == 0 ? ConsoleColor.Green : ConsoleColor.DarkGray);
                    }

                    // позиционирование для вывода элементов в следующую рамку элементов
                    startX = x;
                    y += 2;
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            #endregion

            #region Общие методы

            // вывод матрицы 
            void ShowMatrix(string name, string info)
            {
                // размер матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // вывод шапки таблицы 
                showHead(name, info);

                // установка курсора на следующую строку
                Console.CursorTop++;

                // создание рамки 
                ShowElemFrame();

                // координаты для позиционирования 
                int x = Console.CursorLeft;
                int y = Console.CursorTop;

                // вывод элементов 
                for (int i = 0, startX = x; i < rows; i++)
                {
                    for (int k = 0; k < cols; k++, startX += 6)
                    {
                        // вывод элемента 
                        WriteColor($"{matrix[i, k],4}", startX, y, ConsoleColor.Green);
                    }

                    // позиционирование для вывода элементов в следующую рамку элементов
                    startX = x;
                    y += 2;
                }

                // позиционирование курсора
                Console.CursorTop++;
            }

            // вывод шапки таблицы
            void showHead(string name, string info)
            {
                // координаты для позиционирования курсора
                int x = 1;
                int y = Console.CursorTop;

                // строка с разделительной линией 
                string line = new string('═', 38);

                // вывод заголовка 
                WriteColor($"╔{line,-38}╦═══{line,-38}╗", x, y++, ConsoleColor.Magenta);
                WriteColor($"║{' ',-38}║{" ",-41}║", x, y, ConsoleColor.Magenta);
                WriteColor($"Название: ", x + 2, y, ConsoleColor.DarkYellow);
                WriteColor($"{name,-26}", x + 12, y, ConsoleColor.Green);
                WriteColor($"Информация: ", x + 42, y, ConsoleColor.DarkYellow);
                WriteColor($"{info,-25}", x + 54, y++, ConsoleColor.Green);
                WriteColor($"╚{line,-38}╩═══{line,-38}╝", x, y++, ConsoleColor.Magenta);
            }

            // вывод рамки для вывода значений элементов с индексированием 
            void ShowElemFrame()
            {
                // разделительная линия между полями заголовка
                string line = new string('═', 80);

                // размер матрицы
                int rows = matrix.GetLength(0), cols = matrix.GetLength(1);

                // координаты для позиционирования курсора
                int x = 9;
                int y = Console.CursorTop;

                // если количество элементов равно нулю
                if (rows == 0 && cols == 0)
                {
                    // вывод сообщения 
                    WriteColor($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y, ConsoleColor.Magenta);
                    WriteColor($"{"Нет данных"}", x + 36, y++, ConsoleColor.Red);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                    WriteColor($"╚{line}╝", x, y++, ConsoleColor.Magenta);
                
                    // позиционирование 
                    PosXY(0, y + 1);
                
                    return;
                }

                // исходная позиция по y
                int yTemp = y;

                // чать разделительной линии 
                string partLine = new string('═', 20);

                // позиционирование 
                PosXY(x, y);

                // вывод линии разделителя 
                WriteColor($"╔═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗", x, y++, ConsoleColor.Magenta);

                WriteColor("║     ║ ", x, y, ConsoleColor.Magenta);

                // вывод индексов
                for (int i = 0; i < cols; i++)
                {
                    WriteColor($"{i,3}", ConsoleColor.Yellow);
                    WriteColor(" ║ ", ConsoleColor.Magenta);
                }

                // вывод линии разделителя 
                WriteColor($"╠═════╬═════╪═════╪═════╪═════╪═════╪═════╪═════╪═════╪═════╪═════╣",
                    x, ++y, ConsoleColor.Magenta);

                y++;

                // вывод рамки и индексов по y
                for (int i = 0; i < rows - 1;)
                {
                    WriteColor($"║ ", x, y, ConsoleColor.Magenta);
                    WriteColor($"{i++, 3}", ConsoleColor.Cyan);

                    // вывод полей для вывода элементов 
                    WriteColor(" ║     │     │     │     │     │     │     │     │     │     ║\n\n", ConsoleColor.Magenta);

                    y++;

                    // вывод линии разделителя 
                    WriteColor($"╠═════╫─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────┼─────╢", 
                        x, y++, ConsoleColor.Magenta);

                    // // вывод 
                    // WriteColor($"║ ", ConsoleColor.Magenta);
                    // WriteColor($"      Индекс      ", ConsoleColor.Cyan);
                    // WriteColor($" ║ ", ConsoleColor.Magenta);
                    // 
                    // // вывод индексов
                    // for (int j = 0; j < 10; j++)
                    // {
                    //     WriteColor($"{i++,3}", ConsoleColor.DarkYellow);
                    //     WriteColor(" ║ ", ConsoleColor.Magenta);
                    // }
                }


                WriteColor($"║ ", x, y, ConsoleColor.Magenta);
                WriteColor($"{rows - 1,3}", ConsoleColor.Cyan);

                // вывод полей для вывода элементов 
                WriteColor(" ║     │     │     │     │     │     │     │     │     │     ║\n\n", ConsoleColor.Magenta);

                y++;

                // вывод линии разделителя подвала
                WriteColor($"╚═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝", x, y++, ConsoleColor.Magenta);

                // установка курсора для вывода значения первого элемента 
                PosXY(x + 7, yTemp + 3);
            }

            #endregion

        } // Task4

        #endregion

        #region Утилиты

        // объект Random для заполнения массивов
        static Random rand = new Random();

        // вывод сообщения в цвете 
        static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
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
        static void WriteColor(string msg, int posX, int posY, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            // позиционирование курсора
            PosXY(posX, posY);

            // вывод сообщения в цвете
            WriteColor(msg, textColor, backColor);
        }

        // вывод сообщения о неправильно введённых данных, с указанием позиции
        static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
        {            
            // вывод сообщения 
            WriteColor(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

            // задержка по времени
            Thread.Sleep(500);
        }

        // позиционирование курсора
        static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

        // установка цвета текста 
        static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

        // установка цвета текста и фона 
        static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
        } // SetColor

        // вывод сообщения в первой строке консоли
        static void ShowNavBarMessage(string msg)
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

    } // Program
} // Home_Work
