using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Теперь можно писать Write() или WriteLine() вместо   
// Console.Write() или Consrol.WriteLine()
using static System.Console;

namespace InputOutputDemo
{
    /// <summary>
    /// Это комментарий для документирования в формате XML 
    /// Создается после ввода трех /
    /// Главный класс программы
    /// </summary>
    class Program
    {

        /// <summary>
        /// Это комментарий для документирования в формате XML 
        /// Создается после ввода трех /
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            Console.Title = "Примеры на операции ввода/вывода";

            // тип имя;      // переменная инициируется 0, никаких мусорных значений
            double d;

            // ввести целое число с клавиатуры
            Write("\nЦелое число: ");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("\n\nВы ввели целое число {0}", a);  // C# 1.0 ... 

            // форматная строка
            // WriteXY(41, 4, string.Format("Вы ввели целое число {0}", a));           

            // интерполяционная строка
            WriteXY(41, 4, $"Вы ввели целое число {a}");           // C# 6.0 ...

            // тип переменной может выводиться компилятором
            var c = a + 1;
            ConsoleColor oldColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            WriteXY(0, 7, $"Мы рассчитали, что {a} + 1 будет равно {c}");
            Console.ForegroundColor = oldColor;

            Console.Write("\n\nВещественное число (целая часть от дробной отделяется запятой): ");
            d = double.MaxValue;  // максимальное значение типа

            // out d - выходной параметр процедуры
            string res = double.TryParse(Console.ReadLine(), out d) 
                ?$"\nВы ввели вещественное число {d}"
                :"\nОшибка ввода";
            Console.WriteLine(res);
            WriteXY(41, 13, res);

            // вывод в старом стиле
            Console.WriteLine("\n\nВы ввели: a = {0}  d = {1}", a, d);

            // форматирование строки для вывода
            
            // а) в старом стиле
            string s1 = string.Format("\n\nВывод в строку: a = {0:n2}  d = {1}", a, d); // C# 1.0 ...
            
            // б) в новом стиле - интерполяционная строка
            string s2 = $"\n\n\nВывод в строку: a = {a}  d = {d:n2}"; // C# 6.0 ...
            Console.WriteLine(s1);
            Console.WriteLine(s2);
            
            // применим статический метод для упрощения кодирования
            WriteXY(41,  15, $"Вы ввели: a = {a}  d = {d}");
            // 15:n3 - 15: ширина поля вывода, n - формат с разделением групп разрядов, 3 - знака в дробной части
            WriteXY(41, 17, $"Вы ввели: |{a, 5}| {d, 15:f3} | {d:##,###,###,###.###} |");  
            
            // переместим курсор в нижнюю строку окна
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
        } // Main


        // Вспомогательный метод для вывода в заданных координатах окна консоли 
        static void WriteXY(int x, int y, string s)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(s);
        } // WriteXY
    } // class Program
}
