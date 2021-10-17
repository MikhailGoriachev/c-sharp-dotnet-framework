using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericArray
{
    // Обобщенный тип - вектор, контейнер для хранения 
    // одномерного массива

    // Функционал класса
    //    ☼ вывод массива с выделением локальных минимумов цветом
    //    ☼ поиск минимального и максимального элементов массива
    //    ☼ заполнение массива случайными значениями
    //    ☼ вывод массива на экран
    class Vector<T> where T : IComparable<T>  // CompareTo
    { 
        private T[] _data; //контейнер

        public Vector() : this(10) { }
        public Vector(int n)
        {
            _data = new T[n];

            // Заполнение массива значениями по умолчанию для типа T
            for (int i = 0; i < _data.Length; i++) _data[i] = default;
        } // Vector

        public int Length => _data.Length;


        // Индексатор
        public T this[int index] {
            get => _data[index];
            set => _data[index] = value;
        } // this


        // Вывод массива
        public void Show(string title) =>
            Console.Write($"{title}{this}");


        // Заполнение массива случайными величинами
        public void Fill(T low, T high) {
            for (int i = 0; i < _data.Length; i++) {
                _data[i] = Utils.GetRand(low, high);
            } // for i

        } // Fill


        // Вывод массива в строку
        public override string ToString() {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < _data.Length; i++) {
                // использование оператора typeof(тип)
                sb.Append($"{_data[i],10:0.#####}");
                if ((i + 1) % 8 == 0) sb.Append("\n");
            } // for i
            if (_data.Length % 8 != 0) sb.Append("\n");
            return sb.ToString();
        } // ToString

        // вывод массива с выделением локальных минимумов цветом
        public void ShowLocMinColored(string title, ConsoleColor color) {
            
            // Вспомогательный метод - для упрощения вывода
            string Helper(T x) =>
                typeof(T) == typeof(double) ? $"{x, 10:n5}" : $"{x, 8}";

            Console.WriteLine(title);
            Console.Write(Helper(_data[0]));
            for (int i = 1; i < _data.Length-1; i++) {
                string s = Helper(_data[i]);

                // data[i] < data[i-1] && data[i] < data[i+1]
                if (_data[i].CompareTo(_data[i - 1]) < 0 && _data[i].CompareTo(_data[i + 1]) < 0) {
                    Utils.SetColor(color, Console.BackgroundColor);
                    Console.Write(s);
                    Utils.RestoreColor();
                } else {
                    Console.Write(s);
                } // if

                if ((i + 1) % 8 == 0) Console.WriteLine(); 
            } // for i
            Console.Write(Helper(_data[_data.Length-1]));
            if (_data.Length % 8 != 0) Console.WriteLine();
        } // ShowLocMinColored


        // Поиск и возврат минимального и максимального элементов массива
        public void FindMinMax(out T min, out T max) {
            min = max = _data[0];
            for (int i = 1; i < _data.Length; i++) {
                if (_data[i].CompareTo(min) < 0) min = _data[i];
                if (_data[i].CompareTo(max) > 0) max = _data[i];
            } // for i
        } // FindMinMax
    } //  class Vector
}