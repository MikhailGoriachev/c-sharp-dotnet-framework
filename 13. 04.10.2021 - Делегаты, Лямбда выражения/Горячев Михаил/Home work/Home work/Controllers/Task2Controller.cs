using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_work.Models.Task2;

using static Home_work.Application.App.Utils;       // подключение утилит

/*
    * Задача 2. Разработайте класс, описывающий электроприбор (название,
    * мощность, цена, включен/выключен). 
    * 
    * Сформируйте массив электроприборов (от 10 до 12 элементов), для 
    * массива реализуйте обработки:
    *  •	вывод массива в табличном формате, используйте лямбда-выражение
    *       для Array.Foreach()
    *  •	перемешивание элементов массива
    *  •	сортировка по названию, компаратор реализуйте лямбда-выражением
    *  •	сортировка по мощности прибора, компаратор реализуйте 
    *       лямбда-выражением
    *  •	включение всех приборов, используйте лямбда-выражение для 
    *       Array.ForEach()
    *  •	выключение всех приборов, используйте лямбда-выражение для 
    *       Array.ForEach()
*/

namespace Home_work.Controllers
{
    // Класс Обработка по заданию 2
    internal class Task2Controller
    {
        // коллекция электроприборов
        private ElectricalAppliance[] _appliances;

        #region Свойства 

        // доступ к полю _appliances
        public ElectricalAppliance[] Appliances { get => _appliances; set => _appliances = value; }

        #endregion

        #region Конструкторы 

        // конструктор по умолчанию 
        public Task2Controller()
        {
            // установка значений
            Initialization();
        }

        #endregion

        #region Методы

        #region Инициализация

        // коды электроприборов
        private enum ApplianceCode
        {
            // пылесос
            VacuumCleaner,
            // утюг
            FlatIron,
            // тостер
            Toaster,
            // фен 
            HairDryer,
            // чайник
            ElectricKettle
        }

        // инициализация
        public void Initialization()
        {
            // выделение памяти
            _appliances = new ElectricalAppliance[rand.Next(10, 15)];

            // заполнение массива
            for (int i = 0; i < _appliances.Length; i++) _appliances[i] = FactoryMethod(rand.Next(1, 6));
        }

        // фабричный метод элекстроприборов
        private ElectricalAppliance FactoryMethod(int code)
        {
            switch (code)
            {
                // пылесос
                case (int)ApplianceCode.VacuumCleaner:
                    return new ElectricalAppliance { Name = "Пылесос", Power = 1600, Price = 15_000 };
                // утюг
                case (int)ApplianceCode.FlatIron:
                    return new ElectricalAppliance { Name = "Утюг", Power = 1200, Price = 5_000 };
                // тостер
                case (int)ApplianceCode.Toaster:
                    return new ElectricalAppliance { Name = "Тостер", Power = 700, Price = 2_500 };
                // фен 
                case (int)ApplianceCode.HairDryer:
                    return new ElectricalAppliance { Name = "Фен", Power = 1400, Price = 3_000 };
                // чайник
                case (int)ApplianceCode.ElectricKettle:
                    return new ElectricalAppliance { Name = "Чайник", Power = 800, Price = 1_500 };
                default:
                    goto case (int)ApplianceCode.VacuumCleaner;
            }
        }

        #endregion

        #region Вывод в таблицу

        // вывод в таблицу
        public void ShowTable(string name = "Электроприборы", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(_appliances.Length, name, info);

            // вывод элементов 
            ShowElem(_appliances);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public static void ShowHead(int size , string name = "Электроприборы", string info = "Исходные данные")
        {
            WriteColorXY("     ╔════════════╦══════════════════════════════════╦════════════════════════════╗\n", 
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                  ║                            ║", 
                textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-20}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 55, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-19}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            //                    2                 30                    10            10          10
            WriteColorXY("     ╠════╦═══════╩════════════════════════╦═════════╩══╦════════════╦════════════╣\n", 
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                                ║            ║            ║            ║", 
                textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Название электроприбора    ", 12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Мощность ", 45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Цена   ", 58, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Питание  ", 71, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬════════════╬════════════╬════════════╣\n", 
                textColor: ConsoleColor.Magenta);
        }

        // вывод элементов 
        public static void ShowElem(ElectricalAppliance[] appliances)
        {
            // номер элемента
            int i = 1;

            // вывод элементов массива
            Array.ForEach(appliances, item => item.ShowElem(i++));
        }

        // вывод подвала таблицы
        public static void ShowLine() =>
            WriteColorXY("     ╚════╩════════════════════════════════╩════════════╩════════════╩════════════╝\n", 
                posY:Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        #endregion

        #region Перемешивание

        // перемешивание 
        public void Shuffle()
        {
            // размер массива 
            int size = _appliances.Length;

            // перемешивание
            for (int i = 0, k = rand.Next(0, size); i < size; i++, k = rand.Next(0, size))
                (_appliances[i], _appliances[k]) = (_appliances[k], _appliances[i]);
        }

        #endregion

        #region Сортировка по названию

        // сортировка по названию
        public void SortByName() => Array.Sort(_appliances, (item1, item2) => item1.Name.CompareTo(item2.Name));

        #endregion

        #region Сортировка по мощности

        // сортировка по мощности 
        public void SortByPower() => Array.Sort(_appliances, (item1, item2) => item1.Power.CompareTo(item2.Power));

        #endregion

        #region Включение всех приборов

        // включение всех приборов
        public void AllPowerON() => Array.ForEach(_appliances, item => item.TurnPower(true));

        #endregion

        #region Выключение всех приборов

        // выключение всех приборов
        public void AllPowerOFF() => Array.ForEach(_appliances, item => item.TurnPower(false));

        #endregion

        #endregion
    }
}