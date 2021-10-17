using System;

// Наследование абстрактных классов от интерфейсов.

namespace Interfaces
{
    interface IInterface
    {
        void Method();
    }

    abstract class AbstractClass : IInterface
    {
        // Реализация абстрактного метода из интерфейса, в абстрактном классе обязательна.
        public void Method()
        {
            Console.WriteLine("Метод - реализация интерфейса в абстрактном классе.");
        }
    }

    class ConcreteClass : AbstractClass
    {
    }

    class Program
    {
        static void Main()
        {
            ConcreteClass instance = new ConcreteClass();
            instance.Method();

            Console.WriteLine();
        }
    }
}
