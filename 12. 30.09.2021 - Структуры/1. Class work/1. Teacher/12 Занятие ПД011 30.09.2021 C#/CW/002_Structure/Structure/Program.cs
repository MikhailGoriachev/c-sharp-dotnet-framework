using System;

// Структуры.
// В структурах нельзя инициализировать поля непосредственно в месте создания.

namespace Structure
{
    struct MyStruct  // пример структуры
    {
        public int Field;

    }

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            // Создание экземпляра структурного типа, без вызова конструктора.
            MyStruct instance;

            instance.Field = 1; // Закомментировать.

            // Попытка вывода значения неинициализированного поля приведет к ошибке.
            Console.WriteLine(instance.Field);
        } // Main
    } // class Program
}
