using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Interface;                          // подключение интерфейсов

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Класс Треугольник
    public class Triangle : Figure, IFlatFigure
    {
        // сторона A
        private double _a;

        // сторона B
        private double _b;
        
        // сторона C
        private double _c;

        #region Свойства 

        // установка значения сторон треугольника
        public (double a, double b, double c) Sides { get => (_a, _b, _c); set => (_a, _b, _c) = IsTriangle(value) ? value : 
                throw new Exception($"Triangle: Некорректные даные! Стороны^ a[{_a}], b[{_b}], c[{_c}]  не являются треугольником!"); }

        // доступ к полю _a
        public double A { get => _a; }

        // доступ к полю _b
        public double B { get => _b; }

        // доступ к полю _c
        public double C { get => _c; }

        // площадь
        public override double GetArea { get => Area(); }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Triangle() => _name = "Треугольник";

        #endregion

        #region Методы 

        // проверка треугольника на истинность 
        public static bool IsTriangle((double a, double b, double c) sides) => sides.a + sides.b > sides.c && sides.b + sides.c > sides.a && sides.c + sides.a > sides.b;

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",              7,    textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}",         12,    textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_a,10:n3}",          30,    textColor: ConsoleColor.Green);
            WriteColorXY($"{_b,10:n3}",          43,    textColor: ConsoleColor.Green);
            WriteColorXY($"{_c,10:n3}",          56,    textColor: ConsoleColor.Green);
            WriteColorXY("──────────",          69,    textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",          82,    textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Perimeter(),10:n2}", 95,    textColor: ConsoleColor.Cyan);
            WriteColorXY("──────────",         108,    textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Area(),10:n3}",     121,    textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // площадь          Источник: https://2mb.ru/matematika/geometriya/ploshhad-treugolnika-po-trem-storonam/
        public double Area()
        {
            // полупериметр
            double p = Perimeter() / 2;

            return Math.Sqrt(p * (p - _a) * (p - _b) * (p - _c));
        }

        // периметр         Источник: https://2mb.ru/matematika/geometriya/ploshhad-treugolnika-po-trem-storonam/
        public double Perimeter() => _a + _b + _c;

        #endregion

    }
}
