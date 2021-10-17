using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArray
{
    /* 
         
      Разработать обобщенный класс для хранения одномерного массива. 
      Класс должен иметь следующий функционал:
        ☼ заполнение массива случайными значениями
        ☼ вывод массива на экран
        ☼ вывод массива с выделением локальных минимумов цветом
        ☼ поиск минимального и максимального элементов массива

    
      Проверить работу приложения на типе данных int, double, char      
   */
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 06.12.2020 - применение обобщенных типов";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Vector<int> intVector = new Vector<int>();
            Vector<double> dblVector = new Vector<double>();
            Vector<char> chrVector = new Vector<char>();

            intVector.Fill(-20, 20);
            intVector.Show("\nМассив целых чисел:\n");

            dblVector.Fill(0.5, 12.7);
            dblVector.Show("\nМассив вещественных чисел:\n");

            chrVector.Fill('a', 'z');
            chrVector.Show("\nМассив символов:\n");

            Console.WriteLine("\nЛокальные минимумы:");
            intVector.ShowLocMinColored("\nМассив int:\n", ConsoleColor.Yellow);
            dblVector.ShowLocMinColored("\nМассив double:\n", ConsoleColor.Green);
            chrVector.ShowLocMinColored("\nМассив char:\n", ConsoleColor.Red);

            Console.WriteLine("\nМаксимальный и минимальный элементы массов");
            intVector.FindMinMax(out var intMin, out var intMax);
            Console.WriteLine($"Массив int.    Минимальный элемент: {intMin}; максимальный элемент: {intMax}");

            dblVector.FindMinMax(out var dblMin, out var dblMax);
            Console.WriteLine($"Массив double. Минимальный элемент: {dblMin:n5}; максимальный элемент: {dblMax:n5}");

            chrVector.FindMinMax(out var chrMin, out var chrMax);
            Console.WriteLine($"Массив char.   Минимальный элемент: {chrMin}; максимальный элемент: {chrMax}");

            // double[] xyz;
            Console.ForegroundColor = ConsoleColor.Gray;
        } // Main
    } // class Program

    // class A<T> where T : struct { }
}
