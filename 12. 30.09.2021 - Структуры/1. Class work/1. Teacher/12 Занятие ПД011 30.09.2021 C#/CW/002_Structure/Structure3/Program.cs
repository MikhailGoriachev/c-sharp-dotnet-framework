using System;

// Структуры.

namespace Structure
{
    struct MyStruct
    {
        public int Field;
        public int Age;

        // Конструкторы по умолчанию нельзя задавать явно.
        // public MyStruct()
        // {
        // }

        // Если в структуре имеется пользовательский конструктор,
        // то требуется в нем инициализировать все поля.
        public MyStruct(int value) {
            Console.WriteLine("Constructor");
            this.Field = value;
            Age = 34;
        } // MyStruct
    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа с вызовом конструктора по умолчанию.
            MyStruct instance = new MyStruct();

            Console.WriteLine($"Вывод поля структуры. Field = {instance.Field}, Age = {instance.Age}\n\n");

            // конструктор с параметрами показываем в следующем примере
            instance = new MyStruct(-42);
            Console.WriteLine($"Вывод поля структуры. Field = {instance.Field}, Age = {instance.Age}\n\n");
        } // Main
    } // class Program
}
