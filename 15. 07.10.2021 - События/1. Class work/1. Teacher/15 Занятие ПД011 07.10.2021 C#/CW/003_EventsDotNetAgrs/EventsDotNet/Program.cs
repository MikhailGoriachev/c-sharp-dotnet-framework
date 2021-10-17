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
        static void Main(string[] args)
        {
            Utils.Init("Занятие 07.10.2021 - работа с событиями в C# - передача параметров в обработчик - Ctrl+C для выхода(нажимать бесполезно)");

            // Объект класса - источника событий
            Subject subj = new Subject();

            // Наблюдатели - объекты класса Observer1
            Observer1 ob1 = new Observer1("a");
            Observer1 ob2 = new Observer1("b");

            // Подписка на событие Oops - регистрация наблюдателей
            subj.Oops += ob1.OopsEventHandler;        // подписка метода класса
            subj.Oops += ob2.OopsEventHandler;        // подписка метода класса
            subj.Oops += Observer2.OopsEventHandler;  // подписка статического метода класса
            
            // подписка на событие лямбда-выражения
            subj.Oops += (sender, e) => 
                Console.WriteLine($"Лямбда видит... и получает {e.Value}");

            Console.WriteLine();

            // Пример обработчика события консоли - нажатие Ctrl+C или Ctrl+Break
            Console.CancelKeyPress += (sender, eventArgs) => {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                eventArgs.Cancel = true; // отмена завершения приложения
            };
            
            // Далее - только для демонстрации, принудительно зажигаем событие
            // в цикле
            // Закомментируем выражение условия в цикле для демонстрации
            // обработчика события консоли CancelKeyPress
            for (int i = 0;  i < 5; i++) {
                Console.WriteLine($"Итерация {i}:");
                // subj.Value = i;
                subj.OnOops(); // зажигаем!

                // отписка от события - может выполняться в любой момен, как
                // и подписка на события, 
                // один объект может подписаться на событие несколько раз 
                if (i == 2) subj.Oops -= ob1.OopsEventHandler;
                if (i == 3) subj.Oops += ob2.OopsEventHandler; 
                Console.WriteLine();
                Thread.Sleep(1_500);
            } // for i
            
            Console.WriteLine();
            
            // Обработчик события - изменилось значение свойства 
            subj.ChangeValue += ob1.OopsEventHandler;
            for (int i = 0; i < 10; i++) {
                subj.Interest = Utils.Random(-10, 10);
            } // for i
            
        } // Main
    } // class Program
}
