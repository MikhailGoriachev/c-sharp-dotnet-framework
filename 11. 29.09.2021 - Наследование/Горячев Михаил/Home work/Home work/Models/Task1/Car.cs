using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // для использования утилит

namespace Home_work.Models.Task1
{
    // Класс Машина
    public class Car : Vehicle
    {
        #region Методы

        // вывод элемента в таблицу
        public override void ShowElem(int num)
        {
            WriteColor("     ║    ║                 ║                 ║            ║            ║            ║            ║            ║                         ║", ConsoleColor.Magenta);
            WriteColorXY($"{num,2}",                      7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-15}",                  12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"[{_coord.x:n2};{_coord.y:n2}]",    30, textColor: ConsoleColor.Green);
            WriteColorXY($"{_price,10:n0}",                 48, textColor: ConsoleColor.Green);
            WriteColorXY($"{_speed,10:n0}",                 61, textColor: ConsoleColor.Green);
            WriteColorXY($"──────────",                  74, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"──────────",                  87, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"{_year,10}",                 100, textColor: ConsoleColor.Green);
            WriteColorXY($"────────────────",           113, textColor: ConsoleColor.DarkRed);
            Console.WriteLine();
        }

        #endregion

    }
}
