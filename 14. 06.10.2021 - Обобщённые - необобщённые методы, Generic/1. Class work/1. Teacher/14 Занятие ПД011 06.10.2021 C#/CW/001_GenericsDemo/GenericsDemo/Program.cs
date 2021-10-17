using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsDemo
{
    class Program
    {
        static void Main(string[] args) {   
            Console.Title = "Занятие 06.10.2021 - обобщенные типы в C#, обобщенные методы";
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();

            // Обобщенные методы      C#   ---  :) До-диез   Си-хэш  :) 
            // Demo1();
            // Console.WriteLine();
            
            // Разница между обобщенным типом и object
            Demo2();
            Console.WriteLine("\n\n\n");
            Console.ForegroundColor = ConsoleColor.Black;
        } // Main


        // Демонстрация обобщенных методов
        private static void Demo1() {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nВызовы обобщенных методов:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            // Полный формат вызова обобщенного метода
            // ИмяМетода<СписокПодставляемыхТипов>(СписокПараметров);
            Foo<double>(3);   

            // Подставляемый (универсальный) тип может быть пропущен, если 
            // тип определяется из контекста вызова
            Foo(-1.4);
            Console.WriteLine();

            // Демонстрации вызова обобщенных методов
            Foo<float>(-5.8f);     // полная форма
            Foo(-5.8f);            // краткая форма
            Console.WriteLine();

            Foo<bool>(true);       // полная форма вызова
            Foo(false);            // краткая форма вызова
            Console.WriteLine();

            Foo<string>("Это строка");
            Foo("This is a string");
            Console.WriteLine();
            
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nконфликт по типам: обобщенная и обычная функции с одинаковыми типами");
            Console.ForegroundColor = ConsoleColor.Cyan;

            Foo<int>(123);  // При наличии необобщенной реализации необходимо
                            // явное задание типа
            Foo(123);       // Вызов необобщенной версии
            Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nКоллизия между обычным и обобщенным методами:");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // коллизия - какой метод вызывается обобщенный или нет?
            Foo<int>(); // явное задание типа говорит о том, что нужен обобщенный метод
            Foo();      // C# вызывает необобщенный метод 
            
        } // Demo1

        // Обобщенный метод
        // значение по умолчанию для данного типа default(T) 
        // доступ типЗнач ИмяМетода<Тип1, Тип2, ..., ТипN>(Тип1 p1, Тип2 p2, ..., ТипN pN = default(TипN)) {
        private static void Foo<T>(T p = default(T)) {
            Console.WriteLine($"Foo (generic): {p}");
            // для обобщенного типа не поддерживаются операции + - * / % < > <= >=
            // p = p + 5;
            // bool r = p > 1;
        } // Foo

        // Перегрузка - необобщенная версия перегруженного метода
        private static void Foo(int p = -100) {
            Console.WriteLine($"foo (general): {p}");
            // p = p + 7;
            // bool r = p < 1;
        } // Foo


        // Демонстрация разницы между object  и обобщенным типом
        private static void Demo2() {
            int x = 123;
            int y;
            
            // При передаче параметров в метод выполняется упаковка (inboxing)
            // параметра в тип object, при возврате из метода - распаковка 
            // в тип int (outboxing)
            // На это тратится время...
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nСкалярные типы:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            
            // для object
            // y = (int)Bar((object)x);  // компилятор подставит вызов более эффективного обобщенного метода - поэтому object
            // double r = (double)Bar((object)3.89);
            // string s = (string)Bar((object)"Это еще строка");
            y = Bar(x);  // компилятор подставит вызов более эффективного обобщенного метода
            double r = Bar(3.89);
            string s = Bar("Это еще строка");
            Console.WriteLine($"Для контроля y = {y}; r = {r}; s = \"{s}\"\n");
            
            
            // Синтаксис создания объекта new Тип {ИмяСвойстваИлиПоля1 = значение1, ..., ИмяСвойстваN = значениеN}; 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nСсылочные типы:");
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Demo demo = (Demo)Bar((object)new Demo { Name = "Петя", Height = 110, Width = 80 });
            Demo demo = Bar(new Demo { Name = "Петя", Height = 110, Width = 80 });
            Console.WriteLine($"В точке возврата: {demo}\n");

            
            // Для вызова необобщенного метода в явном виде задаем тип параметра и 
            // возвращаемого значения - только так можно "убедить" компилятор,
            // что мы точно хотим вызвать неэффективный вариант
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n\nИспользование object вместо generic:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            object t = Bar((object)demo);
            Console.WriteLine($"Для контроля t = {t}"); 
            
        } // Demo2


        // Демонстрационный метод - покажем разницу между типом 
        // object и универсальным типом  
        private static object Bar(object p) {
            Console.WriteLine($"Bar (general-object): {p}");
            return p;
        } // Bar

        // Обобщенный метод - более эффективен, чем использовние типа object
        private static T Bar<T>(T p) {
            Console.WriteLine($"Bar (generic): {p}");
            return p;
        } // Bar

        // в общем виде нельзя использовать операции с обобщенными типами
        // private static T Add<T>(T x, T y) { return x + y; }
    } // class Program
}
