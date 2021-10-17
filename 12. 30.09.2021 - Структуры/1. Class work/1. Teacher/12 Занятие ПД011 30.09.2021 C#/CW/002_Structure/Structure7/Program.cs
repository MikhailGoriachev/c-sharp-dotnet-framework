using System;

// Структуры. Конструкторы.

namespace Structure
{
    struct MyStruct
    {
        public int Field;

        // Пользовательский конструктор с параметрами.
        public MyStruct(int value = 121) {
            this.Field = value;

            Console.WriteLine($"constructor: {value}");

        } // MyStruct
    } // struct MyStruct

    class Program
    {
        static void Main() {

            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа без вызова конструктора.
            // MyStruct instance;
            MyStruct instance1 = new MyStruct();  // вызывается конструктор по умолчанию !!!
            MyStruct instance2 = new MyStruct(11);


            // Нельзя использовать не инициализированную переменную.
            // Так как конструктор не вызывался переменная field осталась не инициализированной.

            Console.WriteLine(instance1.Field);   // Убрать комментарий.
            Console.WriteLine(instance2.Field);   // Убрать комментарий.
            Console.WriteLine();
        } // Main
    } // class Program
}
