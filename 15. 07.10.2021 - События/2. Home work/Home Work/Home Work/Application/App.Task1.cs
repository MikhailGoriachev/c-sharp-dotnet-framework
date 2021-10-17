using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Home_Work.Controllers;            // подключение обработки

using static Home_Work.Application.App.Utils;       // для использования утилит

namespace Home_Work.Application
{
    public partial class App
    {
        #region Задание 1. Электроприбор

        /*
         * Задача 1. Доработайте класс, описывающий электроприбор (название, мощность,
         * цена, включен/выключен) из задания на 06.10.2021. Массив приборов выводить 
         * в табличном формате, в массиве должно быть от 12 до 20 прибров.
         * 
         * По командам, назначенным на клавиши, изменять мощность (на случайную 
         * величину), состояние прибора (включен, выключен). Прибор для изменения 
         * выбирается случайным образом из массива приборов.
         * 
         * Если новое значение мощности – нечетное число, то зажигать событие 
         * PowerChange. При присваивании свойству, отражающему состояние электроприбора
         * значения, отличного от текущего, зажигать событие StateChange.
         * 
         * Создать Наблюдатель1, который будет выводить старую и новую мощность прибора 
         * в консоль в строке таблицы для соответствующего прибора
         * Создать Наблюдатель2, который выводит состояние соответствующего прибора в 
         * консоли (в строке, соответствующего прибора в таблице): красный фон для 
         * выключенного прибора, зеленый фон для включенного прибора.
         */

        // Задание 1. Электроприбор
        public void Task1()
        {
            // обработка по заданию 
            Task1Controller controller = new Task1Controller(); 

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Электроприбор"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных электроприборов  ");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод электроприборов в виде таблицы");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Изменение случайного электроприбора");
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

                        // 3. Изменение случайного электроприбора
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
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
                    if (numberTask != 0 && numberTask != 3)
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

                // формирование данных
                controller.Initialization();

                // вывод данных
                controller.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод электроприборов в виде таблицы

            // 2. Вывод электроприборов в виде таблицы
            void Point2()
            {
                ShowNavBarMessage("2. Вывод электроприборов в виде таблицы");

                // вывод данных
                controller.ShowTable(info: "После заполнения");
            }

            #endregion

            #region 3. Изменение случайного электроприбора

            // 3. Изменение случайного электроприбора
            void Point3()
            {
                ShowNavBarMessage("3. Изменение случайного электроприбора");

                // демонстрация изменений случайного электроприбора
                controller.Change();
            }

            #endregion     
            
            #endregion
        }
    }
}