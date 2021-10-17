using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDemo
{
    class Program
    {
        static void Main(string[] args) {
            Utils.Init("Занятие 07.10.2021 - работа с событиями в C#");

            // Объект класса - источника событий
            Subject subj = new Subject();

            // Наблюдатели - объекты класса Observer1
            Observer1 ob1 = new Observer1("Observer1 ob1");
            Observer1 ob2 = new Observer1("Observer1 ob2");

            // Подписка на событие Oops - регистрация наблюдателей
            subj.Oops += ob1.One;        // подписка метода класса
            subj.Oops += ob2.One;        // подписка метода класса
            subj.Oops += Observer2.Two;  // подписка статического метода класса

            // подписка на событие лямбда-выражения
            // subj.Oops += obj => Console.WriteLine($"Лямбда видит... и получает {((Subject)obj).Value}");
            // subj.Oops += obj => Console.WriteLine($"Лямбда видит... и получает {(obj as Subject).Value}");
            // вариант с Элвис-оператором
            subj.Oops += obj => Console.WriteLine($"Лямбда видит... и получает {(obj as Subject)?.Value}");

            Console.WriteLine();

            // Далее - только для демонстрации, принудительно зажигаем событие
            // в цикле
            for (int i = 0; i < 5; i++) {
                subj.FireOops(); // зажигаем!

                // отписка от события - может выполняться в любой момент, как
                // и подписка на события, 
                // один объект может подписаться на событие несколько раз 
                if (i == 2) subj.Oops -= ob1.One;
                if (i == 3) subj.Oops += ob2.One; 
                Console.WriteLine();
                Thread.Sleep(1_200);
            } // for i
            
        } // Main
    } // class Program
}
