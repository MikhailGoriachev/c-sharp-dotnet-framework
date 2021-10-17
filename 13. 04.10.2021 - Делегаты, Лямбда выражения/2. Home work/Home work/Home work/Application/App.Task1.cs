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
        #region Задание 1. Обработка массива

        /*
         * Задача 1. Разработайте классы для обработки массивов, при этом 
         * предикаты и компараторы реализовать при помощи делегатов. 
         * Реализация компараторов анонимными методами, предикатов – 
         * именованными делегатами (сохраненными в переменных).
         * 
         * В одномерном массиве, состоящем из п целых элементов:
         * •	вычислить количество элементов, равных минимальному 
         *      элементу массива;
         * •	вычислить сумму элементов массива, расположенных между 
         *      первым и последним положительными элементами;
         * •	преобразовать массив таким образом, чтобы сначала 
         *      располагались все   элементы, равные нулю, а потом — все 
         *      остальные.
         * Все три обработки запускать одним делегатом.
         * 
         * В одномерном массиве, состоящем из п целых элементов:
         * •	вычислить количество отрицательных элементов массива;
         * •	вычислить сумму элементов массива, расположенных между 
         *      первым и вторым отрицательными элементами;
         * •	преобразовать массив таким образом, чтобы сначала 
         *      располагались все элементы, модуль которых не превышает 
         *      3, а потом — все остальные.
         * Все три обработки запускать одним делегатом.
         */

        // Задание 1. Обработка массива
        public void Task1()
        {
            // объект обработки
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Обработка массива"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Обработка 1");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Обработка 2");
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

                        // 1. Формирование данных массива
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

                        // 3. Обработка 1
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Обработка 2
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

            #region 1. Формирование данных массива

            // 1. Формирование данных массива
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных массива");

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElements, info: "До заполнения");

                Console.WriteLine();

                // инициализация массива 
                controller.Initialization();

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElements, info: "После заполнения");
            }

            #endregion

            #region 2. Вывод массива

            // 2. Вывод массива
            void Point2()
            {
                ShowNavBarMessage("2. Вывод массива");

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElements);
            }

            #endregion

            #region 3. Обработка 1

            // 3. Обработка 1
            void Point3()
            {
                ShowNavBarMessage("3. Обработка 1");

                // вывод условий обработки
                controller.ShowConditionsProc1();

                Console.WriteLine();

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElementsProc1, info: "До обработки");

                Console.WriteLine();

                // обработка массива 
                var result = controller.Processing1();

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElementsProc1, info: "После обработки");

                // вывод результатов
                controller.ShowResult1(result);
            }

            #endregion

            #region 4. Обработка 2

            // 4. Обработка 2
            void Point4()
            {
                ShowNavBarMessage("4. Обработка 2");

                // инициализация массива в нужном диапазоне
                controller.Initialization(-3, 10);

                // вывод условий обработки
                controller.ShowConditionsProc2();

                Console.WriteLine();

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElementsProc2, info: "До обработки");

                Console.WriteLine();

                // обработка массива 
                var result = controller.Processing2();

                // вывод массива
                controller.ShowArray(Task1Controller.ShowElementsProc2, info: "После обработки");

                // вывод результатов
                controller.ShowResult2(result);
            }

            #endregion

        }

        #endregion
    }
}
