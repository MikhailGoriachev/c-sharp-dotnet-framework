using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models
{
    // делегат для инициализации элементов массива
    delegate T InitDel<T>() where T : IComparable;

    // делегат для вывода шапки таблицы
    delegate void ShowHeadDelegate (int size, string name, string info);

    // делегат для вывода элементов массива
    delegate void ShowElements<T> (T[] array) where T : IComparable;

    // делегат для вывода элементов массива с подсветкой по предикатору
    delegate void ShowColorElemenst<T>(T[] array, Predicate<T> pred) where T : IComparable;

    // делегат компаратор для сортировки 
    delegate int CompareItem<T>(T t1, T t2) where T : IComparable;

    // Класс Хранитель массива
    internal class StorageArray<T> where T : IComparable
    {
        // коллекция данынх
        public T[] Data { get; private set; }

        // размер массива
        public int Lenght { get => Data.Length; }

        #region Кострукторы

        // конструктор иницализирующий
        public StorageArray(InitDel<T> initDel, int n)
        {
            // выделение памяти
            Data = new T[n];

            // установка значений
            Initialization(initDel);
        }

        // конструктор инициализирующий
        public StorageArray(InitDel<T> initDel) : this(initDel, 10) { }

        // конструктор по умолчанию 
        public StorageArray()
        {
            // выделение памяти
            Data = new T[10];
        }

        #endregion

        #region Методы

        // заполнение массива данными
        public void Initialization(InitDel<T> initDel) { for (int i = 0; i < Data.Length; i++) Data[i] = initDel(); }

        // поиск первого максимального элемента
        public T MaxElem()
        {
            // максимальное значение 
            T max = Data[0];

            // поиск максимального значения
            Array.ForEach(Data, item => max = max.CompareTo(item) < 0 ? item : max);

            return max;
        }

        // количество элементов с максимальным значением
        public int CountMaxElem()
        {
            // максимальное значение 
            T max = MaxElem();

            // количество максимальных элементов 
            int count = 0;

            // подсчёт максимальных элементов 
            Array.ForEach(Data, item => count += max.Equals(item) ? 1 : 0);

            return count;
        }

        // сортировка по убыванию значения
        public void Sort(CompareItem<T> compare) => Array.Sort(Data, (item1, item2) => compare(item2, item1));

        // вывод массива 
        public void Show(ShowHeadDelegate showHead, ShowElements<T> showElements, string name = "Массив", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            showHead(Data.Length, name, info);

            // вывод элементов таблицы
            showElements(Data);
        } 

        // вывод массива с подсветкой элементов по предикатору
        public void ShowColorElem(ShowHeadDelegate showHead, ShowColorElemenst<T> showElements, Predicate<T> predicate, string name = "Массив", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            showHead(Data.Length, name, info);

            // вывод элементов таблицы
            showElements(Data, predicate);
        }

        #endregion
    }
}
