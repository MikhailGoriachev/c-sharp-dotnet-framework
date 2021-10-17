using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDemo
{
    // Еще один класс-наблюдатель, демонстрирует, что регистрировать, как
    // обработчик события можно статические методы 
    class Observer2
    {
        // сигнатура обработчика соответствует делегату Handler
        public static void Two(object obj) {
            // без элвис-оператора
            // Console.WriteLine($"Observer2: Я тоже вижу, что ой-ой-ой, получил {((Subject)obj).Value}");

            // с оператораом as и элвис-оператором
            Console.WriteLine($"Observer2: Я тоже вижу, что ой-ой-ой, получил {(obj as Subject)?.Value}");
        } // Two
    } // class Observer2
}
