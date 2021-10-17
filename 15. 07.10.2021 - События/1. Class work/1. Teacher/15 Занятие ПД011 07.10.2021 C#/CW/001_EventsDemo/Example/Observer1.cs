using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    internal class Observer1
    {
        // имя наблюдателя
        public string Name { get; set; }

        // обработчик/слушатель событий
        public void One(object obj) {
            Console.WriteLine($"{Name}: Вижу, что Ой-ой-ой, параметр: {(obj as Subject).Value}");
        } // One

        public void PriceObserver(object obj, int newPrice) {
            Console.WriteLine($"{Name} видит новую цену: {newPrice}");
        }
    }
}
