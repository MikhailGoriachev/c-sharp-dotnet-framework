using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Класс Туристическая компания
namespace Home_Work.Task_2._Route
{
    internal class Company
    {
        #region Свойства 

        // название компании
        public string Name { get; set; }

        // коллекция маршрутов
        public Route[] Routes { get; set; }

        #endregion

        #region Методы 

        // сортировка по коду маршрута
        public void SortByCode()
        {
            // компаратор
            int CompareToCode(Route r1, Route r2) => r1.CodeRoute.CompareTo(r2.CodeRoute);

            // сортировка 
            Array.Sort(Routes ?? new Route[0], CompareToCode);
        }

        // cортировка по пункту отправления
        public void SortByPointDepart()
        {
            // компаратор
            int CompareToPointDepart(Route r1, Route r2) => r1.PointDepart.CompareTo(r2.PointDepart);

            // сортировка 
            Array.Sort(Routes ?? new Route[0], CompareToPointDepart);
        }

        // сортировка дистанции маршрута
        public void SortByDistance()
        {
            // компаратор
            int CompareToDistance(Route r1, Route r2) => r2.Distance.CompareTo(r1.Distance);

            // сортировка 
            Array.Sort(Routes ?? new Route[0], CompareToDistance);
        }

        // выбор по диапазону дистанции маршрута
        public Route[] SelectByDistance(int min, int max)
        {
            // предикатор
            bool pred(Route r) => r.Distance >= min && r.Distance <= max;

            // отбор
            return Array.FindAll(Routes ?? new Route[0], pred);
        }

        // выбор по пункту
        public Route[] SelectByPoint(string point)
        {
            // предикатор
            bool pred(Route r) => r.PointDepart.Equals(point) || r.PointDest.Equals(point);

            // отбор
            return Array.FindAll(Routes ?? new Route[0], pred);
        }

        // вывод компании в таблицу
        public void ShowTable(string info = "Маршруты")
        {
            // вывод шапки таблицы
            ShowHead(Routes?.Length ?? 0, Name, info);

            // вывод элементов 
            ShowElem(Routes);
        }

        // вывод шапки таблицы 
        static public void ShowHead(int size, string name, string info = "Маршруты")
        {
            //          10                                          30                              29               
            App.WriteColorXY("          ╔════════════╦════════════════════════════════╦══════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("          ║            ║                                ║                              ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("Размер: ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            App.WriteColorXY("Компания: ", 25, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-20}", textColor: ConsoleColor.Green);
            App.WriteColorXY("Инфо: ", 58, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-22}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╦═══════╩══════════════╦═════════════════╩════╦════════════╦════════════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("          ║    ║                      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("N ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Пункт отправления  ", 17, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("  Пункт назначения  ", 40, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Код    ", 63, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("Дистанция ", 76, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ║    ║                      ║                      ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY(" маршрута ", 63, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("    км    ", 76, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╬══════════════════════╬══════════════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);

        }

        // вывод элементов таблицы
        static public void ShowElem(Route[] routes)
        {
            // если данных нет или массив пуст
            if ((routes?.Length ?? 0) == 0)
                ShowEmpty();

            else
            {
                // порядковый номер 
                int num = 1;

                // вывод элементов 
                foreach (var r in routes)
                {
                    r.ShowElem(num++);
                }

                // вывод подвала таблицы
                ShowLine();
            }
        }

        // вывод подвала таблицы
        static public void ShowLine()
        {
            App.WriteColorXY("          ╚════╩══════════════════════╩══════════════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // вывод сообщения об отсутствии данных
        static public void ShowEmpty()
        {
            App.WriteColorXY("          ╠════╩══════════════════════╩══════════════════════╩════════════╩════════════╣\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                            ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                            ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                 НЕТ ДАННЫХ                                 ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                            ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                            ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ╚════════════════════════════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Red);

        }

        #endregion

    }
}