using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirtMethods
{
    // базовый класс для демонстраций
    class Base
    {
        protected int a;
        public int A { 
            get => a;
            set => a = value;
        }

        public Base() : this(0) { }
        public Base(int a) => A = a;


        // виртуальный метод допускает полимфорный вызов 
        public virtual void Method1() {
            Console.WriteLine($"Метод Method1() класса Base, a = {a}");
        } // Method1


        // виртуальный метод допускает полимфорный вызов
        public virtual void Method1(int x) {
            a = x;
            Console.WriteLine($"Метод Method1(int x) класса Base, a = {a}");
        } // Method1


        // не виртуальный метод - не может быть вызван полиморфно
        public void Method2() {
            Console.WriteLine($"Метод Method2() класса Base, a = {a}");
        } // Method2


        public override string ToString() => $"a = {a}";
    } // class Base
}
