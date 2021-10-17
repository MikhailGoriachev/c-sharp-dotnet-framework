using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtMethods
{
    class Derive: Base
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

        // переопределение виртуального метода
        public override void Method1() {
            Console.WriteLine($"Метод Method1() класса Derive, a = {a}, b = {b}");
        } // Method1

        // переопределение перегруженного виртуального метода
        public override void Method1(int x) {
            a = x;
            Console.WriteLine($"Метод Method1(int x) класса Derive, a = {a}");
        } // Method


        // Перекрываем, но не переопределяем метод базового класса
        // т.е. не участвует в полиморфных вызовах
        public new void Method2() {
            // все-таки вызов метода базового класса возможен
            // base.Method2();
            Console.WriteLine($"Метод Method2() класса Derive, a = {a}, b = {b}");
        } // Method2

        public override string ToString() =>
           base.ToString() + $"; b = {b}";


    } // class Derive
}
