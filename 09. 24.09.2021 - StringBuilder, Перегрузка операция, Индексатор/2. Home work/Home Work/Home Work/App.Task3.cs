using System;
using System.Threading;

using Home_Work.Models.Task3;        // для использования класса Task3

namespace Home_Work
{
    public partial class App
    {

        #region Задание 3. Магазин

        /*
         * Задача 3. Описать класс «товар», содержащий следующие закрытые поля:
         * •	название товара;
         * •	количество товара (в условных единицах);
         * •	стоимость товара в рублях.
         * Предусмотреть свойства для задания и получения состояния объекта.
         * Реализовать перегруженные операции:
         * •	+: сложения товаров с одинаковыми наименованиями, выполняющую сложение их 
         *      стоимостей, т.е. цен, умноженных на количество
         * •	+: сложения товара и целого числа, выполняющего сложение цены и целого числа
         * •	–: вычитание товара и целого числа, выполняющего вычитание целого числа из цены
         * •	сравнение товаров по цене: < >, <= >=, == !=
         * •	операция true: стоимость товара в интервале 1, …, 1000
         * •	операция false: стоимость товара равна 0 или больше 1000
         * Создайте класс Shop (магазин), в котором хранить название магазина, закрытый массив 
         * товаров. Реализуйте в этом классе методы заполнения массива товаров данными, вывод 
         * товаров в консоль, суммирование цен товаров. Разработайте индексатор с контролем 
         * выхода за пределы массива.
         * При помощи индексатора, в классе решения Task3 реализуйте поиск товаров с минимальной
         * ценой, максимальной ценой, сортировку товара по убыванию количества (метод быстрой 
         * сортировки). 
        */

        // Задание 3. Магазин
        public void DemoTask3()
        {
            // объект задания
            Task3 task = new Task3();

            // заполнение магазина товарами
            task.ShopObj.FillProducts(GenProducts()); 

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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 3. Магазин"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Формирование данных о товарах");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Вывод товаров");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Поиск товаров с минимальной и максимальной ценой");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Сортировка товара по убыванию количества");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Суммирование цен товаров");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Сложение товаров с одинаковыми наименованиями");
                Console.SetCursorPosition(x, y++); Console.WriteLine("7. Сложение цены товара и целого числа");
                Console.SetCursorPosition(x, y++); Console.WriteLine("8. Вычитание целого числа из цены товара");
                Console.SetCursorPosition(x, y++); Console.WriteLine("9. Сравнение товаров по цене");
                Console.SetCursorPosition(x, y++); Console.WriteLine("10. Операция true false");
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

                        // 1. Формирование данных о товарах
                        case (int)Cmd.PointOne:
                            Console.Clear();
                            // запуск задания 
                            Point1();
                            break;

                        // 2. Вывод товаров
                        case (int)Cmd.PointTwo:
                            Console.Clear();
                            // запуск задания 
                            Point2();
                            break;

                        // 3. Поиск товаров с минимальной и максимальной ценой
                        case (int)Cmd.PointThree:
                            Console.Clear();
                            // запуск задания 
                            Point3();
                            break;

                        // 4. Сортировка товара по убыванию количества
                        case (int)Cmd.PointFour:
                            Console.Clear();
                            // запуск задания 
                            Point4();
                            break;

                        // 5. Суммирование цен товаров
                        case (int)Cmd.PointFive:
                            Console.Clear();
                            // запуск задания 
                            Point5();
                            break;

                        // 6. Сложение товаров с одинаковыми наименованиями
                        case (int)Cmd.PointSix:
                            Console.Clear();
                            // запуск задания 
                            Point6();
                            break;

                        // 7. Сложение цены товара и целого числа
                        case (int)Cmd.PointSeven:
                            Console.Clear();
                            // запуск задания 
                            Point7();
                            break;

                        // 8. Вычитание целого числа из цены товара
                        case (int)Cmd.PointEight:
                            Console.Clear();
                            // запуск задания 
                            Point8();
                            break;

                        // 9. Сравнение товаров по цене
                        case (int)Cmd.PointNine:
                            Console.Clear();
                            // запуск задания 
                            Point9();
                            break;

                        // 10. Операция true false
                        case (int)Cmd.PointTen:
                            Console.Clear();
                            // запуск задания 
                            Point10();
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

            #region 1. Формирование данных о товарах

            // 1. Формирование данных о товарах
            void Point1()
            {
                ShowNavBarMessage("1. Формирование данных о товарах");

                // вывод товаров до заполнения
                task.ShopObj.ShowTable("До заполнения");

                Console.WriteLine();

                // заполнение магазина массивом новых товаров
                task.ShopObj.FillProducts(GenProducts(rand.Next(10, 15)));

                // вывод товаров до заполнения
                task.ShopObj.ShowTable("После заполнения");
            }

            // создание массива товаров
            Product[] GenProducts(int num = 10)
            {
                // массив с шаблонными данными о товарах
                Product[] temp = new Product[] {
                    new Product{ Name = "Холодильник Samsung",  Price = 40_000  },
                    new Product{ Name = "Телевизор LG",         Price = 100_000 },
                    new Product{ Name = "Наушники Sony",        Price = 5_600   },
                    new Product{ Name = "Клавиатура Rizer",     Price = 8_000   },
                    new Product{ Name = "Монитор Samsung",      Price = 74_000  },
                };

                // массив с товарами
                Product[] products = new Product[num];

                // заполнение массива с товарами
                for (int i = 0; i < products.Length; i++)
                {
                    // индекс шаблона 
                    int index = rand.Next(0, temp.Length - 1);

                    // заполнение массива с товарами
                    products[i] = new Product { Name = temp[index].Name, Count = rand.Next(0, 15), Price = temp[index].Price };
                }

                return products;
            }

            #endregion

            #region 2. Вывод товаров

            // 2. Вывод товаров
            void Point2()
            {
                ShowNavBarMessage("2. Вывод товаров");

                // вывод товаров 
                task.ShopObj.ShowTable();
            }

            #endregion

            #region 3. Поиск товаров с минимальной и максимальной ценой

            // 3. Поиск товаров с минимальной и максимальной ценой
            void Point3()
            {
                ShowNavBarMessage("3. Поиск товаров с минимальной и максимальной ценой");

                // минимальные элементы
                Product[] minElem = task.FindMinElemPrice(out int minValue);

                // максимальные элементы
                Product[] maxElem = task.FindMaxElemPrice(out int maxValue);

                // вывод товаров
                task.ShowTableMinMaxPrice(minValue, maxValue);

                // вывод минимальных элементов
                ShowProducts(minElem, info: "Минимальные элементы");

                // вывод максимальных элементов
                ShowProducts(maxElem, info: "Максимальные элементы");
            }

            // вывод массива товаров
            void ShowProducts(Product[] products, string name = "Товары", string info = "Исходные данные ")
            {
                // вывод шапки таблицы
                Shop.ShowHead(products.Length, name, info);

                // вывод элементов 
                Shop.ShowElem(products);
            }

            #endregion

            #region 4. Сортировка товара по убыванию количества

            // 4. Сортировка товара по убыванию количества
            void Point4()
            {
                ShowNavBarMessage("4. Сортировка товара по убыванию количества");

                // вывод товаров до сортировки
                task.ShopObj.ShowTable("До сортировки");

                Console.WriteLine();

                // сортировка товара
                task.SortByCount();

                // вывод товаров до сортировки
                task.ShopObj.ShowTable("После сортировки");
            }

            #endregion

            #region 5. Суммирование цен товаров

            // 5. Суммирование цен товаров
            void Point5()
            {
                ShowNavBarMessage("5. Суммирование цен товаров");

                // сумма всех товаров
                int sum = task.ShopObj.SumAllPrice();

                // вывод товаров с общей суммой стоимостей
                task.ShowAllSumProduct(sum);
            }

            #endregion

            #region 6. Сложение товаров с одинаковыми наименованиями

            // 6. Сложение товаров с одинаковыми наименованиями
            void Point6()
            {
                ShowNavBarMessage("6. Сложение товаров с одинаковыми наименованиями");

                // товар 1
                Product first = new Product { Name = "Телевизор LG", Count = rand.Next(5, 15), Price = 100_000 };

                // товар 2
                Product second = new Product { Name = "Телевизор LG", Count = rand.Next(5, 15), Price = 80_000 };

                // результат 
                Product result = first + second;

                // вывод товара 1
                ShowProduct(first, "Товар 1");

                // вывод товара 2
                ShowProduct(second, "Товар 2");

                Console.WriteLine();

                // вывод выражения
                ShowOperation("Сложение", "Товар 1", "Товар 2", "Товар 3");

                Console.WriteLine();

                // вывод результата
                ShowProductNotSum(result, "Товар 3", "Результат");

                Console.WriteLine();

                // вывод товара 1
                ShowProduct(first, "Товар 1");

                // вывод товара 2
                ShowProduct(second, "Товар 2");
            }

            #endregion

            #region 7. Сложение цены товара и целого числа

            // 7. Сложение цены товара и целого числа
            void Point7()
            {
                ShowNavBarMessage("7. Сложение цены товара и целого числа");

                // товар 1
                Product first = task.ShopObj[0];

                // целое число для сложения
                int num = 10000;

                // результат 
                Product result = first + num;

                // вывод товара 1
                ShowProduct(first, "Товар 1");
                                
                Console.WriteLine();

                // вывод выражения
                ShowOperation("Сложение", "Товар 1", num.ToString(), "Товар 2");

                Console.WriteLine();

                // вывод результата
                ShowProduct(result, "Товар 2", "Результат");

                Console.WriteLine();

                // вывод товара 1
                ShowProduct(first, "Товар 1");
            }

            #endregion

            #region 8. Вычитание целого числа из цены товара

            // 8. Вычитание целого числа из цены товара
            void Point8()
            {
                ShowNavBarMessage("8. Вычитание целого числа из цены товара");

                // товар 1
                Product first = task.ShopObj[0];

                // целое число для вычитания
                int num = first.Price / 3;

                // результат 
                Product result = first - num;

                // вывод товара 1
                ShowProduct(first, "Товар 1");

                Console.WriteLine();

                // вывод выражения
                ShowOperation("Вычитание", "Товар 1", num.ToString(), "Товар 2");

                Console.WriteLine();

                // вывод результата
                ShowProduct(result, "Товар 2", "Результат");

                Console.WriteLine();

                // вывод товара 1
                ShowProduct(first, "Товар 1");
            }

            #endregion

            #region 9. Сравнение товаров по цене

            // 9. Сравнение товаров по цене
            void Point9()
            {
                ShowNavBarMessage("9. Сравнение товаров по цене");

                // товар 1
                Product first = new Product { Name = "Телевизор LG", Count = rand.Next(5, 15), Price = 100_000 };

                // товар 2
                Product second = new Product { Name = "Холодильник Samsung", Count = rand.Next(5, 15), Price = 40_000 };

                // вывод товара 1
                ShowProduct(first, "Товар 1");

                // вывод товара 2
                ShowProduct(second, "Товар 2");

                Console.WriteLine();

                // операция меньше 
                ShowOperation("  <   ", "Товар 1", "Товар 2", (first < second).ToString());
                ShowOperation("  <   ", "Товар 2", "Товар 1", (second < first).ToString());

                Console.WriteLine();

                // операция больше 
                ShowOperation("  >   ", "Товар 1", "Товар 2", (first > second).ToString());
                ShowOperation("  >   ", "Товар 2", "Товар 1", (second > first).ToString());

                Console.WriteLine();

                // операция меньше или равно 
                ShowOperation("  <=  ", "Товар 1", "Товар 2", (first <= second).ToString());
                ShowOperation("  <=  ", "Товар 2", "Товар 1", (second <= first).ToString());

                Console.WriteLine();

                // операция больше или равно 
                ShowOperation("  >=  ", "Товар 1", "Товар 2", (first >= second).ToString());
                ShowOperation("  >=  ", "Товар 2", "Товар 1", (second >= first).ToString());

                Console.WriteLine();

                // операция равно 
                ShowOperation("  ==  ", "Товар 1", "Товар 2", (first == second).ToString());
                ShowOperation("  ==  ", "Товар 1", "Товар 1", (first == first).ToString());

                Console.WriteLine();

                // операция не равно
                ShowOperation("  !=  ", "Товар 1", "Товар 2", (first != second).ToString());
                ShowOperation("  !=  ", "Товар 1", "Товар 1", (first != first).ToString());
            }

            #endregion

            #region 10. Операция true false

            // 10. Операция true false
            void Point10()
            {
                ShowNavBarMessage("10. Операция true false");

                // вывод условий задания 
                ShowCond("true: стоимость товара в интервале 1, ..., 1000", "false: стоимость товара равна 0 или больше 1000");

                Console.WriteLine();

                // товар 1
                Product first = new Product { Name = "Будтльник", Count = rand.Next(5, 15), Price = 500 };

                // товар 2
                Product second = new Product { Name = "Холодильник Samsung", Count = rand.Next(5, 15), Price = 40_000 };

                // вывод товара 1
                ShowProduct(first, "Товар 1");

                // вывод товара 2
                ShowProduct(second, "Товар 2");

                Console.WriteLine();

                // операция true
                ShowOperation("true false", "Товар 1", "──────────", first ? true.ToString() : false.ToString());

                // операция false
                ShowOperation("true false", "Товар 2", "──────────", second ? true.ToString() : false.ToString());
            }

            #endregion

            #region Общие методы

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

            // вывод товара в консоль в виде таблицы
            void ShowProduct(Product prod, string name = "Товар", string info = "Исходные данные")
            {
                // вывод шапки таблицы
                Shop.ShowHead(1, name, info);

                // вывод элемента
                Shop.ShowElem(new Product[] { prod });
            }
            
            // вывод товара в консоль в виде таблицы без общей стоимости
            void ShowProductNotSum(Product prod, string name = "Товар", string info = "Исходные данные")
            {
                // вывод шапки таблицы
                Shop.ShowHead(1, name, info);

                // вывод элемента
                App.WriteColorXY("          ║    ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY($"{1,2}", 12, textColor: ConsoleColor.DarkGray);
                App.WriteColorXY($"{prod.Name,-20}", 17, textColor:  ConsoleColor.Cyan);
                App.WriteColorXY($"{prod.Count,10}", 40, textColor:  ConsoleColor.Green);
                App.WriteColorXY($"{prod.Price,10}", 53, textColor:  ConsoleColor.Green);
                App.WriteColorXY($"──────────", 66, textColor:  ConsoleColor.DarkRed);
                Console.WriteLine();
                Shop.ShowLine();
            }

            // вывод операции
            void ShowOperation(string operation, string operandFirst, string operandSecond, string result)
            {
                App.WriteColorXY("          ╔════════════╦════════════╦════════════╦═══════════════╗\n", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("          ║            ║            ║            ║               ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("Операнд 1 ", 12, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY(" Операция ", 25, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY("Операнд 2 ", 38, textColor: ConsoleColor.DarkYellow);
                App.WriteColorXY(" Результат ", 51, textColor: ConsoleColor.DarkYellow);
                Console.WriteLine();
                App.WriteColorXY("          ╠════════════╬════════════╬════════════╬═══════════════╣\n", textColor: ConsoleColor.Magenta);
                App.WriteColorXY("          ║            ║            ║            ║               ║", textColor: ConsoleColor.Magenta);
                App.WriteColorXY($"{operandFirst,-10}", 12, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{operation,-10}", 25, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{operandSecond,-10}", 38, textColor: ConsoleColor.Green);
                App.WriteColorXY($"{result,-10}", 51, textColor: ConsoleColor.Cyan);
                Console.WriteLine();
                App.WriteColorXY("          ╚════════════╩════════════╩════════════╩═══════════════╝\n", textColor: ConsoleColor.Magenta);
            }

            #endregion

        }

        #endregion

    }
}