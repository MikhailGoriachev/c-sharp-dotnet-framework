using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsLoop
{
    class Program
    {
        // статический объект для формирования случайных чисел
        // статический объект - в ед. экземпляре
        // создание нового объекта - оператор new
        // Класс имяОбъекта = new Класс(параметры);
        static private Random rand = new Random();

        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.Title = "Занятие 08.09.2021 - операторы повторения";

            While();
            DoWhile();
            For();
            
            ForEach();
        } // Main

        // цикл типа while
        private static void While() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nЦикл типа while():");

            int i = 1;
            while (i <= 10) {
                Console.Write($"{i, 5}");
                ++i;
            } // while
            Console.WriteLine( );

            Console.ForegroundColor = ConsoleColor.Gray;
        } // While

        // цикл типа do-while
        private static void DoWhile() {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\nЦикл типа do - while():");
            int i = 1;
            do {
                Console.Write($"{i, 5}");
                ++i;
            } while (i <= 10);
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Gray;
        } // DoWhile

        // цикл типа for
        private static void For() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nЦикл типа for():");
            
            for(int i = 1; i <= 10; ++i) {
                Console.Write($"{i, 5}");
            } // for i
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Gray;
        } // For

        // цикл типа "для каждого"
        private static void ForEach() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\nЦикл типа foreach():");

            // массив только для примера, о массивах в следующий раз
            int[] arr = new int[10];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = rand.Next(-10, 11);
            } // for i

            // цикл "для каждого" - цикл только для чтения - вывод массива
            foreach (var item in arr) {
                Console.Write($"{item, 5}");
            } // foreach item
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Gray;
        } // ForEach


    } // class Program
}
