using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Interface;                          // подключение интерфейсов

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Класс Цилиндр
    public class Cylinder : Figure, IVolumetricFigure
    {
        // высота 
        private double _height;

        // радиус
        private double _radius;

        #region Свойства 

        // доступ к полю _height
        public double Height { get => _height; set => _height = value > 0d ? value : throw new Exception($"Cylinder: Некорректное значение высоты! Значение: {value}"); }

        // доступ к полю _radius
        public double Radius { get => _radius; set => _radius = value > 0d ? value : throw new Exception($"Cylinder: Некорректное значение радиуса! Значение: {value}"); }

        // площадь
        public override double GetArea { get => Area(); }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Cylinder() => _name = "Цилиндр";

        #endregion

        #region Свойства 

        #endregion

        #region Методы 

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",                  7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}",             12, textColor: ConsoleColor.Cyan);
            WriteColorXY("──────────",              30, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",              43, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",              56, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{_height,10:n3}",         69, textColor: ConsoleColor.Green);
            WriteColorXY($"{_radius,10:n3}",         82, textColor: ConsoleColor.Green);
            WriteColorXY("──────────",             95, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Volume(),10:n3}",       108, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{Area(),10:n3}",         121, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // площадь      Источник: https://www.rapidus.ru/area-of-cylinder.html
        public double Area() => 2 * Math.PI * _radius * (_height + _radius);

        // объём        Источник: https://www.calc.ru/obyem-tsilindra.html
        public double Volume() => Math.PI * (_radius * _radius) * _height;

        #endregion

    }
}
