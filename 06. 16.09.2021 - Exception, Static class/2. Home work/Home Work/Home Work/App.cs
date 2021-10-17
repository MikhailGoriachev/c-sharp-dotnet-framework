using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Home_Work.Task_1_Triangle; // для подключения классов первого задания
using Home_Work.Task_2_Room;     // для подключения классов второго задания

/*
 * Задача 1. Описать класс, представляющий треугольник. Предусмотреть методы для создания 
 *  объектов (конструкторы), вычисления площади, периметра и длин медиан, проверки возможности
 *  создания треугольника.
 *  
 *  Описать свойство типа кортеж для задания трех сторон. При невозможности построения 
 *  треугольника выбрасывается исключение. Описать свойства для получения сторон треугольника.
 *  Разработайте собственный класс исключения, унаследованный от класса Exception. 
 *  Передавать в исключение: сообщении об ошибке, значения для сторон. 
 *  В массиве треугольников (не менее 10 элементов) выполнить сортировку: 
 *      •	по убыванию периметров
 *      •	по возрастанию площадей
 *      
 * Задача 2. Описать класс, содержащий сведения о площади комнаты, высоте потолков и количестве
 *  окон. Описать методы вычисления объема комнаты и свойства для задания и получения состояния 
 *  объекта. В случае недопустимых значений свойств выбрасывается исключение – класс, унаследованный
 *  от Exception. Исключению передавать сообщение об ошибке и значение, приведшее к выбросу исключения.
 * 
 *  В массиве комнат (не менее 10и элементов) выполнить сортировку:
 *          •	по убыванию площади
 *          •	по возрастанию количества окон
*/

namespace Application
{

    // константы для меню
    enum Cmd
    {
        pointExit,
        pointOne,
        pointTwo,
        pointThree,
        pointFour,
        pointFive,
        pointSix
    }

    public class App
    {
        // объект ArrayTriangle для Задания 1
        private ArrayTriangle _arrTrian = new ArrayTriangle();

        #region Меню заданий 

        // меню заданий
        public void Menu()
        {
            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Треугольник");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Комната");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case (int)Cmd.pointExit:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // Задание 1. Треугольник
                    case (int)Cmd.pointOne:
                        // запуск задания 
                        Task1();
                        break;

                    // Задание 2. Комната
                    case (int)Cmd.pointTwo:
                        // запуск задания 
                        Task2();
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
            }
        } // Menu

    #endregion

        #region Задание 1. Треугольник

        /*
         * Задача 1. Описать класс, представляющий треугольник. Предусмотреть методы для создания 
         *  объектов (конструкторы), вычисления площади, периметра и длин медиан, проверки возможности
         *  создания треугольника.
         *  
         *  Описать свойство типа кортеж для задания трех сторон. При невозможности построения 
         *  треугольника выбрасывается исключение. Описать свойства для получения сторон треугольника.
         *  Разработайте собственный класс исключения, унаследованный от класса Exception. 
         *  Передавать в исключение: сообщении об ошибке, значения для сторон. 
         *  В массиве треугольников (не менее 10 элементов) выполнить сортировку: 
         *      •	по убыванию периметров
         *      •	по возрастанию площадей
         */

        // Задание 1. Треугольник
        public void Task1()
        {
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Треугольник"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Генерация треугольников");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод треугольников");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сортировка треугольников по убыванию периметров");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка треугольников по возрастанию площадей");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Демонстрация работы исключения");
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

                        // 1. Генерация треугольников
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            DemoGenTriangle();
                            break;

                        // 2. Вывод треугольников
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            DemoShowTriangle();
                            break;

                        // 3. Сортировка треугольников по убыванию периметров
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByPerimeterTriangle();
                            break;

                        // 4. Сортировка треугольников по возрастанию площадей
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            DemoSortByAreaTriangle();
                            break;

                        // 5. Демонстрация работы исключения
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            DemoExceptionTriangle();
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

                // специальное исключение для объектов Triangle
                catch (TriangleException ex)
                {
                    // вывод сообщения об ошибке
                    ex.ShowException();
                }

                // стандартное исключение
                catch (Exception ex)
                {
                    Console.Clear();

                    // вывод сообщения об ошибке 
                    WriteColor(ex.Message,ConsoleColor.Red);
                    Console.WriteLine();
                    WriteColor(ex.StackTrace,ConsoleColor.Red);
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

            #region 1. Генерация треугольников

            // 1. Генерация треугольников
            void DemoGenTriangle()
            {
                ShowNavBarMessage("1. Генерация треугольников");

                // вывод массива треугольников до заполнения 
                _arrTrian.ShowTable(info: "До заполнения");

                // диапазон количества треугольников
                const int loN = 5, hiN = 10;

                // массив треугольников 
                Triangle[] triangles = new Triangle[rand.Next(loN, hiN)];

                // заполнение массива треугольниками
                FillTriangles(triangles);

                // добавление массива с треугольниками в ArrayTriangle
                _arrTrian.Triangles = triangles;

                // вывод массива треугольников после заполнения 
                _arrTrian.ShowTable(info: "После заполнения");
            }

            // заполнение массива треугольниками
            void FillTriangles(Triangle[] array)
            {
                // размер массива 
                int length = array.Length;

                // заполнение массива треугольниками
                for (int i = 0; i < length; i++)
                    // генерация треугольника
                    array[i] = new Triangle(GenTriangle());
            }

            // метод генерации треугольника 
            (double a, double b, double c) GenTriangle()
            {                
                // диапазоны значений сторон треугольника
                const int loSide = 1, hiSide = 6;

                // данные треугольника 
                (double a, double b, double c) triangle = (0d, 0d, 0d);

                do
                {
                    // генерация данных
                    triangle.a = GetDouble(loSide, hiSide);
                    triangle.b = GetDouble(loSide, hiSide);
                    triangle.c = GetDouble(loSide, hiSide);
                } while (!Triangle.IsTriangle(triangle));

                return triangle;
            }

            #endregion

            #region 2. Вывод треугольников

            // 2. Вывод треугольников
            void DemoShowTriangle()
            {
                ShowNavBarMessage("2. Вывод треугольников");

                // вывод массива треугольников до заполнения 
                _arrTrian.ShowTable();
            }

            #endregion

            #region 3. Сортировка треугольников по убыванию периметров

            // 3. Сортировка треугольников по убыванию периметров
            void DemoSortByPerimeterTriangle()
            {
                ShowNavBarMessage("3. Сортировка треугольников по убыванию периметров");

                // вывод массива треугольников до сортировки
                _arrTrian.ShowTable(info: "До сортировки");

                // сортировка 
                _arrTrian.SortByPerimeter();

                // вывод массива треугольников после сортировки
                _arrTrian.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 4. Сортировка треугольников по возрастанию площадей

            // 4. Сортировка треугольников по возрастанию площадей
            void DemoSortByAreaTriangle()
            {
                ShowNavBarMessage("4. Сортировка треугольников по возрастанию площадей");

                // вывод массива треугольников до сортировки
                _arrTrian.ShowTable(info: "До сортировки");

                // сортировка 
                _arrTrian.SortByArea();

                // вывод массива треугольников после сортировки
                _arrTrian.ShowTable(info: "После сортировки");
            }

            #endregion

            #region 5. Демонстрация работы исключения

            // 5. Демонстрация работы исключения
            void DemoExceptionTriangle()
            {
                ShowNavBarMessage("5. Демонстрация работы исключения");

                // объект Triangle
                Triangle triangle = new Triangle(50, 4, 80);
            }

            #endregion
        }

        #endregion

        // объект ArrayRoom для Задания 2
        private ArrayRoom _arrRoom = new ArrayRoom();

        #region Задание 2. Комната

        /*
        * Задача 2. Описать класс, содержащий сведения о площади комнаты, высоте потолков и количестве
        * окон.Описать методы вычисления объема комнаты и свойства для задания и получения состояния
        * объекта. В случае недопустимых значений свойств выбрасывается исключение – класс, унаследованный
        * от Exception.Исключению передавать сообщение об ошибке и значение, приведшее к выбросу исключения.
        * 
        *  В массиве комнат (не менее 10и элементов) выполнить сортировку:
        *          •	по убыванию площади
        *          •	по возрастанию количества окон
        */

        // Задание 2. Комната
        public void Task2()
        {
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Комната"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Генерация данных");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод коллекции комнат");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Демонстрация работы исключений");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка по убыванию площади");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по возрастанию количества окон");
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

                        // 1. Генерация данных
                        case (int)Cmd.pointOne:
                            // запуск задания 
                            DemoGenRoom();
                            break;

                        // 2. Вывод коллекции комнат
                        case (int)Cmd.pointTwo:
                            // запуск задания 
                            DemoShowRoom();
                            break;

                        // 3. Демонстрация работы исключений
                        case (int)Cmd.pointThree:
                            // запуск задания 
                            DemoException();
                            break;

                        // 4. Сортировк по убыванию площади
                        case (int)Cmd.pointFour:
                            // запуск задания 
                            DemoSortByArea();
                            break;

                        // 5. Сортировка по возрастанию количества окон
                        case (int)Cmd.pointFive:
                            // запуск задания 
                            DemoSortByWindow();
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

                // специальное исключение для объектов Room
                catch (RoomException ex)
                {
                    // вывод сообщения об ошибке
                    ex.ShowException();
                }

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

            #region 1. Генерация данных

            // 1. Генерация данных
            void DemoGenRoom()
            {
                Console.Clear();

                ShowNavBarMessage("1. Генерация данных");

                // вывод массива комнат до заполнения 
                _arrRoom.ShowTable("До заполнения");

                // диапазон количества комнат
                const int lo = 5, hi = 10;

                // создание массива 
                _arrRoom.Rooms = new Room[rand.Next(lo, hi + 1)];

                // заполенение массива данными
                FillRooms(_arrRoom.Rooms);

                // вывод массива комнат после заполнения 
                _arrRoom.ShowTable("После заполнения");
            }

            // генерация данных комнаты
            (double area, double height, int window) GenRoom() => (GetDouble(10, 20), 3 + rand.NextDouble(), rand.Next(1, 5));

            // заполнение массива комнат данными 
            void FillRooms(Room[] rooms)
            {
                // размер массива 
                int length = rooms.Length;

                // заполнение массива данными 
                for (int i = 0; i < length; i++)
                    rooms[i] = new Room { State = GenRoom() };
            }
            #endregion

            #region 2. Вывод коллекции комнат

            // 2. Вывод коллекции комнат
            void DemoShowRoom()
            {
                ShowNavBarMessage("2. Вывод коллекции комнат");

                // вывод массива комнат до заполнения 
                _arrRoom.ShowTable();
            }

            #endregion

            #region 3. Демонстрация работы исключений

            // 3. Демонстрация работы исключений
            void DemoException()
            {
                ShowNavBarMessage("3. Демонстрация работы исключений");

                // создание команты с некорректными данными
                new Room { State = (-1d, 15, -10) };
            }

            #endregion

            #region 4. Сортировк по убыванию площади

            // 4. Сортировка по убыванию площади
            void DemoSortByArea()
            {
                ShowNavBarMessage("4. Сортировк по убыванию площади");

                // вывод массива комнат до сортировки
                _arrRoom.ShowTable("До сортировки");

                // сортировка 
                _arrRoom.SortByArea();

                // вывод массива комнат после сортировки 
                _arrRoom.ShowTable("После сортировки");
            }

            #endregion

            #region 5. Сортировка по возрастанию количества окон

            // 5. Сортировка по возрастанию количества окон
            void DemoSortByWindow()
            {
                ShowNavBarMessage("5. Сортировка по возрастанию количества окон");

                // вывод массива комнат до сортировки
                _arrRoom.ShowTable("До сортировки");

                // сортировка 
                _arrRoom.SortByWindow();

                // вывод массива комнат после сортировки 
                _arrRoom.ShowTable("После сортировки");
            }

            #endregion
        }

        #endregion

        #region Утилиты

        // объект Random для заполнения массивов
        public static Random rand = new Random();

        // получение случайного вещественного числа в диапазоне (min, max]
        public static double GetDouble(int min, int max) => rand.Next(min, max) + rand.NextDouble();

        // вывод сообщения в цвете 
        public static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            // текущий цвет 
            ConsoleColor tempText = Console.ForegroundColor;
            ConsoleColor tempBack = Console.BackgroundColor;

            // установк цвета
            SetColor(textColor, backColor);

            // вывод сообщения 
            Console.Write(msg);

            // возвращение цвета 
            SetColor(tempText, tempBack);
        }

        // вывод сообщения в цвете и позиционированием 
        public static void WriteColorXY(string msg = "", int posX = -1, int posY = -1, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            // позиционирование курсора
            PosXY(posX == -1 ? Console.CursorLeft : posX, posY == -1 ? Console.CursorTop : posY);

            // вывод сообщения в цвете
            WriteColor(msg, textColor, backColor);
        }

        // вывод сообщения о неправильно введённых данных, с указанием позиции
        public static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
        {
            // вывод сообщения 
            WriteColorXY(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

            // задержка по времени
            Thread.Sleep(500);
        }

        // позиционирование курсора
        public static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

        // установка цвета текста 
        public static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

        // установка цвета текста и фона 
        public static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
        } // SetColor

        // вывод сообщения в первой строке консоли
        public static void ShowNavBarMessage(string msg)
        {
            // установка цвета
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // позиционирование курсора
            Console.SetCursorPosition(0, 0);

            // заполенение первой строки цветом 
            Console.WriteLine($"{' ',120}");

            // позиционирование курсора
            Console.SetCursorPosition(2, 0);

            // вывод сообщения 
            Console.WriteLine(msg);

            // позиционирование курсора
            Console.SetCursorPosition(0, 3);

            Console.ResetColor();
        } // ShowNavBarMessage

        #endregion
    }
}
