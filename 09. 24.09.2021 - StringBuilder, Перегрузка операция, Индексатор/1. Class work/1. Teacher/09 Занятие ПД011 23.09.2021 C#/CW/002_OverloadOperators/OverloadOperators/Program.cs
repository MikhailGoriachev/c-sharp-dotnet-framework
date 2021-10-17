using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OverloadOperators
{
    // Перегрузка операторов заключается в определении в классе, для объектов
    // которого мы хотим определить оператор, специального метода:

    // public static возвращаемый_тип operator оператор(параметры)
    // {  код обработки }

    // Этот метод должен иметь модификаторы public static, так как перегружаемый
    // оператор будет использоваться для всех объектов данного класса. Далее идет
    // название возвращаемого типа. Возвращаемый тип представляет тот тип, объекты
    // которого мы хотим получить. К примеру, в результате сложения двух объектов
    // Counter мы ожидаем получить новый объект Counter. А в результате сравнения
    // двух объектов Counter мы хотим получить объект типа bool, который указывает
    // истинно ли условное выражение или ложно.
    // Но в зависимости от задачи возвращаемые типы могут быть любыми.

    // Затем вместо названия метода идет ключевое слово operator и собственно сам
    // оператор. И далее в скобках перечисляются параметры. Бинарные операторы
    // принимают два параметра, унарные - один параметр.
    // И в любом случае один из параметров должен представлять тот тип - класс
    // или структуру, в котором определяется оператор.

    // При перегрузке операторов надо учитывать, что не все операторы можно
    // перегрузить. В частности, мы можем перегрузить следующие операторы:
    //
    // унарные операторы     +, -, !, ~, ++, --
    // бинарные операторы    +, -, *, /, %
    // операции сравнения    ==, !=,    <, >,   <=, >=
    // логические операторы  &, |, &&, ||                       
    // операторы присваивания +=, -=, *=, /=, %=
    //
    // И есть операторы, которые нельзя перегрузить, например,
    // операцию присваивания = или тернарный оператор ?:, а также ряд других
    // (true, false, приведение типа).

    // Но!
    // Интерфейс ICloneable - должен быть реализован в сложном объекте для корректного
    // присваивания

    // Но!
    // [] - это не перегрузка операции, это индексатор
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 23.09.2021 - перегрузка операций";

            Counter c1 = new Counter { Value = 23, Name = "Первый" };
            Counter c2 = new Counter { Value = 42, Name = "Второй" };
 
            Counter c3 = c1 + c2;
            Console.WriteLine($"{c1} + {c2} = {c3}");  // 23 + 42 = 65

            Console.WriteLine($"{c1 + c2}");
            
            int p = 27;
            c3 = c1 + p;
            Console.WriteLine($"{c1} + {p} = {c3}");

            int d = p + c1; // 50
            Console.WriteLine($"{c1} + {p} = {d}\n");
            
            Counter counter = new Counter { Value = 10, Name = "Inc" };
            Console.WriteLine($"\nИсходно    : {counter}");        // 10
            Console.WriteLine($"Префиксный : {++counter}");    // 20
            Console.WriteLine($"После      : {counter}\n");      // 20
            
            Console.WriteLine($"Исходно    : {counter}");
            Console.WriteLine($"Постфиксный: {counter++}");      // 20
            Console.WriteLine($"После      : {counter}\n");      // 30

            counter.Name = "Dec";
            Console.WriteLine($"\nИсходно    : {counter}");        // 30
            Console.WriteLine($"Префиксный : {--counter}");    // 20
            Console.WriteLine($"После      : {counter}\n");      // 20

            Console.WriteLine($"Исходно    : {counter}");
            Console.WriteLine($"Постфиксный: {counter--}");      // 20
            Console.WriteLine($"После      : {counter}\n");      // 10

            // логическая операция
            bool result = c1 > c2;
            Console.WriteLine($"{c1} > {c2} = {result}"); //
            result = c1 < c2;
            Console.WriteLine($"{c1} < {c2} = {result}"); // false
            
            // демонстанция перегруженных операций true/false
            counter.Value = 11;
            Console.Write($"\nПерегрузка операций true/false: {counter} --> ");
            
            // если counter истинный...
            if (counter)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            
            counter.Value = 0;
            Console.Write($"\nПерегрузка операций true/false: {counter} --> ");
            
            // если counter истинный...
            if (counter)
                Console.WriteLine("True");
            else
                Console.WriteLine("False");
            
            Console.WriteLine("\n\n");
        } // Main

        
    } // class Program


}
