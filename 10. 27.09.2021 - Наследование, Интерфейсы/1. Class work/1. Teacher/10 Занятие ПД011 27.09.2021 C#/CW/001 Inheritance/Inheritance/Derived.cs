using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    // класс - наследник от класса Base
    class Derived : Base
    {
        // поле класса
        protected int X;
        public double R;

        // base() - вызов конструктора базового класса
        // в конструкторе по умолчанию конструктор базового класса
        // вызывается по умолчанию, явный вызов избыточен
        public Derived()//: base() // не обязательное обращение
        {
            X = 6;
        } // Derived

        // base() - вызов конструктора базового класса
        public Derived(int a, int p, int u, int x, double r): base(a, p, u)
        {
            X = x;
            R = r;
        } // Derived

        // сокрытие имен в классах
        // метод, перекрывающий метод базового класса
        public new void Foo() {
            base.Foo(); // явный вызов метода базового класса
            Console.WriteLine($"\nDerived: Foo -> _a = {A}, u = {U}");
        } // Foo


        // метод, переопределяющий метод базового класса
        public override string ToString()
        {
            // base.ToString() - метод базового класса  
            return base.ToString() + $"; x = {X}; r = {R}";
        } // ToString
    } // class Derived
}
