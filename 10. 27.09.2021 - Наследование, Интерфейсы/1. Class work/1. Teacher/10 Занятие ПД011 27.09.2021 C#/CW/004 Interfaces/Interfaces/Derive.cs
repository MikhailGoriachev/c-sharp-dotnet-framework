using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    // унаследован от Base и реализует интерфейс IMethods
    // или расширяет Base и реализует интерфейс IMethods
    class Derive: Base, IMethods    
    {
        private int b;
        public int B { 
            get => b;
            set => b = value;
        }

        public Derive() : this(11, 12) { }
        public Derive(int a, int b): base(a)
        {
            B = b;
        } // Derive

        /// /////////////////////////////////////////////////
        
        // Реализация методов интерфейса IMethods:
        public void Method1()
        {
            Console.WriteLine($"Метод Method1() класса Derive, a = {a}, b = {b}");
        } // Method1

        public void Method1(int x)
        {
            a = x;
            Console.WriteLine($"Метод Method1() класса Derive, a = {a}");
        } // Method1

        /// /////////////////////////////////////////////////

        // Перекрываем, но не переопределяем метод базового класса
        // т.е. не участвует в полиморфных вызовах
        public new void Method2()
        {
            Console.WriteLine($"Метод Method2() класса Derive, a = {a}, b = {b}");
            Console.WriteLine("Вызываем метод базового класса из метода производного класса");
            base.Method2();  // вызов метода базового класса
        } // Method2

        public override string ToString()
        {
            return base.ToString() + $"; b = {b}";
        } // ToString
    } // class Derive
}
