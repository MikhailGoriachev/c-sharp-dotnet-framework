using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task1
{
    // Абстрактный класс Транспортное средство
    abstract public class Vehicle
    {
        // название транспортного средства
        protected string _name;

        // географические координаты
        protected (double x, double y) _coord;

        // цена
        protected int _price;

        // скорость(км/ч)
        protected int _speed;

        // год выпуска
        protected int _year;

        #region Свойства

        // доступ к полю _name
        public string Name { get => _name; set => _name = value; }

        // доступ к полю _coord
        public (double x, double y) Coord
        {
            get => _coord; set => _coord = value.x >= -90d && value.x <= 90d && value.y >= -180d && value.y <= 180d ? value :
                throw new Exception($"{GetType()}: Некорректные данные! Данные: x[{value.x}], y[{value.y}]");
        }

        // доступ к полю _price
        public int Price
        {
            get => _price; set => _price = value >= 0 ? value :
                 throw new Exception($"{GetType()}: Некорректные данные! Данные: Цена[{value}]");
        }

        // доступ к полю _speed
        public int Speed
        {
            get => _speed; set => _speed = value >= 0 ? value :
                throw new Exception($"{GetType()}: Некорректные данные! Данные: Скорость[{value}]");
        }

        // доступ к полю _year
        public int Year
        {
            get => _year; set => _year = value >= 0 ? value :
                throw new Exception($"{GetType()}: Некорректные данные! Данные: Год[{value}]");
        }

        #endregion

        #region Методы

        // вывод таблицы 
        public static void ShowTable(Vehicle[] vehicles, string name, string info)
        {
            // вывод шапки таблицы
            ShowHead(vehicles?.Length ?? 0, name, info);

            // вывод элементов 
            ShowElements(vehicles);
        }

        // вывод шапки таблицы 
        public static void ShowHead(int size, string name, string info)
        {
            //                      10                           61                                            49
            WriteColor("     ╔════════════╦══════════════════════════════════════════════════════════════════╦═══════════════════════════════════════════════════╗\n", ConsoleColor.Magenta);
            WriteColor("     ║            ║                                                                  ║                                                   ║", ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-51}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 88, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-43}", textColor: ConsoleColor.Green);
            Console.WriteLine();

            WriteColor("     ╠════╦═══════╩═════════╦═════════════════╦════════════╦════════════╦════════════╬════════════╦════════════╦═════════════════════════╣\n", ConsoleColor.Magenta);

            WriteColor("     ║    ║                 ║                 ║            ║            ║            ║            ║            ║                         ║", ConsoleColor.Magenta);
            WriteColorXY("N ",                        7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Название    ",          12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Координаты   ",               30, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Цена   ",               48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Скорость ",               61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Высота  ",               74, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Пассажиры ",               87, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Год    ",              100, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("     Порт приписки     ", 113, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColor("     ║    ║                 ║                 ║            ║            ║            ║            ║            ║                         ║", ConsoleColor.Magenta);
            WriteColorXY("  [x;y]   ", 30, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  (км/ч)  ", 61, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   (м)    ", 74, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColor("     ╠════╬═════════════════╬═════════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬═════════════════════════╣\n", ConsoleColor.Magenta);
        }

        // вывод элементов в таблицу 
        public static void ShowElements(Vehicle[] vehicles)
        {
            // вывод элементов таблицы
            for (int i = 0; i < vehicles.Length; i++)
                vehicles[i].ShowElem(i + 1);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColor("     ╚════╩═════════════════╩═════════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩═════════════════════════╝\n", ConsoleColor.Magenta);

        // вывод элемента в таблицу
        abstract public void ShowElem(int num);
            
        #endregion
    }
}
