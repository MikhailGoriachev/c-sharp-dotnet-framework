using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enums
{
    class Program
    {
        // Перечисления представляют собой набор логически связанных констант.
        // Объявление перечисления происходит с помощью оператора enum.
        // Далее идет название перечисления, после которого указывается тип
        // перечисления - он обязательно должен представлять целочисленный тип
        // (byte, int, short, long).
        // enum Имя: тип { список констант }
        //
        // Если тип явным образом не указан, то по умолчанию используется тип int.
        // Перечисление может быть объявлено и вне класса
        enum Operation : byte {
            Add = 1,    // можно начать начальное значение для последовательности
            Subtract,
            Multiply,
            Divide // = Add  // так тоже можно, но зачем?
        } // Operation
 
 
        static void Main(string[] args) {
            Console.Title = "Занятие 15.09.2021 - перечисления в C#";

            Console.WriteLine("\n\n    Пример использования перечислений:\n" +
                "    ┌──────────────┬──────────────┬────────────┬────────────┬────────────┐\n" +
                "    │ Имя операции │ Код операции │  Операнд 1 │  Операнд 2 │  Результат │\n" +
                "    ├──────────────┼──────────────┼────────────┼────────────┼────────────┤");
            double op1 = 10, op2 = 2.87;
            Operation op = Operation.Add;
            double result = MathOp(op1, op2, op);
            Console.WriteLine($"    │ {op, -12} │ {(byte)op, 12} │ {op1, 10:f5} │ {op2, 10:f5} │ {result, 10:f5} │");
 
            op = Operation.Subtract;
            result = MathOp(op1, op2, op);
            Console.WriteLine($"    │ {op, -12} │ {(byte)op, 12} │ {op1, 10:f5} │ {op2, 10:f5} │ {result, 10:f5} │");

            op = Operation.Multiply;
            result = MathOp(op1, op2, op);
            Console.WriteLine($"    │ {op, -12} │ {(byte)op, 12} │ {op1, 10:f5} │ {op2, 10:f5} │ {result, 10:f5} │");
 
            op = Operation.Divide;
            result = MathOp(op1, op2, op);
            Console.WriteLine($"    │ {op, -12} │ {(byte)op, 12} │ {op1, 10:f5} │ {op2, 10:f5} │ {result, 10:f5} │");

            Console.Write("    └──────────────┴──────────────┴────────────┴────────────┴────────────┘\n\n\n    ");
        }  // Main

        // выполнение операций
        static double MathOp(double x, double y, Operation op) {
            double result = 0.0;

            // использование сниппета switch совместно с перечислением
            // switch Tab Tab
            // ввести имя переменной перечисления в switch()
            // кликнуть ЛКМ в стороне от switch
            // :)

            switch (op) {
                case Operation.Add:
                    result = x + y;
                    break;
                case Operation.Subtract:
                    result = x - y;
                    break;
                case Operation.Multiply:
                    result = x * y;
                    break;
                case Operation.Divide:
                    result = x / y;
                    break;
            } // switch

            return result;
        } // MathOp
    } // class Program
}
