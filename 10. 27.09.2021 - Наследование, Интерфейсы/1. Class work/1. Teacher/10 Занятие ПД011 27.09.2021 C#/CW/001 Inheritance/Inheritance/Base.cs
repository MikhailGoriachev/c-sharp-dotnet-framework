using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    // базовый класс для наследования другими классами
    // internal  - видимость в приложении
    // public    - видимость в сборке
    // private   - 
    // protected - в производных классах, даже в других сборках
    // protected internal - доступны в производных классах и во всех
    //                      текущей сборки
    // private protected -  в текущем классе, производных классах 
    //                      текущей сборки
    /* sealed class Имя {} */ 
    class Base  
    {
        protected int A;
        private int _p;
        public int U;

        public Base() : this(1, 2, 3) { }
        public Base(int a, int p, int u) {
            A = a;
            _p = p;
            U = u;
        } // Base

        // свойство в краткой форме записи
        protected int P => _p; // только аксессор

        public void Foo() =>
            Console.WriteLine($"\nBase: Foo -> _a = {A}, p = {_p}, u = {U}"); 

        // Настоятельно рекомендуется к реализации
        public override string ToString() {
            // base - ссылка на базовый класс, ToString() надо явно указывать
            // т.к. base - это ключевое слово
            return  $"{base.ToString()}; _a = {A}, p = {_p}, u = {U}";
        } // ToString
    } // class Base
}
