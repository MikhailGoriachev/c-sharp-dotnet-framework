using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollection
{
    class Utils
    {
        // Вспомогательная переменная
        private static Random random = new Random();

        // Обобщенный метод для формирования случайного числа
        public static T GetRandom<T>(T min, T max) where T: struct {
            // значение по умолчанию для заданного типа
            T rand = default(T);

            // генерация случайного числа, в зависимости от типа T
            // обратите внимание на двойное приведение типов 
            if (typeof(T) == typeof(int))            // для int
                rand = (T)(object)(random.Next((int)(object)min, (int)(object)max + 1));
            else if (typeof(T) == typeof(double))   // для double
                rand = (T)(object)((double)(object)min + ((double)(object)max - (double)(object)min) * random.NextDouble());
            else                                    // для остальных типов
                rand = (T)(object)random.Next();
            return rand;
        } // GetRandom


        // создание очереди из size элементов, заполнение ее 
        // случайными числами в диапазоне значаений от from 
        // до to
        public static Queue<T> CreateQueue<T>(int size, T from, T to) where T: struct {
            Queue<T> queue = new Queue<T>();

            for (int i = 0; i < size; i++) {
                queue.Enqueue(GetRandom(from, to));
            } // for i
            return queue;
        } // CreateQueue


        /// <summary>
        /// Возвращает упорядоченную обобщенную очередь из случайных чисел 
        /// </summary>
        /// <param name="size">Размер очереди</param>
        /// <param name="from">Начальное значение диапазона случайных</param>
        /// <param name="to">Конечное значение диапазона случайных</param>
        /// <returns>Упорядоченную по возрастанию обобщенную очередь</returns>
        public static Queue<T> CreateOrderedQueue<T>(int size, T from, T to) where T: struct {
            T[] a = CreateOrderedArray<T>(size, from, to);
            Queue<T> queue = new Queue<T>(a);
            return queue;
        } // CreateOrderedQueue

        /// <summary>
        /// Возвращает массив элементов, отсортированных по возрастанию
        /// </summary>
        /// <param name="size"></param>Размер массива
        /// <param name="from">Начальное значение диапазона случайных значений</param>
        /// <param name="to">Конечное значение диапазона случайных значений</param>
        /// <returns>Упорядоченный по возрастанию массив значений</returns>
        private static T[] CreateOrderedArray<T>(int size, T from, T to) where T: struct
        {
            T[] a = new T[size];
            for (int i = 0; i < a.Length; i++) a[i] = GetRandom(from, to);
            Array.Sort(a);
            return a;
        } // CreateOrderedArray


        // Преобразование queue очереди в строку
        public static string ToString<T>(Queue<T> queue) {
            StringBuilder sb = new StringBuilder("");
            foreach (var item in queue) {
                if (typeof(T) == typeof(double) || typeof(T) == typeof(float))
                    sb.Append($"{item,12:n3}");
                else
                    sb.Append($"{item, 5}");
            } // foreach
            return sb.ToString();
        } // ToString
    } // class Utils
} 