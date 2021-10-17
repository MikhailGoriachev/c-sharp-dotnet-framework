using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Home_work.Controllers;                // для использования классов задания 2
using Home_work.Models.Task2;               // для использования моделей задания 2

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Application
{
    // Задание 2. Фигура
    public partial class App
    {
        #region Задание 2. Фигура

        /*
         * Задача 2. Создать иерархию интерфейсов и классов по следующему заданию:
         * •	Интерфейс ПлоскаяФигура с методами для вычисления площади и периметра   
         * •	Интерфейс ОбъемнаяФигура с методами для вычисления площади поверхности
         *      и объема
         * •	Класс Фигура – базовый класс иерархии.
         * •	Треугольник, наследует от Фигура, реализует интерфейс ПлоскаяФигура
         * •	Прямоугольник, наследует от Фигура, реализует интерфейс ПлоскаяФигура
         * •	Цилиндр, наследует от Фигура, реализует интерфейс ОбъемнаяФигура
         * •	Конус, наследует от Фигура, реализует интерфейс ОбъемнаяФигура
         * •	Разместить классы и интерфейсы в отдельных файлах 
         * 
         * Реализовать по два объекта каждого типа в массиве объектов класса Фигура. 
         * 
         * Для массива выполнить:
         * •	Упорядочить массив по убыванию площади
         * •	Выбрать объекты с минимальной и максимальной площадью
        */

        // Задание 2. Название задания
        public void Task2()
        {
            // обработка по заданию 2
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Название задания"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование начальных фигур");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод коллекции фигур");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сортировка по убыванию площади");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Выборка фигур с минимальной и максимальной площадью");
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

                        // 1. Формирование начальных фигур
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод коллекции фигур
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Сортировка по убыванию площади
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Выборка фигур с минимальной и максимальной площадью
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

            #region 1. Формирование начальных фигур

            // 1. Формирование начальных фигур
            void Point1()
            {
                ShowNavBarMessage("1. Формирование начальных фигур");

                // вывод до формирования
                task.ShowTable(info:"До заполнения");

                Console.WriteLine();

                // формироавние данных
                task.FillFigures();

                // вывод после формирования
                task.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод коллекции фигур

            // 2. Вывод коллекции фигур
            void Point2()
            {
                ShowNavBarMessage("2. Вывод коллекции фигур");

                // вывод фигур
                task.ShowTable();
            }

            #endregion

            #region 3. Сортировка по убыванию площади

            // 3. Сортировка по убыванию площади
            void Point3()
            {
                ShowNavBarMessage("3. Сортировка по убыванию площади");

                // вывод до сортировки
                task.ShowTable(info: "До сортировки");

                Console.WriteLine();

                // сортировка данных
                task.SortByArea();

                // вывод после сортировки
                task.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 4. Выборка фигур с минимальной и максимальной площадью

            // 4. Выборка фигур с минимальной и максимальной площадью
            void Point4()
            {
                ShowNavBarMessage("4. Выборка фигур с минимальной и максимальной площадью");

                // вывод фигур
                task.ShowTable();

                Console.WriteLine();

                // минимальные фигуры по площади
                Figure[] min = task.SelectMinArea();

                // максимальные фигуры по площади
                Figure[] max = task.SelectMaxArea();

                // вывод минимальных фигур по площади
                Figure.ShowTable(min, name: "Фигуры", info: "Минимальная площадь");
                
                // вывод минимальных фигур по площади
                Figure.ShowTable(max, name: "Фигуры", info: "Максимальная площадь");
            }

            #endregion

        }

        #endregion

    }
}
