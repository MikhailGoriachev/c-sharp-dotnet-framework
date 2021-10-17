using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;       // подключение утилит

namespace Home_Work.Models.Task1
{
    /* 
     * Наблюдатель2, который выводит состояние соответствующего 
     * прибора в консоли (в строке, соответствующего прибора в 
     * таблице): красный фон для выключенного прибора, зеленый 
     * фон для включенного прибора.
     */

    // Класс Наблюдатель 2
    internal class Observer2
    {
        public void StateChangeEventHandle(object sender, StateChangeEventArgs e)
        {
            // текущая позиция курсора по x и y
            (int x, int y) cur = (Console.CursorTop, Console.WindowTop);

            // преобразование типа 
            ElectricalAppliance electrical = sender as ElectricalAppliance;

            // вывод старых и новых данных
            WriteColorXY($"{ (e.Active ? "Включено" : "Выключено"), -10}", 81, (electrical?.Id * 2) + 9 ?? throw new Exception("Observer1: Не удалось преобразовать тип"), textColor: e.Active ? ConsoleColor.Green : ConsoleColor.DarkRed);

            // установка курсора на исходную позицию
            PosXY(cur.x, cur.y);
        }
    }
}
