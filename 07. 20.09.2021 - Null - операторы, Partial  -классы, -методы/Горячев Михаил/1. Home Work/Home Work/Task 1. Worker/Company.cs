using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Класс Компания
namespace Home_Work.Task_1._Worker
{
    internal class Company
    {
        // название компании
        private string _name;

        // коллекция рабочих
        private Worker[] _workers;

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = value; }

        // доступ к полю _workers
        public Worker[] Workers { get => _workers; set => _workers = value; }

        #endregion

        #region Методы 

        // сортировка по имени 
        public void SortByName()
        {
            // компаратор 
            int CompareToName(Worker w1, Worker w2) => w1.Name.CompareTo(w2.Name);
                
            // сортировка 
            Array.Sort(_workers ?? new Worker[0], CompareToName);
        }

        // сортировка по должности
        public void SortByPost()
        {
            // компаратор 
            int CompareToPost(Worker w1, Worker w2) => w1.Post.CompareTo(w2.Post);

            // сортировка 
            Array.Sort(_workers ?? new Worker[0], CompareToPost);
        }

        // сортировка по стажу
        public void SortByExp()
        {
            // компаратор 
            int CompareToPost(Worker w1, Worker w2) => w1.Year.CompareTo(w2.Year);

            // сортировка 
            Array.Sort(_workers ?? new Worker[0], CompareToPost);
        }

        // выбор по диапазону зарплат
        public Worker[] SelectBySalary(int min, int max)
        {
            // предикатор 
            bool PredicateToSalary(Worker w) => w.Salary >= min && w.Salary <= max;

            // выборка 
            return Array.FindAll(_workers ?? new Worker[0], PredicateToSalary);
        }

        // выбор по должности
        public Worker[] SelectByPost(string post)
        {
            // предикатор 
            bool PredicateToSalary(Worker w) => w.Post.Equals(post);

            // выборка 
            return Array.FindAll(_workers ?? new Worker[0], PredicateToSalary);
        }

        // вывод данных в таблицу
        public void ShowTable(string info = "Рабочие")
        {
            // вывод шапки таблицы
            ShowHead(_workers?.Length??0, Name, info);

            // вывод элементов 
            ShowElem(_workers);
        }

        // вывод шапки таблицы
        static public void ShowHead(int size, string name, string info = "Рабочие")
        {
            //          10                                          30                                      42               
            App.WriteColorXY("          ╔════════════╦════════════════════════════════╦═══════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("          ║            ║                                ║                                           ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("Размер: ",        12,     textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{size,2}",               textColor: ConsoleColor.Green);
            App.WriteColorXY("Компания: ",      25,     textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{name,-20}",             textColor: ConsoleColor.Green);
            App.WriteColorXY("Инфо: ",          58,     textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{info,-36}",             textColor: ConsoleColor.Green);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╦═══════╩══════════════╦═════════════════╩════╦════════════╦════════════╦════════════╣\n", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("          ║    ║                      ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY("N ",                      12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Фамилия и инициалы ",    17, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("     Должность      ",    40, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("Год устр. ",              63, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("  Оклад   ",              76, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("  Стаж    ",              89, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            App.WriteColorXY("          ╠════╬══════════════════════╬══════════════════════╬════════════╬════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод элементов в таблицу
        static public void ShowElem(Worker[] workers)
        {
            // если массив пуст 
            if ((workers?.Length ?? 0) == 0) 
                ShowEmpty();

            else
            {
                // порядковый номер 
                int num = 1;

                // вывод элементов 
                foreach (var w in workers)
                {
                    w.ShowElem(num++);
                }

                // вывод подвала таблицы
                ShowLine();
            }
        }

        // вывод подвала таблицы
        static public void ShowLine()
        {
            App.WriteColorXY("          ╚════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // вывод сообщения об отсутствии данных
        static public void ShowEmpty()
        {
            App.WriteColorXY("          ╠════╩══════════════════════╩══════════════════════╩════════════╩════════════╩════════════╣\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                                         ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                                         ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                        НЕТ ДАННЫХ                                       ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                                         ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ║                                                                                         ║\n", textColor: ConsoleColor.Red);
            App.WriteColorXY("          ╚═════════════════════════════════════════════════════════════════════════════════════════╝\n", textColor: ConsoleColor.Red);
        }

        #endregion
    }
}