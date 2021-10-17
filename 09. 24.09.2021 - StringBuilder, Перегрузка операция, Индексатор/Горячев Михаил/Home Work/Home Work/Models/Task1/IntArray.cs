using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task1
{
    // Класс Контейнер
    internal class IntArray
    {
        // массив 
        private int[] _data;

        #region Свойства 

        // размер массива 
        public int Length { get => _data.Length; }

        #endregion

        #region Конструкторы и индексирование 

        // конструктор по умолчанию
        public IntArray() => _data = new int[0];

        // конструктор инициализирующий 
        public IntArray(int n) => _data = new int[n];

        // конструктор инициализирующий 
        public IntArray(int[] array) => _data = array;

        // индексирование по массиву data
        public int this[int index]
        {
            get
            {
                // если индекс выходит за границы массива 
                if (index >= _data.Length || index < 0) throw new IndexOutOfRangeException($"Выход за границы массива! Значение {index} недопустимо!");

                // возвращение элемента массива по индексу
                return _data[index];
            }

            set
            {
                // если индекс выходит за границы массива 
                if (index >= _data.Length || index < 0) throw new IndexOutOfRangeException($"Выход за границы массива! Значение {index} недопустимо!");

                // установка значения элемента по индексу
                _data[index] = value;
            }
        }

        #endregion

        #region Методы 

        // заполнение массива случайными значениями
        public void FillRandomArray(int n = 10, int lo = -5, int hi = 5)
        {
            // выделение памяти под массив
            _data = new int[n];

            // заполнение массива случайными элемента
            for (int i = 0; i < _data.Length; i++)
                _data[i] = App.rand.Next(lo, hi);
        }

        // вывод массива в строку
        public override string ToString()
        {
            // строка для элементов массива 
            string line = "";

            // вывод массива в строку
            for (int i = 0; i < _data.Length; i++)
                line += $"{_data[i]}   ";

            return line;
        }

        #endregion
    }
}
