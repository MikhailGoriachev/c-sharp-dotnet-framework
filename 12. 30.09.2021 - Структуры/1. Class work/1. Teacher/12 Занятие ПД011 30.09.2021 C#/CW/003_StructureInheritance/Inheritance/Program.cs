using System;

// Структуры. Наследование.

// Наследование структур разрешено только от интерфейсов.
// Наследование структур, от классов и структур запрещено.

namespace Inheritance
{
    interface IInterface
    {
        void Method();
    }

    struct MyStruct : IInterface
    {
        public void Method() => Console.WriteLine("Method");
    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";
            MyStruct instance;

            instance.Method();

            // полиморфизм :) подстановка Лисков
            IInterface item = instance;
            item.Method();
        }
    }
}
