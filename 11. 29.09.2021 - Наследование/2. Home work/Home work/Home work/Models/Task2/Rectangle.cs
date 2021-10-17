using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Interface;                          // подключение интерфейсов

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Класс Прямоугольник
    public class Rectangle : Figure, IFlatFigure
    {
        // сторона A
        private double _a;

        // сторона B
        private double _b;

        #region Свойства 

        // доступ к полю _a
        public double A { get => _a; set => _a = value > 0d ? value : throw new Exception($"Rectangle: Некорректное значение стороны! Значение: {value}"); }

        // доступ к полю _b
        public double B { get => _b; set => _b = value > 0d ? value : throw new Exception($"Rectangle: Некорректное значение стороны! Значение: {value}"); }

        // площадь
        public override double GetArea { get => Area(); }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Rectangle() => _name = "Прямоугольник";

        #endregion

        #region Методы 

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}",                 7,    textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name, -15}",            12,    textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_a, 10:n3}",             30,    textColor: ConsoleColor.Green);
            WriteColorXY($"{_b, 10:n3}",             43,    textColor: ConsoleColor.Green);
            WriteColorXY("──────────",              56,    textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",              69,    textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",              82,    textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Perimeter(),10:n3}",    95,    textColor: ConsoleColor.Cyan);
            WriteColorXY("──────────",             108,    textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Area(),10:n3}",         121,    textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // площадь
        public double Area() => _a * _b;

        // периметр
        public double Perimeter() => 2 * (_a + _b);

        #endregion

    }
}
