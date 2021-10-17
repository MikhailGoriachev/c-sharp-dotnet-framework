using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrMethods
{
    class Derive: Base
    {
        private int _b;
        public int B
        {
            get => _b; set => _b = value;
        }

        public Derive() : this(11, 12) { }
        public Derive(int a, int b): base(a)
        {
            B = b;
        } // Derive

        /// /////////////////////////////////////////////////
        
        // Реализация абстрактных методов класса Base:
        public override void Method1()
        {
            Console.WriteLine($"Метод Method1() класса Derive, a = {a}, _b = {_b}");
        } // Method1

        public override void Method1(int x)
        {
            a = x;
            Console.WriteLine($"Метод Method1() класса Derive, a = {a}");
        } // Method1

        /// /////////////////////////////////////////////////

        // Перекрываем, но не переопределяем метод базового класса
        // т.е. не участвует в полиморфных вызовах
        public new void Method2()
        {
            Console.WriteLine($"Метод Method2() класса Derive, a = {a}, _b = {_b}");
            Console.WriteLine("Вызываем метод базового класса из метода производного класса");
            base.Method2();  // вызов метода базового класса
        } // Method2

        public override string ToString() => base.ToString() + $"; _b = {_b}";
    } // class Derive
}
