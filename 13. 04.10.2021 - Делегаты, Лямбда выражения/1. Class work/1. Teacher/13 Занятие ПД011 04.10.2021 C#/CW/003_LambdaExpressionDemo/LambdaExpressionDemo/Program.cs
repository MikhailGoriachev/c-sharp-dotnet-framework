using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LambdaExpressionDemo
{

    // Делегат для реализации анонимных делегатов - вывод массива
    public delegate void ShowArray(string title, int[] arr);    
    
    // Делегат для поэлементной операции 
    public delegate int Operation(int a, int b);

    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 04.10.2021 - лямбда-выражения в C#";
            (Console.ForegroundColor, Console.BackgroundColor) = (ConsoleColor.Gray, ConsoleColor.Black);
            Console.Clear();

            // Поэлементная обработка массива, метод обработки передаем через делегат
            #region Делегаты - лямбда-выражения
        
            int[] x = { 2, 5, 6, 1, 7, 8 };
            int[] y = { 3, 6, 7, 2, 8, 3 };

            // Переменная или константа, описанные в методе, но
            // использующиеся в анонимном делегате - захваченные
            // константы, захваченные переменные
            // ‼ переменные/константы, объявленные вне анонимого делегата,
            //   доступны в анонимном делегате  
            const int width = 6;

            // Создание блочного лямбда-выражения для вывода массива из 
            // записи анонимного метода
            // ShowArray show1 = delegate (string title, int[] arr) { 
            ShowArray show1 = (title, arr) => { 
                Console.Write(title);
                // и еще одно лямбда-выражение :)
                Array.ForEach(arr, item => Console.Write($"{item,width}"));
                // foreach (var item in arr) Console.Write($"{item,width}");
                Console.WriteLine();
            };

            // Блочное лямбда-выражение  без параметров () => { код }
            // Строчное лямбда-выражение без параметров () => оператор

            // Блочное лямбда-выражение  с одним параметром имяПараметра => { код }
            // Строчное лямбда-выражение с одним параметром имяПараметра => оператор

            // Блочное лямбда-выражение  с параметрами (списокПараметров) => { код }
            // Строчное лямбда-выражение с параметрами (списокПараметров) => оператор

            // Создание еще одного блочного лямбда-выражения для вывода массива,
            // нечетные числа выделяем цветом
            ShowArray show2 = (title, arr) => {
                Console.Write(title);
                ConsoleColor old = Console.ForegroundColor;
                foreach (var item in arr) {
                    bool r = item % 2 != 0;    // признак нечетного значения элемента
                    if (r) Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"{item,width}");
                    if (r) Console.ForegroundColor = old;
                } // doreach
                Console.WriteLine();
            };

            Console.WriteLine("\nОперации с массивами - операции передаются делегатом");
            show1("x  : ", x);  // отображение массива делегатом
            show1("y  : ", y);
            
            // Proc(x, y, delegate(int a, int b) { return a + b; }); // анонимный делегат
            // строчное лямбда-выражение - метод в один оператор, без использования {}
            Proc(x, y, (a, b) => a + b); // строчное лямбда-выражение с параметрами - поэлементная обработка
            show2("add: ", x);  // отображение массива делегатом - выделение цветом нечетных элементов массива
            Console.WriteLine();

            show1("x  : ", x);
            show1("y  : ", y);
            // пример делагата вместо лямбда-выражения 
            // Proc(x, y, delegate(int a, int b) { return a - b; });
            Proc(x, y, (a, b) => a - b);
            show2("sub: ", x);
            Console.WriteLine();

            show1("x  : ", x);
            show1("y  : ", y);
            Proc(x, y, (u, v) => u * v );
            show2("mul: ", x);
            Console.WriteLine();

            show1("x  : ", x);
            show1("y  : ", y);
            Proc(x, y, (a, b) => b == 0 ? int.MaxValue : a / b);
            show2("div: ", x);
            Console.WriteLine();

            Console.Write("\nВсе четные числа из массива: ");
            // Array.ForEach(Array.FindAll(x, a => (a & 1) == 0), a => Console.Write($"{a, 6}"));
            // int[] evens = Array.FindAll(x, a => (a & 1) == 0);
            // Array.ForEach(evens, a => Console.Write($"{a,6}"));
            Array.ForEach(
                Array.FindAll(x, a => (a & 1) == 0), 
                a => Console.Write($"{a, 6}"));
            Console.WriteLine();
            
            Console.WriteLine("\n\nПримеры сортировки по заданию:");
            Console.WriteLine("\nМассив, упорядоченный по возрастанию:");
            Array.Sort(x, (a, b) => a - b);
            show2("x: ", x);  
            
            Console.WriteLine("\nМассив, упорядоченный по убыванию:");
            // Array.Sort(x, (a, b) => b - a);
            Array.Sort(x, (a, b) => b.CompareTo(a));
            Console.Write("x: ");

            Array.ForEach(x, a => {
                Console.ForegroundColor = a >= 0 ? ConsoleColor.Red : ConsoleColor.Cyan;
                Console.Write($"{a,6}");
            });
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Gray;
            
            show2("x: ", x);

            Console.WriteLine("\nМассив, упорядоченный по правилу \"нечетные числа - в начале массива\"");
            Array.Sort(x, (a, b) => a % 2 != 0 && b % 2 == 0?-1:a % 2 == 0 && b % 2 != 0?1:0);
            show2("x: ", x);

            Console.WriteLine("\nМассив, упорядоченный по правилу \"четные числа - в начале массива\"");
            Array.Sort(x, (a, b) => a % 2 == 0 && b % 2 != 0?-1:a % 2 != 0 && b % 2 == 0?1:0);
            show2("x: ", x);
            
            // Сумма нечетных чисел
            int sum = 0;  // переменная в захвате/замыкании
            Array.ForEach(x, a => sum += ((a & 1) != 0)?a:0);
            Console.WriteLine($"\nСумма нечетных sum = {sum}");
            #endregion

        } // Main

        // Поэлементное выполнение операций oper над массивами arr1, arr2
        // результат операции записываем в массив arr1
        // oper - ссылка на метод, выполняющий операцию 
        private static void Proc(int[] arr1, int[] arr2, Operation oper) {
            for (int i = 0; i < arr1.Length; i++) {
                arr1[i] = oper(arr1[i], arr2[i]);  // !!! вызов операции через делегат !!!
            } // for i
        } // Proc
        
    } // class Program
}
