using System;

// Структуры.
// Конструкторы с параметрами

namespace Structure
{
    struct MyStruct
    {
        public int Field;

        // Конструкторы по умолчанию нельзя задавать явно.
        //public MyStruct()
        //{
        //}

        // Если в структуре имеется пользовательский конструктор,
        // то требуется в нем инициализировать все поля.
        public MyStruct(int value) {
            Console.WriteLine("Constructor");
            this.Field = value;
        } // MyStruct
    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа, с вызовом пользовательского конструктора.            
            MyStruct instance1 = new MyStruct(1);

            Console.WriteLine($"Вывод поля структуры. Field = {instance1.Field}\n");

            // конструктор по умолчанию по-прежнему доступен
            MyStruct instance2 = new MyStruct();
            Console.WriteLine($"Вывод поля структуры. Field = {instance2.Field}\n\n");
        }
    }
}
