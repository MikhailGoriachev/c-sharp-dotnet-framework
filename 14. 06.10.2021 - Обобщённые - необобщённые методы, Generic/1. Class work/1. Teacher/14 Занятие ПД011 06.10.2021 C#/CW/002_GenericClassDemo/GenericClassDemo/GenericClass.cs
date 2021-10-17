using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    // объявление обобщенного класса - без использования ограничений по типам
    // class ИмяКласса<Tип1, Тип2, ..., ТипN> {}
    class GenericClass<T, TK>
    {
        // поля обобщенных типов
        private T _x;
        private TK _y;

        // Задание значений по умолчантю для типов T, K
        // default(Тип) или просто default
        // public GenericClass() : this(default, default) { }
        public GenericClass(): this(default(T), default(TK)) {}
        public GenericClass(T a, TK b) {
            _x = a;
            _y = b;
        } // GenericClass

        public override string ToString() =>
            // {{ - выводится {, }} - - выводится }
            $"{{x = {_x}, y = {_y}}}";

    } // class Generic
}
