using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualBasic;  // для Interaction

/*
 * Разработайте консольное приложение для решения следующих задач. Каждую задачу
 * размещайте в отдельном статическом методе класса Program. 
 * 
 * Задача 1. Выполнить ввод и вывод при помощи методов класса Interaction. 
 * Реализовать решение задачи в бесконечном цикле, выход из цикла – после ввода
 * 0. Вводить трехзначное положительное число (100, …, 999). При помощи операций
 * деления и взятия остатка выделить цифры числа (единицы = число % 10, сотни = 
 * число / 100, десятки = число % 100 / 10). Определить:
 * a)	входят ли в число цифры 4 или 7
 * b)	входят ли в него цифры 3, 6, или 9
 * 
 * Задача 2. Выполнить ввод и вывод при помощи методов класса Interaction. Решение 
 * задачи должно содержать цикл, повторяющийся трижды. Ввести вещественное число. 
 * Если число отрицательное, то возвести его в квадрат, иначе поменять знак числа 
 * на противоположный.
 * 
 * Задача 3. Вывод задачи организовать в консоль, в табличном виде.
 * Игральным картам условно присвоены следующие порядковые номера в зависимости от 
 * их достоинства: «валет» – 11, «дама» -–12, «король» – 13, «туз» – 14. Порядковые 
 * номера остальных карт соответствуют их названиям («шестерка», «семерка», …). 
 * В цикле формировать 10 случайных чисел в диапазоне от 6 до 14, т.е. номер карты. 
 * По этому номеру определить достоинство карты.     
 */

namespace Home_Work
{
    class Program
    {
        static void Main(string[] args)
        {
            // заголовок окна
            Console.Title = "Домашнее задание на 09.09.2021";

            // размер окна
            Console.SetWindowSize(120, 29);

            // меню
            Menu();
        }

        // константы номеров заданий
        public enum CMD
        {
            CMD_POINT_ONE = 1,
            CMD_POINT_TWO,
            CMD_POINT_THREE,
        };

        // меню заданий
        static void Menu()
        {
            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                // пукты меню
                Console.SetCursorPosition(5, 5); Console.WriteLine("1. Задание. Проверка трёхзначного числа");
                Console.SetCursorPosition(5, 6); Console.WriteLine("2. Задание. Проверка вещественного числа");
                Console.SetCursorPosition(5, 7); Console.WriteLine("3. Задание. Карты");
                Console.SetCursorPosition(5, 10); Console.WriteLine("0. Выход");

                // ввод номера задания
                Console.SetCursorPosition(5, 15); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch(n)
                {
                    // выход
                    case 0:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, 15);
                        return;

                    // Задание 1. Проверка трёхзначного числа
                    case (int)CMD.CMD_POINT_ONE:
                        // запуск задания 
                        Task1();
                        break;

                    // Задание 2. Проверка вещественного числа
                    case (int)CMD.CMD_POINT_TWO:
                        // запуск задания 
                        Task2();
                        break;

                    // Задание 3. Карты
                    case (int)CMD.CMD_POINT_THREE:
                        // запуск задания 
                        Task3();
                        break;

                    // если номер задания невалиден
                    default:

                        // установка цвета
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Black;

                        // позиционирование курсора
                        Console.SetCursorPosition(5, 15); Console.WriteLine("         Номер задания невалиден!         ");

                        // выключение курсора
                        Console.CursorVisible = false;

                        // задержка времени
                        Thread.Sleep(1000);

                        // возвращение цвета
                        Console.ResetColor();

                        // включение курсора
                        Console.CursorVisible = true;

                        break;
                }
            }
        }

        // Задание 1. Проверка трёхзначного числа
        static void Task1()
        {

            /*
             * Задача 1. Выполнить ввод и вывод при помощи методов класса Interaction. 
             * Реализовать решение задачи в бесконечном цикле, выход из цикла – после ввода
             * 0. Вводить трехзначное положительное число (100, …, 999). При помощи операций
             * деления и взятия остатка выделить цифры числа (единицы = число % 10, сотни = 
             * число / 100, десятки = число % 100 / 10). Определить:
             * a)	входят ли в число цифры 4 или 7
             * b)	входят ли в него цифры 3, 6, или 9
             */

            // число
            int num;

            while (true)
            {
                // ввод трёхзначного числа
                string line = Interaction.InputBox("Введите трёхзначное число(100, …, 999): ",
                    "Задание 1. Проверка трёхзначного числа");

                // если была нажата кнопка "Отмена"
                if (line.Length == 0)
                    return;

                // преобразование числа из строки
                if (!int.TryParse(line, out num))
                    Interaction.MsgBox("Введённые данные некорректны!", MsgBoxStyle.Critical, "Ввод данных");
                // если число невалидно
                else if (num < 100 || num > 999)
                    Interaction.MsgBox("Число " + num + " невалидно!", MsgBoxStyle.Critical, "Ввод данных");
                else break;
            }

            // обработка по заданию 

            // флаг вхождения цифр 4 или 7
            bool flagA = false;
            bool tempFlagA;

            // флаг вхождения цифр 3, 6, или 9
            bool flagB = false;
            bool tempFlagB;

            // проверка единиц
            CheckNumeral(num % 10, out tempFlagA, out tempFlagB);

            // присваивание значений 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // проверка десятков
            CheckNumeral(num % 100 / 10, out tempFlagA, out tempFlagB);

            // присваивание значений 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // проверка сотен
            CheckNumeral(num / 100, out tempFlagA, out tempFlagB);

            // присваивание значений 
            flagA = tempFlagA == true ? true : flagA;
            flagB = tempFlagB == true ? true : flagB;

            // вывод результата
            Interaction.MsgBox("a)	входят ли в число цифры 4 или 7: " + flagA
                + "\nb)	входят ли в него цифры 3, 6, или 9: " + flagB, MsgBoxStyle.OkOnly, "Результаты выполнения");
        }

        // проверка цифры
        static void CheckNumeral(int num, out bool flagA, out bool flagB)
        {
            flagA = false;
            flagB = false;

            // проверка
            switch (num)
            {
                // вхождения цифр 4 или 7
                case 4:
                    flagA = true;
                    break;
                case 7:
                    goto case 4;

                // вхождения цифр 3, 6, или 9
                case 3:
                    flagB = true;
                    break;
                case 6:
                    goto case 3;
                case 9:
                    goto case 3;

                default:
                    break;
            }
        }

        // Задание 2. Проверка вещественного числа
        static void Task2()
        {
            /*
             * Задача 2.Выполнить ввод и вывод при помощи методов класса Interaction. Решение
             * задачи должно содержать цикл, повторяющийся трижды. Ввести вещественное число.
             *
             * Если число отрицательное, то возвести его в квадрат, иначе поменять знак числа
             * на противоположный.
             */

            // вещественное число
            double num;

            // количество раз ввода 
            const int N_PUT = 3;

            // ввод и обработка данных
            for (int i = 0; i < N_PUT; i++)
            {
                // ввод числа 
                while (true)
                {
                    // ввод числа 
                    string line = Interaction.InputBox("Введите вещественное число: ", "Ввод данных");

                    // если нажата кнопка "Отмена"
                    if (line.Length == 0)
                        return;

                    // преобразование строки в число
                    if (!double.TryParse(line, out num))
                        Interaction.MsgBox("Данные некорректны!", MsgBoxStyle.Critical, "Ввод данных");
                    else break;
                }

                // обработка числа 

                // копия числа 
                double temp = num;

                // если число отрицательное 
                if (num < 0)
                    // возведение числа в квадрат
                    num *= num;

                else
                    // изменение знака на противоположный 
                    num = -num;

                // вывод результата
                Interaction.MsgBox("Исходное число: " + temp + "\n Результат: " + num, 
                    MsgBoxStyle.OkOnly, "Резултат выполнения");
            }
        }

        // Задание 3. Карты
        static void Task3()
        {
            /*
             * Задача 3. Вывод задачи организовать в консоль, в табличном виде.
             * Игральным картам условно присвоены следующие порядковые номера в зависимости от 
             * их достоинства: «валет» – 11, «дама» -–12, «король» – 13, «туз» – 14. Порядковые 
             * номера остальных карт соответствуют их названиям («шестерка», «семерка», …). 
             * В цикле формировать 10 случайных чисел в диапазоне от 6 до 14, т.е. номер карты. 
             * По этому номеру определить достоинство карты.     
             */

            // отчистка экрана
            Console.Clear();

            ShowNavBarMessage("Задание 3. Карты");

            // объект Random для генерации чисел
            Random rand = new Random();

            // вывод шапки таблицы 
            ShowHead();

            // минимальное значение кода карты
            const int LO_CODE = 6;

            // максимальное значения кода карты 
            const int HI_CODE = 14;

            // количество генерируемых чисел
            const int N_NUM = 10;

            // генерация чисел и вывод фигур в таблицу
            for (int i = 0; i < N_NUM; i++)
            {
                // вывод элемента таблицы 
                ShowElem(i + 1, rand.Next(LO_CODE, HI_CODE + 1));
            }

            // вывод линии-разделителя
            ShowLine();

            // Изменение цвета
            Console.ForegroundColor = ConsoleColor.Cyan;

            // вывод сообщения 
            Console.Write("\n\n\tНажмите любую клавишу...");

            // ожидание нажатия любой клавиши
            Console.ReadKey(true);

            // возвращение исходного цвета
            Console.ResetColor();
        }

        // определение достоинства карты 
        static string CheckCard(int code)
        {
            // строковое достоинство карты 
            string line;

            // опеределение достоинства карты
            switch(code)
            {
                // Шестёрка
                case 6:
                    line = "Шестёрка";
                    break;

                // Семёрка
                case 7:
                    line = "Семёрка";
                    break;

                // Восьмёрка
                case 8:
                    line = "Восьмёрка";
                    break;

                // Девятка
                case 9:
                    line = "Девятка";
                    break;
                    
                // Десятка
                case 10:
                    line = "Десятка";
                    break;

                // Валет
                case 11:
                    line = "Валет";
                    break;

                // Дама
                case 12:
                    line = "Дама";
                    break;

                // Король
                case 13:
                    line = "Король";
                    break;

                // Туз
                case 14:
                    line = "Туз";
                    break;

                default:
                    line = "Ошибка";
                    break;
            }

            return line;
        }

        // вывод шапки таблицы 
        static void ShowHead()
        {
            // позиционироавние курсора
            Console.SetCursorPosition(0, 3);

            // вывод линии-разделителя
            ShowLine();

            // вывод заголовка
            SetColor(ConsoleColor.DarkCyan);    Console.Write("        | ");
            SetColor(ConsoleColor.Green);   Console.Write("N ");
            SetColor(ConsoleColor.DarkCyan);    Console.Write(" | ");
            SetColor(ConsoleColor.Green);   Console.Write("Достоинство ");
            SetColor(ConsoleColor.DarkCyan);    Console.Write(" | ");
            SetColor(ConsoleColor.Green);   Console.Write("Код");
            SetColor(ConsoleColor.DarkCyan);    Console.WriteLine(" |");
            Console.ResetColor();

            // вывод линии-разделителя
            ShowLine();
        }

        // вывод элемента таблицы 
        static void ShowElem(int numElem, int code)
        {
            SetColor(ConsoleColor.DarkCyan);        Console.Write("        | ");
            SetColor(ConsoleColor.DarkGray);        Console.Write($"{numElem,2}");
            SetColor(ConsoleColor.DarkCyan);        Console.Write(" | ");
            SetColor(ConsoleColor.DarkYellow);      Console.Write($"{CheckCard(code), -12}");
            SetColor(ConsoleColor.DarkCyan);            Console.Write(" | ");
            SetColor(ConsoleColor.Magenta);         Console.Write($"{code, 3}");
            SetColor(ConsoleColor.DarkCyan);        Console.WriteLine(" |");
            Console.ResetColor();
        }

        // вывод линии-разделителя
        static void ShowLine()
        {
            SetColor(ConsoleColor.DarkCyan); Console.WriteLine("        +————+——————————————+—————+");
        }

        // установка цвета текста 
        static void SetColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }

        // вывод сообщения в первой строке консоли
        static void ShowNavBarMessage(string msg)
        {
            // установка цвета
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // позиционирование курсора
            Console.SetCursorPosition(0, 0);

            // заполенение первой строки цветом 
            Console.WriteLine($"{' ', 120}");

            // позиционирование курсора
            Console.SetCursorPosition(2, 0);

            // вывод сообщения 
            Console.WriteLine(msg);

            // позиционирование курсора
            Console.SetCursorPosition(0, 1);

            Console.ResetColor();
        }
    }
}
