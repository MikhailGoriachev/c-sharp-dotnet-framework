using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    // Еще один класс-наблюдатель, демонстрирует, что регистрировать
    // как обработчик события можно статические методы 
    class Observer2
    {
        public static void OopsEventHandler(object sender, EventArgs e) {
            Console.WriteLine($"Observer2: Я тоже вижу, что ой-ой-ой, получил {(sender as Subject)?.Value}");
        } // OopsEventHandler
    } // class Observer2
}
