using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work
{
    // Класс Конус
    class Conoid
    {
        // радиус верхнего основания 
        private double _r1;

        // радиус нижнего основания 
        private double _r2;

        // высота 
        private double _height;

        #region Свойства 

        // свойство для _r1
        public double R1 {  get => _r1; set { _r1 = value == _r2 || value < 0 ? -1d : value; } }

        // свойство для _r2
        public double R2 {  get => _r2; set { _r2 = value == _r1 || value < 0 ? -1d : value; } }

        // свойство для _h
        public double H {  get => _height; set { _height = value <= 0d ? -1d : value; } }

        // свойство вычисление объема 
        public double Volume
        {
            get
            {
                // радиус основания и радиус вершины 
                double R = _r1 > _r2 ? _r1 : _r2, r = R != _r1 ? _r2 : _r1;

                return Math.PI / 3 * _height * (Math.Pow(R, 2) + R * r + Math.Pow(r, 2));
            }
        }

        // свойство вычисление площади 
        public double Area
        {
            get
            {

                // радиус основания и радиус вершины 
                double R = _r1 > _r2 ? _r1 : _r2, r = R != _r1 ? _r2 : _r1;

                // образующая Источник https://znanija.com/task/976501
                double l = Math.Sqrt(_height * _height + Math.Pow((R - r), 2));

                // объём Источник: https://geleot.ru/education/math/geometry/area/truncated_cone
                return Math.PI * (R + r) * l;
            }
        }

        #endregion

        #region Методы 

        // компаратор для сортировки по возрастанию объемов
        public static int CompareToVolume(Conoid c1, Conoid c2) => c1.Volume.CompareTo(c2.Volume);

        // компаратор для сортировки по убыванию высот
        public static int CompareToHeight(Conoid c1, Conoid c2) => -c1._height.CompareTo(c2._height);

        // ToString(), выводит только радиус и высоту
        public override string ToString() => $"Радиус верхнего основания: {_r1:n4}\nРадиус нижнего основания: {_r2:n4}\nВысота: {_height:n4}\n";

        // вывод элемента в таблицу 
        public void ShowElem(int num, bool colorActive = false)
        {
            App.WriteColor("      ║    ║                ║                ║                ║                ║                ║", ConsoleColor.Cyan);
            App.WriteColorXY($"{num,2}",        8,  textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_r1,14:n4}",       13, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_r2,14:n4}",       30, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_height,14:n4}",        47, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{Area,14:n4}",      64, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{Volume,14:n4}",    81, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            Console.WriteLine();
        }

        #endregion
    }
}
