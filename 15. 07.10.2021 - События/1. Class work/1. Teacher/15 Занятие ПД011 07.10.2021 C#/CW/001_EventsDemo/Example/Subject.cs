using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    // делегат обработчика события Oops
    internal delegate void Handler(object obj);

    // делегат обработчика события PriceChanging
    internal delegate void PriceChangingHandler(object obj, int newPrice);

    internal class Subject
    {
        public int Value { get; set; }


        public override string ToString() => $"{Value}";

        // поле события
        // доступ event ДелегатСигнатураОбработчика ИмяСобытия
        public event Handler Oops;

        // метод, зажигающий событие Oops
        public void FireOops() {
            
            // имитация изменени состояния объекта
            Value = DateTime.Now.Second;
            Console.WriteLine($"Subject: Ой-ой-ой, что-то случилось. Параметр {Value}");

            // if (Oops != null) Oops.Invoke(this);
            Oops?.Invoke(this);
        } // FireOops

        public event PriceChangingHandler PriceChanging; 

        // свойство, за изменениями которого мы будем наблюдать
        private int _price;
        public int Price {
            get => _price;
            set {
                // if (value <= 0)
                //     throw new ArgumentOutOfRangeException("Недопустимое значение цены");

                // зажигаем событие
                if (_price != value)
                    PriceChanging?.Invoke(this, value);

                _price = value;
            }
        }

    }
}
