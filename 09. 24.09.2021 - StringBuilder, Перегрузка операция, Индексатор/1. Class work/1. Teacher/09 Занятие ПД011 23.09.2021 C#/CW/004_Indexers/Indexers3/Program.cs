using System;

// Индексаторы.

namespace Indexers
{
    class Program
    {
        static void Main()
        {
            Console.Title = "Занятие 23.09.2021 - индексаторы";

            // дополнительное свойство - длина массива в классе MyClass 
            MyClass my = new MyClass();

            for (int i = 0; i < my.Length; i++) {
                my[i] = $"string {i}";
            }
            
            for (int i = 0; i < my.Length; i++) {
                Console.WriteLine(my[i]); 
            }
        }
    }
}
