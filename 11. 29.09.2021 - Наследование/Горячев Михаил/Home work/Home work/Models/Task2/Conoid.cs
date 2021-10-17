using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Interface;                          // подключение интерфейсов

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task2
{
    // Класс Конус
    public class Conoid : Figure, IVolumetricFigure
    {
        // высота 
        private double _height;

        // радиус
        private double _radius;

        #region Свойства 

        // доступ к полю _height
        public double Height { get => _height; set => _height = value > 0d ? value : throw new Exception($"Conoid: Некорректное значение высоты! Значение: {value}"); }

        // доступ к полю _radius
        public double Radius { get => _radius; set => _radius = value > 0d ? value : throw new Exception($"Conoid: Некорректное значение радиуса! Значение: {value}"); }

        // образующая      Источник: http://ru.solverbook.com/question/kak-najti-obrazuyushhuyu-konusa/
        private double Generatrix { get => Math.Sqrt((_height * _height) + (_radius * _radius)); }

        // площадь
        public override double GetArea { get => Area(); }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Conoid() => _name = "Конус";

        #endregion

        #region Методы 

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",              7, textColor:ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}",         12, textColor: ConsoleColor.Cyan);
            WriteColorXY("──────────",          30, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",          43, textColor: ConsoleColor.DarkRed);
            WriteColorXY("──────────",          56, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{_height,10:n3}",     69, textColor:ConsoleColor.Green);
            WriteColorXY($"{_radius,10:n3}",     82, textColor:ConsoleColor.Green);
            WriteColorXY("──────────",         95, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{Volume(),10:n3}",   108, textColor:ConsoleColor.Cyan);
            WriteColorXY($"{Area(),10:n3}",     121, textColor:ConsoleColor.Cyan);
            Console.WriteLine();
        }

        // площадь      Источник: https://www.rapidus.ru/area-of-cone.html
        public double Area()
        {
            // образующая 
            double l = Generatrix;

            return Math.PI * _radius * (_radius + l);
        }

        // объём        Источник: https://www.webmath.ru/web/prog39_1.php
        public double Volume() => (_height / 3) * Math.PI * (_radius * _radius);

        #endregion

    }
}
