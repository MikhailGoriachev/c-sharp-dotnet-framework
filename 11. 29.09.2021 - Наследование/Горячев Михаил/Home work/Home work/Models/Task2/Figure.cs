using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Базовый класс Фигура
    abstract public class Figure
    {
        // название фигуры
        protected string _name;

        #region Свойства 

        // доступ к полю _name
        public string Name { get=>_name; }

        // площадь
        abstract public double GetArea { get; }

        #endregion

        #region Методы

        // вывод таблицы 
        static public void ShowTable(Figure[] figures, string name, string info)
        {
            // вывод шапки таблицы
            ShowHead(figures?.Length ?? 0, name, info);

            // вывод элементов 
            ShowElements(figures);
        }

        // вывод шапки таблицы
        static public void ShowHead(int size, string name, string info)
        {
            //                      10                           56                                            49
            WriteColor("     ╔════════════╦═════════════════════════════════════════════════════════════╦═══════════════════════════════════════════════════╗\n", ConsoleColor.Magenta);
            WriteColor("     ║            ║                                                             ║                                                   ║", ConsoleColor.Magenta);
            WriteColorXY("Размер: ",    7,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size, 2}",       textColor: ConsoleColor.Green);
            WriteColorXY("Название: ",  20,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-46}",      textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ",      82,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-43}",      textColor: ConsoleColor.Green);
            Console.WriteLine();

            WriteColor("     ╠════╦═══════╩═════════╦════════════╦════════════╦════════════╦════════════╬════════════╦════════════╦════════════╦════════════╣\n", ConsoleColor.Magenta);

            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY("N ",               7,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Название    ", 12,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сторона A ",      30,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сторона B ",      43,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Сторона C ",      56,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Высота  ",      69,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Радиус  ",      82,  textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Периметр ",      95, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Объём   ",      108, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Площадь  ",      121, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColor("     ╠════╬═════════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", ConsoleColor.Magenta);
        }

        // вывод элементов в таблицу
        static public void ShowElements(Figure[] figures)
        {
            // вывод элементов таблицы
            for (int i = 0; i < figures.Length; i++)
                figures[i].ShowElem(i + 1);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод подвала таблицы
        static public void ShowLine() =>
            WriteColor("     ╚════╩═════════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", ConsoleColor.Magenta);

        // вывод элемента таблицы
        abstract public void ShowElem(int num);

        #endregion
    }
}
