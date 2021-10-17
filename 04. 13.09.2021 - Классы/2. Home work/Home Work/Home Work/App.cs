using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*
 *  Задача 1. Это задание Вы выполняли в курсе «ООП C++», будет полезно выполнить его на C#. Создайте класс, 
 *  описывающий усеченный конус Conoid (радиус верхнего основания, радиус нижнего основания, высота – тип 
 *  полей double). Реализуйте полные свойства, вычисляемые свойства для площади и объема усеченного конуса, 
 *  метод формирующий строковое представление конуса (ToString(), выводить только радиус и высоту), метод 
 *  формирующий строку таблицы со сведениями о конусе (радиус, высота, площадь поверхности, объем). 
 *  Разработайте компараторы для сортировки по возрастанию объемов, для сортировки по убыванию высот.
 *  
 *   Создайте класс ArrayConoid, хранящий массив из усеченных конусов – объектов класса Conoid и название 
 *   коллекции конусов. 
 *   Реализуйте методы класса ArrayConoid:
 *      •	заполнение массива данными конусов (не менее 12 элементов, используйте генератор случайных 
 *          чисел, вводить с клавиатуры ничего не надо)
 *      •	вычисления суммарного объема конусов 
 *      •	вычисления суммарной площади поверхности конусов
 *      •	вывод названия коллекции и массива конусов в консоль, в табличном виде
 *      •	вывод названия коллекции и массива в консоль в табличном виде: радиусы и высота усеченного конуса,
 *          площадь и объем с выделением цветом конуса/конусов с максимальной площадью, также выводить итоговую 
 *          информацию – суммарный объем конусов, суммарную площадь поверхности конусов
 *      •	сортировка массива конусов по возрастанию объемов
 *      •	сортировка массива конусов по убыванию высот
 *   Продемонстрируйте работу методов ArrayConoid, напоминаю  – в массиве должно быть не менее 12 конусов.  
 *   
 *   Задача 2. Разработайте класс Персона со следующими полными свойствами: 
 *      •	фамилия и инициалы имени и отчества (например, Семенов Р.О.) 
 *      •	возраст в полных годах (целое число)
 *      •	рост в сантиметрах (целое число)
 *      •	вес в кг (вещественное число)
 *      •	название города проживания (строка)
 *   Заполнить массив данными для не менее чем 12 персон. Рекомендую для наработки навыков кодирования не 
 *   генерировать объекты массива, а создавать с использованием свойств. Для массива персон выполнить следующие
 *   обработки:
 *      •	Вывести массив персон в консоль.
 *      •	Вывести в консоль персону/персон с максимальным ростом.
 *      •	Вывести в консоль персону/персон с минимальным возрастом. 
 *      •	Разработайте методы-компараторы для упорядочивания массива. Упорядочить массив и вывести его в 
 *          консоль. Упорядочивать по:
 *      o	по городу проживания
 *      o	по убыванию веса
 *      o	по возрастанию роста
*/

namespace Home_Work
{
    class App
    {
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
                Console.SetCursorPosition(x, y++); Console.WriteLine("1 Задание. Усеченный конус");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2 Задание. Персона");
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

        #region 1 Задание. Усеченный конус

        // *      •	заполнение массива данными конусов (не менее 12 элементов, используйте генератор случайных 
        // *          чисел, вводить с клавиатуры ничего не надо)
        // *      •	вычисления суммарного объема конусов 
        // *      •	вычисления суммарной площади поверхности конусов
        // *      •	вывод названия коллекции и массива конусов в консоль, в табличном виде
        // *      •	вывод названия коллекции и массива в консоль в табличном виде: радиусы и высота усеченного конуса,
        // *          площадь и объем с выделением цветом конуса/конусов с максимальной площадью, также выводить итоговую 
        // *          информацию – суммарный объем конусов, суммарную площадь поверхности конусов
        // *      •	сортировка массива конусов по возрастанию объемов
        // *      •	сортировка массива конусов по убыванию высот

        // 1 Задание. Усеченный конус
        public void Task1()
        {
            // объект ArrayConoid
            ArrayConoid conoids = new ArrayConoid { Name = "Усеченные конусы"};

            // начальное заполнение массива 
            FillConoid(12);

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    1 Задание. Усеченный конус"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine($"1. Заполнение массива");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"2. Вычисление суммарного объема конусов ");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"3. Вычисление суммарной площади поверхности конусов ");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"4. Вывод названия коллекции и массива конусов в консоль, в табличном виде ");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"5. Вывод всех данных массива с выделением элементов с максимальной площадью");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"6. Сортировка массива конусов по возрастанию объемов ");
                Console.SetCursorPosition(x, y++); Console.WriteLine($"7. Сортировка массива конусов по убыванию высот ");
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
                        Console.SetCursorPosition(2, ++y);
                        return;

                    // 1. Заполнение массива
                    case 1:
                        // запуск задания 
                        DemoFillConoid();
                        break;

                    // 2. Вычисление суммарного объема конусов 
                    case 2:
                        // запуск задания 
                        DemoSumVolume();
                        break;

                    // 3. Вычисление суммарной площади поверхности конусов 
                    case 3:
                        // запуск задания 
                        DemoSumArea();
                        break;

                    // 4. Вывод названия коллекции и массива конусов в консоль, в табличном виде 
                    case 4:
                        // запуск задания 
                        DemoShowArrayConoid();
                        break;

                    // 5. Вывод всех данных массива с выделением элементов с максимальной площадью
                    case 5:
                        // запуск задания 
                        DemoShowArrayConoidAll();
                        break;

                    // 6. Сортировка массива конусов по возрастанию объемов 
                    case 6:
                        // запуск задания 
                        DemoSortConoidByVolume();
                        break;

                    // 7. Сортировка массива конусов по убыванию высот
                    case 7:
                        // запуск задания 
                        DemoSortConoidByHeight();
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

            #region 1. Заполнение массива

            // 1. Заполнение массива
            void DemoFillConoid()
            {
                App.ShowNavBarMessage("1. Заполнение массива");

                // количество элементов Conoid
                const int n = 12;

                // заполнение объекта ArrayConoid
                FillConoid(n);

                // вывод конусов 
                conoids.ShowTable();
            }

            // заполнение массива объектами Conoid
            void FillConoid(int n)
            {
                // массив объектов Conoid
                Conoid[] array = new Conoid[n];

                // генерация данных и заполнение ими объектов 
                for (int i = 0; i < n; i++)
                {
                    array[i] = new Conoid();
                    array[i].R1 = rand.Next(2, 3) + rand.NextDouble();
                    array[i].R2 = rand.Next(4, 5) + rand.NextDouble();
                    array[i].H = rand.Next(7, 10) + rand.NextDouble();
                }

                // инициализация объекта ArrayConoid массивом
                conoids.Data = array;
            }

            #endregion

            #region 2. Вычисление суммарного объема конусов

            // 2. Вычисление суммарного объема конусов 
            void DemoSumVolume()
            {
                App.ShowNavBarMessage("2. Вычисление суммарного объема конусов");

                // вывод конусов 
                conoids.ShowTable("Суммарный объем");

                // вывод 
                ShowSumVolume(conoids.SumVolume());
            }

            // вывод суммарного объема
            void ShowSumVolume(double value)
            {
                App.WriteColor("                                                    ╔═══════════════════════════════════════════╗\n", ConsoleColor.Cyan);
                App.WriteColor("                                                    ║                                           ║", ConsoleColor.Cyan);
                App.WriteColorXY(" Суммарный объем: ", 53, textColor: ConsoleColor.DarkYellow);
                App.WriteColor($"{value,22:n4}", ConsoleColor.Green);
                App.WriteColor("\n                                                    ╚═══════════════════════════════════════════╝\n", ConsoleColor.Cyan);
            }

            #endregion

            #region 3. Вычисление суммарной площади поверхности конусов

            // 3. Вычисление суммарной площади поверхности конусов 
            void DemoSumArea()
            {
                App.ShowNavBarMessage("3. Вычисление суммарной площади поверхности конусов");

                // вывод конусов 
                conoids.ShowTable("Суммарная площадь");

                // вывод 
                ShowSumArea(conoids.SumArea());
            }

            // вывод суммарного объема
            void ShowSumArea(double value)
            {
                App.WriteColor("                                                    ╔═══════════════════════════════════════════╗\n", ConsoleColor.Cyan);
                App.WriteColor("                                                    ║                                           ║", ConsoleColor.Cyan);
                App.WriteColorXY(" Суммарная площадь: ", 53, textColor: ConsoleColor.DarkYellow);
                App.WriteColor($"{value,21:n4}", ConsoleColor.Green);
                App.WriteColor("\n                                                    ╚═══════════════════════════════════════════╝\n", ConsoleColor.Cyan);
            }

            #endregion

            #region 4. Вывод названия коллекции и массива конусов в консоль, в табличном виде

            // 4. Вывод названия коллекции и массива конусов в консоль, в табличном виде 
            void DemoShowArrayConoid()
            {
                App.ShowNavBarMessage("4. Вывод названия коллекции и массива конусов в консоль, в табличном виде");

                // вывод конусов 
                conoids.ShowTable();
            }

            #endregion

            #region 5. Вывод всех данных массива с выделением элементов с максимальной площадью

            // 5. Вывод всех данных массива с выделением элементов с максимальной площадью
            void DemoShowArrayConoidAll()
            {
                App.ShowNavBarMessage("5. Вывод всех данных массива с выделением элементов с максимальной площадью");

                // вывод конусов 
                conoids.ShowTableAllMaxArea();
            }

            #endregion

            #region 6. Сортировка массива конусов по возрастанию объемов

            // 6. Сортировка массива конусов по возрастанию объемов 
            void DemoSortConoidByVolume()
            {
                App.ShowNavBarMessage("6. Сортировка массива конусов по возрастанию объемов");

                // вывод конусов до сортировки 
                conoids.ShowTable("До сортировки");

                Console.Write("\n\n");

                // сортировка 
                conoids.SortByVolume();

                // вывод конусов после сортировки
                conoids.ShowTable("После сортировки");
            }

            #endregion

            #region 7. Сортировка массива конусов по убыванию высот

            // 7. Сортировка массива конусов по убыванию высот
            void DemoSortConoidByHeight()
            {
                App.ShowNavBarMessage("7. Сортировка массива конусов по убыванию высот");

                // вывод конусов до сортировки 
                conoids.ShowTable("До сортировки");

                Console.Write("\n\n");

                // сортировка 
                conoids.SortByHeight();

                // вывод конусов после сортировки
                conoids.ShowTable("После сортировки");
            }
            #endregion

        } // Task1

        #endregion

        #region 2 Задание. Персона

        /*
         *   Задача 2. Разработайте класс Персона со следующими полными свойствами: 
         *      •	фамилия и инициалы имени и отчества (например, Семенов Р.О.) 
         *      •	возраст в полных годах (целое число)
         *      •	рост в сантиметрах (целое число)
         *      •	вес в кг (вещественное число)
         *      •	название города проживания (строка)
         *   Заполнить массив данными для не менее чем 12 персон. Рекомендую для наработки навыков кодирования не 
         *   генерировать объекты массива, а создавать с использованием свойств. Для массива персон выполнить следующие
         *   обработки:
         *      •	Вывести массив персон в консоль.
         *      •	Вывести в консоль персону/персон с максимальным ростом.
         *      •	Вывести в консоль персону/персон с минимальным возрастом. 
         *      •	Разработайте методы-компараторы для упорядочивания массива. Упорядочить массив и вывести его в 
         *          консоль. Упорядочивать по:
         *      o	по городу проживания
         *      o	по убыванию веса
         *      o	по возрастанию роста
        */
        

        // 2 Задание. Персона
        public void Task2()
        {
            // массив объектов Person
            Person[] persons = new Person[] {

                new Person{Name = "Гусев Э. Е.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Львов" },

                new Person{Name = "Грибова С. Д.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Кривой Рог" },

                new Person{Name = "Комаров Д. Е.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Одесса" },

                new Person{Name = "Поляков В. И.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Кривой Рог" },

                new Person{Name = "Андреева Д. К.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Одесса" },

                new Person{Name = "Савин М. А.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Львов" },

                new Person{Name = "Успенский А. И.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Кривой Рог" },

                new Person{Name = "Ежов Д. А.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Львов" },

                new Person{Name = "Тарасов А. М.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Одесса" },

                new Person{Name = "Павлов М. С.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Львов" },

                new Person{Name = "Морозов Д. А.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Кривой Рог" },

                new Person{Name = "Парфенов А. Д.", Age = rand.Next(20, 25), Height = rand.Next(16, 20) * 10,
                    Weight = rand.Next(50, 80) + rand.NextDouble(), City = "Львов" },
            };

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    2 Задание. Персона"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Вывод персон");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Персоны с максимальным ростом");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Персоны с минимальным возрастом");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка по городу проживания");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сортировка по убыванию веса");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Сортировка по возрастанию роста");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 3;

                // ввод номера задания
                Console.SetCursorPosition(5, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // 1. Вывод персон
                    case 1:
                        // запуск задания 
                        DemoShowPerson();
                        break;

                    // 2. Персоны с максимальным ростом
                    case 2:
                        // запуск задания 
                        DemoMaxHeight();
                        break;

                    // 3. Персоны с минимальным возрастом
                    case 3:
                        // запуск задания 
                        DemoMinAge();
                        break;

                    // 4. Сортировка по городу проживания
                    case 4:
                        // запуск задания 
                        DemoSortByCity();
                        break;

                    // 5. Сортировка по убыванию веса
                    case 5:
                        // запуск задания 
                        DemoSortByWeight();
                        break;

                    // 6. Сортировка по возрастанию роста
                    case 6:
                        // запуск задания 
                        DemoSortByHeight();
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

            #region 1. Вывод персон

            // 1. Вывод персон
            void DemoShowPerson()
            {
                ShowNavBarMessage("1. Вывод персон");

                // вывод персон
                Person.ShowTable(persons);
            }

            #endregion

            #region 2. Персоны с максимальным ростом

            // 2. Персоны с максимальным ростом
            void DemoMaxHeight()
            {
                ShowNavBarMessage("2. Персоны с максимальным ростом");

                // поиск максимального роста 
                int max = MaxHeight();

                // предикатор для поиска 
                bool pred(Person p) => p.Height == max;

                // результирующий массив
                Person[] result = Array.FindAll(persons, pred);

                // вывод персон
                Person.ShowTable(persons);

                Console.Write("\n\n");

                // вывод массива 
                Person.ShowTable(result, info: "Максимальный рост");
            }

            // поиск максимального значения роста 
            int MaxHeight()
            {
                // максимальный рост
                int max = 0;

                // поиск 
                foreach (var item in persons)
                {
                    if (max < item.Height)
                        max = item.Height;
                }

                return max;
            }

            #endregion

            #region 3. Персоны с минимальным возрастом

            // 3. Персоны с минимальным возрастом
            void DemoMinAge()
            {
                ShowNavBarMessage("3. Персоны с минимальным возрастом");

                // поиск максимального роста 
                int min = MinAge();

                // предикатор для поиска 
                bool pred(Person p) => p.Age == min;

                // результирующий массив
                Person[] result = Array.FindAll(persons, pred);

                // вывод персон
                Person.ShowTable(persons);

                Console.Write("\n\n");

                // вывод массива 
                Person.ShowTable(result, info: "Минимальный возраст");
            }

            // поиск максимального значения роста 
            int MinAge()
            {
                // минимальный возраст
                int min = persons[0].Age;

                int length = persons.Length; 

                // поиск 
                for (int i = 0; i < length; i++)
                {
                    if (min > persons[i].Age)
                        min = persons[i].Age;
                }

                return min;
            }

            #endregion

            #region 4. Сортировка по городу проживания

            // 4. Сортировка по городу проживания
            void DemoSortByCity()
            {
                ShowNavBarMessage("4. Сортировка по городу проживания");

                // вывод массива до сортировки
                Person.ShowTable(persons, info: "До сортировки");

                Console.WriteLine();

                // компаратор для сортировки
                int Compare(Person p1, Person p2) => p1.City.CompareTo(p2.City);

                // сортировка 
                Array.Sort(persons, Compare);

                // вывод массива после сортировки
                Person.ShowTable(persons, info: "После сортировки");
            }

            #endregion

            #region 5. Сортировка по убыванию веса

            // 5. Сортировка по убыванию веса
            void DemoSortByWeight()
            {
                ShowNavBarMessage("5. Сортировка по убыванию веса");

                // вывод массива до сортировки
                Person.ShowTable(persons, info: "До сортировки");

                Console.WriteLine();

                // компаратор для сортировки
                int Compare(Person p1, Person p2) => -p1.Weight.CompareTo(p2.Weight);

                // сортировка 
                Array.Sort(persons, Compare);

                // вывод массива после сортировки
               Person.ShowTable(persons, info: "После сортировки");
            }

            #endregion

            #region 6. Сортировка по возрастанию роста

            // 6. Сортировка по возрастанию роста
            void DemoSortByHeight()
            {
                ShowNavBarMessage("6. Сортировка по возрастанию роста");

                // вывод массива до сортировки
                Person.ShowTable(persons, info: "До сортировки");

                Console.WriteLine();

                // компаратор для сортировки
                int Compare(Person p1, Person p2) => p1.Height.CompareTo(p2.Height);

                // сортировка 
                Array.Sort(persons, Compare);

                // вывод массива после сортировки
                Person.ShowTable(persons, info: "После сортировки");
            }

            #endregion

        } // Task2

        #endregion

        #region Утилиты

        // объект Random для заполнения массивов
        public static Random rand = new Random();

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
