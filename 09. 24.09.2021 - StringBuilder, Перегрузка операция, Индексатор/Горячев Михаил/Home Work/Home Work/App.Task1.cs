using System;
using System.Threading;

using Home_Work.Models.Task1;       // для использования класса Task1

namespace Home_Work
{
    public partial class App
    {

        #region Задание 1. Одномерный массив

        /*
         * Задача 1. Разработайте класс для хранения одномерного массива из п элементов, 
         * типа int, имя класса IntArray.  В классе реализовать:
         * •	Индексатор с контролем выхода за допустимые пределы (при выходе выбрасывать
         *      исключение)
         * •	Контейнер данных – собственно массив с уровнем доступа private
         * •	свойство Length - размер массива
         * •	метод заполнения случайными числами
         * •	метод вывода в строку
         * В классе Task1 с использованием класса одномерного массива и индексатора реализовать
         * обработки:
         * •	произведение элементов массива с четными номерами, вывести массив с выделением 
         *      цветом элементов с четными номерами 
         * •	сумму элементов массива, расположенных между первым и последним нулевыми 
         *      элементами, вывести диапазон суммирования с выделением цветом: границ и слагаемых
         * •	отрицательным элементам массива поменять знак, сортировать массив по убыванию. 
         *      Метод сортировки – сортировка вставками
         */

        // Задание 1. Одномерный массив
        public void DemoTask1()
        {
            // объект первого задания
            Task1 task = new Task1();

            #region Меню

            // пункт меню
            int n;

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Одномерный массив"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Заполнение массива случайными значениями");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Вычислить произведение элементом с чётными номерами ");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Вычислить сумму элементов, между первым и последним нулевыми элементами");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка вставками по убыванию и смена знака отрицательными элементам");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out n))
                    continue;

                try
                {

                    // обработка ввода 
                    switch (n)
                    {
                        // выход
                        case (int)Cmd.PointExit:
                            // позициониаровние курсора 
                            Console.SetCursorPosition(2, y + 5);
                            return;

                        // 1. Заполнение массива случайными значениями
                        case (int)Cmd.PointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод массива
                        case (int)Cmd.PointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Вычислить произведение элементом с чётными номерами 
                        case (int)Cmd.PointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Вычислить сумму элементов, между первым и последним нулевыми элементами
                        case (int)Cmd.PointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Сортировка вставками по убыванию и смена знака отрицательными элементам
                        case (int)Cmd.PointFive:
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
                    if (n != 0)
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

            #region 1. Заполнение массива случайными значениями

            // 1. Заполнение массива случайными значениями
            void Point1()
            {
                ShowNavBarMessage("1. Заполнение массива случайными значениями");

                // вывод массива до заполнения 
                task.ShowData(info:"До заполнения");

                Console.WriteLine();

                // заполнение массива 
                task.Data.FillRandomArray();

                // вывод массива после заполнения
                task.ShowData(info: "После заполнения");
            }

            #endregion

            #region 2. Вывод массива

            // 2. Вывод массива
            void Point2()
            {
                ShowNavBarMessage("2. Вывод массива");

                // вывод массива 
                task.ShowData();
            }

            #endregion

            #region 3. Вычислить произведение элементом с чётными номерами 

            // 3. Вычислить произведение элементом с чётными номерами 
            void Point3()
            {
                ShowNavBarMessage("3. Вычислить произведение элементом с чётными номерами ");

                // вывод массива с подсветкой элементов с чётными номерами
                task.ShowEvenNum(task.ProdEven());
            }

            #endregion

            #region 4. Вычислить сумму элементов, между первым и последним нулевыми элементами

            // 4. Вычислить сумму элементов, между первым и последним нулевыми элементами
            void Point4()
            {
                ShowNavBarMessage("4. Вычислить сумму элементов, между первым и последним нулевыми элементами");

                // установка массива с вхождением нулевых элементов 
                task.Data = new IntArray(new int[10] { 1, 5, 0, 7, 9, 3, -1, 0, 8, 2 });

                // вывод массива с подсветкой суммируемых элементов
                task.ShowSumElem(task.SumFirstLastNull(out int first, out int last), first, last);
            }

            #endregion

            #region 5. Сортировка вставками по убыванию и смена знака отрицательными элементам

            // 5. Сортировка вставками по убыванию и смена знака отрицательными элементам
            void Point5()
            {
                ShowNavBarMessage("5. Сортировка вставками по убыванию и смена знака отрицательными элементам");

                // массив индексов отрицательных элементов
                int[] index = NegativeElem(task.Data);

                // вывод до смены знаков и сортировки 
                task.ShowColorIndex(index, info: "До сортировки");

                Console.WriteLine();

                // смена знаков отрицательных элементов и сортировка
                task.ChangeSignSort();

                // вывод после смены знаков и сортировки
                task.ShowColorIndex(index, info: "После сортировки");
            }

            // массив индексов отрицательных элементов 
            int[] NegativeElem(IntArray array)
            {
                // массив для индексов
                int[] index = new int[array.Length];

                // размер заполнения массива
                int size = 0;

                for (int i = 0; i < array.Length; i++)
                    if (array[i] < 0) index[size++] = i;

                // уменьшение размера массива 
                Array.Resize(ref index, size);

                return index;
            }

            #endregion
        }

        #endregion

    }
}