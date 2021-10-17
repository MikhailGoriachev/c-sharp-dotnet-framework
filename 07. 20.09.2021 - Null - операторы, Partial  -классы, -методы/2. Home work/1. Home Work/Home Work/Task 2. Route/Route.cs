using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Класс Маршрут
namespace Home_Work.Task_2._Route
{
    internal class Route
    {
        // пункт отправления
        private string _pointDepart;

        // пункт назначения
        private string _pointDest;

        // буквенно-цифровой код маршрута
        private string _codeRoute;

        // дистанция маршрута в километрах
        private int _distance;

        #region Свойства

        // доступ к полю _pointDepart
        public string PointDepart { get => _pointDepart; set => _pointDepart = String.IsNullOrWhiteSpace(value) ? _pointDepart : value; }

        // доступ к полю _pointDest
        public string PointDest { get => _pointDest; set => _pointDest = String.IsNullOrWhiteSpace(value) ? _pointDest : value; }

        // доступ к полю _codeRoute
        public string CodeRoute { get => _codeRoute; set => _codeRoute = String.IsNullOrWhiteSpace(value) ? _codeRoute : value; }

        // доступ к полю _distance
        public int Distance { get => _distance; set => _distance = value < 0 ? throw new Exception($"Невалидные данные дистанции {value}") : value; }

        #endregion

        #region Методы 

        // вывод маршрута в таблицу
        public void ShowElem(int num)
        {
            App.WriteColorXY("          ║    ║                      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"{num,2}", 12, textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_pointDepart ?? "Нет данных",-20}", 17, textColor: ConsoleColor.Green);
            App.WriteColorXY($"{_pointDest ?? "Нет данных",-20}", 40, textColor: ConsoleColor.Green);
            App.WriteColorXY($"{_codeRoute,-10}", 63, textColor: ConsoleColor.Cyan);
            App.WriteColorXY($"{_distance,10:n0}", 76, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        #endregion
    }
}
