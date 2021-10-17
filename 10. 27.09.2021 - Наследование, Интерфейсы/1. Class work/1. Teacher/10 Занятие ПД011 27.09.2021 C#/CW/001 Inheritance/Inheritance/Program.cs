using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 27.09.2021 - наследование";

            Base obj1 = new Base();
            Console.WriteLine($"\nobj1 = {obj1}\n");

            Derived obj2 = new Derived(-1, 2, 3, 4, Math.PI);
            Console.WriteLine($"\nobj2 = {obj2}");
            
            // вызов метода производного класса
            obj2.Foo();

            // изменение поля, определенного в базовом классе
            obj2.U = 132;

            // изменение поля, определенного в производном классе
            obj2.R = Math.PI;

            Console.WriteLine($"\nobj2 = {obj2}\n");
        } // Main
    } // class Program
 
} // namespace Inheritance
