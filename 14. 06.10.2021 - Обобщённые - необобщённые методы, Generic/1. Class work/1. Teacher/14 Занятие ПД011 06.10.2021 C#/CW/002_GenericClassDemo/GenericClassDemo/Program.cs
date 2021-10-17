using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    // значения по умолчанию для обобщенных типов
    // ограничения обобщенных типов
    
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "занятие 06.10.2021 - обобщенные типы, обобщенные классы, ограничения";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            /*
            // создание объектов обобщенного класса
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nОбъекты обобщенного класса");
            Console.ForegroundColor = ConsoleColor.Cyan;

            GenericClass<int, bool>    obj1 = new GenericClass<int, bool>();
            GenericClass<int, bool>    obj2 = new GenericClass<int, bool>(-5, true);
            GenericClass<char, double> obj3 = new GenericClass<char, double>('ё', Math.PI);
            GenericClass<int, string>  obj4 = new GenericClass<int, string>(101, "Это generic");

            Console.WriteLine($"obj1: {obj1};\nobj2: {obj2};\nobj3: {obj3}\nobj4: {obj4}\n");
            */
            
            Console.WriteLine("\nИспользование обобщенных классов - обобщенный контейнер\n");
            
            Vector<int> v1 = new Vector<int>(10);
            for (int i = 0; i < v1.Length; i++) {
                v1[i] = 10 + i;
                
                // if (v1[i] > v1[0]) Console.WriteLine("+");
            } // for i
            Show("\nВектор<int>:\n", v1);

            v1.SortDescend();
            Show("\nВектор<int>:\n", v1);

            Vector<double> v2 = new Vector<double>(12);
            for (int i = 0; i < v2.Length; i++) {
                v2[i] = Math.PI / (i + 1d);
            } // for i
            Show("\nВектор<double>:\n", v2);

            v2.SortDescend();
            Show("\nВектор<double>:\n", v2);


            // Такое объявление, естественно, вызывает ошибку компиляции
            // Vector<GenericClass<int, bool>> obj3 = new Vector<GenericClass<int, bool>>();
            // Vector<GenericConstraintClass<int, string>> vector= new Vector<GenericConstraintClass<int,>>

            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Black;
        } // Main

        // т.к. Vector с ограничениями на struct,  то метод тоже д.б. с такими же
        // ограничениями
        private static void Show<T>(string title, Vector<T> container) 
            where T: struct, IComparable<T>
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(title);
            Console.ForegroundColor = ConsoleColor.Cyan;

            for (int i = 0; i < container.Length; i++) {
                // 0.#### - выводить 0 для чисел ]1,.., 0]
                Console.Write($"{container[i], 10:0.####}   ");
                if ((i + 1) % 8 == 0) Console.WriteLine();
            } // for i
            Console.WriteLine();
        } // Show
    } // class Program
}
