using System;

// Множественное наследование от одного класса и нескольких интерфейсов.

namespace Interfaces
{
    class Program
    {
        static void Main()
        {
            DerivedClass instance = new DerivedClass();
            instance.Method();
            instance.Method1();
            instance.Method2();

            Console.WriteLine($"\n{new string('-', 40)}\n");

            // ключевое слово для приведения типа as
            // имя as Тип  --> попытка приведения типа переменной имя к типу Тип
            BaseClass instance0 = instance as BaseClass; // (BaseClass) instance;
            instance0.Method();

            Interface1 instance1 = instance as Interface1;
            instance1.Method1();

            Interface2 instance2 = instance as Interface2;
            instance2.Method2();

            Console.WriteLine();
        }
    }
}
