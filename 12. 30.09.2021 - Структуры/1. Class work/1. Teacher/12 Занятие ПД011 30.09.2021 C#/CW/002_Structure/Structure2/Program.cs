using System;

// Структуры.
// Если в структуре имеются члены, которые обращаются к полю и нет пользовательского конструктора,
// то требуется при создании экземпляра вызывать конструктор по умолчанию. (Иначе будет ошибка.)

namespace Structure
{
    struct MyStruct
    {
        // свойство в структуре - требует вызова конструктора
        private int _field;
        public int Field {
            get => _field;
            set => _field = value;
        }

        // метод в структуре - для использования не требуется конструктор
        public void Show() =>
            Console.WriteLine(_field);
    } // struct MyStruct

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа с вызовом конструктора по умолчанию.
            MyStruct instance1 = new MyStruct();
            instance1.Field = 1;

            // более современный подход
            MyStruct instance2 = new MyStruct { Field = 100 };
            Console.WriteLine($"Вывод поля структуры 1. Field = {instance1.Field}\n\n");
            Console.WriteLine($"Вывод поля структуры 2. Field = {instance2.Field}\n\n");

            instance1.Show();
            instance2.Show();
        } // Main
    } // class Program
}
