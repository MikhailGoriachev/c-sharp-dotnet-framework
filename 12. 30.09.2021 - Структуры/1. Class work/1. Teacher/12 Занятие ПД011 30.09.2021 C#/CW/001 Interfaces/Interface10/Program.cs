using System;

// Наследование от класса и интерфейса у которых совпадают сигнатуры членов.

namespace Interfaces
{
    interface IInterface
    {
        void Method();
    }

    class BaseClass
    {
        public void Method()
        {
            Console.WriteLine("BaseClass.Method()");
        }
    }

    class DerivedClass : BaseClass, IInterface
    {
        // Реализация интерфейса не обязательна, т.к., 
        // сигнатуры методов в классе и интерфейсе совпадают.
        // public new void Method() => Console.WriteLine("\nПривет!"); 
    }

    class Program
    {
        static void Main()
        {
            DerivedClass instance = new DerivedClass();
            instance.Method();
            Console.WriteLine();

            IInterface instance1 = instance as IInterface;
            instance1.Method();

            Console.WriteLine();
        }
    }
}
