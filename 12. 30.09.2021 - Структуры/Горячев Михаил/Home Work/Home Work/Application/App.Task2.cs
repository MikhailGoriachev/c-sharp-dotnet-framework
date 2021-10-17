using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Home_Work.Controllers;                   // для использования обработки по заданию  
using Home_Work.Models.Task2;                   // для использования классов первого задания


using static Home_Work.Application.App.Utils;       // для использования утилит

namespace Home_Work.Application
{
    public partial class App
    {
        #region Задание 2. Студент 

        /*
        * Задача 2. Описать структуру Student, содержащую поля:
        *   •	фамилия и инициалы;
        *   •	название группы;
        *   •	успеваемость (массив из пяти элементов типа Mark – вложенная
        *       структура: название предмета, оценка (short)) 
        *   •	индексатор для массива оценок Mark – вложенная структура: 
        *       название предмета, оценка (short)
        *       
        *   Написать программу, выполняющую обработку массива структур Student:
        *   •	заполнение данными (сгенерированными) массива из десяти структур
        *       типа Student
        *   •	вывод на экран фамилий и названия групп для всех студентов, 
        *       имеющих хотя бы одну оценку 2 (если таких студентов нет, вывести
        *       соответствующее сообщение)
        *   •	вывод на экран фамилий и названий групп для всех студентов,
        *       имеющих оценки только 4 и 5 (если таких студентов нет, вывести
        *       соответствующее сообщение)
        *   •	упорядочивание массива по возрастанию среднего балла
        *   •	упорядочивание массива по фамилиям и инициалам
        *   •	перемешивание массива студентов
        */

        // Задание 2. Студент
        public void Task2()
        {
            // обработка по заданию
            Task2 task = new Task2();

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Студент"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод студентов");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Вывод фамилий и названий групп для студентов имеющих оценку 2");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Вывод фамилий и названий групп для студентов имеющих оценки только 4 и 5");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по возрастанию среднего бала");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Сортировка по фамилиям и инициалам");
                Console.SetCursorPosition(x, y++); Console.WriteLine("7. Перемешивание массива студентов");
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

                        // 1. Формирование данных
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод студентов
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Вывод фамилий и названий групп для студентов имеющих оценку 2
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Вывод фамилий и названий групп для студентов имеющих оценки только 4 и 5
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Сортировка по возрастанию среднего бала
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Сортировка по фамилиям и инициалам
                        case (int)Cmd.pointSix:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Перемешивание массива студентов
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

            #region 1. Формирование данных

            // 1. Формирование данных
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных");

                // формирование данных 
                task.Initialization();

                // вывод студентов
                task.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод студентов

            // 2. Вывод студентов
            void Point2()
            {
                ShowNavBarMessage("2. Вывод студентов");

                // вывод студентов
                task.ShowTable();
            }

            #endregion

            #region 3. Вывод фамилий и названий групп для студентов имеющих оценку 2

            // 3. Вывод фамилий и названий групп для студентов имеющих оценку 2
            void Point3()
            {
                ShowNavBarMessage("3. Вывод фамилий и названий групп для студентов имеющих оценку 2");

                // вывод всех студентов
                task.ShowTable();

                Console.WriteLine();

                // выборка студентов
                Student[] select = task.SelectByMarkTwo();

                // вывод выбранных студентов
                task.ShowHead(select.Length, info: "Выборка студентов");
                task.ShowElem(select);
                task.ShowLine();
            }

            #endregion

            #region 4. Вывод фамилий и названий групп для студентов имеющих оценки только 4 и 5

            // 4. Вывод фамилий и названий групп для студентов имеющих оценки только 4 и 5
            void Point4()
            {
                ShowNavBarMessage("4. Вывод фамилий и названий групп для студентов имеющих оценки только 4 и 5");

                // вывод всех студентов
                task.ShowTable();

                Console.WriteLine();

                // выборка студентов
                Student[] select = task.SelectByMarkFourFive();

                // вывод выбранных студентов
                task.ShowHead(select.Length, info: "Выборка студентов");
                task.ShowElem(select);
                task.ShowLine();
            }

            #endregion

            #region 5. Сортировка по возрастанию среднего бала

            // 5. Сортировка по возрастанию среднего бала
            void Point5()
            {
                ShowNavBarMessage("5. Сортировка по возрастанию среднего бала");

                // сортировка 
                task.SortAscendByAvgMark();

                // вывод студентов
                task.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 6. Сортировка по фамилиям и инициалам

            // 6. Сортировка по фамилиям и инициалам
            void Point6()
            {
                ShowNavBarMessage("6. Сортировка по фамилиям и инициалам");

                // сортировка 
                task.SortByName();

                // вывод студентов
                task.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 7. Перемешивание массива студентов

            // 7. Перемешивание массива студентов
            void Point7()
            {
                ShowNavBarMessage("7. Перемешивание массива студентов");

                // перемешивание 
                task.ShuffleStudents();

                // вывод студентов
                task.ShowTable(info: "После перемешивания");
            }

            #endregion
        }

        #endregion

    }
}
