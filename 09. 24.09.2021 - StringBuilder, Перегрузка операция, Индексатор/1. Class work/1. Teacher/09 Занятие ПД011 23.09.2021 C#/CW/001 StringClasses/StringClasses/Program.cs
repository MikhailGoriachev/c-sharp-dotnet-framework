using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClasses
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 23.09.2021 - строки в C#, классы string, StringBuilder";

            // одна из форм конструктора строки - создание строки
            // из заданного количества заданных символов
            string s = new string('~', 80);
            // Console.WriteLine(new string('~', 80));
            Console.WriteLine(s);

            // Класс StringBuilder - изменяющаяся строка
            DemoStringBuilder();
        } // Main


        // Демо для класса StringBuilder
        private static void DemoStringBuilder() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Класс StringBuilder\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // StringBuilder sb = new StringBuilder();
            StringBuilder sb = new StringBuilder("кот ломом колол слона");
            Console.WriteLine($"\n{sb}\nДлина {sb.Length}, емкость {sb.Capacity}");
            
            sb.Append(" и еще одного кота");
            Console.WriteLine($"\n{sb}\nДлина {sb.Length}, емкость {sb.Capacity}");

            sb.Append(" и еще одного кота");
            Console.WriteLine($"\n{sb}\nДлина {sb.Length}, емкость {sb.Capacity}");
            
            sb.Append(" и еще одного кота");
            Console.WriteLine($"\n{sb}\nДлина {sb.Length}, емкость {sb.Capacity}");
            sb.Append($"{sb.Length}");
            sb.AppendFormat("{0}", sb.Length);

            sb.Append(" и еще одного кота и еще и еще и еще...");
            Console.WriteLine($"\n{sb}\nДлина {sb.Length}, емкость {sb.Capacity}");
            
            // доступ к произвольному символу при помощи индексатора []
            sb[1] = 'и';
            Console.WriteLine(sb);

            Console.WriteLine("\n\n");

            // интенсивная работа с памятью 
            int[] arr = new int[10];
            string s = "";
            foreach (var item in arr) {
                s += $"{item, 5}";
            }
            Console.WriteLine(s);

            // экономная работа с памятью
            sb = new StringBuilder(100);
            foreach (var item in arr) {
                sb.Append($"{item, 5}");
            }
            Console.WriteLine(sb);
            
        } // DemoStringBuilder
    } // class Program
}
