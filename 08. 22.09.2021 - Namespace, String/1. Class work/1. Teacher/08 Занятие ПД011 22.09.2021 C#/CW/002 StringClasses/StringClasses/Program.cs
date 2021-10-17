using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringClasses
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 22.09.2021 - строки в C#, классы string, StringBuilder";

            // одна из форм конструктора строки - создание строки
            // из заданного количества заданных символов
            string s = new string('~', 80);
            // Console.WriteLine(new string('~', 80));
            Console.WriteLine(s);

            // класс string - неизменные строки, immutable object
            DemoString();

        } // Main

        // Демо для класса string
        private static void DemoString() {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Класс string\n\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            // строки для обработки
            string s1 = "   кот    ломом    колол    слона  ", s2 = "ло";
            string zxz = string.Empty;
            
            // есть ли подстрока s2 в строке s1 
            if (s1.Contains(s2)) Console.WriteLine(
                string.Concat(@"Да, в строке """, s1, "\" есть вхождение \"", s2 + @""""));

            // строка начинается с ...
            string start = " ";
            if (s1.StartsWith(start)) Console.WriteLine(
                string.Concat(@"Да, строка """, s1, "\" начинается  с \"", start + @""""));

            // строка заканичвается на ...
            string end = " ";
            if (s1.EndsWith(end)) Console.WriteLine(
                string.Concat(@"Да, строка """, s1, "\" заканчивается на \"", start + @""""));

            // первое вхождение s2 в s1
            int n = s1.IndexOf(s2);
            Console.WriteLine($"В строке \"{s1}\" первое вхождение \"{s2}\" с позиции {n}");

            // последнее вхождение s2 в s1
            n = s1.LastIndexOf(s2);
            Console.WriteLine($"В строке \"{s1}\" последнее вхождение \"{s2}\" с позиции {n}");

           
            // первое вхождение символа из массива символов
            n = s1.IndexOfAny(new []{ 'а', 'е', 'ё', 'и', 'о', 'у', 'ы', 'э', 'ю', 'я' });
            Console.WriteLine($"В строке \"{s1}\" первая гласная буква нижнего регистра в позиции {n}");

            // последнее вхождение символа из массива символов
            n = s1.LastIndexOfAny("аеёиоуыэюя".ToCharArray());
            Console.WriteLine($"В строке \"{s1}\" последняя гласная буква нижнего регистра в позиции {n}");

            // ----------------------------------------------------------------------
            
            Console.WriteLine("\nМетод Split - строка преобразуется в массив слов:");
            char[] sep = " ,.:".ToCharArray();                                   // массив разделителей
            string[] sw = s1.Split(sep, StringSplitOptions.RemoveEmptyEntries);  // массив слов
            foreach (var item in sw)
                Console.WriteLine($@"""{item}""");   // непосредственные строки - для иллюстрации возможности
            
            Console.WriteLine("\nJoin - склеивание слов из массива в строку, с использованием разделителя:");
            s2 = string.Join(" ", sw);
            Console.WriteLine(@"""" + s2 + @"""");   // демонстрация операции конкатенации строк
            
            // Порядок слов в строке - менять на обратный
            Console.WriteLine("\nArray.Reverse и Join - слова в строке в обратном порядке:");
            Array.Reverse(sw);
            s2 = string.Join(" ", sw);
            Console.WriteLine(@"""" + s2 + @"""");
            
            Console.WriteLine("\nМетод Trim() - убрать ведущие и хвостовые пробелы:");
            Console.WriteLine(@"""" + s1 + @"""");
            s1 = s1.Trim();   // !!! строка s1 не меняется, в Trim() создается новая строка !!!
            Console.WriteLine(@"""" + s1 + @"""");

            // Добавление 10 пробелов слева
            int pad = 10;
            Console.WriteLine($"\nДобавление {pad} пробелов слева от строки:");
            s1 = s1.PadLeft(pad + s1.Length);
            Console.WriteLine(@"""" + s1 + @"""");

            s1 = "кот ломом колол слона";
            s2 = "ло";

            // Удвоение первого вхождения подстроки s2
            s1 = s1.Insert(s1.IndexOf(s2), s2);
            Console.WriteLine(s1);

            // Удаление первого вхождения s2 в s1
            
            // аномалия неизменности строки     
            // Console.WriteLine($"{s1.Remove(s1.IndexOf(s2), s2.Length)}");
            // Console.WriteLine($"{s1}");
            s1 = s1.Remove(s1.IndexOf(s2), s2.Length);
            Console.WriteLine(s1);

            s1 = s1.Replace(s2, "+++++");
            // s1 = s1.Replace("л", "лллллл");
            // Console.WriteLine($"String30. {s1}");
            Console.WriteLine(s1);

            // удаление всех вхождений s2 из s1  
            // s1 = s1.Replace(s2, "");
            s1 = s1.Replace("+++++", "");
            Console.WriteLine(s1);

            // Получение подстроки из строки
            // Подстрока от последнего вхождения s2 до конца строки
            s1 = "кот ломом колол слона";
            Console.WriteLine("\n" + s1);
            s1 = s1.Substring(s1.LastIndexOf(s2));
            Console.WriteLine(s1);

            s1 = "праСтИти зА нИрОвНыЙ пОчИрК".ToLower();
            s1 = s1.Substring(0, 1).ToUpper() + s1.Substring(1);
            Console.WriteLine(s1);
        } // DemoString

    } // class Program
}
