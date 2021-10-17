using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrMethods
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 27.09.2021 - абстрактные классы и методы";
            Derive derive = new Derive();
            Console.WriteLine(derive);

            Console.WriteLine("\nОбычные вызовы методов:");

            derive.Method1();
            derive.Method1(-1);
            derive.Method2();

            Console.WriteLine("\nПолиморфные вызовы методов:");

            // позднее связывание - отсюда и начинается полиморфизм
            Base baseClass = new Derive();

            baseClass.Method1();  // Полиморфный вызов - вызывается метод производного класса
            baseClass.Method1(-100);

            Console.WriteLine("\nОбычный вызов:");
            baseClass.Method2();  // Обычный вызов, т.к. Method2() не виртуальный
                              // будет вызваться метод базового класса

            Console.WriteLine();
            baseClass = new Derive1 {A = -111};

            Console.WriteLine("\nПолиморфный вызов:");
            baseClass.Method1();  // Полиморфный вызов - вызывается метод производного класса
            baseClass.Method1(-100);

            Console.WriteLine("\nОбычный вызов:");
            baseClass.Method2();  // Обычный вызов, т.к. Method2() не виртуальный
            // будет вызваться метод базового класса
        } // Main
    } // class Program
}
