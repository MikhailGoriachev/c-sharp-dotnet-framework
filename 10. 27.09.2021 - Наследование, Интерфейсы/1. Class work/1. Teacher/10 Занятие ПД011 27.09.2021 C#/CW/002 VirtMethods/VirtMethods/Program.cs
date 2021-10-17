using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtMethods
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 27.09.2021 - виртуальные методы";

            // @base - ключевое слово в качестве имени 
            // Base @base = new Base();
            Base baseClass = new Base();

            // int @if = 1;
            // int @for = 2;
            // int @while = @if + @for;

            Console.WriteLine(baseClass);

            Derive derive = new Derive();
            Console.WriteLine(derive);

            Console.WriteLine("\nОбычные вызовы методов:");
            baseClass.Method1();
            baseClass.Method1(-2);
            baseClass.Method2();

            Console.WriteLine();
       
            derive.Method1();
            derive.Method1(-1);
            derive.Method2();

            Console.Write("\n\nНажмите любую клавишу...");
            Console.ReadKey();

            
            Console.WriteLine("\nПолиморфные вызовы методов:");
            
            // позднее связывание - отсюда и начинается полиморфизм
            // SOLID
            // !!! по принципу подстановки Лисков !!!  Барбара Лисков !!!
            baseClass = new Derive();

            baseClass.Method1();  // Полиморфный вызов - вызывается метод производного класса
            baseClass.Method1(-100);

            Console.WriteLine("\nНе полиморфный вызов:");
            baseClass.Method2();  // Обычный вызов, т.к. Method2() не виртуальный
                              // будет вызваться метод базового класса

          Console.Write("\n\nНажмите любую клавишу...");
          Console.ReadKey();

        // доступ к свойствам
        Console.WriteLine();
        baseClass.A = 123;
        derive.B = 456;
        Console.WriteLine($"\n@base: {baseClass}\nderive: {derive}");
            
        } // Main
    } // class Program
} 
