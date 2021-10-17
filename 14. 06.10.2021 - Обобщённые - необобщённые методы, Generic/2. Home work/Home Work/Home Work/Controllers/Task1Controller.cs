using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;               // для использования утилит

using Home_Work.Models;        // подключение моделей

namespace Home_Work.Controllers
{
    // Класс Обработка по заданию
    internal class Task1Controller
    {
        // массив 
        public StorageArray<int> Data { get; set; } = new StorageArray<int>();

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
        public void Initialization() => Data.Initialization(() => rand.Next(-3, 3));

        #endregion

        #region Вывод массива

        // вывод масссива 
        public void Show(string name = "Массив", string info = "Исходные данные") => Data.Show(ShowHead, ShowElements);

        #endregion

        #region Количество минимальных элементов 

        // количество минимальных элементов
        public int CountMaxElements() => Data.CountMaxElem();

        // вывод массива с подсветкой максимальных элементов 
        public void ShowColorMaxElem(int max, string name = "Массив", string info = "Исходные данные") => Data.ShowColorElem(ShowHead, ShowColorElements, item => item == max);


        #endregion

        #region Сортировка 

        // сортировка 
        public void Sort() => Data.Sort((item1, item2) => item1.CompareTo(item2));

        #endregion

        #region Общие методы

        // вывод шапки таблицы 
        static private void ShowHead(int size, string name = "Массив", string info = "Исходные данные")
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
        private void ShowElements(int[] array)
        {
            // вывод рамки таблицы 
            ShowElemFrame(Data.Lenght);

            // индекс элемента
            int i = 0;

            // вывод элементов массива
            Array.ForEach(array, delegate (int item) { ShowElem(i++, item); });

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        }

        // вывод элементов
        private void ShowColorElements(int[] array, Predicate<int> predicate)
        {
            // вывод рамки таблицы 
            ShowElemFrame(Data.Lenght);

            // индекс элемента
            int i = 0;

            // вывод элементов массива
            Array.ForEach(array, delegate (int item) { ShowElem(i++, item, predicate(item)); });

            // позиционирование курсора
            PosXY(0, Console.CursorTop + 4);
        }

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

        // вывод элементов
        static private void ShowElem(int num, int value, bool flagActiveColor = false, ConsoleColor colorIndex = ConsoleColor.DarkYellow, ConsoleColor colorValue = ConsoleColor.Green)
        {
            // координаты для позиционирования 
            int x = Console.CursorLeft;
            int y = Console.CursorTop;

            // вывод индекса
            WriteColorXY($"{num,3}", x, y, textColor: flagActiveColor ? ConsoleColor.White : colorIndex);

            // вывод элемента 
            WriteColorXY($"{value,3}", x, y + 2, textColor: flagActiveColor ? ConsoleColor.Cyan : colorValue);

            // смещение позиции по x
            PosXY(x + 6, y);
        }

        #endregion

        #endregion

    }
}
