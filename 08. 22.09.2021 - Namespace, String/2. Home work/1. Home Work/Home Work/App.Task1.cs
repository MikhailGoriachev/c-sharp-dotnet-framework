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
        #region Задание 1. Название задания

        /*
            Задача 1. Решение задачи разместите в классе, класс расположите во 
            вложенном пространстве имен Models Вашего проекта. Выполнить 
            обработку строк – используйте класс string:
                •	Даны строки S и S0. Удалить из строки S все подстроки, 
                    совпадающие с S0. Если совпадающих подстрок нет, то вывести 
                    строку S без изменений.
                •	Даны строки S, S1 и S2. Заменить в строке S все вхождения 
                    строки S1 на строку S2
                •	Дана строка, состоящая из слов, разделенных пробелами (одним 
                    или несколькими). Вывести строку, содержащую эти же слова, 
                    разделенные одним символом «.» (точка). В конце строки точку не
                    ставить.
                •	Дана строка, состоящая из слов, разделенных пробелами (одним или 
                    несколькими). Вывести строку, содержащую эти же слова, разделенные
                    одним пробелом и расположенные в обратном порядке.
                •	Дана строка, состоящая из слов, набранных заглавными буквами и 
                    разделенных пробелами (одним или несколькими). Вывести строку, 
                    содержащую эти же слова, разделенные одним пробелом и расположенные 
                    в алфавитном порядке строчным буквами.
         */

        // Задание 1. Мианипуляция со строками
        public void Task1()
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
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Задание 1. Мианипуляция со строками"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("1. Удаление подстроки");
                Console.SetCursorPosition(x, y++); Console.WriteLine("2. Удаление подстроки (демонстрация отсутвия подстроки)");
                Console.SetCursorPosition(x, y++); Console.WriteLine("3. Замена подстрок");
                Console.SetCursorPosition(x, y++); Console.WriteLine("4. Замена разделителя слов ' ' на '.'");
                Console.SetCursorPosition(x, y++); Console.WriteLine("5. Изменение порядка слов на обратный и с разделителем ' '");
                Console.SetCursorPosition(x, y++); Console.WriteLine("6. Cортировка в алфавитном порядке и перевод в нижний регистр");
                Console.SetCursorPosition(x, y++); Console.WriteLine("0. Выход");

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

                        // 1. Удаление подстроки
                        case (int)Cmd.pointOne:
                            Console.Clear();
                            // запуск задания 
                            DemoRemoveSubstring();
                            break;

                        // 2. Удаление подстроки (демонстрация отсутвия подстроки)
                        case (int)Cmd.pointTwo:
                            Console.Clear();
                            // запуск задания 
                            DemoRemoveSubstringNotFound();
                            break;

                        // 3. Замена подстрок
                        case (int)Cmd.pointThree:
                            Console.Clear();
                            // запуск задания 
                            DemoReplaceSubstring();
                            break;

                        // 4. Замена разделителя слов ' ' на '.'
                        case (int)Cmd.pointFour:
                            Console.Clear();
                            // запуск задания 
                            DemoReplaceSeparator();
                            break;

                        // 5. Изменение порядка слов на обратный и с разделителем ' '
                        case (int)Cmd.pointFive:
                            Console.Clear();
                            // запуск задания 
                            DemoReversLine();
                            break;

                        // 6. Cортировка в алфавитном порядке и перевод в нижний регистр
                        case (int)Cmd.pointSix:
                            Console.Clear();
                            // запуск задания 
                            DemoSortLine();
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
                } // try

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

            #region 1. Удаление подстроки

            // 1. Удаление подстроки
            void DemoRemoveSubstring()
            {
                ShowNavBarMessage("1. Удаление подстроки");

                // основная строка 
                _task1.Line = "Очень очень очень красивые глаза";

                // подстрока 
                string substring = "очень";

                // вывод строки до удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка до удаления подстроки");

                Console.WriteLine();

                // если нет вхождений 
                if (_task1.Line.IndexOf(substring) == -1)
                {
                    ShowNotFoundSubstring(substring);

                    return;
                }

                // удаление подстроки из основной строки
                _task1.RemoveSubstring(substring);

                // вывод строки после удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка после удаления подстроки");

                Console.WriteLine();

                // вывод подстроки 
                ShowLine(substring, "Подстрока");
            }

            #endregion

            #region 2. Удаление подстроки (демонстрация отсутвия подстроки)

            // 2. Удаление подстроки (демонстрация отсутвия подстроки)
            void DemoRemoveSubstringNotFound()
            {
                ShowNavBarMessage("2. Удаление подстроки (демонстрация отсутвия подстроки)");

                // основная строка 
                _task1.Line = "Очень очень очень красивые глаза";

                // подстрока 
                string substring = "Кот";

                // вывод строки до удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка до удаления подстроки");

                Console.WriteLine();

                // если нет вхождений 
                if (_task1.Line.IndexOf(substring) == -1)
                {
                    ShowNotFoundSubstring(substring);

                    return;
                }

                // удаление подстроки из основной строки
                _task1.RemoveSubstring(substring);

                // вывод строки после удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка после удаления подстроки");

                Console.WriteLine();

                // вывод подстроки 
                ShowLine(substring, "Подстрока");
            }

            #endregion

            #region 3. Замена подстрок

            // 3. Замена подстрок
            void DemoReplaceSubstring()
            {
                ShowNavBarMessage("3. Замена подстрок");

                // основная строка 
                _task1.Line = "кот кота ломом колол, а другие кололи слона";

                // подстрока 
                string substring = "кот";

                // строка для замены 
                string repString = "морж";

                // вывод строки до замены подстроки 
                ShowLine(_task1.Line, "Исходная строка", "Строка до замены подстроки");

                Console.WriteLine();

                // если нет вхождений 
                if (_task1.Line.IndexOf(substring) == -1)
                {
                    ShowNotFoundSubstring(substring);

                    return;
                }

                // замена подстроки на строку
                _task1.ReplaceSubstring(substring, repString);

                // вывод строки после замены подстроки 
                ShowLine(_task1.Line, "Исходная строка", "Строка после замены подстроки");

                Console.WriteLine();

                // вывод подстроки 
                ShowLine(substring, "Подстрока");

                Console.WriteLine();

                // вывод заменяющей строки 
                ShowLine(repString, "Заменяющая строка");
            }

            #endregion

            #region 4. Замена разделителя слов ' ' на '.'

            // 4. Замена разделителя слов ' ' на '.'
            void DemoReplaceSeparator()
            {
                ShowNavBarMessage("4. Замена разделителя слов ' ' на '.'");

                // основная строка 
                _task1.Line = "кот кота ломом колол, а другие кололи слона";

                // вывод строки до замены разделителя 
                ShowLine(_task1.Line, "Исходная строка", "Строка до замены разделителя");

                Console.WriteLine();

                // замена разделителя 
                _task1.ReplaceSeparator();

                // вывод строки после замены разделителя 
                ShowLine(_task1.Line, "Исходная строка", "Строка после замены разделителя");
            }

            #endregion

            #region 5. Изменение порядка слов на обратный и с разделителем ' '

            // 5. Изменение порядка слов на обратный и с разделителем ' '
            void DemoReversLine()
            {
                ShowNavBarMessage("5. Изменение порядка слов на обратный и с разделителем ' '");

                // основная строка 
                _task1.Line = "Четвёртый   Третий Второй           Первый";

                // вывод строки до изменения порядка 
                ShowLine(_task1.Line, "Исходная строка", "Строка до изменения порядка");

                Console.WriteLine();

                // замена разделителя 
                _task1.ReversReplaceSeparator();

                // вывод строки после изменения порядка 
                ShowLine(_task1.Line, "Исходная строка", "Строка после изменения порядка");
            }

            #endregion

            #region 6. Cортировка в алфавитном порядке и перевод в нижний регистр

            // 6. Cортировка в алфавитном порядке и перевод в нижний регистр

            void DemoSortLine()
            {
                ShowNavBarMessage("6. Cортировка в алфавитном порядке и перевод в нижний регистр");

                // исходная строка 
                _task1.Line = "гигант бабабуданит вавилон абажур".ToUpper();

                // вывод строки до удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка до сортировки ");

                Console.WriteLine();

                // сортировка слов в алфавитном порядке 
                _task1.SortAndToLower();

                // вывод строки после удаления 
                ShowLine(_task1.Line, "Исходная строка", "Строка после сортировки");
            }

            #endregion

            #region Общие методы

            // сообщение о том, что подстрока не входит в строку
            void ShowNotFoundSubstring(string substring)
            {
                WriteColor($"     ╔══════════════════════════════════════════════════════════════════════════════════╗\n", ConsoleColor.Red);
                WriteColor($"     ║                                                                                  ║", ConsoleColor.Red);
                WriteColorXY("Сообщение: ", posX: 7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY($"Подстрока не найдена в исходной строке", textColor: ConsoleColor.Green);
                WriteColor($"\n     ╠══════════════════════════════════════════════════════════════════════════════════╣\n", ConsoleColor.Red);
                WriteColor($"     ║                                                                                  ║", ConsoleColor.Red);
                WriteColorXY("Подстрока: ", posX: 7, textColor: ConsoleColor.DarkYellow);
                WriteColorXY($"{substring,-69}", textColor: ConsoleColor.Green);
                WriteColor($"\n     ╚══════════════════════════════════════════════════════════════════════════════════╝\n", ConsoleColor.Red);

            }

            #endregion
        }

        #endregion

    }
}
