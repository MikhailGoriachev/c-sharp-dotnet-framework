using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
   
    // пример ограничений для класса
    // T  - значимые типы (struct)
    // TK - ссылочные типы (class), требуется конструктор по умолчанию (new())  
    class GenericConstraintClass<T, TK> : IComparable<TK>, IComparer<TK>
        where T: struct
        where TK: class, new()

    {
        // поля обобщенных типов
        private T  _x;
        private TK _y;

        // Задание значений по умолчантю для типов T, K
        // default(Тип)
        public GenericConstraintClass(): this(default(T), default(TK)) {}
        public GenericConstraintClass(T a, TK b) {
            _x = a;
            _y = b;
        } // GenericConstraintClass

        public int Compare(TK x, TK y) {
            throw new NotImplementedException();
        }

        public int CompareTo(TK other) {
            throw new NotImplementedException();
        }

        public override string ToString() => $"{{x = {_x}, y = {_y}}}";

    } // class GenericConstraintClass
}
