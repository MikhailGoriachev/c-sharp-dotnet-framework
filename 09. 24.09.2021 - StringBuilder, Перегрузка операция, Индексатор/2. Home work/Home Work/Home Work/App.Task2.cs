using System;
using System.Threading;

using Home_Work.Models.Task2;       // для использования класса Task2

namespace Home_Work
{
    public partial class App
    {

        #region Задание 2. Игрушка

        /*
         * Задача 2. Разработайте класс Toy для представления игрушки со свойствами – название
         * игрушки (string), возрастная категория (int), стоимость игрушки (int). 
         * Перегрузите операции для класса Toy:
         * •	+: сложения игрушки с целым числом – операция выполняет сложение цены и числа
         * •	–: вычитания целого числа из игрушки – операция выполняет вычитание целого 
         *      числа из цены игрушки
         * •	< и >: сравнение цен двух игрушек
         * •	true: если возрастная категория больше 5
         * •	false: если возрастная категория меньше или равна 5 
         * Продемонстрируйте работу перегруженных операций.
        */

        // Задание 2. Игрушка
        public void DemoTask2()
        {
            #region Меню

            // размер массива 
            const int sizeToys = 10;

            // формирование начальных данных
            Toy[] toys = new Toy[sizeToys];
            GenerToys();

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Игрушка"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование начальных данных");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод данных");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Сложение цены и числа");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Вычитание числа из цены игрушки");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Сравнение двух игрушек по цене");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Демонстрация операции true и false");
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

                        // 1. Формирование начальных данных
                        case (int)Cmd.PointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод данных
                        case (int)Cmd.PointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Сложение цены и числа
                        case (int)Cmd.PointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Вычитание числа из цены игрушки
                        case (int)Cmd.PointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Сравнение двух игрушек по цене
                        case (int)Cmd.PointFive:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Демонстрация операции true и false
                        case (int)Cmd.PointSix:
                            Console.Clear();
                            // запуск задания 
                            Point6();
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

            #region 1. Формирование начальных данных

            // 1. Формирование начальных данных
            void Point1()
            {
                ShowNavBarMessage("1. Формирование начальных данных");

                // вывод данных до заполнения
                Toy.ShowTable(toys, info: "До заполнения");

                Console.WriteLine();

                // формирование новых данных
                GenerToys();

                // вывод данных после заполнения
                Toy.ShowTable(toys, info: "После заполнения");
            }

            // формирование игрушек
            void GenerToys()
            {
                // массив игрушек с данными 
                (string name, int ageCategory, int price)[] arrayToys = {
                    (name:"Fancy Котик", ageCategory: 3, price: 539),
                    (name:"Fancy Осьминожка", ageCategory : 2, price : 200),
                    (name:"Tigres Зайчик", ageCategory : 5, price : 343),
                    (name:"Fancy Ждун", ageCategory : 5, price : 310),
                    (name:"Fancy Кот", ageCategory : 4, price : 562),
                    (name:"Tigres Панда", ageCategory : 4, price : 269),
                    (name:"Fancy Авокадо", ageCategory : 6, price : 189),
                    (name:"LEGO Friends", ageCategory : 7, price : 979),
                    (name:"LEGO Architecture", ageCategory : 12, price : 1_119),
                    (name:"LEGO Duplo", ageCategory : 12, price : 809)
                };

                // заполнение массива 
                for (int i = 0; i < sizeToys; i++)
                {
                    // данные игрушки из массива 
                    var toy = arrayToys[rand.Next(0, sizeToys - 1)];

                    // заполнение игрушки данными 
                    (toys[i] ?? (toys[i] = new Toy())).Name = toy.name;
                    toys[i].AgeCategory = toy.ageCategory;
                    toys[i].Price = toy.price;
                }
            }

            #endregion

            #region 2. Вывод данных

            // 2. Вывод данных
            void Point2()
            {
                ShowNavBarMessage("2. Вывод данных");

                // вывод данных доформирования
                Toy.ShowTable(toys);
            }

            #endregion

            #region 3. Сложение цены и числа

            // 3. Сложение цены и числа
            void Point3()
            {
                ShowNavBarMessage("3. Сложение цены и числа");

                // вывод данных игрушки операнда
                Toy.ShowTable(toys[0], name: "Игрушка 1");

                Console.WriteLine();

                // число для сложения 
                int num = 1000;

                // операция
                var result = toys[0] + num;

                // вывод операции и результата
                ShowOperation("Сложение", "Игрушка 1", num.ToString(), "Игрушка 2");

                Console.WriteLine();

                // вывод данных игрушки результата
                Toy.ShowTable(result, name: "Игрушка 2", info: "Результат");

                Console.WriteLine();

                // вывод данных игрушки операнда
                Toy.ShowTable(toys[0], name: "Игрушка 1");
            }

            #endregion

            #region 4. Вычитание числа из цены игрушки

            // 4. Вычитание числа из цены игрушки
            void Point4()
            {
                ShowNavBarMessage("4. Вычитание числа из цены игрушки");

                // вывод данных игрушки операнда
                Toy.ShowTable(toys[0], name: "Игрушка 1");

                Console.WriteLine();

                // число для вычитания 
                int num = toys[0].Price / 3;

                // операция
                var result = toys[0] - num;

                // вывод операции и результата
                ShowOperation("Вычитание", "Игрушка 1", num.ToString(), "Игрушка 2");

                Console.WriteLine();

                // вывод данных игрушки результата
                Toy.ShowTable(result, name: "Игрушка 2", info: "Результат");

                Console.WriteLine();

                // вывод данных игрушки операнда
                Toy.ShowTable(toys[0], name: "Игрушка 1");
            }

            #endregion

            #region 5. Сравнение двух игрушек по цене 

            // 5. Сравнение двух игрушек по цене
            void Point5()
            {
                ShowNavBarMessage("5. Сравнение двух игрушек по цене");

                // игрушки для сравнения
                Toy first = new Toy { Name = "LEGO Friends", AgeCategory = 7, Price = 979 };
                Toy second = new Toy { Name = "LEGO Architecture", AgeCategory = 12, Price = 1_119 };

                // вывод данных игрушки операнда
                Toy.ShowTable(first, name: "Игрушка 1");

                // вывод данных игрушки операнда
                Toy.ShowTable(second, name: "Игрушка 2");

                Console.WriteLine();

                // вывод операции и результата
                ShowOperation("Меньше", "Игрушка 1", "Игрушка 2", (first < second).ToString());

                Console.WriteLine();

                // вывод операции и результата
                ShowOperation("Больше", "Игрушка 1", "Игрушка 2", (first > second).ToString());
            }

            #endregion

            #region 6. Демонстрация операции true и false

            // 6. Демонстрация операции true и false
            void Point6()
            {
                ShowNavBarMessage("6. Демонстрация операции true и false");

                // игрушки для сравнения
                Toy first = new Toy { Name = "LEGO Friends", AgeCategory = 7, Price = 979 };
                Toy second = new Toy { Name = "Fancy Котик", AgeCategory = 3, Price = 539 };

                // вывод условий
                ShowCond("true: если возрастная категория больше 5", "false: если возрастная категория меньше или равна 5");

                // вывод данных игрушки операнда
                Toy.ShowTable(first, name: "Игрушка 1");

                // вывод данных игрушки операнда
                Toy.ShowTable(second, name: "Игрушка 2");

                Console.WriteLine();

                // вывод операции и результата
                ShowOperation("true false", "Игрушка 1", "──────────", first ? true.ToString() : false.ToString());

                Console.WriteLine();

                // вывод операции и результата
                ShowOperation("true false", "Игрушка 2", "──────────", second ? true.ToString() : false.ToString());
            }

            // вывод условий задания
            void ShowCond(string line1, string line2)
            {
                App.WriteColorXY("          ╔═════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("          ║                                                     ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY($"{line1,-51}", 12, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
                App.WriteColorXY("          ║                                                     ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY($"{line2,-51}", 12, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
                App.WriteColorXY("          ╚═════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
            }

            #endregion

            #region Общие методы

            // вывод операции
            void ShowOperation(string operation, string operandFirst, string operandSecond, string result)
            {
                App.WriteColorXY("          ╔════════════╦════════════╦════════════╦═══════════════╗\n", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("          ║            ║            ║            ║               ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("Операнд 1 ",              12, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY(" Операция ",              25, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY("Операнд 2 ",              38, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY(" Результат ",             51, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();
                App.WriteColorXY("          ╠════════════╬════════════╬════════════╬═══════════════╣\n", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("          ║            ║            ║            ║               ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY($"{operandFirst,-10}",       12, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{operation,-10}",        25, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{operandSecond,-10}",    38, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{result,-10}",           51, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
                App.WriteColorXY("          ╚════════════╩════════════╩════════════╩═══════════════╝\n", textColor: ConsoleColor.Magenta);
            }

            #endregion
        }

        #endregion

    }
}