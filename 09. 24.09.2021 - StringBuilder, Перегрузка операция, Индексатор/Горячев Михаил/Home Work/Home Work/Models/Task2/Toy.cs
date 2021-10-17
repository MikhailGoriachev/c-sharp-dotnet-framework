using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task2
{
    // Класс Игрушка
    internal class Toy
    {
        #region Свойства

        // Название
        public string Name {  get; set; }

        // Возрастная категория
        public int AgeCategory { get; set; }

        // Стоимость 
        public int Price { get; set; }

        #endregion

        #region Методы 

        // вывод таблицы
        public static void ShowTable(Toy[] array, string name = "Игрушки", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(array.Length, name, info);

            // вывод элементов
            for (int i = 0; i < array.Length; i++)
                array[i].ShowElem(i + 1);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод таблицы
        public static void ShowTable(Toy toy, string name = "Игрушки", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(1, name, info);

            // вывод элемента
            toy.ShowElem(1);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public static void ShowHead(int size, string name = "Игрушки", string info = "Исходные данные")
        {
            //                                10                 22                         26
            App.WriteColorXY("          ╔════════════╦════════════════════════╦════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("          ║            ║                        ║                            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("Размер: ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            App.WriteColorXY("Название: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-12}", textColor: ConsoleColor.Green);
            App.WriteColorXY("Инфо: ", 50, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-20}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╦═══════╩════════════════════════╩══╦════════════╦════════════╣\n", textColor: ConsoleColor.Magenta);

            App.WriteColorXY("          ║    ║                                   ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"N ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"        Название игрушки         ", 17, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Возрастная", 53, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"   Цена   ", 66, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ║    ║                                   ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"категория ", 53, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╬═══════════════════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод элемента 
        void ShowElem(int num)
        {
            App.WriteColorXY("          ║    ║                                   ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"{num,2}", 12, textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{Name,-33}", 17, textColor: ConsoleColor.Cyan);
            App.WriteColorXY($"{AgeCategory,10}", 53, textColor: ConsoleColor.Green);
            App.WriteColorXY($"{Price,10}", 66, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        public static void ShowLine()
        {
            App.WriteColorXY("          ╚════╩═══════════════════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #region Перегрузка операций

        // сложение цены и числа
        public static Toy operator +(Toy toy, int num) => new Toy { Name = toy.Name, AgeCategory = toy.AgeCategory, Price = toy.Price + num };

        // вычитание числа из цены
        public static Toy operator -(Toy toy, int num) => new Toy { Name = toy.Name, AgeCategory = toy.AgeCategory, Price = toy.Price - num };

        // сравнение цен двух игрушек

        // меньше 
        public static bool operator<(Toy toy1, Toy toy2) => toy1.Price < toy2.Price;

        // больше 
        public static bool operator >(Toy toy1, Toy toy2) => toy1.Price > toy2.Price;

        // если возрастная категория больше 5
        public static bool operator true(Toy toy) => toy.AgeCategory > 5;

        // если возрастная категория меньше или равна 5
        public static bool operator false(Toy toy) => toy.AgeCategory <= 5;

        #endregion
    }
}
