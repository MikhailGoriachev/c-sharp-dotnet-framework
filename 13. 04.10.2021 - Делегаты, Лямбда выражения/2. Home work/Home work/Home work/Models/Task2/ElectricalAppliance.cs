using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // подключение утилит

namespace Home_work.Models.Task2
{
    // Класс Электроприбор
    internal class ElectricalAppliance
    {
        // название
        private string _name;

        // мощность
        private int _power;

        // цена 
        private int _price;

        #region Свойства

        // доступ к полю _name
        public string Name { get => _name; set => _name = !String.IsNullOrWhiteSpace(value) ? 
                value : throw new Exception("ElectricalAppliance: Поле name не может оставаться пустым!"); }

        // доступ к полю _power
        public int Power { get => _power; set => _power = value >= 0 ? 
                value : throw new Exception($"ElectricalAppliance: Мощность не может быть отрицательной! Значение: {value,5}"); }

        // доступ к полю _price
        public int Price {  get => _price; set => _price = value >= 0 ? 
                value : throw new Exception($"ElectricalAppliance: Цена не может быть отрицательной! Значение: {value,5}"); }

        // статус питания
        public bool StateActive { get; private set; } = false;

        #endregion

        #region Методы 

        // включение / выключение питания 
        public void TurnPower(bool value) => StateActive = value;

        // вывод элемента в таблицу
        public void ShowElem(int num)
        {
            WriteColorXY("     ║    ║                                ║            ║            ║            ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name, -30}", 12, textColor: ConsoleColor.Green);
            WriteColorXY($"{_power, 10}", 45, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_price, 10}", 58, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{(StateActive ? "Включено" : "Выключено"), -10}", 71, textColor: StateActive ? ConsoleColor.Green : ConsoleColor.DarkRed);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.Magenta);
        }

        #endregion 
    }
}
