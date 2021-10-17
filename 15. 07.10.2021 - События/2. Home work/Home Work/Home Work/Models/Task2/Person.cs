using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;       // подключение утилит

namespace Home_Work.Models.Task2
{
    // делегат события Childhood
    internal delegate void ChildhoodEvent(object sender, ChildhoodEventArgs s);

    // делегат события Relocate
    internal delegate void RelocateEvent(object sender, RelocateEventArgs s);

    // Класс Персона
    internal class Person
    {
        // фамилия и инициалы
        string _name;

        // возраст в годах
        int _age;

        // название города проживания
        string _city;

        #region События 

        // событие Childhood
        public event ChildhoodEvent Childhood;

        // событие Childhood
        public event RelocateEvent Relocate;

        #endregion

        #region Свойства

        // доступ к полю _name
        public string Name{ get => _name; set => _name = !String.IsNullOrWhiteSpace(value) ? value :
                throw new Exception("Person: поле name не может оставаться пустым!");
        }

        // доступ к полю _age
        public int Age
        {
            get => _age;
            set
            {
                // установка значения
                _age = value >= 0 ? value :
                        throw new Exception("Person: поле age не может быть меньше 0!");

                // зажигание события RelocateEvent
                if (_age < 21)
                    Childhood?.Invoke(this, new ChildhoodEventArgs { Age = _age});
            }
        }


        // доступ к полю _city
        public string City 
        { 
            get => _city;
            set
            {

                // копия текущего значения
                string oldCity = _city;

                // установка значения
                _city = !String.IsNullOrWhiteSpace(value) ? value :
                    throw new Exception("Person: поле city не может оставаться пустым!");

                // зажигание события RelocateEvent
                if (_city != oldCity)
                    Relocate?.Invoke(this, new RelocateEventArgs { OldSity = oldCity, NewSity = _city });
            }
        }

        // идентификатор (не уникальный, требуется для позиционирования в таблице)
        public int Id { get; set; }

        #endregion

        #region Методы 

        // вывод элемента таблицы
        public void ShowElem(int num)
        {
            WriteColorXY(" ║    ║                      ║                                ║                      ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}", 3, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{_name, -20}", 8, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_age, 30}", 31, textColor: ConsoleColor.Green);
            WriteColorXY($"{_city, -20}", 64, textColor: ConsoleColor.Cyan);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬════════════════════════════════╬══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод таблицы
        public static void ShowTable(Person[] persons, string name = "Персоны", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(persons.Length, name, info);

            // вывод элементов 
            ShowElelements(persons);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public static void ShowHead(int size, string name = "Персоны", string info = "Исходные данные")
        {
            //                       10                     30                                  35                         15
            WriteColorXY(" ╔════════════╦════════════════════════════════╦═════════════════════════════════════╦════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║            ║                                ║                                     ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size, 2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 16, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name, -20}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 49, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info, -29}", textColor: ConsoleColor.Green);
            WriteColorXY("Кол-во несовершеннолетних: ", 87, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"———", textColor: ConsoleColor.DarkRed);
            Console.WriteLine();

            //                        2             20                   30                            20
            WriteColorXY(" ╠════╦═══════╩══════════════╦═════════════════╩══════════════╦══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
            WriteColorXY(" ║    ║                      ║                                ║                      ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 3, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Фамилия и инициалы ", 8, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("            Возраст           ", 31, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Город проживания  ", 64, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Смена города проживания    ", 87, textColor: ConsoleColor.Cyan);
            Console.WriteLine();

            WriteColorXY(" ╠════╬══════════════════════╬════════════════════════════════╬══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод элементов таблицы
        public static void ShowElelements(Person[] persons)
        {
            // номер элемента 
            int i = 1;

            // вывод элементов 
            Array.ForEach(persons, item => item.ShowElem(i++));
        }

        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY(" ╚════╩══════════════════════╩════════════════════════════════╩══════════════════════╩════════════════════════════════╝\n", posY: Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        #endregion
    }
}
