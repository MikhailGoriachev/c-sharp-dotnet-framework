using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hello
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Первое приложение C#";

            Thread.Sleep(1_000);
            Console.SetWindowSize(80, 35);
            
            ConsoleColor foreColor = Console.ForegroundColor;
            ConsoleColor backColor = Console.BackgroundColor;

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Clear();

            Console.WriteLine("Это строка для вывода");
            Console.WriteLine("Привет, мир!");
            Console.WriteLine("Hello, world!");

            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;

            Console.SetCursorPosition(0, Console.WindowHeight-1);
        }
    }
}
