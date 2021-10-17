using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Пространство имен Задание 2. Комната
namespace Home_Work.Task_2_Room
{
    // Класс Массив Комнат
    public class ArrayRoom
    {
        #region Свойства 

        // название коллекции 
        public string Name { get; set; } = "Комнаты";

        // коллекция комнат
        public Room[] Rooms { get; set; } = new Room[0];

        #endregion

        #region Методы 

        // сортировка по убыванию площади
        public void SortByArea()
        {
            // компаратор для сортировки
            int CompareToArea(Room r1, Room r2) => r2.Area.CompareTo(r1.Area);

            // сортировка 
            Array.Sort(Rooms, CompareToArea);
        }

        // сортировка по возрастанию количества окон
        public void SortByWindow()
        {
            // компаратор для сортировки
            int CompareToWindow(Room r1, Room r2) => r1.Window.CompareTo(r2.Window);

            // сортировка 
            Array.Sort(Rooms, CompareToWindow);
        }

        // вывод таблицы 
        public void ShowTable(string info = "Исходные данные")
        {
            // вывод шапки таблицы 
            ShowHead(Rooms.Length, Name, info);

            // вывод элементов таблицы 
            ShowElem();
        }

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name = "Треугольники", string info = "Исходные данные")
        {
            App.WriteColor  ("          ╔════════════╦═══════════════════════════════════════════╗\n", ConsoleColor.Magenta);
            App.WriteColor  ("          ║            ║                                           ║", ConsoleColor.Magenta);

            App.WriteColorXY($"Название: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-31}", textColor: ConsoleColor.Green);

            App.WriteColor("\n          ║            ╠═══════════════════════════════════════════╣", ConsoleColor.Magenta);

            App.WriteColorXY($"Размер: ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);


            App.WriteColor  ("\n          ║            ║                                           ║", ConsoleColor.Magenta);
                        
            App.WriteColorXY($"Информация: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-29}", textColor: ConsoleColor.Green);

            App.WriteColor("\n          ╠════╦═══════╩════╦════════════╦════════════╦════════════╣\n", ConsoleColor.Magenta);
            App.WriteColor  ("          ║    ║            ║            ║            ║            ║", ConsoleColor.Magenta);
            App.WriteColorXY($"N ",         12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($" Площадь  ", 17, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"  Высота  ", 30, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"   Окна   ", 43, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"  Объем   ", 56, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n          ╠════╬════════════╬════════════╬════════════╬════════════╣\n", ConsoleColor.Magenta);

        }

        // вывод элементов в таблицу
        public void ShowElem()
        {
            // если нет элементов в таблице
            if (Rooms.Length == 0)
                ShowEmpty();

            else
            {
                // номер элемента
                int num = 1;

                // вывод элементов
                foreach (var item in Rooms)
                    item.ShowElem(num++);

                App.WriteColor("          ╚════╩════════════╩════════════╩════════════╩════════════╝\n", ConsoleColor.Magenta);
            }

        }

        // вывод сообщения об отсутствии данных
        static public void ShowEmpty()
        {
            App.WriteColor("          ╠════╩════════════╩════════════╩════════════╩════════════╣\n", ConsoleColor.Red);
            App.WriteColor("          ║                                                        ║\n", ConsoleColor.Red);
            App.WriteColor("          ║                                                        ║\n", ConsoleColor.Red);
            App.WriteColor("          ║                       НЕТ ДАННЫХ                       ║\n", ConsoleColor.Red);
            App.WriteColor("          ║                                                        ║\n", ConsoleColor.Red);
            App.WriteColor("          ║                                                        ║\n", ConsoleColor.Red);
            App.WriteColor("          ╚════════════════════════════════════════════════════════╝\n", ConsoleColor.Red);
            Console.WriteLine();
        }

        #endregion
    }
}
