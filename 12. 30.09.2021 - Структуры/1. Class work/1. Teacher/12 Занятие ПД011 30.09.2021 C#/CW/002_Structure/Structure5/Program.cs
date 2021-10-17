using System;

// Структуры.

// Структуры могут содержать статические члены.
// Статические структуры недопустимы.

namespace Structure
{
    struct MyStruct
    {
        // статические члены инициируются автоматически
        public static int Field { get; set; }

        public static void Show() =>
            Console.WriteLine($"MyStruct.Field = {Field}\n\n");

        public int Age { get; set; }
        public override string ToString() => $"static Field = {Field}; Age = {Age}";
    } // struct MyStruct

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";
            MyStruct.Show();

            // Инициализация статических полей необязательна.
            MyStruct.Field = 42;
            MyStruct.Show();

            // при выводе статическое поле имеет значение 211 (см. строку 29)
            MyStruct instance = new MyStruct { Age = 33};
            Console.WriteLine($"{instance}");
        }
    }
}
