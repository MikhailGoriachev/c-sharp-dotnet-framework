using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;       // подключение утилит

namespace Home_Work.Models.Task1
{
    /*
     * Наблюдатель1, который будет выводить старую и новую 
     * мощность прибора в консоль в строке таблицы для 
     * соответствующего прибора
     */

    // Класс Наблюдатель 1
    internal class Observer1
    {
        // обработчик 1
        public void PowerChangeEventHandle(Object sender, PowerChangeEventArgs e)
        {       
            // текущая позиция курсора по x и y
            (int x, int y) cur = (Console.CursorTop, Console.WindowTop);

            // преобразование типа 
            ElectricalAppliance electrical = sender as ElectricalAppliance;

            // вывод старых и новых данных
            WriteColorXY($"{e.OldPower, 10} --> {e.NewPower, 5}", 45, (electrical?.Id * 2) + 9 ?? throw new Exception("Observer1: Не удалось преобразовать тип"), textColor: ConsoleColor.Blue);

            // установка курсора на исходную позицию
            PosXY(cur.x, cur.y);
        }
    }
}
