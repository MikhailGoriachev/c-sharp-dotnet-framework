using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 *  Задача 2. Разработайте класс Самолет со следующими полными свойствами:
 *  	производитель и тип самолета (это одно свойство, например: Ил-76, Boeing 747, …)
 *  	количество пассажирских мест (целое число)
 *  	расход горючего за час полета (вещественное число)
 *  	количество двигателей (целое число)
 *  	название авиакомпании – владельца
 *  	
 *  В массиве самолетов (не менее 10 элементов) определить самолет/самолеты с максимальным 
 *  количеством пассажирских мест, упорядочить массив:
 *  	по свойству производитель и тип (!!! это одно свойство !!!)
 *  	по убыванию количества двигателей
 *  	по возрастанию расхода горючего за час полета
 */

// Класс Самолёт
namespace Home_work.Task_2
{
    internal class Plane
    {
        // производитель и тип самолета         20
        private string _model;

        // количество пассажирских мест         10
        private int _seat;

        // расход горючего за час полета        10 
        private double _consumption;

        // количество двигателей                10
        private int _engine;

        // название авиакомпании                20
        private string _name;

        #region Свойства 

        // свойство поля _model 
        public string Model { get => _model; set => _model = value; }

        // свойство поля _seat
        public int Seat {  get => _seat; set => _seat = value < 0 ? -1 : value; }

        // свойство поля _consumption
        public double Consumption {  get => _consumption; set => _consumption = value < 0d ? -1d : value; }

        // свойство поля _engine
        public int Engine {  get => _engine; set => _engine = value < 0 ? -1 : value; }

        // свойство поля _name
        public string Name { get => _name; set => _name = value; }

        #endregion

        #region Методы 

        // вывод самолётов в виде таблицы 
        public static void ShowTable(Plane[] planes_, string name, string info)
        {
            // вывод шапки таблицы
            ShowHead(name, info, planes_.Length);

            // номер элемента 
            int num = 1;

            // вывод элементов таблицы 
            foreach (var item in planes_)
                item.ShowElem(num++);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public static void ShowHead(string name, string info, int size)
        {
            //                    10                     33                                   33
            App.WriteColor("     ╔════════════╦═══════════════════════════════════╦════════════════════════════════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor("     ║            ║                                   ║                                        ║", ConsoleColor.Cyan);
            App.WriteColorXY("Размер: ",    7,  textColor:ConsoleColor.DarkYellow);
            App.WriteColor($"{size,2}",                 ConsoleColor.Green);
            App.WriteColorXY("Название: ",  20, textColor:ConsoleColor.DarkYellow);
            App.WriteColor($"{name,-23}",                ConsoleColor.Green);
            App.WriteColorXY("Инфо: ",      56, textColor:ConsoleColor.DarkYellow);
            App.WriteColor($"{info,-31}\n",              ConsoleColor.Green);
            App.WriteColor("     ╠════╦═══════╩══════════════╦════════════╦═══════╩════╦════════════╦══════════════════════╣\n", ConsoleColor.Cyan);
            App.WriteColor("     ║    ║                      ║            ║            ║            ║                      ║", ConsoleColor.Cyan);
            App.WriteColorXY("N ",                      7,  textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("       Модель       ",    12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("  Места   ",              35, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("  Расход  ",              48, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("Двигатели ",              61, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Авиакомпания    ",     74, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n     ╠════╬══════════════════════╬════════════╬════════════╬════════════╬══════════════════════╣\n", ConsoleColor.Cyan);

        }

        // вывод элемента таблицы
        public void ShowElem(int num, bool activeColor = false)
        {
            App.WriteColor("     ║    ║                      ║            ║            ║            ║                      ║", ConsoleColor.Cyan);
            App.WriteColorXY($"{num,             2}",    7, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.DarkGray);
            App.WriteColorXY($"{_model,         -20}",   12, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.Green);
            App.WriteColorXY($"{_seat,          10}",   35, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.Green);
            App.WriteColorXY($"{_consumption,10:n2}",   48, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.Green);
            App.WriteColorXY($"{_engine,        10}",   61, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.Green);
            App.WriteColorXY($"{_name,          -20}",   74, textColor: activeColor ? ConsoleColor.Cyan : ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы 
        public static void ShowLine()
        {
            App.WriteColor("     ╚════╩══════════════════════╩════════════╩════════════╩════════════╩══════════════════════╝\n", ConsoleColor.Cyan);
        }

        #endregion
    }
}
