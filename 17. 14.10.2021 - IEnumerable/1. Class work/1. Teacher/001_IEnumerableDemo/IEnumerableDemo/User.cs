using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerableDemo
{
    // демонстрационный класс - перебор свойств класса при помощи итератора
    class User: IEnumerable
    {
        public string Name   { get; set; }
        public int    Age    { get; set; }
        public double Salary { get; set; }


        public override string ToString() => 
            $"[Name = {Name}; Age = {Age}; Salary = {Salary:n2}]";

        
        // итератор для перебора свойств класса

        public IEnumerator GetEnumerator() {
            yield return $"Name   = {Name}";
            yield return $"Age    = {Age:N0}";
            yield return $"Salary = {Salary:n2}";
        
        } // GetEnumerator
        
    } // User
}
