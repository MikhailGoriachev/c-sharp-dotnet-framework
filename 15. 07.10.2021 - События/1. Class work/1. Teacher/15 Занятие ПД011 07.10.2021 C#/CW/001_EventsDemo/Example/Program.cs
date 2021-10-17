using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Example
{
    internal class Program
    {
        private static Random _random = new Random();
        static void Main(string[] args)
        {
            Observer2.Two(null);
            Observer2.PriceObserver(null, -1);

            Subject subject = new Subject { Value = 1, Price = 1_000 };

            Observer1 observerA = new Observer1 { Name = "ObserverA" };
            Observer1 observerB = new Observer1 { Name = "ObserverB" };

            // подписка на событие
            subject.Oops += observerA.One;
            subject.Oops += observerB.One;
            subject.Oops += Observer2.Two;
            subject.Oops += (obj) => 
                Console.WriteLine($"Лямбда видит, что Ой-ой-ой, параметр: {(obj as Subject).Value}"); 

            subject.PriceChanging += (obj, newPrice) =>
                Console.WriteLine($"Лямбда видит, новую цену: {newPrice}");
            subject.PriceChanging += observerA.PriceObserver;
            subject.PriceChanging += Observer2.PriceObserver;

            // цикл, имитирующий обработку - приводит к зажиганию события 
            for (int i = 0; i < 10; i++) {
                Console.WriteLine(i);
                // if (i == 3) subject.Oops -= observerA.One;
                // if (i == 5) subject.Oops += observerA.One;

                // subject.FireOops();

                subject.Price = (i & 1) == 0
                    ? _random.Next(1_000, 12_000)
                    :subject.Price;

                Console.WriteLine($"subject.Price = {subject.Price}");
                Console.WriteLine();
                Thread.Sleep(1_500);
            }
        }
    }
}
