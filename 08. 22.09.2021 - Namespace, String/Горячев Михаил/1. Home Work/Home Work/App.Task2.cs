using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

using Home_Work.Models; // подключение пространства имен для заданий

namespace Application
{
    public partial class App
    {

        #region Задание 2. Навание задания

        /*
        * Задача 2. Дана строка S (класс string). В строке слова разделяются одним или несколькими 
        * пробелами, в результирующей строке слова должны разделяться одним пробелом:
        *   •	В строке поменять местами каждые два соседних слова.
        *   •	Из строки удалить все слова, начинающиеся и заканчивающиеся гласными буквами
        *   •	Поменять местами первое слово максимальной длины и первое слово минимальной длины в строке
        *   •	В каждом слове строки установить верхний регистр первой буквы
        */

        // Задание 2. Мианипуляция со строками
        public void Task2()
        {
            #region Меню

            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 2. Мианипуляция со строками"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Поменять местами каждые два соседних слова ");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Удаление из строки всех слов начинающихся или заканчивающихся гласной буквой");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Поменять местами первое слово масимальной длины и первое слово минимальной длины");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. В каждом слове строки установить верхний регистр первой буквы");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                try
                {

                    // обработка ввода 
                    switch (n)
                    {
                        // выход
                        case (int)Cmd.pointExit:
                            // позициониаровние курсора 
                            Console.SetCursorPosition(2, y + 5);
                            return;

                        // 1. Поменять местами каждые два соседних слова 
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            DemoSwapEveryTwoWords();
                            break;

                        // 2. Удаление из строки всех слов начинающихся или заканчивающихся гласной буквой
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            DemoRemoveWordsVowel();
                            break;

                        // 3. Поменять местами первое слово масимальной длины и первое слово минимальной длины
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            DemoSwapLongShortWords();
                            break;

                        // 4. В каждом слове строки установить верхний регистр первой буквы
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            DemoToUpper();
                            break;

                        // если номер задания невалиден
                        default:

                            // установка цвета
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.ForegroundColor = ConsoleColor.Black;

                            // позиционирование курсора
                            Console.SetCursorPosition(x, y); Console.WriteLine("         Номер задания невалиден!         ");

                            // выключение курсора
                            Console.CursorVisible = false;

                            // задержка времени
                            Thread.Sleep(1000);

                            // возвращение цвета
                            Console.ResetColor();

                            // включение курсора
                            Console.CursorVisible = true;

                            break;
                    } // switch
                }// Try


                // стандартное исключение
                catch (Exception ex)
                {
                    Console.Clear();

                    // вывод сообщения об ошибке 
                    WriteColor(ex.Message, ConsoleColor.Red);
                    Console.WriteLine();
                    WriteColor(ex.StackTrace, ConsoleColor.Red);
                    Console.WriteLine();
                } // catch

                // обязательная часть
                finally
                {
                    // ввод клавиши для продолжения 
                    WriteColor("\n\n\tНажмите на [Enter] для продолжения...", ConsoleColor.Cyan);
                    Console.CursorVisible = false;
                    while (Console.ReadKey(true).Key != ConsoleKey.Enter) ;
                    Console.CursorVisible = true;
                } // finally
            }

            #endregion

            #region 1. Поменять местами каждые два соседних слова 

            // 1. Поменять местами каждые два соседних слова 
            void DemoSwapEveryTwoWords()
            {
                ShowNavBarMessage("1. Поменять местами каждые два соседних слова ");

                // основная строка 
                _task2.Line = "Первый Второй Третий Четвёртый Пятый";

                // вывод строки до изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка до изменения порядка слов");

                Console.WriteLine();

                // изменения порядка слов
                _task2.SwapEveryTwoWords();

                // вывод строки после изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка после изменения порядка слов");

            }

            #endregion

            #region 2. Удаление из строки всех слов начинающихся или заканчивающихся гласной буквой

            // 2. Удаление из строки всех слов начинающихся или заканчивающихся гласной буквой
            void DemoRemoveWordsVowel()
            {
                ShowNavBarMessage("2. Удаление из строки всех слов начинающихся или заканчивающихся гласной буквой");

                // основная строка 
                _task2.Line = "Азбука нравится Алисе и Наташе, но не нравится Егору";

                // вывод строки до удаления 
                ShowLine(_task2.Line, "Исходная строка", "Строка до удаления");

                Console.WriteLine();

                // удаление подстроки
                _task2.RemoveWordsStartEndVowel();

                // вывод строки после удаления 
                ShowLine(_task2.Line, "Исходная строка", "Строка после удаления");
            }

            #endregion

            #region 3. Поменять местами первое слово масимальной длины и первое слово минимальной длины

            // 3. Поменять местами первое слово масимальной длины и первое слово минимальной длины
            void DemoSwapLongShortWords()
            {
                ShowNavBarMessage("3. Поменять местами первое слово масимальной длины и первое слово минимальной длины");

                _task2.Line = "Як сильнее жирафа, но медленнее гипарда";

                // вывод строки до изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка до изменения порядка слов");

                Console.WriteLine();

                // изменения порядка слов
                _task2.SwapLongShortWords();

                // вывод строки после изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка после изменения порядка слов");
            }

            #endregion

            #region 4. В каждом слове строки установить верхний регистр первой буквы

            // 4. В каждом слове строки установить верхний регистр первой буквы
            void DemoToUpper()
            {
                ShowNavBarMessage("4. В каждом слове строки установить верхний регистр первой буквы");

                // основная строка 
                _task2.Line = "Азбука нравится Алисе и Егору, но не нравится Наташе";

                // вывод строки до изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка до изменения слов");

                Console.WriteLine();

                // изменение слов
                _task2.ToUpperFirstLetterWords();

                // вывод строки после изменения порядка слов 
                ShowLine(_task2.Line, "Исходная строка", "Строка после изменения слов");
            }

            #endregion
        }

        #endregion

    }
}
