using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work.Controllers
{
    // Класс Обработка по заданию 1
    internal class Task1Controller
    {
        // коллекция электроприборов
        private ElectricalAppliance[] _appliances;

        // наблюдатель 1
        Observer1 observer1 = new Observer1();

        // наблюдатель 2
        Observer2 observer2 = new Observer2();

        #region Свойства 

        // доступ к полю _appliances
        public ElectricalAppliance[] Appliances { get => _appliances; set => _appliances = value; }

        #endregion

        #region Конструкторы 

        // конструктор по умолчанию 
        public Task1Controller()
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
            for (int i = 0; i < _appliances.Length; i++)
            {
                _appliances[i] = FactoryMethod(rand.Next(1, 6));
                _appliances[i].Id = i + 1;
            }
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

        #region Изменение электроприборов

        // изменение электроприборов
        public void Change()
        {
            // выключение курсора 
            Console.CursorVisible = false;

            // подписка на события
            Subscribe();

            // вывод клавиш для управления
            ShowKey();

            // вывод таблицы с электроприборами
            ShowTable(info: "Данные для изменения");

            // считанная клавиша
            ConsoleKey key;

            // считывание клавиши
            while (true)
            {
                // клавиша 
                key = Console.ReadKey(true).Key;

                // проверка клавиши
                switch (key)
                {
                    // выход
                    case ConsoleKey.Escape:
                        // включение курсора 
                        Console.CursorVisible = true;
                        return;

                    // изменение возраста
                    case ConsoleKey.Q:
                        PowerChangeRandomElectrical();
                        break;

                    // изменение города проживания
                    case ConsoleKey.W:
                        StateChangeRandomElectrical();
                        break;

                    default:
                        continue;
                }
            }
        }

        // вывод клавиш для управления
        private void ShowKey()
        {
            WriteColorXY("     ╔════════════════════════════════╦════════════════════════════════╦════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║                                ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Изменение мощности: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Q", textColor: ConsoleColor.Cyan);
            WriteColorXY($"Изменение состояния: ", 40, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("W", textColor: ConsoleColor.Cyan);
            WriteColorXY("Выход: ", 73, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Esc", textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╚════════════════════════════════╩════════════════════════════════╩════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // подписка на события
        private void Subscribe()
        {
            Array.ForEach(_appliances, item =>
            {
                // подписка на события Наблюдатель 1
                item.PowerChange += observer1.PowerChangeEventHandle;

                // подписка на события Наблюдатель 2
                item.StateChangee += observer2.StateChangeEventHandle;
            });
        }

        // изменение мощности случайного электроприбора
        private void PowerChangeRandomElectrical()
        {
            // индекс персоны
            int index = rand.Next(0, _appliances.Length);

            // новые данные возраста 
            int power = rand.Next(1000, 2500);

            // текущая позиция курсора по x и y
            (int x, int y) cur = (Console.CursorTop, Console.WindowTop);

            // вывод новых данных
            WriteColorXY($"{power,20}", 45, (_appliances[index].Id * 2) + 9, textColor: ConsoleColor.Cyan);

            _appliances[index].Power = power;

            // установка курсора на исходную позицию
            PosXY(cur.x, cur.y);
        }

        // изменение состояния питания случайного электроприбора 
        private void StateChangeRandomElectrical() => _appliances[rand.Next(0, _appliances.Length)].TurnPower(rand.Next(0, 2) == 1);

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
        public static void ShowHead(int size, string name = "Электроприборы", string info = "Исходные данные")
        {
            WriteColorXY("     ╔════════════╦══════════════════════════════════╦══════════════════════════════════════╗\n",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                  ║                                      ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-20}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 55, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-29}", textColor: ConsoleColor.Green);
            Console.WriteLine();
            //                    2                 30                    10            10          10
            WriteColorXY("     ╠════╦═══════╩════════════════════════╦═════════╩════════════╦════════════╦════════════╣\n",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║    ║                                ║                      ║            ║            ║",
                textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Название электроприбора    ", 12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("      Мощность      ", 45, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Цена   ", 68, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Питание  ", 81, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            WriteColorXY("     ╠════╬════════════════════════════════╬══════════════════════╬════════════╬════════════╣\n",
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
            WriteColorXY("     ╚════╩════════════════════════════════╩══════════════════════╩════════════╩════════════╝\n",
                posY: Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        #endregion

        #endregion
    }
}