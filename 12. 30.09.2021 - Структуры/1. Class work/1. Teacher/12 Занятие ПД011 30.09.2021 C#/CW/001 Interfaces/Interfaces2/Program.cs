using System;

// Множественное наследование.

namespace Interfaces
{
    class Program
    {
        static void Main()
        {
            Interface1 instance1 = new DerivedClass();
            Interface2 instance2 = new DerivedClass();
            DerivedClass instance3 = new DerivedClass();

            instance1.Method1();
            // instance1.Method2();
            Console.WriteLine();

            instance2.Method2();
            // instance2.Method1();
            Console.WriteLine();

            // объект видит оба метода
            instance3.Method1();
            instance3.Method2();
            Console.WriteLine();
        }
    }
}
