using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Перегрузка операции приведения типа
// неявное приведение
// public static implicit operator ТипКкоторомуПриводим(ТипЗначения имя)
// {
//     return new ТипКкоторомуПриводим { использовать переменную имя для задания поля/полей};
// }
//
// применение
// ТипЗначения имя2;                       Тип2 имя2;           float a;
// ТипКкоторомуПриводим имя1 = имя2;       Тип1 имя1 = имя2;    double b = a;
// 


// явное приведение типа
// public static explicit operator Тип1(Тип2 имя)
// {
//     return тип.ПолеТип1;
// }
//
// применение - явное приведение объекта имя2 к типу Тип1
// Тип2 имя2;                    double a;
// Тип1 имя1 = (Тип1)имя2;       float  b = (float)a;

namespace Overload
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 23.09.2021 - перегруженные операции";

            Counter counter1 = new Counter { Seconds = 115 };
            Console.WriteLine($"counter1 = {counter1}");

            // применение неявного приведение типа int -> Counter
            counter1 = 1_000;
            Console.WriteLine($"counter1 = {counter1}");

            counter1.Seconds = 288;
            Console.WriteLine($"counter1 = {counter1}");
            
            // применение неявного приведение типа Counter -> Timer
            Timer timer = counter1;
            Console.WriteLine($"{timer.Hours}:{timer.Minutes}:{timer.Seconds}"); // 0:1:55
 
            // применение операции явного приведения типа
            Counter counter2 = (Counter)timer;
            Console.WriteLine(counter2.Seconds);  //115
        } // Main
    } // class Program

    // пример класса для использования в демонстрации перегрузки
    // операторов приведения типов
    class Timer
    {
        public int Hours { get; set; }
        public int Minutes { get; set; }    
        public int Seconds { get; set; }
    } // class Timer


    // пример класса с перегрузкой операций приведения типа
    class Counter
    {
        public int Seconds { get; set; }
 
        // неявное приведение int -> Counter
        public static implicit operator Counter(int value) =>
            new Counter {  Seconds = value };

        // явное приведение типа int -> Counter
        // !! может быть либо implicit либо explcit, но не два приведения типа вместе  
        // public static explicit operator Counter(int value) =>
        //     new Counter { Seconds = value };




        // явное приведение типа Counter -> int
        public static explicit operator int(Counter counter) {
            return counter.Seconds;
        } //  operator int

        // неявное приведение Counter -> Timer
        public static implicit operator Timer(Counter counter) {
            int h = counter.Seconds / 3600;
            int m = (counter.Seconds % 3600) / 60;
            int s = counter.Seconds % 60;
            return new Timer { Hours = h, Minutes = m, Seconds = s };
        } // operator Timer


        // явное приведение типа Timer -> Counter
        public static explicit operator Counter(Timer timer) =>
            new Counter { Seconds = timer.Hours* 3600 + timer.Minutes* 60 + timer.Seconds };



        public override string ToString() => $"{Seconds}";
    } // class Counter
}
