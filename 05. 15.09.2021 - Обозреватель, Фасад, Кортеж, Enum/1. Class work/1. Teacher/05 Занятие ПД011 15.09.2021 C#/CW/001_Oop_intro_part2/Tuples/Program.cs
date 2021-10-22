using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tuples
{
    class Program
    {
        // Кортежи предоставляют удобный способ для работы с набором значений,
        // который был добавлен в версии C# 7.0.

        private static Random _random = new Random();

        private static int _ytt;

        static void Main(string[] args) {
            Console.Title = "Занятие 15.09.2021 - кортежи в C#";

            // Кортеж представляет набор значений, заключенных в круглые скобки:
            // var имя = (списокЗначений);
            var tuple = (5, 10);
            // tuple = (15, 20);

            // (списокТипов) имя = (списокЗначений);
            // (int, int) tuple0;
            (int, int) tuple0 = (15, -110);

            // у этого набора доступ к значениям по именам
            // имя.Item1, имя.Item2, ..., имя.ItemN

            Console.WriteLine($"\nКортеж  : {tuple}, по элементам Item1 = {tuple.Item1}, Item2 = {tuple.Item2}");
            Console.WriteLine($"\nКортеж 0: {tuple0}, по элементам Item1 = {tuple0.Item1}, Item2 = {tuple0.Item2}");

      
            // операция с одним из значений
            tuple.Item2 += 32;
            Console.WriteLine($"\nКортеж: Item1 = {tuple.Item1}, Item2 = {tuple.Item2}");
            
            // Объявление с явным указанием типов
            (string, int, double) person = ("Tom", 25, 81.23);
            Console.WriteLine($"\nЗначение кортежа person: {person}, по элементам {person.Item1}, {person.Item2}, {person.Item3}\n");
            
           
            // задание имен значениям кортежа
            var tuple1 = (Count:5, Sum:-10);
            Console.WriteLine($"\nВывод кортежа {tuple1} по именам значений: {tuple1.Count} и {tuple1.Sum}\n");
            Console.WriteLine($"Вывод кортежа {tuple1} через Item-имена  : {tuple1.Item1} и {tuple1.Item2}\n");
            
            // использование переменных в качестве значений кортежа
            // тогда с полями кортежа мы сможем работать как с переменными,
            // которые определены в рамках метода
            var (name, age) = ("Федор Царан", 23);
            Console.WriteLine($"\nИспользование переменных как значений кортежа: {name}, {age} года\n\n");

            Console.WriteLine("\nВозврат кортежа из метода");
            tuple = GetValues();
            Console.WriteLine($"Получено из GetValues(): {tuple}\n\n");

            
            Console.WriteLine($"\nДо вызова метода : {name}, {age} года\n");
            (name, age) = GetTuple((name, age), 10);
            Console.WriteLine($"\nИзменено в методе: {name}, {age} года\n\n");
          
            // еще о применении кортежей
            int x = 5, y = 10;
            Console.WriteLine($"\nДо    обмена: x = {x, 2}, y = {y, 2}");
            (x, y) = (y, x);
            Console.WriteLine($"\nПосле обмена: x = {x, 2}, y = {y, 2}\n\n");

            
            // более хитрый вариант
            int z = 15;
            x = 5;
            y = 10;
            Console.WriteLine($"\nДо    сдвига влево : x = {x, 2}, y = {y, 2}, z = {z, 2}");
            (x, y, z) = (y, z, x);
            Console.WriteLine($"\nПосле сдвига влево : x = {x, 2}, y = {y, 2}, z = {z, 2}\n\n");

            Console.WriteLine($"\nДо    сдвига вправо: x = {x, 2}, y = {y, 2}, z = {z, 2}");
            (x, y, z) = (z, x, y);
            Console.WriteLine($"\nПосле сдвига вправо: x = {x, 2}, y = {y, 2}, z = {z, 2}\n\n");
            
        } // Main

        // возврат набора значений из метода при помощи кортежа
        private static (int, int) GetValues() {
            
            var result = (_random.Next(-10, 11), _random.Next(-10, 11));
            return result;   
        } // GetValues

        // передача кортежа в качестве параметра, возврат кортежа
        // из метода
        // метод увеличивает возраст на x
        private static (string name, int age) GetTuple((string n, int a) tuple, int x) {
            return (name: tuple.n, age: tuple.a + x);
        } // GetTuple
    } // class Program
}
