using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Models.Task1
{
    // Класс Обработка по заданию
    internal class Task1
    {
        // коллекция данных (одномерный массив)
        private IntArray _data = new IntArray(10);

        #region Свойства 

        // свойство для доступа к полю _data
        public IntArray Data { get => _data; set => _data = value ?? _data; }

        #endregion

        #region Методы

        // произведение элементов с четными номерами
        public int ProdEven()
        {
            // произведение элементов
            int prod = 1;

            // вычисление произведения 
            for (int i = 0; i < _data.Length; i++)
                if ((i & 1) == 1) prod *= _data[i];

            return prod;
        }

        // вывод с выделением четных по номеру элементов
        public void ShowEvenNum(int prod, string name = "Массив", string info = "Исходные данные")
        {
            //                              15                         32                                 32                                            
            App.WriteColorXY("     ╔═════════════════╦══════════════════════════════════╦══════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║                                  ║                                  ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{_data.Length,3}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Название: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-22}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Инфо: ", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-26}", textColor: ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╦══════╦══════╦══════╦══════╬══════╦══════╦══════╦══════╦══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"    Индекс     ", 7, textColor: ConsoleColor.DarkYellow);

            // максимальный размер массива 
            const int n = 10;

            // вывод индексов
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{i,4}", x, textColor: (i & 1) == 0 ? ConsoleColor.DarkGray : ConsoleColor.Cyan);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"   Значение   ", 7, textColor: ConsoleColor.DarkYellow);

            // вывод значений
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{_data[i],4}", x, textColor: (i & 1) == 0 ? ConsoleColor.DarkGray : ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╩══════╩══════╩══════╩══════╩══════╬══════╩══════╩══════╬══════╩══════╣\n", textColor: ConsoleColor.Magenta);

            App.WriteColorXY("     ║                                                    ║                    ║             ║", textColor: ConsoleColor.Magenta);

            App.WriteColorXY($"Произведение", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{prod, 11}", 81, textColor: ConsoleColor.Blue);

            Console.WriteLine();

            App.WriteColorXY("     ╚════════════════════════════════════════════════════╩════════════════════╩═════════════╝\n", textColor: ConsoleColor.Magenta);

        }

        // cумма элементов между первыми и последним нулевыми элементами
        public int SumFirstLastNull(out int first, out int last)
        {
            // индексы первого и последнего элементов со значением 0
            last = first = -1;

            // поиск индексов 
            for (int i = 0; i < _data.Length; i++)
                if (_data[i] == 0) { last = i; if (first == -1) first = i; }

            // сумма элементов 
            int sum = 0;

            // вычисление суммы
            for (int i = first + 1; i < last; i++)
                sum += _data[i];

            return sum;

        }

        // вывод с выделением границ и слогаемых элементов
        public void ShowSumElem(int sum, int first, int last, string name = "Массив", string info = "Исходные данные")
        {
            //                              15                         32                                 32                                            
            App.WriteColorXY("     ╔═════════════════╦══════════════════════════════════╦══════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║                                  ║                                  ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{_data.Length,3}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Название: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-22}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Инфо: ", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-26}", textColor: ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╦══════╦══════╦══════╦══════╬══════╦══════╦══════╦══════╦══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"    Индекс     ", 7, textColor: ConsoleColor.DarkYellow);

            // максимальный размер массива 
            const int n = 10;

            // вывод индексов
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{i,4}", x, textColor: i < first || i > last ? ConsoleColor.DarkGray : 
                    i == first || i == last ? ConsoleColor.Red : ConsoleColor.Cyan);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"   Значение   ", 7, textColor: ConsoleColor.DarkYellow);

            // вывод значений
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{_data[i],4}", x, textColor: i < first || i > last ? ConsoleColor.DarkGray : 
                    i == first || i == last ? ConsoleColor.DarkRed : ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╩══════╩══════╩══════╩══════╩══════╬══════╩══════╩══════╬══════╩══════╣\n", textColor: ConsoleColor.Magenta);

            App.WriteColorXY("     ║                                                    ║                    ║             ║", textColor: ConsoleColor.Magenta);

            App.WriteColorXY($"Сумма", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{sum,11}", 81, textColor: ConsoleColor.Blue);

            Console.WriteLine();

            App.WriteColorXY("     ╚════════════════════════════════════════════════════╩════════════════════╩═════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // Смена знака отрицательных элементов и сортировка по убыванию
        // (сортировка вставками)
        public void ChangeSignSort()
        {
            // смена знака отрицательных элементов
            for (int i = 0; i < _data.Length; i++)
                if (_data[i] < 0) _data[i] = -_data[i];

            // сортировка вставками
            InsertSort(_data);
        }

        // сортировка вставками         Источик: http://algolist.ru/sort/insert_sort.php
        private void InsertSort(IntArray a)
        {
            int x;
            int i, j;

            int size = a.Length;

            for (i = 0; i < size; i++)
            {  // цикл проходов, i - номер прохода
                x = a[i];

                // поиск места элемента в готовой последовательности 
                for (j = i - 1; j >= 0 && a[j] < x; j--)
                    a[j + 1] = a[j];    // сдвигаем элемент направо, пока не дошли

                // место найдено, вставить элемент
                a[j + 1] = x;
            }
        }

        // вывод массива с подсветкой элементов по индексам
        public void ShowColorIndex(int[] index, string name = "Массив", string info = "Исходные данные")
        {
            //                              15                         32                                 32                                            
            App.WriteColorXY("     ╔═════════════════╦══════════════════════════════════╦══════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║                                  ║                                  ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{_data.Length,3}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Название: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-22}", textColor: ConsoleColor.Green);
            App.WriteColorXY($"Инфо: ", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-26}", textColor: ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╦══════╦══════╦══════╦══════╬══════╦══════╦══════╦══════╦══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"    Индекс     ", 7, textColor: ConsoleColor.DarkYellow);

            // максимальный размер массива 
            const int n = 10;

            // вывод индексов
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{i,4}", x, textColor: Array.IndexOf(index, i) == -1 ? ConsoleColor.Cyan : ConsoleColor.Blue);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"   Значение   ", 7, textColor: ConsoleColor.DarkYellow);

            // вывод значений
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{_data[i],4}", x, textColor: Array.IndexOf(index, i) == -1 ? ConsoleColor.Green : ConsoleColor.DarkRed);

            Console.WriteLine();

            App.WriteColorXY("     ╚═════════════════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╝\n", textColor: ConsoleColor.Magenta);
        }

        // вывод массива
        public void ShowData(string name = "Массив", string info = "Исходные данные")
        {
            //                              15                         32                                 32                                            
            App.WriteColorXY("     ╔═════════════════╦══════════════════════════════════╦══════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║                                  ║                                  ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"Размер: ",            7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{_data.Length,3}",       textColor: ConsoleColor.Green);
            App.WriteColorXY($"Название: ",         25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-22}",             textColor: ConsoleColor.Green);
            App.WriteColorXY($"Инфо: ",             60, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-26}",             textColor: ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╦══════╦══════╦══════╦══════╬══════╦══════╦══════╦══════╦══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"    Индекс     ", 7, textColor: ConsoleColor.DarkYellow);

            // максимальный размер массива 
            const int n = 10;

            // вывод индексов
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{i,4}", x, textColor: ConsoleColor.Cyan);

            Console.WriteLine();

            App.WriteColorXY("     ╠═════════════════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╬══════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("     ║                 ║      ║      ║      ║      ║      ║      ║      ║      ║      ║      ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"   Значение   ", 7, textColor: ConsoleColor.DarkYellow);

            // вывод значений
            for (int i = 0, x = 25; i < n; i++, x += 7)
                App.WriteColorXY($"{_data[i],4}", x, textColor: ConsoleColor.Green);

            Console.WriteLine();

            App.WriteColorXY("     ╚═════════════════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╩══════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion
    }
}
