using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelloApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // объектный тип string
            string msg = "Hello, мир!";

            // стандартный статический класс Console - работа с консолью
            Console.Title = "Первая программа C#";

            // стандартное перечисление ConsoleColor - цвета консоли
            ConsoleColor oldColor = Console.ForegroundColor;
            
            // Задать размер окна консоли, цвет символа и фона
            Console.SetWindowSize(80, 25);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
           
            // позиционирование в окне
            Console.SetCursorPosition((Console.WindowWidth - msg.Length)/2, Console.WindowHeight/2);
            Console.Write(msg);
            Console.ForegroundColor = oldColor;

            Console.SetCursorPosition(0, Console.WindowHeight - 1);

            // немного забегая вперед - оператор цикла for()
            for (int f = 800; f <= 2000; f += 400) {
                Console.Beep(f, 1500);
                Thread.Sleep(1500);
            } // for i

            Console.Write("Нажмите любую клавишу для продолжения");
            Console.ReadKey();
        } // Main
    } // class Program
}
