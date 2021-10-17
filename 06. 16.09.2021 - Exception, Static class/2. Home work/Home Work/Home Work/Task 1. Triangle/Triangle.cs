using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Пространство имён Задание 1. Треугольник
namespace Home_Work.Task_1_Triangle
{
    // Класс Треугольник
    public class Triangle
    {
        // сторона треугольника A
        private double _sideA;

        // сторона треугольника B
        private double _sideB;

        // сторона треугольника C
        private double _sideC;

        #region Свойства 

        // свойство для доступа к полю _sideA
        public double SideA { get => _sideA; }

        // свойство для доступа к полю _sideB
        public double SideB { get => _sideB; }

        // свойство для доступа к полю _sideC
        public double SideC { get => _sideC; }

        // свойство установка сторон труегольника
        public (double sideA, double sideB, double sideC) Sides { get => (_sideA, _sideB, _sideC); set {

                // если полученые значения сторон треугольника валидны
                if (IsTriangle(value))
                {
                    _sideA = value.sideA;
                    _sideB = value.sideB;
                    _sideC = value.sideC;
                }

                // иначе
                else
                    throw new TriangleException("Данные треугольника невалидны!", value);
            } 
        }

        #endregion

        #region Конструкторы

        // инициализирующий конструктор | Делегирование инициализирующему конструктору принимающему кортеж
        public Triangle(double sideA, double sideB, double sideC) : this((sideA, sideB, sideC)) { }

        // инициализирующий конструктор 
        public Triangle((double sideA, double sideB, double sideC) sides) 
        {
            // установка значений
            Sides = sides;
        }

        #endregion

        #region Методы 

        // проверка данных сторон треугольника на валидность
        static public bool IsTriangle((double sideA, double sideB, double sideC) t)
                    => (t.sideA + t.sideB) > t.sideC && (t.sideB + t.sideC) > t.sideA && (t.sideC + t.sideA) > t.sideB;

        // площадь
        public double Area()
        {
            // радиус вписанной окружности
            // Источник: https://ppt4web.ru/geometrija/radius-vpisannojj-i-opisannojj-okruzhnosti.html
            double r = (_sideA * _sideB) / (_sideA + _sideB + _sideC);

            // площадь треугольника
            // Источник: https://skysmart.ru/articles/mathematic/ploshad-treugolnika
            return (_sideA * _sideB * _sideC) / (4 * r);
        }

        // периметр
        public double Perimeter() => _sideA + _sideB + _sideC;

        // медианы
        // Источник: https://ru.wikipedia.org/wiki/%D0%9C%D0%B5%D0%B4%D0%B8%D0%B0%D0%BD%D0%B0_%D1%82%D1%80%D0%B5%D1%83%D0%B3%D0%BE%D0%BB%D1%8C%D0%BD%D0%B8%D0%BA%D0%B0
        public (double medA, double medB, double medC) Median() => 
            (((Math.Sqrt((2 * (_sideB * _sideB) + 2 * (_sideC * _sideC) - _sideA) / 4))),
            ((Math.Sqrt((2 * (_sideA * _sideA) + 2 * (_sideC * _sideC) - _sideB) / 4))),
            ((Math.Sqrt((2 * (_sideA * _sideA) + 2 * (_sideB * _sideB) - _sideC) / 4))));

        // вывод элемента в таблицу 
        public void ShowElem(int num, bool activeColor = false)
        {
            // медианы 
            var m = Median();

            App.WriteColor("     ║    ║            ║            ║            ║            ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            App.WriteColorXY($"{num, 2}",                  7, textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_sideA,         10:n3}",  12, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{_sideB,         10:n3}",  25, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{_sideC,         10:n3}",  38, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{Perimeter(),    10:n3}",  51, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.DarkYellow ));
            App.WriteColorXY($"{Area(),         10:n3}",  64, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.DarkYellow));
            App.WriteColorXY($"{m.medA,         10:n3}",  77, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Cyan));
            App.WriteColorXY($"{m.medB,         10:n3}",  90, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Cyan));
            App.WriteColorXY($"{m.medC,         10:n3}", 103, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Cyan));
            Console.WriteLine();
        }

        #endregion
    }
}
