using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Пространство имён Задание 1. Треугольник
namespace Home_Work.Task_1_Triangle
{
    // Класс Массив треугольников
    public class ArrayTriangle
    {
        #region Свойства

        // название коллекции 
        public string Name { get; set; } = "Треугольники";

        // коллекция треугольников 
        public Triangle[] Triangles { get; set; } = new Triangle[0];

        #endregion

        #region Методы 

        // cортировка по убыванию периметров
        public void SortByPerimeter()
        {
            // компаратор по периметру
            int CompareToPerimeter(Triangle t1, Triangle t2)
                => t2.Perimeter().CompareTo(t1.Perimeter());

            // сортировка 
            Array.Sort(Triangles, CompareToPerimeter);
        }

        // сортировка по возрастанию площадей
        public void SortByArea()
        {
            // компаратор по площади
            int CompareToArea(Triangle t1, Triangle t2)
                => t1.Area().CompareTo(t2.Area());

            // сортировка 
            Array.Sort(Triangles, CompareToArea);
        }

        // вывод таблицы
        public void ShowTable(string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(Triangles.Length, Name, info);

            // вывод элементов 
            ShowElem(Triangles);
        }

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name = "Треугольники", string info = "Исходные данные")
        {
            App.WriteColor("     ╔════════════╦═══════════════════════════════════════════╦═══════════════════════════════════════════════════╗\n", ConsoleColor.Magenta);
            App.WriteColor("     ║            ║                                           ║                                                   ║", ConsoleColor.Magenta);

            App.WriteColorXY($"Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);

            App.WriteColorXY($"Название: ", 20, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-31}", textColor: ConsoleColor.Green);

            App.WriteColorXY($"Информация: ", 64, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-38}", textColor: ConsoleColor.Green);

            App.WriteColor("\n     ╠════╦═══════╩════╦════════════╦════════════╦════════════╬════════════╦════════════╦════════════╦════════════╣\n", ConsoleColor.Magenta);
            App.WriteColor  ("     ║    ║            ║            ║            ║            ║            ║            ║            ║            ║",   ConsoleColor.Magenta);
            App.WriteColorXY($"N ",          7, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Сторона A ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Сторона B ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Сторона C ", 38, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($" Периметр ", 51, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($" Площадь  ", 64, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Медиана a ", 77, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Медиана b ", 90, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"Медиана c ", 103, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n     ╠════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╬════════════╣\n", ConsoleColor.Magenta);

        }

        // вывод элементов 
        static public void ShowElem(Triangle[] triangles)
        {
            // если нет элементов в таблице
            if (triangles.Length == 0)
                ShowEmpty();

            else
            {
                // номер элемента
                int num = 1;

                // вывод элементов
                foreach (var item in triangles)
                    item.ShowElem(num++);

                App.WriteColor("     ╚════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╝\n", ConsoleColor.Magenta);
            }
        }

        // вывод сообщения об отсутствии данных
        static public void ShowEmpty()
        {
            App.WriteColor("     ╠════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╩════════════╣\n", ConsoleColor.Red);
            App.WriteColor("     ║                                                                                                            ║\n", ConsoleColor.Red);
            App.WriteColor("     ║                                                                                                            ║\n", ConsoleColor.Red);
            App.WriteColor("     ║                                                 НЕТ ДАННЫХ                                                 ║\n", ConsoleColor.Red);
            App.WriteColor("     ║                                                                                                            ║\n", ConsoleColor.Red);
            App.WriteColor("     ║                                                                                                            ║\n", ConsoleColor.Red);
            App.WriteColor("     ╚════════════════════════════════════════════════════════════════════════════════════════════════════════════╝\n", ConsoleColor.Red);
            Console.WriteLine();
        }

        #endregion
    }
}
