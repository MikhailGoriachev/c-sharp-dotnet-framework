using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    // демонстрационнный класс - использование итератора
    class Person: IEnumerable
    {
        public string Name   { get; set; }
        public int Age       { get; set; }
        public double Weight { get; set; }


        public override string ToString() {
            return $"[Name = {Name}; Age = {Age}; Weight = {Weight:n2} кг]";
        } // ToString


        // реализация интерфейса IEnumerable для перебора свойств :)
        public IEnumerator GetEnumerator() {
            yield return $"Name   = {Name}";
            yield return $"Age    = {Age}";
            yield return $"Weight = {Weight}";
        } // GetEnumerator

    } // class Person
}
