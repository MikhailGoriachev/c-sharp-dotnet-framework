using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Подключает в программу все статические методы и свойства, а также константы.
// После использования этой конструкции мы можем не указывать название класса
// при вызове метода.
// using static ПолноеИмяКласса;
using static System.Console;
using static System.Math;
using static NamespaceThird.Geometry;  

namespace NamespaceThird
{
    class Program
    {
        static void Main(string[] args) {
            Title = "Занятие 01.11.2020 - пространства имен, статический импорт";


            double radius = 50;
            double result = GetArea(radius);                    // Geometry.GetArea
            WriteLine($"\n\nВывод значения: {result:f3}\n\n");  // Console.WriteLine
        } // Main
    } // class Program
 
    // пример класса со статическим методом - для
    // демонстрации статического импорта этого метода
    class Geometry
    {
        public static double GetArea(double radius) => PI * radius * radius; // Math.PI
        
        // Демонстрация конфликта имен
        // public static void WriteLine(string str) { }
    } // class Geometry

} // namespace NamespaceThird
