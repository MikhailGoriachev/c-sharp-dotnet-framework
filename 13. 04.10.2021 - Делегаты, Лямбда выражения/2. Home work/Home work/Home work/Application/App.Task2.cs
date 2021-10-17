using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Home_work.Controllers;                        // для использования обработки

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Application
{
    public partial class App
    {
        #region Задание 2. Электроприбор

        /*
        * Задача 2. Разработайте класс, описывающий электроприбор (название,
        * мощность, цена, включен/выключен). 
        * 
        * Сформируйте массив электроприборов (от 10 до 12 элементов), для 
        * массива реализуйте обработки:
        *  •	вывод массива в табличном формате, используйте лямбда-выражение
        *       для Array.Foreach()
        *  •	перемешивание элементов массива
        *  •	сортировка по названию, компаратор реализуйте лямбда-выражением
        *  •	сортировка по мощности прибора, компаратор реализуйте 
        *       лямбда-выражением
        *  •	включение всех приборов, используйте лямбда-выражение для 
        *       Array.ForEach()
        *  •	выключение всех приборов, используйте лямбда-выражение для 
        *       Array.ForEach()
        */

        // Задание 2. Электроприбор
        public void Task2()
        {
            // обработка по заданию 2
            Task2Controller controller = new Task2Controller();

            #region Меню

            // номер задания 
            int numberTask = 0;

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Электроприбор"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных электроприборов");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод электроприборов в виде таблицы");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Перемешивание списка электроприборов");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка по названию");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по мощности");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Включение всех приборов");
                Console.SetCursorPosition(x, y++); Console.WriteLine("7. Выключение всех приборов");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out numberTask))
                    continue;

                try
                {

                    // обработка ввода 
                    switch (numberTask)
                    {
                        // выход
                        case (int)Cmd.pointExit:
                            // позициониаровние курсора 
                            Console.SetCursorPosition(2, y + 5);
                            return;

                        // 1. Формирование данных электроприборов
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод электроприборов в виде таблицы
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Перемешивание списка электроприборов
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Сортировка по названию
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Сортировка по мощности
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Включение всех приборов
                        case (int)Cmd.pointSix:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Выключение всех приборов
                        case (int)Cmd.pointSeven:
                            Console.Clear();
                            // запуск задания 
                            Point7();
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
                }// Try


                // стандартное исключение
                catch (Exception ex)
                {
                    Console.Clear();

                    // вывод сообщения об ошибке 
                    WriteColor(ex.Message, ConsoleColor.Red);
                    Console.WriteLine();
                    WriteColor(ex.StackTrace, ConsoleColor.Red);
                    Console.WriteLine();
                } // catch

                // обязательная часть
                finally
                {
                    // если пункт меню 0
                    if (numberTask != 0)
                    {
                        // ввод клавиши для продолжения 
                        WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                        Console.CursorVisible = false;
                        while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                        Console.CursorVisible = true;
                    }
                } // finally
            }

            #endregion

            #region 1. Формирование данных электроприборов

            // 1. Формирование данных электроприборов
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных электроприборов");

                // вывод приборов до заполнения 
                controller.ShowTable(info:"До заполнения");

                Console.WriteLine();

                // инициализация массива 
                controller.Initialization();

                // вывод приборов после заполнения
                controller.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод электроприборов в виде таблицы

            // 2. Вывод электроприборов в виде таблицы
            void Point2()
            {
                ShowNavBarMessage("2. Вывод электроприборов в виде таблицы");

                // вывод приборов
                controller.ShowTable();
            }

            #endregion

            #region 3. Перемешивание списка электроприборов

            // 3. Перемешивание списка электроприборов
            void Point3()
            {
                ShowNavBarMessage("3. Перемешивание списка электроприборов");

                // заполнение данными
                controller.Initialization();

                // вывод приборов до перемешивания
                controller.ShowTable(info: "До перемешивания");

                Console.WriteLine();

                // перемешивание 
                controller.Shuffle();

                // вывод приборов после перемешивания
                controller.ShowTable(info: "После перемешивания");
            }

            #endregion

            #region 4. Сортировка по названию

            // 4. Сортировка по названию
            void Point4()
            {
                ShowNavBarMessage("4. Сортировка по названию");

                // вывод приборов до сортировки
                controller.ShowTable(info: "До сортировки");

                Console.WriteLine();

                // сортировка
                controller.SortByName();

                // вывод приборов после сортировки
                controller.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 5. Сортировка по мощности

            // 5. Сортировка по мощности
            void Point5()
            {
                ShowNavBarMessage("5. Сортировка по мощности");

                // вывод приборов до сортировки
                controller.ShowTable(info: "До сортировки");

                Console.WriteLine();

                // сортировка
                controller.SortByPower();

                // вывод приборов после сортировки
                controller.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 6. Включение всех приборов

            // 6. Включение всех приборов
            void Point6()
            {
                ShowNavBarMessage("6. Включение всех приборов");

                // вывод приборов до включения 
                controller.ShowTable(info: "До включения");

                Console.WriteLine();

                // включение приборов
                controller.AllPowerON();

                // вывод приборов после включения
                controller.ShowTable(info: "После включения");
            }

            #endregion

            #region 7. Выключение всех приборов

            // 7. Выключение всех приборов
            void Point7()
            {
                ShowNavBarMessage("7. Выключение всех приборов");

                // вывод приборов до выключения 
                controller.ShowTable(info: "До выключения");

                Console.WriteLine();

                // выключение приборов
                controller.AllPowerOFF();

                // вывод приборов после выключения
                controller.ShowTable(info: "После выключения");
            }

            #endregion
        }

        #endregion

    }
}
