using System;

// Структуры. Наследование.

// Все структуры неявно наследуются от абстрактного класса - ValueType

namespace Inheritance
{
    struct MyStruct // : ValueType
    {
        public MyStruct(int value)
        {
            Field = value;
        }

        public void Method() {
            Console.WriteLine("Method");
        }

        public int Field { get; set; }

        public override int GetHashCode() => new Random().Next();

        public override string ToString() => $"{Field}";
        public override bool Equals(object obj) => ((MyStruct)obj).Field == Field;
    } // struct MyStruct

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";
            MyStruct instance1 = new MyStruct(1);
            MyStruct instance2 = new MyStruct(2);

            // ValueType valueType = instance as ValueType;
            ValueType valueType = instance1;  // создание клона структуры
            instance1.Field = -1;             // instance1 и valueType независимы

            Console.WriteLine($"instance1  = {instance1}");
            Console.WriteLine($"valueType  = {(MyStruct)valueType}\n");
            Console.WriteLine($"instance2  = {instance2}");
        } // Main
    } // class Program
}
