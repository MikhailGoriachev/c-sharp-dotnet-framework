using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethods
{
    // делегат нужен для организации вызова метода
    public delegate int Operation(int a, int b);

    // Демонстрация возможности определения сложных анонимных методов
    public delegate void ShowDelegate(int[] a, string s);

    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 04.10.2021 - анонимные методы";
            ArrayProc();
        } // Main

        // Использование анонимных методов рассмотрим на примере обработки
        // массивов
        private static void ArrayProc() {
            int[] ar1 = { 2, 5, 6, 2, 3, 1 };
            int[] ar2 = { 6, 1, 4, 1, 7, 8 };

            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            
            // Создание делегата  анонимного метода и присваивание 
            // его переменной 
            
            Operation oper = delegate (int a, int b) { return a + b; };
            
            // использование делегата, хранящего анонимный метод
            Proc(ar1, ar2, oper);  
            Show(ar1, "add: ");
            Console.WriteLine();

            // в этом случае создается анонимная переменная, в которую 
            // записывается анонимный метод. Эта анонимная переменная
            // и передается в метод Proc
            // !!! явное определение делегата в точке вызова метода - стиль "быстро но грязно"
            Proc(ar1, ar2, delegate (int u, int v) { return u - v; });

            Show(ar1, "ar1: ");
            Show(ar2, "ar2: ");
            Show(ar1, "sub: ");
            Console.WriteLine();
            
           
            // Демонстрация захвата переменной/константы делегатом
            const int width = 5;

            // Создаем анонимный делегат типа ShowDelegate
            // для вывода массива с цветовым выделением нечетных
            // элементов
            ShowDelegate showDelegate = delegate (int[] x, string title) {
                Console.Write(title);
                ConsoleColor oldColor = Console.ForegroundColor;

                foreach (var item in x) {
                    if (item % 2 != 0) Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write($"{item, width}");   // тут захваченная константа
                    // время жизни захваченой переменной определяется временем жизни делегата
                    Console.ForegroundColor = oldColor;
                } // foreach
                Console.WriteLine();
            };
            
            // Использование переменной-делегата, хранящей анонимный
            // метод вывода массива
            showDelegate(ar1, "ar1: ");
            showDelegate(ar2, "ar2: ");
            Console.WriteLine();
            
            // переопределение делегата
            showDelegate = delegate (int[] x, string title) {
                Console.Write(title);
                (ConsoleColor fg, ConsoleColor bg) oldColor  = (Console.ForegroundColor, Console.BackgroundColor);

                foreach (var item in x) {
                    if (item % 2 == 0) {
                        (Console.ForegroundColor, Console.BackgroundColor) = 
                            (ConsoleColor.Black, ConsoleColor.Cyan);
                    } // if

                    Console.Write($"{item, width} ");   // тут захваченная константа
                    
                    // время жизни захваченой переменной определяется временем жизни делегата
                    (Console.ForegroundColor, Console.BackgroundColor) = oldColor;
                    Console.Write(" ");
                } // foreach
                Console.WriteLine();
            };
            showDelegate(ar1, "ar1: ");
            showDelegate(ar2, "ar2: ");
            Console.WriteLine();
            
            
            // Именованная переменная, хранящая делегат
            oper = delegate (int a, int b) { return a * b; };
            Proc(ar1, ar2, oper);  
			showDelegate(ar1, "mpy: ");

			// анонимная переменная, хранящая анонимный делегат передается методу Proc
            Proc(ar1, ar2, delegate(int a, int b) { return b == 0 ? int.MaxValue : a / b; });  
            showDelegate(ar1, "div: ");
            Console.WriteLine();
            
        } // ArrayProc


        // Вывод массива
        private static void Show(int[] ar1, string title) {
            Console.Write(title);
            foreach (var item in ar1) Console.Write($"{item,5}");
            Console.WriteLine();
        } // Show


        // Метод для поэлементной обработки массивов
        // Операция передается через делегат
        private static void Proc(int[] ar1, int[] ar2, Operation oper) {
            for (int i = 0; i < ar1.Length; i++) {
                ar1[i] = oper(ar1[i], ar2[i]);
            } // for i
        } // Proc

    } // class Program
}
