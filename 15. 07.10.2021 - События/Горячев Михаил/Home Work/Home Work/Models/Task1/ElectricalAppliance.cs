using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;       // подключение утилит

namespace Home_Work.Models.Task1
{
    // тип события PowerChange
    internal delegate void PowerChangeEvent(object sender, PowerChangeEventArgs e);

    // тип события StateChange
    internal delegate void StateChangeeEvent(object sender, StateChangeEventArgs e);

    // Класс Электроприбор
    internal class ElectricalAppliance
    {
        // название
        private string _name;

        // мощность
        private int _power;

        // цена 
        private int _price;

        // состояние питания
        private bool _active;

        #region События

        // событие изменения мощности на нечётное значение 
        public event PowerChangeEvent PowerChange;

        // событие изменения состояния питания
        public event StateChangeeEvent StateChangee;

        #endregion

        #region Свойства

        // доступ к полю _name
        public string Name { get => _name; set => _name = !String.IsNullOrWhiteSpace(value) ? 
                value : throw new Exception("ElectricalAppliance: Поле name не может оставаться пустым!"); }

        // доступ к полю _power
        public int Power
        {
            get => _power; set
            {
                // старое значение мощности 
                int old = _power;

                // присваивание значения
                _power = value >= 0 ?
                       value : throw new Exception($"ElectricalAppliance: Мощность не может быть отрицательной! Значение: {value,5}");

                // если новое значение нечётное
                if (_power != old && (_power & 1) == 1)
                    PowerChange?.Invoke(this, new PowerChangeEventArgs { OldPower = old, NewPower = _power });
            }
        }

        // доступ к полю _price
        public int Price {  get => _price; set => _price = value >= 0 ? 
                value : throw new Exception($"ElectricalAppliance: Цена не может быть отрицательной! Значение: {value,5}"); }

        // статус питания
        public bool StateActive { get => _active; 
            private set {

                // текущее состояние 
                bool old = _active;

                // установка значения
                _active = value;

                // если состояние изменилось
                if (old != value)
                    StateChangee?.Invoke(this, new StateChangeEventArgs { Active = _active });
            }
        }

        // идентификатор (не уникальный, требуется для позиционирования в таблице)
        public int Id { get; set; }

        #endregion

        #region Методы 

        // включение / выключение питания 
        public void TurnPower(bool value) => StateActive = value;

        // вывод элемента в таблицу
        public void ShowElem(int num)
        {
            WriteColorXY("     ║    ║                                ║                      ║            ║            ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name, -30}", 12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_power, 20}", 45, textColor: ConsoleColor.Green);
            WriteColorXY($"{_price, 10}", 68, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{(StateActive ? "Включено" : "Выключено"), -10}", 81, textColor: StateActive ? ConsoleColor.Green : ConsoleColor.DarkRed);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬══════════════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.Magenta);
        }

        #endregion 
    }
}
