using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BinaryStream
{
    static class Utils
    {
        // объект для получения случайных чисел
        public static readonly Random Random = new Random(Environment.TickCount);

        // вывести строку в заданную позицию
        public static void WritePos(int left, int top, string str) {
            Console.SetCursorPosition(left, top);
            Console.Write(str);
        } // WritePos

        // пример краткой формы записи метода
        public static void SetPos(int left, int top) =>
            Console.SetCursorPosition(left, top);
        
        // Вычисление наибольшего общего делителя
        public static int Gcd(int a, int b) {
            return b == 0 ? a : Gcd(b, a % b);
        } // Gcd

        // Получение случайного числа
        // краткая форма записи метода - это не лямбда выражение
        public static int GetRand(int lo, int hi) => Random.Next(lo, hi + 1);
        public static double GetRand(double lo, double hi) => lo + (hi - lo)*Random.NextDouble();

        // вывод сообщения о разработке метода
        public static void UnderConstruction() {
            SetColor(ConsoleColor.Yellow, ConsoleColor.DarkYellow);

            WritePos(8, 3, "┌──────────────────────────────────┐");
            WritePos(8, 4, "│    [К сведению]                  │");
            WritePos(8, 5, "│                                  │");
            WritePos(8, 6, "│    Метод в разработке            │");
            WritePos(8, 7, "│                                  │");
            WritePos(8, 8, "└──────────────────────────────────┘");

            RestoreColor();
            Console.Write("\n\n\n\n\n");
        } // UnderConstruction

        // Установить текущий цвет символов и фона с сохранением
        // текущего цвета символов и фона
        private static (ConsoleColor Fore, ConsoleColor Back) _storeColor;
        public static void SetColor(ConsoleColor fore, ConsoleColor back) {
            _storeColor = (Console.ForegroundColor, Console.BackgroundColor);
            Console.ForegroundColor = fore;
            Console.BackgroundColor = back;
        } // SetColor

        // Сохранить цвет
        public static void SaveColor() =>
            _storeColor = (Console.ForegroundColor, Console.BackgroundColor);

        // Восстановить сохраненный цвет
        public static void RestoreColor() =>
            (Console.ForegroundColor, Console.BackgroundColor) = _storeColor;

        // вернуть имя из массива имен - первая, упрощенная версия
        public static string GetName() {
            string[] names = {
                "Марфа", "Ерофей", "Агафон", "Спиридон", "Оксана", "Анна", "Лидия",
                "Тимофей", "Сергей", "Евлампия", "Наталья", "Павел", "Федор",
                "Тамара"
            };
            return names[GetRand(0, names.Length - 1)];
        } // GetName

        // вернуть имя из массива имен - вторая, улучшенная версия, работает с учетом пола
        public static string GetName(bool gender) {
            string[] maleNames = {
                "Ерофей", "Агафон", "Спиридон", "Тимофей", "Сергей", 
                "Павел", "Федор", "Тарас", "Николай", "Валерий",
                "Юрий", "Алексей"
            };

            string[] femaleNames = {
                "Марфа", "Оксана", "Анна", "Лидия", "Евлампия", "Наталья", "Полина", 
                "Фекла", "Тамара", "Яся", "Татьяна"
            };

            return gender?maleNames[GetRand(0, maleNames.Length - 1)]
                         :femaleNames[GetRand(0, femaleNames.Length - 1)];
        } // GetName

        // вернуть фамилию из массива имен - очень примитивный 
        // алгоритм формирования женских фамилий
        public static string GetSurname(bool gender) {
            string[] surnames = {
                "Огородников", "Иванов", "Семенов", "Охрименков", "Васильев", "Ларин", 
                "Тяглов", "Тимофеев", "Сергеев", "Елизаветин", "Шматков", "Луков", "Федоров",
                "Туркин"
            };

            string surname = surnames[GetRand(0, surnames.Length - 1)]; 
            return gender?surname:surname + "а";
        } // GetSurname

        // вернуть оклад из массива окладов
        private static double[] _salaries = {8100, 12600, 23000, 36000, 42000};
        public static double GetSalary() => _salaries[GetRand(0, _salaries.Length - 1)];

        // формирование знака зодиака по дате - очень примитивно, 
        // только по методу
        public static string GetZodiac(DateTime date) {
            string[] zodiac = {
                "Козерог", "Водолей", "Рыбы", "Овен", "Телец",
                "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион",
                "Стрелец"
            };

            return zodiac[date.Month - 1];
        } // GetZodiac

        // Просмотр файла - вывод файла, заданного именем в консоль
        // private static void ViewFile(string fileName) =>
        //     Console.WriteLine($"\n{fileName}{File.ReadAllText(fileName)}");

        // выводим файл в консоль, при выводе в консоль в каждую строку
        // вставляем символ табуляции - для улучшения читаемости вывода
        public static void ViewFile(string title, string fileName, Encoding encoding = null)
        {
            // заголовок выводим текущим цветом, а текст файла - заданным
            Console.WriteLine($"{title} {fileName}");
            SetColor(ConsoleColor.Yellow, Console.BackgroundColor);

            if (encoding == null) encoding = Encoding.Default;

            using (var sr = new StreamReader(fileName, encoding))
                while (!sr.EndOfStream)
                    Console.WriteLine($"\t{sr.ReadLine()}");

            RestoreColor();
        } // ViewFile
    } // class Utils

}
