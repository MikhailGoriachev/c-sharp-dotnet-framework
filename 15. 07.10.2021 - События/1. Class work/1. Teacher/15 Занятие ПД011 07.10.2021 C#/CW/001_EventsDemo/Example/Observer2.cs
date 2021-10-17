using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class Observer2
    {
        // обработчик/слушатель событий
        public static void Two(object obj)
        {
            Console.WriteLine($"Observer: Вижу, что Ой-ой-ой, параметр: {(obj as Subject)?.Value}");
        } // Two

        public static void PriceObserver(object obj, int newPrice)
        {
            Console.WriteLine($"Observer видит новую цену: {newPrice}");
        }
    }
}
