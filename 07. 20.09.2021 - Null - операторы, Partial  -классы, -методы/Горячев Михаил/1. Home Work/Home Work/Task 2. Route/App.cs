using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Microsoft.VisualBasic;            // для доступа к классу Interaction

using Home_Work.Task_2._Route;          // для подключения классов второго задания

namespace Application
{
    // главный класс приложения
    internal partial class App
    {
        #region Задание 2. Маршрут

        /*
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

        // Задание 2. Маршрут
        public void Task2()
        {
            // туристическая фирма 
            Company company = new Company { Name = "Лидер-тур" };

            #region Меню

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Маршрут"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование начальных данных для фирмы");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод данных фирмы в таблицу");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сортировка по коду маршрута");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка по начальному пункту маршрута");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по убыванию протяженности маршрута");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Выбрать маршруты по диапазону дистанции");
                Console.SetCursorPosition(x, y++); Console.WriteLine("7. Выбрать маршруты по заданному пункту");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                try
                {
                    // 4. Сортировка по начальному пункту маршрута
                    // обработка ввода 
                    switch (n)
                    {
                        // выход
                        case (int)Cmd.pointExit:
                            // позициониаровние курсора 
                            Console.SetCursorPosition(2, y + 5);
                            return;

                        // 1. Формирование начальных данных для фирмы
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            DemoFillRoutes();
                            break;

                        // 2. Вывод данных фирмы в таблицу
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            DemoShowCompany();
                            break;

                        // 3. Сортировка по коду маршрута
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByCode();
                            break;

                        // 4. Сортировка по начальному пункту маршрута
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByPointDepart();
                            break;

                        // 5. Сортировка по убыванию протяженности маршрута
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByDistance();
                            break;

                        // 6. Выбрать маршруты по диапазону дистанции
                        case (int)Cmd.pointSix:
                            Console.Clear();
                            // запуск задания 
                            DemoSelectByDistance();
                            break;

                        // 7. Выбрать маршруты по заданному пункту
                        case (int)Cmd.pointSeven:
                            Console.Clear();
                            // запуск задания 
                            DemoSelectByPoint();
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
                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;
                } // finally
            }

            #endregion

            #region 1. Формирование начальных данных для фирмы

            // 1. Формирование начальных данных для фирмы
            void DemoFillRoutes()
            {
                ShowNavBarMessage("1. Формирование начальных данных для фирмы");

                // вывод фирмы до заполнения 
                company.ShowTable("До заполнения");

                Console.WriteLine();

                // маршруты
                Route[] routes = new Route[]
                {
                    new Route{ PointDepart = "Черногора",           PointDest = "Мармаросы",                CodeRoute = "A58", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Горганы",             PointDest = "Свидовецкий хребет",       CodeRoute = "H47", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Синевир",             PointDest = "Боржавский хребет",        CodeRoute = "D80", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Межигорье",           PointDest = "Водопад Шипот",            CodeRoute = "Z70", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Говерла",             PointDest = "Боржавский хребет",                  CodeRoute = "L50", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Свидовецкий хребет",  PointDest = "Синевир",                  CodeRoute = "J89", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Черногора",           PointDest = "Говерла",                  CodeRoute = "N54", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Синевир",             PointDest = "Водопад Шипот",            CodeRoute = "Y78", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Межигорье",           PointDest = "Говерла",                  CodeRoute = "O53", Distance = rand.Next(1,5) * 100},
                    new Route{ PointDepart = "Черногора",           PointDest = "Говерла",                  CodeRoute = "B40", Distance = rand.Next(1,5) * 100}
                };

                // заполнение компании маршрутами
                company.Routes = routes;

                // вывод фирмы после заполнения 
                company.ShowTable("После заполнения");
            }

            #endregion

            #region 2. Вывод данных фирмы в таблицу

            // 2. Вывод данных фирмы в таблицу
            void DemoShowCompany()
            {
                ShowNavBarMessage("2. Вывод данных фирмы в таблицу");

                // вывод фирмы 
                company.ShowTable();
            }

            #endregion

            #region 3. Сортировка по коду маршрута

            // 3. Сортировка по коду маршрута
            void DemoSortByCode()
            {
                ShowNavBarMessage("3. Сортировка по коду маршрута");

                // вывод фирмы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByCode();

                // вывод фирмы после сортировки 
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 4. Сортировка по начальному пункту маршрута

            // 4. Сортировка по начальному пункту маршрута
            void DemoSortByPointDepart()
            {
                ShowNavBarMessage("4. Сортировка по начальному пункту маршрута");

                // вывод фирмы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByPointDepart();

                // вывод фирмы после сортировки 
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 5. Сортировка по убыванию протяженности маршрута

            // 5. Сортировка по убыванию протяженности маршрута
            void DemoSortByDistance()
            {
                ShowNavBarMessage("5. Сортировка по убыванию протяженности маршрута");

                // вывод фирмы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByDistance();

                // вывод фирмы после сортировки 
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 6. Выбрать маршруты по диапазону дистанции

            // 6. Выбрать маршруты по диапазону дистанции
            void DemoSelectByDistance()
            {
                while (true)
                {
                    ShowNavBarMessage("6. Выбрать маршруты по диапазону дистанции");

                    // вывод таблицы с исходными данными 
                    company.ShowTable("Исходные данные");

                    Console.WriteLine();

                    // диапазон дистанции
                    int min, max;

                    // ввод данных
                    WriteColorXY("          ╔════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ║                                ║\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ╠════════════════╦═══════════════╣\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ║                ║               ║\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ╠════════════════╬═══════════════╣\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ║                ║               ║\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ╚════════════════╩═══════════════╝\n", textColor: ConsoleColor.Magenta);

                    // позиция курсора
                    int x = 12, y = Console.CursorTop - 6;

                    WriteColorXY("          Ввод данных          ", x, y++, ConsoleColor.DarkYellow);
                    WriteColorXY("Мин дистанция", x, ++y, ConsoleColor.DarkYellow); y += 2;
                    WriteColorXY("Макс дистанция", x, y, ConsoleColor.DarkYellow);

                    // включение отображения курсора
                    Console.CursorVisible = true;

                    // установка цвета 
                    Console.ForegroundColor = ConsoleColor.Green;

                    y -= 2;

                    // ввод данных 
                    WriteColorXY(posX: 29, posY: y); if (!int.TryParse(Console.ReadLine(), out min)) continue;
                    WriteColorXY(posX: 29, posY: y + 2); if (!int.TryParse(Console.ReadLine(), out max)) continue;

                    // если minS > maxS
                    if (min > max)
                    {
                        // вывод сообщения 
                        WriteColorXY("Невалидные данные! Минимум больше максимума!", posX: 29, posY: y + 5, textColor: ConsoleColor.Red);

                        Console.WriteLine("\n\n");

                        // задержка по времени (1.5 с)
                        Thread.Sleep(1500);

                        continue;
                    }

                    Console.WriteLine("\n");

                    // установка исходного цвета 
                    Console.ResetColor();

                    // выбор
                    Route[] selRoutes = company.SelectByDistance(min, max);

                    // вывод таблицы отобранных элементов
                    Company.ShowHead(selRoutes?.Length ?? 0, company.Name, "Выборка маршрутов");
                    Company.ShowElem(selRoutes);

                    break;
                }

            }

            #endregion

            #region 7. Выбрать маршруты по заданному пункту

            // 7. Выбрать маршруты по заданному пункту
            void DemoSelectByPoint()
            {
                while (true)
                {
                    ShowNavBarMessage("7. Выбрать маршруты по заданному пункту");

                    // вывод таблицы с исходными данными 
                    company.ShowTable("Исходные данные");

                    Console.WriteLine();

                    // пункт
                    string point = Interaction.InputBox("Название маршрута", "Ввод данных", "Говерла");

                    // если нажата кнопка отмена 
                    if (point.Length == 0)
                        return;

                    Console.WriteLine("\n");

                    // выбор
                    Route[] selRoutes = company.SelectByPoint(point);

                    // вывод таблицы отобранных элементов
                    Company.ShowHead(selRoutes?.Length ?? 0, company.Name, info:"Выборка маршрутов");
                    Company.ShowElem(selRoutes);

                    break;

                }

            }

            #endregion

            #endregion
        }
    }
}