using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassDemo
{
    // ограничения обобщенных типов:
    // where имяТипа: список ограничений

    // объявление обобщенного класса - с ограничениями по типам
    // class Имя<тип1, тип2, ..., типN> where тип1: список ограничений
    //                                  where тип2: список ограничений
    //                                  ...
    //                                  where типN: список ограничений

    // В качестве ограничений мы можем использовать следующие типы:
    // Класс      - только одно имя класса
    // Интерфейсы - список имен интерфейс
    // class  - универсальный параметр должен представлять класс
    // struct - универсальный параметр должен представлять структуру
    // new()  - универсальный параметр должен представлять тип,
    //          который имеет общедоступный (public) конструктор без параметров

    // Порядок задания ограничений в списке ограничений:
    // 1. или имя класса или class или struct
    // 2. список имен интерфейса
    // 3. new()

    // для типа T допустимы только значимые типы (int, double, ...)
    class Vector<T> where T: struct, IComparable<T>
        // class Vector<T> where T: class, IComparable<T>, IComparer<T>, new()
    {
        // контейнер для хранения данных обобщенного типа
        private T[] _data;
        private T _f;      // еще один атрибут

        // конструктор
        public Vector(int n) {
            _data = new T[n];
        } // Vector

        // размер контейнера
        public int Length => _data.Length;

        // индексатор для доступа к контейнеру
        public T this[int index] {
           get => _data[index]; 
           set => _data[index] = value; 
        } // this

        // T add(int i, int j) => _data[i] + _data[j];
        public void SortDescend() =>
            Array.Sort(_data, (a, b) => b.CompareTo(a));
    } //  class Vector
}
