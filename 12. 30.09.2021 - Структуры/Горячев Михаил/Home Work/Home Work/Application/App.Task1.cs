using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Home_Work.Controllers;                        // для использования обработки по заданию

using static Home_Work.Application.App.Utils;       // для использования утилит

namespace Home_Work.Application
{
    public partial class App
    {
        #region Задание 1. Уравнение

        /*
         * Задача 1. Создать иерархию классов и интерфейс для решения линейных и 
         * квадратных уравнений. Линейное уравнение имеет вид: ax + b = 0, 
         * квадратное уравнение имеет вид ax2 + bx + c = 0
         * 
         * Базовый абстрактный класс Root, класс для линейных уравнений Linear, 
         * класс для квадратных уравнений Square. Интерфейс ISolver должен 
         * содержать методы void Solve() для решения уравнения, void  Show()   
         * для   вывода решения в консоль, bool HasSolve() для определения 
         * наличия решения уравнения. 
         * 
         * Создать массив из 20 уравнений, типы и коэффициенты уравнений выбирать
         * случайно. Решить уравнения в массиве, вывести уравнения и решения (или
         * сообщение об отсутствии решения).
         * 
         * Вычислить и вывести следующую статистику:
         *  •	общее количество уравнений
         *      —	сколько из них квадратных
         *      —	сколько из них линейных
         *  •	общее количество решений
         *      —	сколько из них для квадратных уравнений
         *      —	сколько из них для линейных уравнений
         */

        // Задание 1. Уравнение
        public void Task1()
        {
            // обработка по заданию
            Task1 task = new Task1();

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Уравнение"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Решение уравнений");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Вывод уравнений");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Статистика");
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

                        // 2. Решение уравнений
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Вывод уравнени
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Статистика
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
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
                } // try

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
            } // while

            #endregion

            #region 1. Формирование данных

            // 1. Формирование данных
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных");

                // инициализация 
                task.Initialization();

                // вывод уравнений
                task.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Решение уравнений

            // 2. Решение уравнений
            void Point2()
            {
                ShowNavBarMessage("2. Решение уравнений");

                // решение уравнений
                task.Solve();

                // вывод уравнений
                task.ShowTable(info: "Решение уравнений");
            }

            #endregion

            #region 3. Вывод уравнени

            // 3. Вывод уравнени
            void Point3()
            {
                ShowNavBarMessage("3. Вывод уравнени");

                // вывод уравнений
                task.ShowTable();
            }

            #endregion

            #region 4. Статистика

            // 4. Статистика
            void Point4()
            {
                ShowNavBarMessage("4. Статистика");

                // вывод статистики 
                task.ShowStatistics(task.CountSolve, task.CountEquat, task.CountSolveLinear(), task.CountSolveSquare(), task.CountEquatLinear(), task.CountEquatSquare());
            }

            #endregion

        }

        #endregion
    }
}
