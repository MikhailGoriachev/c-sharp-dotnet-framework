using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadOperators
{
    // пример класса с перегрузкой операций
    class Counter
    {
        // свойство для ведения счета
        public int Value { get; set; }

        // имя счетчика
        public string Name { get; set; }

        public override string ToString() => $"[{Name}:{Value}]";

        // ------------------------------------------------------------

        // перегрузка операции + сложение двух объектов
        public static Counter operator +(Counter c1, Counter c2) {
            return new Counter { Value = c1.Value + c2.Value, Name = "Summa"  };
        }


        // перегрузка операции + сложение объекта и целого числа
        public static Counter operator +(Counter c1, int number) =>
            new Counter { Name = c1.Name, Value = c1.Value + number };


        // перегрузка операции + целого числа и сложение объекта 
        public static int operator +(int number, Counter c1) => c1.Value + number;


        // Следует учитывать, что при перегрузке не должны
        // изменяться те объекты, которые передаются в оператор
        // через параметры.
        public static Counter operator ++(Counter c1) {
            return new Counter { Value = c1.Value + 10, Name = c1.Name };
        } // operator++

        // еще один пример - реализация декремента
        public static Counter operator --(Counter c1) {
            return new Counter { Value = c1.Value - 10, Name = c1.Name };
        } // operator++


        // операции сравнения перегружаются только попарно - противоположные операции
        public static bool operator >(Counter c1, Counter c2) {
            return c1.Value > c2.Value;
        } // operator >

        // новый синтаксис для операции >
        // public static bool operator >(Counter c1, Counter c2) => c1.Value > c2.Value;

        // парная перегрузка оператора > в новом синтаксисе
        public static bool operator <(Counter c1, Counter c2) => c1.Value < c2.Value;



        // true и false тоже можно перегрузить для удобства
        // записи условных операторов в стиле C
        public static bool operator true(Counter c1) => c1.Value != 0;

        public static bool operator false(Counter c1) => c1.Value == 0; // operator false
    } // class Counter
}
