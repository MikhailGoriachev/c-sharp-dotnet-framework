using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work.Interface;                      // для использования интерфейсов
using Home_Work.Models.Task1;                   // для использования классов первого задания

using static Home_Work.Application.App.Utils;   // для использования утилит

namespace Home_Work.Controllers
{
    // Класс Обработка по заданию 1
    internal class Task1
    {
        // коллекция уравнений 
        private ISolver[] _solvers;

        #region Конструкторы

        // конструктор по умолчанию
        public Task1()
        {
            // создание массива 
            _solvers = new ISolver[20];

            // инициализация
            Initialization();
        }

        #endregion

        #region Свойства 

        // количество решений 
        public int CountSolve => CountSolveSquare() + CountSolveLinear();

        // количество выражений 
        public int CountEquat => CountEquatSquare() + CountEquatLinear();

        #endregion

        #region Методы 

        #region Инициализация массива 

        // инициализация массива 
        public void Initialization()
        {
            // генерация уравнений
            for (int i = 0; i < _solvers.Length; i++)
                _solvers[i] = FactoryMethod(rand.Next(0, 2));
        }

        // фабричный метод для создания выражения
        private ISolver FactoryMethod(int code)
        {
            switch (code)
            {
                // линейное уравнение 
                case 0:
                    return new Linear() { A = rand.Next(-5, 5), B = rand.Next(-5, 5) };

                // квадратное уравнение
                case 1:
                    return new Square() { A = rand.Next(-5, 5), B = rand.Next(-5, 5), C = rand.Next(-5, 5) };

                default:
                    goto case 0;
            }
        }

        #endregion

        #region Вычисление выражений

        // вычисление выражений
        public void Solve() { foreach (var item in _solvers) item.Solve(); }

        #endregion

        #region Количество решений квадратных выражений

        // количество решений квадратных выражений
        public int CountSolveSquare()
        {
            // количество 
            int count = 0;

            // счётчик с условием
            void Counter(ISolver s) { if (s.GetName() == Square.Name && s.HasSolver()) count++; };

            // подсчёт 
            Array.ForEach(_solvers, Counter);

            return count;
        }

        #endregion

        #region Количество решений линейных выражений

        // количество решений линейных выражений
        public int CountSolveLinear()
        {
            // количество 
            int count = 0;

            // счётчик с условием
            void Counter(ISolver s) { if (s.GetName() == Linear.Name && s.HasSolver()) count++; };

            // подсчёт 
            Array.ForEach(_solvers, Counter);

            return count;
        }

        #endregion

        #region Количество квдратных выражений

        // количество квдратных выражений
        public int CountEquatSquare()
        {
            // количество 
            int count = 0;

            // счётчик с условием
            void Counter(ISolver s) { if (s.GetName() == Square.Name) count++; };

            // подсчёт 
            Array.ForEach(_solvers, Counter);

            return count;
        }

        #endregion

        #region Количество линейных выражений

        // количество линейных выражений
        public int CountEquatLinear()
        {
            // количество 
            int count = 0;

            // счётчик с условием
            void Counter(ISolver s) { if (s.GetName() == Linear.Name) count++; };

            // подсчёт 
            Array.ForEach(_solvers, Counter);

            return count;
        }

        #endregion

        #region Вывод массива в таблицу

        // вывод массива в таблицу
        public void ShowTable(string name = "Уравнения", string info = "Исходные данные")
        {
            // вывод шапки таблицы 
            ShowHead(_solvers.Length, name, info);

            // вывод элементов в таблицу 
            ShowElem(_solvers);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public void ShowHead(int size, string name = "Уравнения", string info = "Исходные данные")
        {
            //                      10                            40                                        44
            WriteColorXY("     ╔════════════╦══════════════════════════════════════════╦══════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                          ║                                              ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size, 2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name, -30}",textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 63, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info, -38}", textColor: ConsoleColor.Green);
            Console.WriteLine();

            //                    2          15           5       5       5              20                          30
            WriteColorXY("     ╠════╦═══════╩═════════╦═══════╦═══════╦═══════╦════════╩═════════════╦════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
            //                                                     12,44          ax2 + bx + c = 0       x1 = 45, 2; x2 = 456;
            WriteColorXY("     ║    ║                 ║       ║       ║       ║                      ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Тип уравнения ", 12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  a  ", 30, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  b  ", 38, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  c  ", 46, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("     Уравнение      ", 54, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("          Результат           ", 77, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠════╬═════════════════╬═══════╬═══════╬═══════╬══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);

        }

        // вывод элементов в таблицу
        public void ShowElem(ISolver[] solvers)
        {
            for (int i = 0; i < _solvers.Length; i++)
                _solvers[i].Show(i + 1);
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩═════════════════╩═══════╩═══════╩═══════╩══════════════════════╩════════════════════════════════╝\n", posY:Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        #endregion

        #region Вывод статистики

        // вывод статистики
        public void ShowStatistics(int countSolve, int countEquat, int countSolveLinear, int countSolveSquare, int countEquatLinear, int countEquatSquare)
        {
            // вывод рамки
            //                                 30                     10
            WriteColorXY("     ╔════════════════════════════════╦════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("      Название показателя      ",  7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Значение ", 40, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            // количество уравнений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Общее количество уравнений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countEquat, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();

            // количество квадратных уравнений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Количество квадратных уравнений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countEquatSquare, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();

            // количество линейных уравнений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Количество линейных уравнений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countEquatLinear, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();

            // общее количество решений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Общее количество решений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countSolve, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();

            // решение квадратных уравнений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Решение квадратных уравнений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countSolveSquare, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();

            // решение линейных уравнений
            WriteColorXY("     ╠════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Решение линейных уравнений", 7, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{countSolveLinear, 10}", 40, textColor: ConsoleColor.Green);
            Console.WriteLine();
            WriteColorXY("     ╚════════════════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #endregion
    }
}
