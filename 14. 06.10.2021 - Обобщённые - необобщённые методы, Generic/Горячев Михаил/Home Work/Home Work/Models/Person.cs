using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_work.Application.App.Utils;               // для использования утилит

namespace Home_Work.Models
{
    // Класс Персона
    internal class Person : IComparable, IComparer
    {
        // фамилия и инициалы
        private string _name;

        // возраст 
        private int _age;

        // зарплата
        private double _salary;

        #region Свойства 

        // доступ к полю _name
        public string Name { get => _name; set => _name = !String.IsNullOrWhiteSpace(value) ? value : 
                throw new Exception("Person: Поле Name нельзя оставлять пустым!"); }

        // доступ к полю _age
        public int Age { get => _age; set => _age = value >= 0 ? value :
                throw new Exception($"Person: Значение поля Age должно быть больше 0! Значение: {value}"); }

        // доступ к полю _salary
        public double Salary { get => _salary; set=>_salary = value >= 0 ? value : 
                throw new Exception($"Person: Значение поля Salary должно быть больше 0! Значение: {value}"); }

        #endregion

        #region Методы

        // вывод шапки таблицы
        public static void ShowHead(int size, string name, string info)
        {
            WriteColorXY("     ╔════════════╦════════════════════════╦═════════════════════════╗\n",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                        ║                         ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-12}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-17}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            //                    2                 30                    10            10          10
            WriteColorXY("     ╠════╦═══════╩════════════════════════╬════════════╦════════════╣\n",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                                ║            ║            ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("      Фамилия и инициалы      ", 12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Возраст  ", 45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Зарплата ", 58, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.Magenta);

        }

        // вывод элементов в таблицу
        public static void ShowColorElements(Person[] persons, Predicate<Person> predicate)
        {
            // порядковый номер
            int i = 1;

            // вывод элементов 
            Array.ForEach(persons, item => item.ShowElem(i++, predicate(item)));

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод элементов в таблицу
        public static void ShowElements(Person[] persons)
        {
            // порядковый номер
            int i = 1;

            // вывод элементов 
            Array.ForEach(persons, item => item.ShowElem(i++));

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод элемента в таблицу
        public void ShowElem(int num, bool activeColor = false)
        {
            WriteColorXY("     ║    ║                                ║            ║            ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num,2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name,-30}", 12, textColor: activeColor ? ConsoleColor.Blue : ConsoleColor.Green);
            WriteColorXY($"{_age,10}", 45, textColor: activeColor ? ConsoleColor.Blue : ConsoleColor.Cyan);
            WriteColorXY($"{_salary,10}", 58, textColor: activeColor ? ConsoleColor.Blue : ConsoleColor.Cyan);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬════════════╬════════════╣\n",
                textColor: ConsoleColor.Magenta);
        }

        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY("     ╚════╩════════════════════════════════╩════════════╩════════════╝\n",
        posY: Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        // сравнение текущего объекта с объектом 
        public int CompareTo(object obj)
        {
            // преобразование типа Person из Object
            Person p = obj as Person;

            // сравнение 
            return _salary.CompareTo(p._salary);
        }

        // сравнение двух объектов
        public int Compare(object x, object y)
        {
            // преобразование типа Person из Object
            Person p1 = x as Person;
            Person p2 = y as Person;

            return p2.Age.CompareTo(p1.Age);
        }

        // перегрузка проверки на равность
        public override bool Equals(object obj)
        {
            // преобразование типа Person из Object
            Person p1 = obj as Person;

            return _salary.Equals(p1._salary);
        }

        #endregion 
    }
}
