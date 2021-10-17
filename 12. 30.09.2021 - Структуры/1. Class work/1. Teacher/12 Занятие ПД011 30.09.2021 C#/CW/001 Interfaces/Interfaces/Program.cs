using System;

// Интерфейсы.

namespace Interfaces
{
    // объявление интерфейса
    interface IInterface
    {
        void Method();
    }

    // реализация интерфейса в классе MyClass1
    class MyClass1 : IInterface
    {
        public void Method()
        {
            Console.WriteLine("MyClass1 - реализация интерфейса IInterface.");
        }
        public void Foo() { }
    } // class MyClass1

    class MyClass2: IInterface
    {
        public void Method() {
            Console.WriteLine("MyClass2 - реализация интерфейса IInterface.");
        }

        public void Baz() { }
    }

    class Program
    {
        static void Main()
        {
            MyClass1 my1 = new MyClass1();
            MyClass2 my2 = new MyClass2();

            my1.Method();
            my2.Method();
            Console.WriteLine();

            IInterface instance1 = my1;
            IInterface instance2 = my2;

            instance1.Method();
            instance2.Method();
            Console.WriteLine();

            // полиморфизм на уровне интерфейса
            IInterface instance = my1;
            instance.Method();

            instance = my2;
            instance.Method();
            Console.WriteLine();
        }
    }
}
