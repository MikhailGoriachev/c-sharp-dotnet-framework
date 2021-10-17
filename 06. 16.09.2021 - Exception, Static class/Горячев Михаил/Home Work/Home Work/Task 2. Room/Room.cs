using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Пространство имен Задание 2. Комната
namespace Home_Work.Task_2_Room
{
    // Класс Комната
    public class Room
    {
        // площадь комнаты
        private double _area;

        // высота потолков
        private double _height;

        // количество окон
        private int _window;

        #region Свойства

        // свойство для доступа к полю _area
        public double Area { get => _area; }

        // свойство для доступа к полю _height
        public double Height { get => _height; }

        // свойство для доступа к полю _window
        public int Window { get => _window; }

        // свойство для получения и установки состояния объекта
        public (double area, double height, int window) State { get => (_area, _height, _window);
            set {

                // если данные некорректны
                if (value.area <= 0d || value.height <= 0d || value.window < 0)
                    throw new RoomException("Данные комнаты невалидны!", value);

                // установка значений
                (_area, _height, _window) = value;

                } 
        }

        #endregion

        #region Методы 

        // объем 
        public double Volume() => _area * _height;

        // вывод комнаты в таблицу 
        public void ShowElem(int num, bool activeColor = false)
        {

            App.WriteColor("          ║    ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            App.WriteColorXY($"{num,2}",            12, textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_area,10:n3}",      17, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{_height,10:n3}",    30, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{_window,10   }",    43, textColor: (activeColor ? ConsoleColor.Cyan : ConsoleColor.Green));
            App.WriteColorXY($"{Volume(),10:n3}",   56, textColor: (activeColor ? ConsoleColor.Green : ConsoleColor.Cyan));
            Console.WriteLine();
        }

        #endregion
    }
}
