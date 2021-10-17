using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Home_Work.Task_1._Worker;      // для подключения классов первого задания

namespace Application
{
    // главный класс приложения
    internal partial class App
    {
        #region Задание 1. Работник

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
         */

        // Задание 1. Работник
        public void Task1()
        {
            // объект Company
            Company company = new Company { Name = "Oracle"};

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Работник"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование начальных данных работников");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод предприятия в консоль");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сортировка по алфавиту");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка по должности");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по убыванию стажа работы");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Выбрать работников по диапазону оклада и вывести в консоль");
                Console.SetCursorPosition(x, y++); Console.WriteLine("7. Выбрать работников по должности и вывести в консоль");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                try
                {

                    // обработка ввода 
                    switch (n)
                    {
                        // выход
                        case (int)Cmd.pointExit:
                            // позициониаровние курсора 
                            Console.SetCursorPosition(2, y + 5);
                            return;

                        // 1. Формирование начальных данных работников
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            DemoFillWorkers();
                            break;

                        // 2. Вывод предприятия в консоль
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            DemoShowWorkers();
                            break;

                        // 3. Сортировка по алфавиту
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByName();
                            break;

                        // 4. Сортировка по должности
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByPost();
                            break;

                        // 5. Сортировка по убыванию стажа работы
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByExp();
                            break;

                        // 6. Выбрать работников по диапазону оклада и вывести в консоль
                        case (int)Cmd.pointSix:
                            Console.Clear();
                            // запуск задания 
                            DemoSelectBySalary();
                            break;

                        // 7. Выбрать работников по должности и вывести в консоль
                        case (int)Cmd.pointSeven:
                            Console.Clear();
                            // запуск задания 
                            DemoSelectByPost();
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
                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;
                } // finally
            }

            #endregion

            #region 1. Пункт меню

            // 1. Формирование начальных данных работников
            void DemoFillWorkers()
            {
                ShowNavBarMessage("1. Формирование начальных данных работников");

                // вывод таблицы до заполенения 
                company.ShowTable("До заполнения");

                Console.WriteLine();

                // массив с рабочими
                Worker[] workers = new Worker[]
                    {
                        new Worker{ Name = "Золотарев Ю. Р.",   Post = "Junior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(60,   80) * 1000},
                        new Worker{ Name = "Чистякова С. Е.",   Post = "Middle dev", Year =rand.Next(2002, 2019), Salary = rand.Next(80,  120) * 1000},
                        new Worker{ Name = "Долгов В. Д.",      Post = "Junior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(60,   80) * 1000},
                        new Worker{ Name = "Марков Б. П.",      Post = "Senior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(120, 160) * 1000},
                        new Worker{ Name = "Русаков А. И.",     Post = "Junior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(60,   80) * 1000},
                        new Worker{ Name = "Еремина Д. Ф.",     Post = "Middle dev", Year =rand.Next(2002, 2019), Salary = rand.Next(80,  120) * 1000},
                        new Worker{ Name = "Сергеева Н. И.",    Post = "Middle dev", Year =rand.Next(2002, 2019), Salary = rand.Next(80,  120) * 1000},
                        new Worker{ Name = "Комарова Е. Т.",    Post = "Senior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(120, 160) * 1000},
                        new Worker{ Name = "Наумова А. А.",     Post = "Junior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(60,   80) * 1000},
                        new Worker{ Name = "Русаков Л. А.",     Post = "Junior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(60,   80) * 1000},
                        new Worker{ Name = "Ершова А. А.",      Post = "Middle dev", Year =rand.Next(2002, 2019), Salary = rand.Next(80,  120) * 1000},
                        new Worker{ Name = "Лобанов И. А.",     Post = "Senior dev", Year =rand.Next(2002, 2019), Salary = rand.Next(120, 160) * 1000},
                    };

                // заполнение компании массивом рабочих
                company.Workers = workers;

                // вывод таблицы после заполенения 
                company.ShowTable("После заполнения");
            }

            #endregion

            #region 2. Вывод предприятия в консоль

            // 2. Вывод предприятия в консоль
            void DemoShowWorkers()
            {
                ShowNavBarMessage("2. Вывод предприятия в консоль");

                // вывод таблицы  
                company.ShowTable();
            }

            #endregion

            #region 3. Сортировка по алфавиту

            // 3. Сортировка по алфавиту
            void DemoSortByName()
            {
                ShowNavBarMessage("3. Сортировка по алфавиту");

                // вывод таблицы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByName();

                // вывод таблицы после сортировки
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 4. Сортировка по должности

            // 4. Сортировка по должности
            void DemoSortByPost()
            {
                ShowNavBarMessage("4. Сортировка по должности");

                // вывод таблицы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByPost();

                // вывод таблицы после сортировки
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 5. Сортировка по убыванию стажа работы

            // 5. Сортировка по убыванию стажа работы
            void DemoSortByExp()
            {
                ShowNavBarMessage("5. Сортировка по убыванию стажа работы");

                // вывод таблицы до сортировки 
                company.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка 
                company.SortByExp();

                // вывод таблицы после сортировки
                company.ShowTable("После сортировки");
            }

            #endregion

            #region 6. Выбрать работников по диапазону оклада и вывести в консоль

            // 6. Выбрать работников по диапазону оклада и вывести в консоль
            void DemoSelectBySalary()
            {
                while (true)
                {
                    ShowNavBarMessage("6. Выбрать работников по диапазону оклада и вывести в консоль");

                    // вывод таблицы с исходными данными 
                    company.ShowTable("Исходные данные");

                    Console.WriteLine();

                    // диапазон оклада
                    int minS, maxS;

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
                    WriteColorXY("Мин. оклад", x, ++y, ConsoleColor.DarkYellow); y += 2;
                    WriteColorXY("Макс. оклад", x, y, ConsoleColor.DarkYellow);

                    // включение отображения курсора
                    Console.CursorVisible = true;

                    // установка цвета 
                    Console.ForegroundColor = ConsoleColor.Green;

                    y -= 2;

                    // ввод данных 
                    WriteColorXY(posX: 29, posY: y); if (!int.TryParse(Console.ReadLine(), out minS)) continue;
                    WriteColorXY(posX: 29, posY: y + 2); if (!int.TryParse(Console.ReadLine(), out maxS)) continue;

                    // если minS > maxS
                    if (minS > maxS)
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
                    Worker[] selWorker = company.SelectBySalary(minS, maxS);

                    // вывод таблицы отобранных элементов
                    Company.ShowHead(selWorker?.Length ?? 0, company.Name, "Выборка рабочих");
                    Company.ShowElem(selWorker);

                    break;
                }
            }

            #endregion

            #region 7. Выбрать работников по должности и вывести в консоль

            // 7. Выбрать работников по должности и вывести в консоль
            void DemoSelectByPost()
            {
                while (true)
                {
                    ShowNavBarMessage("7. Выбрать работников по должности и вывести в консоль");

                    // вывод таблицы с исходными данными 
                    company.ShowTable("Исходные данные");

                    Console.WriteLine();

                    // должность
                    string post;

                    Console.WriteLine("\n");

                    // ввод данных
                    WriteColorXY("          ╔════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ║                                ║\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ╠════════════════╦═══════════════╣\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ║                ║               ║\n", textColor: ConsoleColor.Magenta);
                    WriteColorXY("          ╚════════════════╩═══════════════╝\n", textColor: ConsoleColor.Magenta);

                    // позиция курсора
                    int x = 12, y = Console.CursorTop - 4;

                    WriteColorXY("          Ввод данных          ", x, y++, ConsoleColor.DarkYellow);
                    WriteColorXY("Должность", x, ++y, ConsoleColor.DarkYellow); 

                    // включение отображения курсора
                    Console.CursorVisible = true;

                    // установка цвета 
                    Console.ForegroundColor = ConsoleColor.Green;

                    // ввод данных 
                    WriteColorXY(posX: 29, posY: y); post = Console.ReadLine();
                    if (String.IsNullOrWhiteSpace(post)) continue;

                    Console.WriteLine("\n");

                    // установка исходного цвета 
                    Console.ResetColor();

                    // выбор
                    Worker[] selWorker = company.SelectByPost(post);

                    // вывод таблицы отобранных элементов
                    Company.ShowHead(selWorker?.Length ?? 0, company.Name, "Выборка рабочих");
                    Company.ShowElem(selWorker);

                    break;
                }

            }

            #endregion
        }

        #endregion

    }
}
