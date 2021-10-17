using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Home_work.Controllers;                // для использования классов задания 1
using Home_work.Models.Task1;               // для использования моделей задания 1

using static Home_work.Application.App.Utils;       // для использования утилит


namespace Home_work.Application
{
    // Задание 1. Транспортное средство
    public partial class App
    {
        #region Задание 1. Транспортное средство

        /*
         * Задача 1. Создать абстрактный класс Vehicle (транспортное средство). На его 
         * основе реализовать классы Plane (самолет), Саг (автомобиль) и Ship (корабль).
         * Классы должны иметь возможность задавать и получать параметры средств 
         * передвижения (географические координаты, цена, скорость, год выпуска) с 
         * помощью свойств.
         * 
         * Дополнительно для самолета должна быть определена высота, для самолета и 
         * корабля — количество пассажиров, для корабля — порт приписки. 
         * 
         * Создайте массив транспортных средств, состоящий из 2х самолетов, 3х 
         * кораблей и 5и автомобилей. В массиве найти:
         * •	самое старое транспортное средство
         * •	самое быстрое и самое медленное транспортные средства (может быть 
         *      найдено больше 1 транспортного средства) 
         */

        // Задание 1. Транспортное средство
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Транспортное средство"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных транспортных средств");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод транспортных средств");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Найти самое старое транспортное средство ");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Найти самое быстрое и самое медленное транспортные средства");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по убыванию цены");
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

                        // 1. Формирование данных транспортных средств
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод транспортных средств
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Найти самое старое транспортное средство 
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Найти самое быстрое и самое медленное транспортные средства
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Сортировка по убыванию цены
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            Point5();
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

            #region 1. Формирование данных транспортных средств

            // 1. Формирование данных транспортных средств
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных транспортных средств");

                // вывод массива до заполнения
                task.ShowTable(info:"До заполнения");

                Console.WriteLine();

                // заполнение массива данными 
                task.FillData();

                // вывод массива после заполнения
                task.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод транспортных средств

            // 2. Вывод транспортных средств
            void Point2()
            {
                ShowNavBarMessage("2. Вывод транспортных средств");

                // вывод массива 
                task.ShowTable();
            }

            #endregion

            #region 3. Найти самое старое транспортное средство 

            // 3. Найти самое старое транспортное средство 
            void Point3()
            {
                ShowNavBarMessage("3. Найти самое старое транспортное средство ");

                // вывод массива
                task.ShowTable();

                Console.WriteLine();

                // поиск самых старых траспортных средств
                Vehicle[] vehicles = task.SelectOldest();

                // вывод массива
                Vehicle.ShowTable(vehicles, "Траспортные средства", "Самые старые");
            }

            #endregion

            #region 4. Найти самое быстрое и самое медленное транспортные средства

            // 4. Найти самое быстрое и самое медленное транспортные средства
            void Point4()
            {
                ShowNavBarMessage("4. Найти самое быстрое и самое медленное транспортные средства");

                // вывод массива
                task.ShowTable();

                Console.WriteLine();

                // поиск самых быстрых траспортных средств
                Vehicle[] fast = task.SelectFastest();
                
                // поиск самых медленных траспортных средств
                Vehicle[] slow = task.SelectSlowest();

                // вывод массива
                Vehicle.ShowTable(fast, "Траспортные средства", "Самые быстрые");

                Console.WriteLine();

                Vehicle.ShowTable(slow, "Траспортные средства", "Самые медленные");
            }

            #endregion

            #region 5. Сортировка по убыванию цены

            // 5. Сортировка по убыванию цены
            void Point5()
            {
                ShowNavBarMessage("5. Сортировка по убыванию цены");

                // вывод массива до сортировки
                task.ShowTable(info: "До сортировки");

                Console.WriteLine();

                // сортировка массива 
                task.SortByPrice();

                // вывод массива после заполнения
                task.ShowTable(info: "После сортировки");

            }

            #endregion

        }

        #endregion
    }
}
