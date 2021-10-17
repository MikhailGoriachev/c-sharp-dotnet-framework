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
        #region Задание 2. Персона

        /*
         * Задача 2. Для описания персоны используются фамилия и инициалы, возраст в 
         * годах, название города проживания. Разработайте класс и следующие события 
         * для этого класса: 
         * •	при присваивании возраста меньше 21 – зажигать событие Childhood
         * •	при изменении города проживания зажигать событие Relocate
         * 
         * Для проверки работы подпишите на события как минимум трех наблюдателей (метод 
         * класса, статический метод класса, лямбда-выражение). 
         * 
         * Сгенерируйте массив (не менее чем 10 персон). Выводите массив в табличной 
         * форме. По командам, назначенным на клавиши задавать некоторому случайно 
         * выбранному элементу массива возраст (присваиванием свойству некоторого 
         * случайного числа), город проживания (выбирать при помощи случайного индекса 
         * название города из массива названий городов).
         * 
         * Для события Childhood обработчики события должны выполнять следующее:
         * 1.	В первом обработчике выводить возраст, фамилию и инициалы, сообщение 
         *      "возраст меньше допустимого" некоторым цветом в консоль, в строке 
         *      отображения персоны в таблице
         * 2.	Во втором обработчике выводить строку "обнаружен несовершеннолетний" в 
         *      заголовок окна. 
         * 3.	В третьем обработчике подсчитывать общее количество персон с возрастом
         *      < 21 года, выводить это количество некоторым цветом в консоль, в строку 
         *      заголовка таблицы
         * Для события Relocate обработчики должны выполнять следующее:
         * 1.	Подсчет количества персон в городах, выводить результат в некоторую 
         *      область консоли в виде таблицы со столбцами «Город» и «Количество 
         *      проживающих»
         * 2.	Вывод строки формата «старый город -> новый город» возле соответствующей 
         *      строки таблицы, отображающей массив персон
         */

        // Задание 2. Персона
        public void Task2()
        {
            // обработка 
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Персона"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных о персонах");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод персон в виде таблицы");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Изменение случайной персоны");
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

                        // 1. Формирование данных о персонах
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод персон в виде таблицы
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Изменение случайной персоны
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

            #region 1. Формирование данных о персонах

            // 1. Формирование данных о персонах
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных о персонах");

                // инициализация 
                controller.Initialization();

                // вывод персон
                controller.ShowTable("После заполнения");
            }

            #endregion

            #region 2. Вывод персон в виде таблицы

            // 2. Вывод персон в виде таблицы
            void Point2()
            {
                ShowNavBarMessage("2. Вывод персон в виде таблицы");

                // вывод персон
                controller.ShowTable();
            }

            #endregion

            #region 3. Изменение случайной персоны

            // 3. Изменение случайной персоны
            void Point3()
            {
                ShowNavBarMessage("3. Изменение случайного электроприбора");

                // демонстрация изменений случайной персоны
                controller.Change();
            }

            #endregion
        }

        #endregion

    }
}
