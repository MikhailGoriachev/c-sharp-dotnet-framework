using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
        /*
         *      •	фамилия и инициалы имени и отчества (например, Семенов Р.О.) 
         *      •	возраст в полных годах (целое число)
         *      •	рост в сантиметрах (целое число)
         *      •	вес в кг (вещественное число)
         *      •	название города проживания (строка)
         */
namespace Home_Work
{
    class Person
    {

        // фамилия и инициалы 
        private string _name; // 20

        // возраст 
        private int _age;    // 10

        // рост 
        private int _height; // 10

        // вес 
        private double _weight; // 10

        // город проживания
        private string _city;  // 20

        #region Свойства 

        // свойство для поля _name
        public string Name { get => _name; set => _name = value;  }

        // свойство для поля _age
        public int Age {  get => _age; set => _age = value < 0 ? -1 : value; }

        // свойство для поля _height
        public int Height { get => _height; set => _height = value < 1 ? -1 : value; }

        // свойство для поля _weight
        public double Weight {  get => _weight; set => _weight = value < 0d ? -1d : value; }

        // свойство для поля _city
        public string City {  get => _city; set => _city = value; }

        #endregion

        #region Методы

        // вывод таблицы 
        static public void ShowTable(Person[] persons, string name = "Персоны", string info = "Исходные данные")
        {
            // вывод шапки таблицы 
            ShowHead(name, info, persons.Length);

            // номер в списке 
            int num = 1;

            // вывод элемента в таблицу
            foreach (var item in persons)
                item.ShowElem(num++);

            // вывод подвала таблицы 
            ShowLine();
        }

        // вывод шапки таблицы 
        static public void ShowHead(string name, string info, int size)
        {
            // вывод заголовка          10                          36                                     35
            App.WriteColor("      ╔════════════╦══════════════════════════════════════╦═════════════════════════════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor("      ║            ║                                      ║                                     ║", ConsoleColor.Cyan);
            App.WriteColorXY("Размер: ", 8, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{size,2}", ConsoleColor.Green);
            App.WriteColorXY("Название: ", 21, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{name,-16}", ConsoleColor.Green);
            App.WriteColorXY("Информация: ", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{info,-23}", ConsoleColor.Green);
            App.WriteColor("\n      ╠════╦═══════╩════════════╦════════════╦════════════╬════════════╦════════════════════════╣\n", ConsoleColor.Cyan);
            App.WriteColor("      ║    ║                    ║            ║            ║            ║                        ║", ConsoleColor.Cyan);
            App.WriteColorXY("N ", 8, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("Фамилия и инициалы",      13, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY(" Возраст  ",              35, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Рост   ",              48, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Вес    ",              61, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("       Город        ",    74, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n      ╠════╬════════════════════╬════════════╬════════════╬════════════╬════════════════════════╣\n", ConsoleColor.Cyan);

        }

        // вывод элемента в таблицу 
        public void ShowElem(int num, bool colorActive = false)
        {
            App.WriteColor("      ║    ║                    ║            ║            ║            ║                        ║", ConsoleColor.Cyan);
            App.WriteColorXY($"{num,      2}",  8,  textColor: ConsoleColor.DarkGray);
            App.WriteColorXY($"{_name,  -18}",  13, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_age,   9}",   35, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_height,9}",   48, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_weight,9:n1}",61, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            App.WriteColorXY($"{_city,  -21}",   73, textColor: colorActive ? ConsoleColor.Magenta : ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы
        static public void ShowLine()
        {
            App.WriteColor("      ╚════╩════════════════════╩════════════╩════════════╩════════════╩════════════════════════╝\n", ConsoleColor.Cyan);
        }

        #endregion
    }
}
