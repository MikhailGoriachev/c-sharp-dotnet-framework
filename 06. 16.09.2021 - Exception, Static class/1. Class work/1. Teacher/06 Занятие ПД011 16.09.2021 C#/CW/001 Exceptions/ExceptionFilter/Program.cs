using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionFilter
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 16.09.2021 - фильтры в исключениях";

            // Фильтры в исключениях
            // catch (тип) when (выражениеФильтра) {
            //     операторы обработки
            // }
            //
            // исключение обрабатывается, если выражениеФильтра имеет
            // значение true

            int x = 1, y = 0;

            for (int i = 0; i < 5; ++i, ++x) {
                try {
                    switch (i) {
                        // при первом проходе цикла
                        // сработает исключение DivideByZeroException с фильтром
                        // при втором проходе цикла
                        // сработает исключение DivideByZeroException 
                        // при четвертом проходе цикла исключение не будет выброшено
                        case 3:
                            y = 2;
                            goto case 0;

                        case 0:
                        case 1:
                            int result = x / y;
                            Console.WriteLine($"{x} / {y} = {result}");
                            ++x;
                            break;

                        // при третьем проходе цикла сработает обработчик исключения без типа,
                        // но с фильтром
                        case 2:
                            throw new ArgumentException(
                                $"Это сообщение об исключении, x = {x}");
                        // break;

                        // при пятом проходе выбрасывается необрабатываемое 
                        // исключение, что прерывает работу консольного приложения
                        case 4:
                            throw new InvalidDataException(
                                $"Исключение при i = {i}, x = {x}");
                        // break;
                    } // switch

                } // try

                // использование фильтра исключений
                catch (DivideByZeroException) when (y == 0 && x == 1) {
                    Console.WriteLine(
                        "Использование фильтра исключений. Переменные x, y не должны быть равны 0 и 1");
                }

                catch (DivideByZeroException ex) {
                    Console.WriteLine($"Обработчик без фильтра: {ex.Message}"); 
                }

                // фильтр в бестиповом исключении
                catch when (y == 0 && x == 3) {
                    Console.WriteLine("Исключение без типа, только с фильтром");
                }

                // бестиповое исключение без фильтра
                catch {
                    Console.WriteLine("Oops! I did it again!");
                }

                finally {
                    Console.WriteLine("\n");
                }// try-catch-finally
            } // while
        } // Main
    } // class Program
}
