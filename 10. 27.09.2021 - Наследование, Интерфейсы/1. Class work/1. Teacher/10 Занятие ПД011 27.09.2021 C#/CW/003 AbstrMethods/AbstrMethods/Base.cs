using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrMethods
{
    // базовый класс для демонстрации
    abstract class Base
    {
        protected int a;
        public int A { 
            get => a;
            set => a = value;
        }

        public Base() : this(0) { }
        public Base(int a) => A = a;


        // обязуем производные классы реализовать эти методы
        public abstract void Method1();
        public abstract void Method1(int x);

        public void Method2() {
            Console.WriteLine($"Метод Method2() класса Base, a = {a}");
        } // Method2


        public override string ToString() => $"a = {a}";
    } // class Base
}
