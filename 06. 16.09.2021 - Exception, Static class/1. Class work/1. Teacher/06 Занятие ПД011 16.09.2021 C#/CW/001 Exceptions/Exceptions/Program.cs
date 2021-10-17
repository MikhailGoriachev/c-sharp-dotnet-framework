using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions
{
    // Исключения в приложениях C#
    // try {} catch (тип ex) {} finally {}
    // try {} catch (тип ex) {} 
    // try {} finally {}
    // throw new тип(параметры);
    // checked {}     checked()
    // unchecked {}   unchecked()
    class Program
    {
        static void Main(string[] args) {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.Title = "16.09.2021 - исключения  в C#";

            try {
                double a = double.MaxValue, b = 100d;
                double c;

                int n = int.MaxValue, m = 10, v;

                v = n + m;
                Console.WriteLine($"До включения контроля переполнения {n} + {m} = {v}");


                Console.WriteLine("Проверка реакции на деление на ноль int:");
                // m = 0;
                v = n / m;
                Console.WriteLine($"{n} / {m} = {v}\n");

                /*
                // включить контроль переполнений
                checked {
                    // вычисления на целых типах
                    /*
                    // v = n + m;
                    Console.WriteLine($"v = {v}");
                    
                    Console.WriteLine("Проверка реакции на переполнение int:");
                    v = unchecked(n + m);
                    Console.WriteLine($"unchecked: {n} + {m} = {v}\n");

                    
                    v = checked(n + m);
                    v = n + m;
                    Console.WriteLine($"checked: {n} + {m} = {v}\n");
                    

                    // демонстрация контроля вычислений для double

                    // программист обязан контролировать переполнение сам
                    Console.WriteLine("Проверка реакции на переполнение double:");
                    c = a * b;
                    string str = $"{a} * {b} = " + (double.IsInfinity(c)?"Переполнение\n":$"{c}\n");
                    Console.WriteLine(str);

                    b = 0d;
                    if (b == 0d) throw new ProbablyDivideByZeroException();
                    c = a / b;
                    Console.WriteLine($"{a} / {b} = {c}");
                } // checked
                */
                
                // Console.WriteLine("\nИсключения в методах");
                // Foo();
                // Bar();
                b = 99d;
                b += 3d;

                if (b >= 100d)
                    throw new MyException($"Тест сообщения: переменная b == {b}", b);
                // оператор для примера - finally сработает ПОСЛЕ return
                return;
                
            }
            catch (MyException ex) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine($"\n{ex.Message}, значение вызвавшее ошибку: {ex.GetValue()}");
            }
            catch (ProbablyDivideByZeroException ex) {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\n{ex.Message}");
                //throw;
            }
            catch (UriFormatException ex) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{ex.Message}");
            }
            catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(
                    "\nИсключение:\n" +
                    $"Тип                     : {ex.GetType()}\n" +
                    $"Метод                   : {ex.TargetSite}\n" +
                    $"Сообщение               : {ex.Message}\n" +
                    $"Место обнаружения ошибки:\n{ex.StackTrace}");
            }
            // catch {
            //     Console.ForegroundColor = ConsoleColor.Red;
            //     Console.WriteLine("Случилось страшное...");
            //     Console.ForegroundColor = ConsoleColor.Gray;
            // }
            finally {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nКод финализации");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

            // если раскомментирован return в секции try{} эти +++ не выводятся
            Console.WriteLine("+++");
        } // Main

        // Исключения в методах
        private static void Foo() {
            try {
                throw new NotImplementedException("Метод Foo() не реализован");
            } catch (NotImplementedException ex) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n{ex.TargetSite}: {ex.Message}");
                throw;  // повторный выброс исключения NotImplementedException с передачей на верхний уровень
            }
        } // Foo

        // выброс исключения без обработки
        private static void Bar() {
            throw new NotImplementedException("Метод Bar() не реализован");
        } // Bar
    } // class Program

}
