using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;       // подключение утилит

/*
     * Задача 1. Разработайте классы для обработки массивов, при этом 
     * предикаты и компараторы реализовать при помощи делегатов. 
     * Реализация компараторов анонимными методами, предикатов – 
     * именованными делегатами (сохраненными в переменных).
     * 
     * В одномерном массиве, состоящем из п целых элементов:
     * •	вычислить количество элементов, равных минимальному 
     *      элементу массива;
     * •	вычислить сумму элементов массива, расположенных между 
     *      первым и последним положительными элементами;
     * •	преобразовать массив таким образом, чтобы сначала 
     *      располагались все   элементы, равные нулю, а потом — все 
     *      остальные.
     * Все три обработки запускать одним делегатом.
     * 
     * В одномерном массиве, состоящем из п целых элементов:
     * •	вычислить количество отрицательных элементов массива;
     * •	вычислить сумму элементов массива, расположенных между 
     *      первым и вторым отрицательными элементами;
     * •	преобразовать массив таким образом, чтобы сначала 
     *      располагались все элементы, модуль которых не превышает 
     *      3, а потом — все остальные.
     * Все три обработки запускать одним делегатом.
 */

namespace Home_work.Controllers
{
    // делегат для предикатора
    public delegate bool PredicateDelegate(int item);

    // делегат для обработки по заданию 
    public delegate void ProcessingDelegate();

    // делегат для вывода элементов 
    public delegate void ShowDelegate(int[] array);

    // Класс Обработка по заданию 1
    internal class Task1Controller
    {
        // массив элементов 
        private int[] _data;

        #region Свойства 

        // доступ к полю _array
        public int[] Data { get => _data; set => _data = value; }

        #endregion

        #region Конструкторы

        // конструктор по умолчанию
        public Task1Controller()
        {
            // установка значений
            Initialization();
        }

        #endregion 

        #region Методы

        #region Инициализация массива

        // инициализация массива 
        public void Initialization(int min = -3, int max = 3)
        {
            // размер массива 
            const int lenght = 10;

            // выделение памяти
            if (_data == null) _data = new int[lenght];

            // заполнение массива случайными значениями
            for (int i = 0; i < _data.Length; i++) _data[i] = rand.Next(min, max);
        }

        #endregion

        #region Обработка массива 1

        /*
        * •	вычислить количество элементов, равных минимальному 
        *   элементу массива;
        * •	вычислить сумму элементов массива, расположенных между
        *   первым и последним положительными элементами;
        * •	преобразовать массив таким образом, чтобы сначала
        *   располагались все элементы, равные нулю, а потом — все
        *   остальные.
        */

        // обработка массива 1
        public (int countElem, int sum) Processing1()
        {
            // минимальное значение
            int min = _data[0];

            // поиск минимального значения 
            Array.ForEach(_data, item => { if (item < min) min = item; });

            // предикатор для вычисления количества минимальных элементов 
            PredicateDelegate isMin = delegate (int item) { return item == min; };

            // делегат сортирующий массив 
            ProcessingDelegate Sort = delegate () { Array.Sort(_data, delegate (int a, int b) { return a == 0 && b != 0 ? -1 : a != 0 && b == 0 ? 1 : 0; }); };

            // сумма элементов
            int sum = 0;

            // количество минимальных элементов 
            int countMin = 0;

            // делегат для группового выполнения
            ProcessingDelegate processing = delegate () { sum = SumFirstLastPos(); };
            processing += delegate () { Array.ForEach(_data, delegate (int item) { if (isMin(item)) countMin++; }); };
            processing += Sort;

            // обработка по заданию 
            processing();

            return (countMin, sum);
        }

        // получение суммы между первым и последним положительными элементами
        private int SumFirstLastPos()
        {
            // поиск индексов первого и последнего положительного элемента 
            int first = Array.FindIndex(_data, delegate (int item) { return item >= 0; });
            int last = Array.FindLastIndex(_data, delegate (int item) { return item >= 0; });

            // предикатор для вычислении суммы элементов 
            PredicateDelegate isInRange = delegate (int item) { return item > first && item < last; };

            // сумма 
            int sum = 0;

            // получение суммы 
            for (int i = 0; i < _data.Length; i++) { if (isInRange(i)) sum += _data[i]; }

            return sum;
        }

        #endregion

        #region Обработка массива 2

        /*
         * •	вычислить количество отрицательных элементов массива;
         * •	вычислить сумму элементов массива, расположенных между 
         *      первым и вторым отрицательными элементами;
         * •	преобразовать массив таким образом, чтобы сначала 
         *      располагались все элементы, модуль которых не превышает 
         *      3, а потом — все остальные.
         */

        // Обработка массива 2
        public (int countElem, int sum) Processing2()
        {
            // предикатор для вычисления количества отрицательных элементов 
            PredicateDelegate isNeg = delegate (int item) { return item < 0; };

            // делегат сортирующий массив 
            ProcessingDelegate Sort = delegate () { Array.Sort(_data, delegate (int a, int b) {
                // модули элементов 
                int absA = Math.Abs(a);
                int absB = Math.Abs(b);

                return absA <= 3 && absB > 3 ? -1 : absA > 3 && absB <= 3 ? 1 : 0; }); 
            };

            // сумма элементов
            int sum = 0;

            // количество минимальных элементов 
            int countNeg = 0;

            // делегат для группового выполнения
            ProcessingDelegate processing = delegate () { sum = SumFirstSecondNeg(); };
            processing += delegate () { Array.ForEach(_data, item => { if (isNeg(item)) countNeg++; }); };
            processing += Sort;

            // обработка по заданию 
            processing();

            return (countNeg, sum);
        }

        // получение суммы между первым и вторым отрицательным элементами
        private int SumFirstSecondNeg()
        {
            // поиск индексов первого и второго отрицательных элементов
            int first = Array.FindIndex(_data, delegate (int item) { return item < 0; });
            int second = Array.FindIndex(_data, first + 1, delegate (int item) { return item < 0; });

            // предикатор для вычислении суммы элементов 
            PredicateDelegate isInRange = delegate (int item) { return item > first && item < second; };

            // сумма 
            int sum = 0;

            // получение суммы 
            for (int i = 0; i < _data.Length; i++) { if (isInRange(i)) sum += _data[i]; }

            return sum;
        }


        #endregion

        #region Вывод массива с подсветкой минимальных элементов

        // вывод массива с нулевых елементов
        static public ShowDelegate ShowElementsProc1 = delegate (int[] array)
        {
            // индекс элемента
            int i = 0;

            // вывод элементов массива
            Array.ForEach(array, delegate (int item) { ShowElem(i++, item, colorValue: item == 0 ? ConsoleColor.Blue : ConsoleColor.Green); });

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        };

        #endregion

        #region Вывод массива с подсветкой элементов, которые по модулю не превышают 3

        // вывод массива с подсветкой элементов, которые по модулю не превышают 3
        static public ShowDelegate ShowElementsProc2 = delegate (int[] array)
        {
            // индекс элемента
            int i = 0;

            // вывод элементов массива
            Array.ForEach(array, item => ShowElem(i++, item, colorValue: Math.Abs(item) <= 3 ? ConsoleColor.Blue : ConsoleColor.Green));

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        };

        #endregion

        #region Вывод массива 

        // вывод массива
        public void ShowArray(ShowDelegate showElemnts, string name = "Массив", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(_data.Length, name, info);

            // вывод рамки таблицы 
            ShowElemFrame(_data.Length);

            // вывод элементов
            showElemnts(_data);
        }

        #endregion

        #region Вывод условий обработки задания 1

        // вывод условий обработки задания 1
        public void ShowConditionsProc1()
        {
            //                                                         80
            WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("                              Условия обработки", 7, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"1. Вычислить количество элементов, равных минимальному элементу массива", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"2. Вычислить сумму элементов массива, расположенных между первым и последним", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"положительными элементами", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"3. Преобразовать массив таким образом, чтобы сначала располагались все элементы", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"равные нулю, а потом — все остальные", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #region Вывод условий обработки задания 2

        // вывод условий обработки задания 2
        public void ShowConditionsProc2()
        {
            //                                                       80
            WriteColorXY("     ╔══════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("                              Условия обработки", 7, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════════════════════════════════════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"1. Вычислить количество отрицательных элементов массива", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"2. Вычислить сумму элементов массива, расположенных между первым и вторым", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"отрицательными элементами", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"3. Преобразовать массив таким образом, чтобы сначала располагались все элементы,", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ║                                                                                  ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"модуль которых не превышает 3, а потом — все остальные", 7, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╚══════════════════════════════════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);

        }

        #endregion 

        #region Вывод результатов первой обработки

        // вывод результатов первой обработки
        public void ShowResult1((int countElem, int sum) info)
        {
            WriteColorXY("     ╔══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("      Название      ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Значение ", 30, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"Кол-во мин. элементов", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{info.countElem, 10}", 30, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"Сумма элементов", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{info.sum, 10}", 30, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #region Вывод результатов второй обработки

        // вывод результатов второй обработки
        public void ShowResult2((int countElem, int sum) info)
        {
            WriteColorXY("     ╔══════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("      Название      ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Значение ", 30, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"Кол-во элементов", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{info.countElem,10}", 30, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╠══════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                      ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"Сумма элементов", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{info.sum,10}", 30, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚══════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #region Общие методы

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name = "Массив", string info = "Исходные данные")
        {
            //                  10                     30                                   33
            WriteColorXY("     ╔════════════╦═════════════════════════════════╦═════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                 ║                                 ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-20}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-25}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚════════════╩═════════════════════════════════╩═════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // вывод элементов
        static public ShowDelegate ShowElements = delegate (int[] array)
        {
            // индекс элемента
            int i = 0;

            // вывод элементов массива
            Array.ForEach(array, delegate (int item) { ShowElem(i++, item); });

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        };

        // вывод рамки для вывода значений элементов с индексированием 
        static private void ShowElemFrame(int countElem)
        {
            // разделительная линия между полями заголовка
            string line = new string('═', 80);

            // координаты для позиционирования курсора
            int x = 5;
            int y = Console.CursorTop;

            // если количество элементов равно нулю
            if (countElem == 0)
            {
                // вывод сообщения 
                WriteColorXY($"╔{line}╗", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y, ConsoleColor.Magenta);
                WriteColorXY($"{"Нет данных"}", x + 36, y++, ConsoleColor.Red);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"║{' ',80}║", x, y++, ConsoleColor.Magenta);
                WriteColorXY($"╚{line}╝", x, y++, ConsoleColor.Magenta);

                // позиционирование 
                PosXY(0, y + 1);

                return;
            }

            // исходная позиция по y
            int yTemp = y;

            // чать разделительной линии 
            string partLine = new string('═', 20);

            // вывод рамки

            // вывод линии разделителя 
            WriteColorXY($"╔{partLine,-20}╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╦═════╗", x, y++, ConsoleColor.Magenta);

            // позиционирование 
            PosXY(x, y);

            // вывод 
            WriteColorXY($"║ ", textColor: ConsoleColor.Magenta);
            WriteColorXY($"      Индекс      ", textColor: ConsoleColor.Cyan);
            WriteColorXY($" ║ ", textColor: ConsoleColor.Magenta);

            // вывод индексов
            WriteColorXY(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n\n",
            x + 20, y, ConsoleColor.Magenta);

            // вывод линии разделителя 
            WriteColorXY($"╠{partLine,-20}╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╬═════╣", x, ++y, ConsoleColor.Magenta);

            WriteColorXY($"║ ", x, ++y, textColor: ConsoleColor.Magenta);
            WriteColorXY($"     Значение    ", textColor: ConsoleColor.Cyan);

            // вывод полей для вывода элементов 
            WriteColorXY(" ║     ║     ║     ║     ║     ║     ║     ║     ║     ║     ║\n",
            x + 20, y, ConsoleColor.Magenta);

            // вывод линии разделителя подвала
            WriteColorXY($"╚{partLine,-20}╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╩═════╝", x, textColor: ConsoleColor.Magenta);

            y++;

            // установка курсора для вывода значения первого элемента 
            PosXY(x + 23, yTemp + 1);
        }

        // вывод элементв 
        static private void ShowElem(int num, int value, ConsoleColor colorIndex = ConsoleColor.DarkYellow, ConsoleColor colorValue = ConsoleColor.Green)
        {
            // координаты для позиционирования 
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            // вывод индекса
            WriteColorXY($"{num,3}", x, y, textColor: colorIndex);

            // вывод элемента 
            WriteColorXY($"{value,3}", x, y + 2, textColor: colorValue);

            // смещение позиции по x
            PosXY(x + 6, y);
        }

        #endregion

        #endregion
    }
}
