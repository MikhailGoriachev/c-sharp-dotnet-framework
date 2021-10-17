using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task1
{
    // Класс Самолёт
    public class Plane : Vehicle
    {
        // количество пассажиров
        private int _passengers;

        // порт приписки
        private int _height;

        #region Свойства

        // доступ к полю _price
        public int Passengers
        {
            get => _passengers; set => _passengers = value >= 0 ? value :
                throw new Exception($"Ship: Некорректные данные! Данные: Пассажиры[{value}]");
        }

        // доступ к полю _height
        public int Height
        {
            get => _height; set => _height = value >= 0 ? value :
                throw new Exception($"Ship: Некорректные данные! Данные: Высота[{value}]");
        }

        #endregion

        #region Методы

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║                 ║            ║            ║            ║            ║            ║                         ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",                   7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}",               12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"[{_coord.x:n2};{_coord.y:n2}]", 30, textColor: ConsoleColor.Green);
            WriteColorXY($"{_price,10:n0}",              48, textColor: ConsoleColor.Green);
            WriteColorXY($"{_speed,10:n0}",              61, textColor: ConsoleColor.Green);
            WriteColorXY($"{_height,10:n0}",             74, textColor: ConsoleColor.Green);
            WriteColorXY($"{_passengers,10:n0}",         87, textColor: ConsoleColor.Green);
            WriteColorXY($"{_year,10}",              100, textColor: ConsoleColor.Green);
            WriteColorXY($"────────────────",        113, textColor: ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        #endregion

    }
}
