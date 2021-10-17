using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит

// Класс Рабочий
namespace Home_Work.Task_1._Worker
{
    internal class Worker
    {
        // фаимлия и инициалы
        private string _name;

        // должность
        private string _post;

        // год поступления на работу
        private int _year;

        // оклад
        private int _salary;

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = String.IsNullOrEmpty(value) ? "Worker: Поле не может быть пустым!" : value; }

        // доступ к полю _post
        public string Post { get => _post; set => _post = String.IsNullOrEmpty(value) ? "Worker: Поле не может быть пустым!" : value; }

        // доступ к полю _year
        public int Year { get => _year; set => _year = value >= 1950 && value <= DateTime.Now.Year ? value : throw new Exception($"Worker: Некорректное значение поля Year {value}!"); }

        // доступ к полю _salary
        public int Salary { get => _salary; set => _salary = value >= 0 ? value : throw new Exception($"Worker: Некорректное значение поля Salary {value}!"); }

        // стаж
        public int Experience { get => DateTime.Now.Year - _year; }

        #endregion

        #region Методы

        // вывод работника в таблицу
        public void ShowElem(int num)
        {
            App.WriteColorXY("          ║    ║                      ║                      ║            ║            ║            ║", textColor: ConsoleColor.Magenta);
            App.WriteColorXY($"{num,2}",                                12, textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_name??"Нет данных",-20}",              17, textColor: ConsoleColor.Green);
            App.WriteColorXY($"{_post??"Нет данных",-20}",              40, textColor: ConsoleColor.Green);
            App.WriteColorXY($"{_year,10}",                             63, textColor: ConsoleColor.Cyan);
            App.WriteColorXY($"{_salary,10:n0}",                        76, textColor: ConsoleColor.Cyan);
            App.WriteColorXY($"{Experience,10}",                        89, textColor: ConsoleColor.Cyan);
            Console.WriteLine();
        }

        #endregion
    }
}
