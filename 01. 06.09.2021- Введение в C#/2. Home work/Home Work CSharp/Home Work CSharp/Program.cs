using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
 * Задание по C#. Разработайте консольное приложение .Net Framework для решения следующей 
 * задачи. Код решения разместите в статическом методе Main() класса Program. Используйте
 * возможности консоли по работе с цветом, позиционирование курсора.
 * 
 * Установите размер окна консоли 80 символов на 35 строк. Выведите ASCII-картинку, 
 * приведенную ниже (и в файле ascii_art.txt) в верхней левой части консоли, по центру 
 * консоли, в нижней правой части консоли. Не применяйте вычислений, циклов, методов – в 
 * этом задании просто хард-код 😊 вспомните первые задания базового семестра 😊
 * Перед вторым и третьим выводом сделайте паузу в 3 секунды, для каждого рисунка изменяйте
 * цвет символов (можно и цвет фона).
 *
 *   |\_/|   ****************************  (\_/) 
 *  / @ @ \  *  "Purrrfectly pleasant"  * (='.'=) 
 * ( > o < ) *       Poppy Prinz        * (")_(") 
 *  '>>x<<'  *   (pprinz@example.com)   * 
 *   / O \   ****************************
 *
 * 
 */

namespace Home_Work_CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Домашнее задание на 08.09.2021";

            // установка размера консоли
            Console.SetWindowSize(80, 35);

            // картинка 
            string s1 = "  |\\_/|   ****************************  (\\_/)   ";
            string s2 = " / @ @ \\  *  \"Purrrfectly pleasant\"  * (='.'=) ";
            string s3 = "( > o < ) *       Poppy Prinz        * (\")_(\")  ";
            string s4 = " '>>x<<'  *   (pprinz@example.com)   *            ";
            string s5 = "  / O \\   ****************************           ";


            // установка цвета 
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.Clear();

            // вывод картинки
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s4);
            Console.WriteLine(s5);

            // пауза
            Thread.Sleep(3_000);

            // установка цвета 
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            // вывод картинки по центру
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2,  Console.WindowHeight / 2 - 2 );
            Console.WriteLine(s1);
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.WindowHeight / 2 - 1);
            Console.WriteLine(s2);
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.WindowHeight / 2);
            Console.WriteLine(s3);
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.WindowHeight / 2 + 1);
            Console.WriteLine(s4);
            Console.SetCursorPosition((Console.WindowWidth - s1.Length) / 2, Console.WindowHeight / 2 + 2);
            Console.WriteLine(s5);

            // пауза
            Thread.Sleep(3_000);

 
            // установка цвета 
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.Clear();

            // вывод картинки в правом нижнем углу
            Console.SetCursorPosition(Console.WindowWidth - s1.Length, Console.WindowHeight - 5);
            Console.WriteLine(s1);
            Console.SetCursorPosition(Console.WindowWidth - s1.Length, Console.WindowHeight - 4);
            Console.WriteLine(s2);
            Console.SetCursorPosition(Console.WindowWidth - s1.Length, Console.WindowHeight - 3);
            Console.WriteLine(s3);
            Console.SetCursorPosition(Console.WindowWidth - s1.Length, Console.WindowHeight - 2);
            Console.WriteLine(s4);
            Console.SetCursorPosition(Console.WindowWidth - s1.Length, Console.WindowHeight - 1);
            Console.WriteLine(s5);
        }
    }
}
