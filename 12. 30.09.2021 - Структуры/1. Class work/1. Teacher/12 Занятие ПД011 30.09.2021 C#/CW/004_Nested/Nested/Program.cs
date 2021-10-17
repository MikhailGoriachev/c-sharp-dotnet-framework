using System;

// Nested structures.

namespace Nested
{
    struct MyStruct
    {
        private int a;


        public struct Nested
        {
            MyStruct m;
            int a;

            public void Method() {
                Console.WriteLine($"Nested {m.a}");
            }
        }
    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - вложенные структуры";

            MyStruct.Nested instance = new MyStruct.Nested();
            instance.Method();
        }
    }
}
