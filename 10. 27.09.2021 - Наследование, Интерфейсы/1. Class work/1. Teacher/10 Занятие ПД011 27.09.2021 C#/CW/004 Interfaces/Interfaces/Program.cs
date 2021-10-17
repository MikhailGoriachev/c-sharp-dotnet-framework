using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbstrMethods;

namespace Interfaces
{
    // Интерфейс представляет ссылочный тип, который определяет набор методов и свойств,
    // но не реализует их. Затем этот функционал реализуют классы и структуры, которые
    // применяют данные интерфейсы.
    class Program
    {
        static void Main(string[] args)
        {
            
            Derive derive = new Derive();
            Console.WriteLine(derive);

            Console.WriteLine("\nОбычные вызовы методов:");

            derive.Method1();
            derive.Method1(-1);
            derive.Method2();

            Console.WriteLine("\nПолиморфные вызовы методов:");

            // позднее связывание - отсюда и начинается полиморфизм
            IMethods iMethods = new Derive();

            iMethods.Method1();  // Полиморфный вызов - вызывается метод производного класса
            iMethods.Method1(-100);

            Console.WriteLine("\nОбычный вызов");
            Base @base = new Derive();
            @base.Method2();  // Обычный вызов, т.к. Method2() не виртуальный
                              // будет вызваться метод базового класса

            Console.WriteLine();
            iMethods = new Class2();

            Console.WriteLine("\nПолиморфный вызов");
            iMethods.Method1();  // Полиморфный вызов - вызывается метод производного класса
            iMethods.Method1(-100);
        } // Main
    } // class Program
}
