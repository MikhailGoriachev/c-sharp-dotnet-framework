using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EventsDotNet
{
    class Program
    {
        static void Main(string[] args) {
            //Console.CancelKeyPress += (o, e) => {
            //    Console.BackgroundColor = ConsoleColor.DarkRed;
            //    Console.Clear();
            //};

            Utils.Init("Занятие 07.10.2021 - работа с событиями в C#, .NET соглашения");

            // Объект класса - источника событий
            Subject subj = new Subject();

            // Наблюдатели - объекты класса Observer1
            Observer1 ob1 = new Observer1("Observer1 a");
            Observer1 ob2 = new Observer1("Observer1 b");

            // Подписка на событие Oops - регистрация наблюдателей
            subj.Oops += ob1.OopsEventHandler;        // подписка метода класса
            subj.Oops += ob2.OopsEventHandler;        // подписка метода класса
            subj.Oops += Observer2.OopsEventHandler;  // подписка статического метода класса
            
            // подписка на событие лямбда-выражения
            subj.Oops += (sender, e) => 
                    Console.WriteLine($"Лямбда видит... и получает {(sender as Subject)?.Value}");

            Console.WriteLine();

            // Далее - только для демонстрации, принудительно зажигаем событие
            // в цикле
            for (int i = 0; i < 5; i++) {
                Console.WriteLine($"\nИтерация i = {i}");
                subj.OnOops(); // зажигаем!

                // отписка от события - может выполняться в любой момен, как
                // и подписка на события, 
                // один объект может подписаться на событие несколько раз 
                if (i == 2) subj.Oops -= ob1.OopsEventHandler;
                if (i == 3) subj.Oops += ob2.OopsEventHandler; 

                Thread.Sleep(1_200);
            } // for i

            Console.WriteLine("\n");
        } // Main
    } // class Program
}
