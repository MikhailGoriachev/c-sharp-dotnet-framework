using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task3
{
    // Класс Магазин
    internal class Shop
    {
        // название магазина
        private string _name;

        // коллекция товаров
        private Product[] _products;

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = value; }

        // размер массива 
        public int Length { get => _products.Length; }

        #endregion

        #region Конструктор и индексатор 

        // конструктор по умолчанию
        public Shop() : this("Магазин") { }

        // конструктор инициализирующий 
        public Shop(string name) : this(name, new Product[0]) { }

        // конструктор иницаилизирующий
        public Shop(string name, Product[] products)
        {
            // установка значений
            _name = name;
            _products = products;
        }

        // индексатор 
        public Product this[int index]
        {
            get
            {
                // если индекс невалиден
                if (index < 0 || index >= _products.Length) throw new IndexOutOfRangeException($"Выход за границы массива! Значение {index} недопустимо!");

                return _products[index];
            }

            set
            {
                // если индекс невалиден
                if (index < 0 || index >= _products.Length) throw new IndexOutOfRangeException($"Выход за границы массива! Значение {index} недопустимо!");

                // установка значения
                _products[index] = value;
            }
        }

        #endregion

        #region Методы 

        // заполнение массива товаров данными 
        public void FillProducts(Product[] products) => _products = products;

        // суммирование стоимостей единиц товара
        public int SumPrice(Product product) => product.Count * product.Price;

        // суммирование стоимостей единиц товара
        public int SumPrice(int index) => _products[index].Price * _products[index].Count;

        // cуммирование стоимостей всех товаров
        public int SumAllPrice()
        {
            // сумма
            int sum = 0;

            // суммирование 
            for (int i = 0; i < _products.Length; i++)
                sum += SumPrice(i);

            return sum;
        }

        // вывод товаров в консоль в виде таблицы
        public void ShowTable(string info = "Список товаров")
        {
            // вывод шапки таблицы
            ShowHead(_products.Length, _name, info);

            // вывод элементов 
            ShowElem(_products);
        }

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name, string info = "Список товаров")
        {
            //                                10                 22                         26
            App.WriteColorXY("          ╔════════════╦════════════════════════╦════════════════════════════╗\n", textColor:ConsoleColor.Magenta);
            App.WriteColorXY("          ║            ║                        ║                            ║", textColor:ConsoleColor.Magenta);
            App.WriteColorXY("Размер: ", 12,        textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size, 2}",          textColor: ConsoleColor.Green);
            App.WriteColorXY("Название: ", 25,      textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name, -12}",         textColor: ConsoleColor.Green);
            App.WriteColorXY("Инфо: ", 50,          textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info, -20}",         textColor: ConsoleColor.Green);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╦═══════╩══════════════╦═════════╩══╦════════════╦════════════╣\n", textColor:ConsoleColor.Magenta);

            App.WriteColorXY("          ║    ║                      ║            ║            ║            ║", textColor:ConsoleColor.Magenta);
            App.WriteColorXY($"N ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"      Название      ", 17, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Количество", 40, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Цена(руб) ", 53, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Стоимость ", 66, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ║    ║                      ║            ║            ║            ║", textColor:ConsoleColor.Magenta);
            App.WriteColorXY($"за 1 у.е. ", 53, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"всех един.", 66, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╬══════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод элементов 
        static public void ShowElem(Product[] products)
        {
            // если в массиве нет данных
            if ((products?.Length ?? 0) == 0)
                ShowEmpty();

            else
            {
                // вывод элементов
                for (int i = 0; i < products.Length; i++)
                    products[i].ShowElem(i + 1);

                // вывод подвала таблицы
                ShowLine();
            }
        }

        // вывод подвала таблицы
        static public void ShowLine() =>
            App.WriteColorXY("          ╚════╩══════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);

        // вывод сообщения об отстутствии данных
        static public void ShowEmpty()
        {
            App.WriteColorXY("          ╠════╩══════════════════════╩════════════╩════════════╩════════════╣\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                  ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                  ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                            НЕТ ДАННЫХ                            ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                  ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                  ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ╚══════════════════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Red);
        }

        #endregion
    }
}
