using System;

// Упаковка и распаковка - Хранитель - Memento 

namespace Boxing
{
    struct MyStruct //: ValueType
    {
        public void Method()
        {
            Console.WriteLine("Method");
        }

        public int Field1 { get; set; }
        public double Field2 { get; set; }

        public MyStruct(int field1, double field2) {
            Field1 = field1;
            Field2 = field2;
        }

        public override string ToString() => $"{Field1}; {Field2}";
    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - упаковка и распаковка";

            MyStruct my = new MyStruct(100, Math.PI);
            my.Method();
            Console.WriteLine($"my: {my}");

            // Упаковка (Boxing) - запись в Хранитель
            ValueType boxed = my;
            // boxed.Method();
            
            // Распаковка объекта (UnBoxing) - чтение из Хранителя
            MyStruct unBoxed = (MyStruct)boxed;
            unBoxed.Method();
            Console.WriteLine($"unBoxed: {unBoxed}");
        } // Main
    } // class Program
}
