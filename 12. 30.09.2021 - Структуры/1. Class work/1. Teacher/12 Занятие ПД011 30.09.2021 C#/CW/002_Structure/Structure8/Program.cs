using System;

// Структуры.

// В структурах можно создавать автоматически реализуемые свойства,
// при этом требуется использовать конструктор при построении экземпляра.

namespace Structure
{
    struct MyStruct
    {
        public int MyProperty { get; set; }
    } // struct MyStruct

    class Program
    {
        static void Main() {
            Console.Title = "Занятие 30.09.2021 - структуры";

            MyStruct instance = new MyStruct();
            instance.MyProperty = 1; 
            Console.WriteLine(instance.MyProperty);
            
            // рекомендуется - без явного вызова конструктора
            instance = new MyStruct { MyProperty = 11 };
            Console.WriteLine(instance.MyProperty);

            // Delay.
        } // Main
    } // class Program
}
