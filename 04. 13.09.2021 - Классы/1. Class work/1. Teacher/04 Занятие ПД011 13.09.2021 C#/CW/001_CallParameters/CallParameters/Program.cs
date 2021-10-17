using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallParameters
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 13.09.2021 - передача параметров в методы";

            /*
            // Передача по значению, в порядке перечисления параметров
            Bar(1, 2, 3);

            
            // Передача по именам - константы
            // формальноеИмя: значение
            Bar(c:-4, b:-3, a:-1);

            // Передача по именам - переменные, имена которых не совпадают 
            // с именами параметров
            int x = 199, y = 101, z = 911;
            Bar(b: y, c: z, a: x);

            // Передача по именам - переменные, имена которых совпадают 
            // с именами параметров
            int a = -11, b = -12, c = -13;
            // Bar(имяПарам1: значение1, имяПарам2: значение2, имяПарам3: значение3);
            Bar(c: c, b: b, a: a);

            Console.WriteLine();
            
            // Передача всех параметров по умолчанию
            Bar();

            // Совместное использование параметров по умолчанию
            // и передачи параметров по имени
            Bar(a:x, c:z);
            Bar(b: 999);

            // не все параметры можно указывать
            // параметр c принимает значение по умолчанию
            Bar(b: y, a: x);
            */
            
            // Пример передачи по ссылке - ref - параметр является и входным и выходным
            // т.е. он может изменяться в методе
            Console.WriteLine();
            int[] arr = new int[12];
            arr.Initialize();   // заполнить массив начальными значенияи - в д.с. 0

            int a = -11, b = -12, c = -13;
            Console.WriteLine($"Main: a = {a}, b = {b}, c = {c}, arr.Length = {arr.Length}");
            Foo(a, ref b, ref c, ref arr);
            Console.WriteLine($"Main: a = {a}, b = {b}, c = {c}, arr.Length = {arr.Length}");

            
            // Пример использования выходных параметров метода - out
            // int sum, dif = 42;
            // Zoo(a, b, c, out sum, out dif);
            Zoo(a, b, c, out int sum, out int dif);  // C# 7.0 объявление out параметров при вызове
            Console.WriteLine($"Main: a = {a}, b = {b}, c = {c}, sum = {sum}, dif = {dif}");

            // при повторнрм вызове объявление выходных переменных не требуется
            Zoo(a, b, c, out sum, out dif);
            Console.WriteLine($"Main: a = {a}, b = {b}, c = {c}, sum = {sum}, dif = {dif}");
            Console.WriteLine();
            
            
			Boo("Тест0:\n");
			Boo("\nТест1:", 5, 6, 7);
            Boo("\nТест2:", -3, -2, 51, 16, -17);
            Boo("\nТест3:", 3, -12, 1, -6);

            Choo();
            Choo(Math.E, Math.PI, 9.81);
        } // Main

        // Демонстарционный метод - передача параметров
        static void Bar(int a=10, int b=20, int c=30) {
            Console.WriteLine($"Bar: a = {a, 3}  b = {b, 3}  c = {c, 3}");
        } // Bar


        // Пример передачи по ссылке
        static void Foo(int a, ref int b, ref int c, ref int[] arr) {
            a = 12;
            b = a + 3;
            c = a - 5;

            // массив по ссылке - т.е. можно изменять размер массива
            // !!! Все массивы в C# - динамические !!!
            arr = new int[150];
            arr.Initialize();

            Console.WriteLine($"Foo : a = {a,3}, b = {b,3}, c = {c,3}, arr.Length = {arr.Length}");
        } // Foo

        // Пример передачи выходых параметров
        private static void Zoo(int a, int b, int c, out int sum, out int dif) {

            sum = a + b + c;
            dif = a - b - c;
        } // Zoo
		
        // передача списка параметров переменной длины
        // params - ключевое слово - псевдомассив параметров
        // переменной длины, д.б. последним параметром метода 
		static void Boo(string title, params int[] x) {
            Console.WriteLine(title);
            foreach (var t in x) {
                // пример вывода при помщи форматной строки
                Console.WriteLine($"параметр: {t}");
            } // for
            Console.WriteLine($"-----------------\nВсего параметров: {x.Length}");
        } // Boo

        // только переменная часть списка параметров
        static void Choo(params double[] data) {
            Console.WriteLine("\nChoo:");
            foreach (var t in data) {
                // пример вывода при помщи форматной строки
                Console.WriteLine($"параметр: {t}");
            } // for
            Console.WriteLine($"-----------------\nВсего параметров: {data.Length}");
        } // Choo


    } // class Program
}
