using System;

// Структуры. Статический конструктор.

namespace Structure
{
    struct MyStruct
    {
        public static int Test;
        public int Field;
        public int Age;

        // Статический конструктор всегда отрабатывает первым.
        static MyStruct() {
            Test = 1;
            Console.WriteLine("\nStatic Constructor");
        } // MyStruct

        // Если в структуре имеется пользовательский конструктор,
        // то требуется в нем инициализировать все поля.
        public MyStruct(int field, int age) {
            Console.WriteLine("Constructor");
            this.Field = field;
            this.Age = age;
        } // MyStruct
    } // struct MyStruct

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа, 
            // использование конструктора и инициализатора
            
            // !!! вызывается static-конструктор
            MyStruct instance1 = new MyStruct { Field = 10, Age = 33};
            Console.WriteLine("instance1");
            Console.WriteLine($"field = {instance1.Field}; instance.Age = {instance1.Age}; Test = {MyStruct.Test}");

            // !!! не вызывается static-конструктор
            MyStruct instance2 = new MyStruct(20, 55);
            Console.WriteLine("instance2");            
            Console.WriteLine($"field = {instance2.Field}; instance.Age = {instance2.Age}; Test = {MyStruct.Test}");
        } // Main
    } // class Program
}
