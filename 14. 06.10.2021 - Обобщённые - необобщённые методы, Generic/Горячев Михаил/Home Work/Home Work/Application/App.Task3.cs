using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Home_Work.Controllers;                        // для использования обработок

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_Work.Application
{
    public partial class App
    {
        #region 3. Обработка массива Person

        /*
         * Задача 1. Разработать обобщенный класс для хранения одномерного массива. 
         * Класс должен иметь следующий функционал:
         *   •	начальная инициализация массива (заполнение в методе случайными 
         *      значениями)
         *   •	вывод массива в консоль
         *   •	определение количества максимальных элементов массива
         *   •	упорядочение массива 
         *   Проверить работу приложения на типах данных 
         *   •	Person (Name: string, Age: int, Salary: double) для Person - максимальный по 
         *      значению свойства Salary, упорядочение по убыванию свойства Age
         */

        // 3. Обработка массива Person
        public void Task3()
        {
            // контоллер обработки 
            Task3Controller controller = new Task3Controller();

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    3. Обработка массива Person"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Инициализация массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Определение количества максимальных элементов по зарплате ");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Упорядочивание массива по убыванию возраста");
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

                        // 1. Инициализация массива
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод массива
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Определение количества максимальных элементов по зарплате 
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Упорядочивание массива по убыванию возраста
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

            #region 1. Инициализация массива

            // 1. Инициализация массива
            void Point1()
            {
                ShowNavBarMessage("1. Инициализация массива");

                // вывод массива до инициализации
                controller.Show(info: "До заполнения");

                Console.WriteLine();

                // инициализация
                controller.Initialization();

                // вывод массива после инициализации
                controller.Show(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод массива

            // 2. Вывод массива
            void Point2()
            {
                ShowNavBarMessage("2. Вывод массива");

                // вывод массива 
                controller.Show();
            }

            #endregion

            #region 3. Определение количества максимальных элементов по зарплате 

            // 3. Определение количества максимальных элементов по зарплате 
            void Point3()
            {
                ShowNavBarMessage("3. Определение количества максимальных элементов по зарплате ");

                // вывод массива с подсветкой максималных элементов
                controller.ShowColorMaxElem(controller.Data.MaxElem(), info: "Максимальные элементы");

                Console.WriteLine();

                // вывод количества максимальных элементов 
                ShowCountMaxElem(controller.CountMaxElements());
            }

            #endregion

            #region 4. Упорядочивание массива по убыванию возраста

            // 4. Упорядочивание массива по убыванию возраста
            void Point4()
            {
                ShowNavBarMessage("4. Упорядочивание массива по убыванию возраста");

                // вывод массива до сортировки
                controller.Show(info: "До сортировки");

                Console.WriteLine();

                // сортировка
                controller.Sort();

                // вывод массива после сортировки
                controller.Show(info: "После сортировки");
            }

            #endregion

        }

        #endregion

    }
}
