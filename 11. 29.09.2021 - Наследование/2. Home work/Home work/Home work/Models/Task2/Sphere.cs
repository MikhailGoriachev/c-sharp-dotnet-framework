using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Interface;                          // подключение интерфейсов

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Класс Шар
    public class Sphere : Figure, IVolumetricFigure
    {
        // радиус
        private double _radius;

        #region Свойства 

        // доступ к полю _radius
        public double Radius { get => _radius; set => _radius = value > 0d ? value : throw new Exception($"Sphere: Некорректное значение радиуса! Значение: {value}"); }

        // площадь
        public override double GetArea { get => Area(); }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Sphere() => _name = "Шар";

        #endregion

        #region Методы 

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}", 12, textColor: ConsoleColor.Cyan);
            WriteColorXY("──────────", 30, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────", 43, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────", 56, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────", 69, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{_radius,10:n3}", 82, textColor: ConsoleColor.Green);
            WriteColorXY("──────────", 95, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Volume(),10:n3}", 108, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{Area(),10:n3}", 121, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // площадь      Источник: http://www.math24.ru/%D1%81%D1%84%D0%B5%D1%80%D0%B0-%D0%B8-%D1%88%D0%B0%D1%80.html
        public double Area() => 4 * Math.PI * (_radius * _radius);

        // объём        Источник: http://www.math24.ru/%D1%81%D1%84%D0%B5%D1%80%D0%B0-%D0%B8-%D1%88%D0%B0%D1%80.html
        public double Volume() => (4 * Math.PI * Math.Pow(_radius, 3)) / 3;

        #endregion

    }
}
