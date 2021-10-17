using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work
{
    // Класс Массив конусов
    class ArrayConoid
    {
        // название коллекции
        private string _name;

        // массив конусов 
        private Conoid[] _data;

        #region Свойства 

        // свойство для поля _name
        public string Name { get => _name; set { _name = value; } }

        // свойство для поля _data
        public Conoid[] Data {  get => _data; set { _data = value; } }

        #endregion

        #region Методы 

        // заполнение массива 
        public void SetData(Conoid[] value) => _data = value;

        // суммарный объем конусов 
        public double SumVolume()
        {
            // сумма 
            double sum = 0;

            // callBack функция для суммирования
            void Func(Conoid c) { sum += c.Volume; }

            // суммирование 
            Array.ForEach(_data, Func);

            return sum;
        }

        // суммарная площадь поверхности 
        public double SumArea()
        {
            // сумма 
            double sum = 0;

            // callBack функция для суммирования
            void Func(Conoid c) { sum += c.Area; }

            // суммирование 
            Array.ForEach(_data, Func);

            return sum;
        }

        // сортировка по возрастанию объемов
        public void SortByVolume() => Array.Sort(_data, Conoid.CompareToVolume);

        // сортировка по убыванию высот
        public void SortByHeight() => Array.Sort(_data, Conoid.CompareToHeight);

        // максимальная площадь
        double MaxArea()
        {
            // максимальная плозадь
            double max = 0d;

            // поиск максимальной площади
            foreach (var item in _data)
            {
                // текущая площадь
                double area = item.Area;

                // если максиамальная площадь меньше текущей
                if (max < area) max = area;
            }

            return max;
        }

        // вывод таблицы 
        public void ShowTable(string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(info);

            // вывод элементов
            ShowElem();
        }

        // вывод таблицы со всеми данными и подсветкой элементов с максимальной площадью
        public void ShowTableAllMaxArea(string info = "Максимальная площадь")
        {
            // вывод шапки таблицы
            ShowHead(info);

            // вывод элементов
            ShowElemMaxArea();

            // вывод суммарного объема и площади
            ShowSumVolumeAndArea();
        }

        // вывод шапки
        public void ShowHead(string info)
        {
            // вывод заголовка          10                          36                                     35
            App.WriteColor  ("      ╔════════════╦══════════════════════════════════════╦═════════════════════════════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor  ("      ║            ║                                      ║                                     ║", ConsoleColor.Cyan);
            App.WriteColorXY("Размер: ", 8, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{_data.Length,2}", ConsoleColor.Green);
            App.WriteColorXY("Название: ", 21, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{_name,-16}", ConsoleColor.Green);
            App.WriteColorXY("Информация: ", 60, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{info,-23}", ConsoleColor.Green);
            App.WriteColor("\n      ╠════╦═══════╩════════╦════════════════╦════════════╩═══╦════════════════╦════════════════╣\n", ConsoleColor.Cyan);
            App.WriteColor  ("      ║    ║                ║                ║                ║                ║                ║", ConsoleColor.Cyan);
            App.WriteColorXY("N ",              8, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Радиус 1   ", 13, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Радиус 2   ", 30, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("    Высота    ", 47, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("   Площадь    ", 64, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY("    Объём     ", 81, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n      ╠════╬════════════════╬════════════════╬════════════════╬════════════════╬════════════════╣\n", ConsoleColor.Cyan);
        }

        // вывод элементов 
        public void ShowElem()
        {
            // номер элемента 
            int num = 1;

            // вывод элементов 
            foreach (var c in _data)
                c.ShowElem(num++);

            // вывод подвала таблицы 
            App.WriteColor($"      ╚════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝\n", ConsoleColor.Cyan);
        }

        // вывод элементов с подсветкой максимальной площади
        public void ShowElemMaxArea()
        {
            // номер элемента 
            int num = 1;

            // максимальная площадь
            double max = MaxArea();

            // вывод элементов 
            foreach (var c in _data)
                c.ShowElem(num++, Math.Abs(c.Area - max) < 0.1e-10);

            // вывод подвала таблицы 
            App.WriteColor($"      ╚════╩════════════════╩════════════════╩════════════════╩════════════════╩════════════════╝\n", ConsoleColor.Cyan);
        }

        // вывод суммарного объема и площади
        public void ShowSumVolumeAndArea()
        {                                       //      42                                          40
            App.WriteColor("      ╔═════════════════════════════════════════════╦═══════════════════════════════════════════╗\n", ConsoleColor.Cyan);
            App.WriteColor("      ║                                             ║                                           ║", ConsoleColor.Cyan);
            App.WriteColorXY("Суммарный объем: ", 8, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{SumVolume(),25:n4}", ConsoleColor.Green);
            App.WriteColorXY("Суммарная площадь: ", 54, textColor: ConsoleColor.DarkYellow);
            App.WriteColor($"{SumArea(),21:n4}", ConsoleColor.Green);
            App.WriteColor("\n      ╚═════════════════════════════════════════════╩═══════════════════════════════════════════╝\n", ConsoleColor.Cyan);
        }

        #endregion
    }
}