using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Home_work.Task_1; // для подключения классов первого задания
using Home_work.Task_2; // для подключения классов второго задания

/*
 *  Задача 1. Разработайте методы в статическом классе TuplesDemo, закодируйте решение задач 
 *  
 *  	Proc3. Описать метод Mean(x, y), вычисляющую среднее арифметическое a_mean=(x+y)/2 и 
 *  	среднее геометрическое g_mean=√(x∙y), двух положительных вещественных чисел x и y. 
 *  	Возвращать a_mean, g_mean из метода в кортеже. С помощью этого метода найти среднее 
 *  	арифметическое и среднее геометрическое для трех пар случайных чисел из диапазона 
 *  	значений [0, 10].
 *  	
 *  	Proc5. Описать метод RectPS(x1, y1, x2, y2), вычисляющую периметр и площадь 
 *  	прямоугольника со сторонами, параллельными осям координат, по координатам (x1, y1), 
 *  	(x2, y2) его противоположных вершин (стороны вычисляются как a = Math.Abs(x2 - x1), 
 *  	b = Math.Abs(y2 – y1)). Метод возвращает кортеж с периметром и площадью. С помощью 
 *  	этого метода найти периметры и площади трех прямоугольников с данными противоположными
 *  	вершинами.
 *  	
 *  Задача 2. Разработайте класс Самолет со следующими полными свойствами:
 *  	производитель и тип самолета (это одно свойство, например: Ил-76, Boeing 747, …)
 *  	количество пассажирских мест (целое число)
 *  	расход горючего за час полета (вещественное число)
 *  	количество двигателей (целое число)
 *  	название авиакомпании – владельца
 *  	
 *  В массиве самолетов (не менее 10 элементов) определить самолет/самолеты с максимальным 
 *  количеством пассажирских мест, упорядочить массив:
 *  	по свойству производитель и тип (!!! это одно свойство !!!)
 *  	по убыванию количества двигателей
 *  	по возрастанию расхода горючего за час полета
 *  
*/

namespace Home_work
{
    class App
    {
        // !!! ДАННЫЕ ДЛЯ ПРИМЕРА, ОНИ НЕ СООТВЕТСТВУЮТ ДАННЫМ РЕАЛЬНЫХ САМОЛЁТОВ И ЛОГИЧЕСКИ СКГЕНЕРИРОВАНЫ НЕПРАВИЛЬНО !!!
        private Plane[] planes_ = new Plane[]{

            new Plane{Model = "Airbus A220-100", Seat = 120, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Aegean Airlines"},

            new Plane{Model = "Boeing 737", Seat = 190, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Air Astana"},

            new Plane{Model = "Airbus A319neo", Seat = 200, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Aegean Airlines"},

            new Plane{Model = "Boeing 737", Seat = 190, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Austrian Airlines"},

            new Plane{Model = "Airbus A319neo", Seat = 200, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Air France"},

            new Plane{Model = "Boeing 737", Seat = 190, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Aegean Airlines"},

            new Plane{Model = "Airbus A319neo", Seat = 200, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Aegean Airlines"},

            new Plane{Model = "Airbus A320", Seat = 150, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Air Astana"},

            new Plane{Model = "Airbus A320", Seat = 150, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Air France"},

            new Plane{Model = "Boeing 737", Seat = 190, Consumption = GetDouble(1000, 2000), 
                Engine = rand.Next(2,5), Name = "Air Astana"},
        };

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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Вычисление по формулам");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Самолёты");
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
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // 1 Задание. Усеченный конус
                    case 1:
                        // запуск задания 
                        Task1();
                        break;

                    // 2 Задание. Персона
                    case 2:
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

        #region Задание 1. Вычисление по формулам

        // Задание 1. Вычисление по формулам
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Вычисление по формулам"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Proc3 — Арифметическое и геометрическое среднее вещественных чисел");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Proc5 — Периметр и площадь прямоугольника");
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
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // 1. Proc3 — Арифметическое и геометрическое среднее вещественных чисел
                    case 1:
                        // запуск задания 
                        DemoAvgNaturalNumbers();
                        break;

                    // 2. Proc5 — Периметр и площадь прямоугольника
                    case 2:
                        // запуск задания 
                        DemoPerimeterAreaRectangle();
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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.CursorVisible = true;
            }

            #endregion

        }

        #region 1. Proc3 — Арифметическое и геометрическое среднее вещественных чисел

        // 1. Proc3 — Арифметическое и геометрическое среднее вещественных чисел
        void DemoAvgNaturalNumbers()
        {
            // отчистка консоли
            Console.Clear();

            ShowNavBarMessage("1. Proc3 — Арифметическое и геометрическое среднее вещественных чисел");

            // количество пар значений
            const int n = 3;

            // массив из трех пар вещественных чисел
            (double a, double b)[] array = new (double a, double b)[n];

            // диапазон значений 
            int lo = 0, hi = 10;

            // генерация трех пар вещественных чисел
            for (int i = 0; i < n; i++)
                array[i] = (GetDouble(lo, hi), GetDouble(lo, hi));

            // вычисление результатов
            (double a_mean, double g_mean)[] result = CalcResultProc3(array);

            ShowTableTask1Proc3(array, result);
        }

        // вычисление результатов
        (double a_mean, double g_mean)[] CalcResultProc3((double x, double y)[] array)
        {
            // размер массива
            int length = array.Length;

            // результирующий массив
            (double a_mean, double g_mean)[] result = new (double a_mean, double g_mean)[length];

            // вычисление результатов
            for (int i = 0; i < length; i++)
                result[i] = TuplesDemo.Mean(array[i].x, array[i].y);

            return result;
        }

        // вывод таблицы чисел и результатов
        void ShowTableTask1Proc3((double a, double b)[] array, (double a_mean, double g_mean)[] result)
        {
            App.WriteColor("     ╔════╦════════════╦════════════╦════════════╦════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor("     ║    ║            ║            ║            ║            ║", ConsoleColor.Cyan);
            App.WriteColorXY("N ",           7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Число X  ",  13, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Число Y  ",  26, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" A Mean",     39, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" G Mean",     52, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n     ╠════╬════════════╬════════════╬════════════╬════════════╣\n", ConsoleColor.Cyan);

            // размер массива 
            int length = array.Length;

            // вывод элементов 
            for (int i = 0; i < length; i++)
            {
                // текущий элемент массива чисел
                (double a, double b) item = array[i];

                // текущий элемент массива результатов
                (double a_mean, double g_mean) res = result[i];

                App.WriteColor("     ║    ║            ║            ║            ║            ║", ConsoleColor.Cyan);
                App.WriteColorXY($"{i + 1, 2}",          7, textColor: ConsoleColor.DarkGray);
                App.WriteColorXY($"{item.a,9:n4}",     13, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{item.b,9:n4}",     26, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{res.a_mean,9:n4}", 39, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{res.g_mean, 9:n4}", 52, textColor: ConsoleColor.Green);
                Console.WriteLine();
            }

            // вывод подвала таблицы
            App.WriteColor("     ╚════╩════════════╩════════════╩════════════╩════════════╝\n", ConsoleColor.Cyan);
        }

        #endregion

        #region 2. Proc5 — Периметр и площадь прямоугольника

        // 2. Proc5 — Периметр и площадь прямоугольника
        void DemoPerimeterAreaRectangle()
        {            
            // отчистка консоли
            Console.Clear();

            ShowNavBarMessage("2. Proc5 — Периметр и площадь прямоугольника");

            // количество пар значений
            const int n = 3;

            // массив из трех прямоугольников
            (double x1, double y1, double x2, double y2)[] array = new (double x1, double y1, double x2, double y2)[n];

            // диапазон значений 
            int lo = 0, hi = 10;

            // генерация трех прямоугольников
            for (int i = 0; i < n; i++)
                array[i] = (GetDouble(lo, hi), GetDouble(lo, hi), GetDouble(lo, hi), GetDouble(lo, hi));

            // вычисление результатов
            (double perimeter, double area)[] result = CalcResultProc5(array);

            ShowTableTask1Proc5(array, result);
        }

        // вычисление результатов
        (double perimeter, double area)[] CalcResultProc5((double x1, double y1, double x2, double y2)[] array)
        {
            // размер массива
            int length = array.Length;

            // результирующий массив
            (double perimeter, double area)[] result = new (double perimeter, double area)[length];

            // вычисление результатов
            for (int i = 0; i < length; i++)
                result[i] = TuplesDemo.RectPS(array[i].x1, array[i].y1, array[i].x2, array[i].y2);

            return result;
        }

        // вывод таблицы чисел и результатов
        void ShowTableTask1Proc5((double x1, double y1, double x2, double y2)[] array, (double perimeter, double area)[] result)
        {
            App.WriteColor("     ╔════╦════════════╦════════════╦════════════╦════════════╦════════════╦════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor("     ║    ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Cyan);
            App.WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   X1     ", 13, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Y1     ", 26, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   X2     ", 39, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Y2     ", 52, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("Периметр  ", 65, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Площадь  ", 78, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n     ╠════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", ConsoleColor.Cyan);

            // размер массива 
            int length = array.Length;

            // вывод элементов 
            for (int i = 0; i < length; i++)
            {
                // текущий элемент массива чисел
                (double x1, double y1, double x2, double y2) item = array[i];

                // текущий элемент массива результатов
                (double perimeter, double area) res = result[i];

                App.WriteColor("     ║    ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Cyan);
                App.WriteColorXY($"{i + 1,2}",              7, textColor: ConsoleColor.DarkGray);
                App.WriteColorXY($"{item.x1,9:n4}",         13, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{item.y1,9:n4}",         26, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{item.x2,9:n4}",         39, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{item.y2,9:n4}",         52, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{res.perimeter,9:n4}",   65, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{res.area,9:n4}",        78, textColor: ConsoleColor.Green);
                Console.WriteLine();
            }

            // вывод подвала таблицы
            App.WriteColor("     ╚════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", ConsoleColor.Cyan);
        }


        #endregion

        #endregion

        #region Задание 2. Самолёты

        // Задание 2. Самолёты
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Самолёты"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Сортировка по модели");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Сортировка по убыванию количества двигателей");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сортировка по возрастанию расхода горючего за час полета");
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
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // 1. Сортировка по модели
                    case 1:
                        // запуск задания 
                        DemoSortByModel();
                        break;

                    // 2. Сортировка по убыванию количества двигателей
                    case 2:
                        // запуск задания 
                        DemoSortByEngine();
                        break;

                    // 3. Сортировка по возрастанию расхода горючего за час полета
                    case 3:
                        // запуск задания 
                        DemoSortByConsumption();
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

                // ввод клавиши для продолжения 
                WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                Console.CursorVisible = false;
                while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                Console.CursorVisible = true;
            }

            #endregion

        }

        #region 1. Сортировка по модели

        // 1. Сортировка по модели
        void DemoSortByModel()
        {
            ShowNavBarMessage("1. Сортировка по модели");

            // вывод массива самолётов до сортировки
            ShowTable(planes_, "Самолёты", "До сортировки");

            // сортировка 
            Array.Sort(planes_, CompareToModel);

            // вывод массива самолётов после сортировки
            ShowTable(planes_, "Самолёты", "После сортировки");
        }

        // компаратор по модели
        int CompareToModel(Plane p1, Plane p2) => p1.Model.CompareTo(p2.Model);

        #endregion

        #region 2. Сортировка по убыванию количества двигателей

        // 2. Сортировка по убыванию количества двигателей
        void DemoSortByEngine()
        {
            ShowNavBarMessage("2. Сортировка по убыванию количества двигателей");
            
            // вывод массива самолётов до сортировки
            ShowTable(planes_, "Самолёты", "До сортировки");

            // сортировка 
            Array.Sort(planes_, CompareToEngine);

            // вывод массива самолётов после сортировки
            ShowTable(planes_, "Самолёты", "После сортировки");
        }

        // компаратор по двигателю
        int CompareToEngine(Plane p1, Plane p2) => -p1.Engine.CompareTo(p2.Engine);


        #endregion

        #region 3. Сортировка по возрастанию расхода горючего за час полета

        // 3. Сортировка по возрастанию расхода горючего за час полета
        void DemoSortByConsumption()
        {
            ShowNavBarMessage("3. Сортировка по возрастанию расхода горючего за час полета"); 
            
            // вывод массива самолётов до сортировки
            ShowTable(planes_, "Самолёты", "До сортировки");

            // сортировка 
            Array.Sort(planes_, CompareToConsumption);

            // вывод массива самолётов после сортировки
            ShowTable(planes_, "Самолёты", "После сортировки");
        }

        // компаратор по расходу горючего
        int CompareToConsumption(Plane p1, Plane p2) => p1.Consumption.CompareTo(p2.Consumption);


        #endregion

        #region Общие методы

        // вывод самолётов в виде таблицы с выделением самолёта с максимальным количеством пассажирских мест
        public void ShowTable(Plane[] planes_, string name, string info)
        {
            // вывод шапки таблицы
            Plane.ShowHead(name, info, planes_.Length);

            // максимальное значение количества пассажирских мест
            int max = MaxSeat(planes_);

            // номер элемента 
            int num = 1;

            // вывод элементов таблицы 
            foreach (var item in planes_)
                item.ShowElem(num++, item.Seat == max);

            // вывод подвала таблицы
            Plane.ShowLine();
        }

        // поиск максимального значения количества пассажирских мест
        int MaxSeat(Plane[] planes_)
        {
            // максимальное значение 
            int max = 0;

            foreach (var item in planes_)
                if (max < item.Seat) max = item.Seat;

            return max;
        }

        #endregion

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
