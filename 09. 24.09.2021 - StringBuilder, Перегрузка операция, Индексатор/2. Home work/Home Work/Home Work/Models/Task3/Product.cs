using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task3
{
    // Класс Товар
    internal class Product
    {
        // название товара
        private string _name;       

        // количество товара 
        private int _count;             

        // цена товара в рублях
        private int _price;         

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = value; }

        // доступ к полю _count
        public int Count { get => _count; set => _count = value >= 0 ? value : 
                throw new Exception($"Product: Некорректное значение {value}! Значение должно быть => 0!"); }

        // доступ к полю _price
        public int Price {  get => _price; set => _price = value >= 0 ? value : 
                throw new Exception($"Product: Некорректное значение {value}! Значение должно быть => 0!"); }

        #endregion

        #region Методы 

        // вывод элемента в таблицу
        public void ShowElem(int num, bool flagActive = false, ConsoleColor activeColor = ConsoleColor.Blue)
        {
            App.WriteColorXY("          ║    ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"{num,2}", 12, textColor: flagActive ? activeColor : ConsoleColor.DarkGray);
            App.WriteColorXY($"{_name,-20}", 17, textColor: flagActive ? activeColor : ConsoleColor.Cyan);
            App.WriteColorXY($"{_count,10}", 40, textColor: flagActive ? activeColor : ConsoleColor.Green);
            App.WriteColorXY($"{_price,10}", 53, textColor: flagActive ? activeColor : ConsoleColor.Green);
            App.WriteColorXY($"{(+this).Price,10}", 66, textColor: flagActive ? activeColor : ConsoleColor.Cyan);
            Console.WriteLine();
        }

        #endregion

        #region Перегрузка операций

        // получение суммарной стоимости всех единиц товара 
        public static Product operator +(Product prod) => new Product { Name = prod._name, Count = prod._count, Price = prod._price * prod._count };

        // получение суммарной стоимости всех единиц двух товаров с одинаковым наименованием
        public static Product operator +(Product prod1, Product prod2)
        {
            // если наименования не одинаковые
            if (prod1.Name != prod2.Name)
                throw new Exception($"Наименования {prod1.Name} и {prod2.Name} должны быть идентичны!");

            return new Product { Name = prod1._name, Count = prod1._count + prod2._count, 
                Price = (prod1._price * prod1._count) + (prod2._price * prod2._count) };
        }

        // сложение цены и целого числа
        public static Product operator +(Product prod, int num) => 
            new Product { Name = prod._name, Count = prod._count, Price = prod._price + num };

        // вычитание целого числа из цены 
        public static Product operator -(Product prod, int num) => 
            new Product { Name = prod._name, Count = prod._count, Price = prod._price - num };

        // сравнение товаров по цене

        // операция меньше 
        public static bool operator <(Product prod1, Product prod2) => prod1._price < prod2._price;

        // операция больше 
        public static bool operator >(Product prod1, Product prod2) => prod1._price > prod2._price;

        // операция меньше или равно 
        public static bool operator >=(Product prod1, Product prod2) => prod1._price >= prod2._price;

        // операция больше или равно 
        public static bool operator <=(Product prod1, Product prod2) => prod1._price <= prod2._price;

        // операция равно 
        public static bool operator ==(Product prod1, Product prod2) => prod1._price == prod2._price;

        // операция не равно
        public static bool operator !=(Product prod1, Product prod2) => prod1._price != prod2._price;

        // если стоимость товара в интервале 1, ..., 1000
        public static bool operator true(Product prod) => prod._price >= 1 && prod._price <= 1000;

        // если стоимость равна 0 или больше 1000
        public static bool operator false(Product prod) => prod._price == 0 || prod._price > 1000;

        #endregion
    }
}
