using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Home_Work.Models;     // для подключения классов первого и второго заданий

/*
 * Задача 1. Решение задачи разместите в классе, класс расположите во вложенном пространстве имен 
 * Models Вашего проекта. Выполнить обработку строк – используйте класс string:
 *      •	Даны строки S и S0. Удалить из строки S все подстроки, совпадающие с S0. Если совпадающих
 *          подстрок нет, то вывести строку S без изменений.
 *      •	Даны строки S, S1 и S2. Заменить в строке S все вхождения строки S1 на строку S2
 *      •	Дана строка, состоящая из слов, разделенных пробелами (одним или несколькими). Вывести 
 *          строку, содержащую эти же слова, разделенные одним символом «.» (точка). В конце строки точку
 *          не ставить.
 *      •	Дана строка, состоящая из слов, разделенных пробелами (одним или несколькими). Вывести 
 *          строку, содержащую эти же слова, разделенные одним пробелом и расположенные в обратном порядке.
 *      •	Дана строка, состоящая из слов, набранных заглавными буквами и разделенных пробелами (одним
 *          или несколькими). Вывести строку, содержащую эти же слова, разделенные одним пробелом и 
 *          расположенные в алфавитном порядке строчным буквами.
 *      
 * Задача 2. Дана строка S (класс string). В строке слова разделяются одним или несколькими 
 * пробелами, в результирующей строке слова должны разделяться одним пробелом:
 *      •	В строке поменять местами каждые два соседних слова.
 *      •	Из строки удалить все слова, начинающиеся и заканчивающиеся гласными буквами
 *      •	Поменять местами первое слово максимальной длины и первое слово минимальной длины в строке
 *      •	В каждом слове строки установить верхний регистр первой буквы
*/

namespace Application
{
    // константы для меню
    internal enum Cmd
    {
        pointExit,
        pointOne,
        pointTwo,
        pointThree,
        pointFour,
        pointFive,
        pointSix
    }

    public partial class App
    {
        // объект первого задания 
        Task1 _task1 = new Task1();

        // объект второго задания 
        Task2 _task2 = new Task2();
         
        #region Меню заданий 

        // меню заданий
        public void Menu()
        {
            // вывод меню
            while (true)
            {
                // отчистка консоли
                Console.Clear();

                // цвет 
                Console.ForegroundColor = ConsoleColor.Cyan;

                int x = 5, y = Console.CursorTop + 3;

                // заголовок
                Console.SetCursorPosition(x + 3, y); WriteColor($"{"    Главное меню"}", ConsoleColor.Blue);

                y += 2;

                // пукты меню
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Мианипуляция со строками");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Мианипуляция со строками");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case (int)Cmd.pointExit:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // Задание 1. Название задания
                    case (int)Cmd.pointOne:
                        // запуск задания 
                        Task1();
                        break;

                    // Задание 2. Название задания
                    case (int)Cmd.pointTwo:
                        // запуск задания 
                        Task2();
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
            }
        } // Menu

        #endregion

        #region Общие методы 

        // вывод cтроки 
        public void ShowLine(string line, string name, string info)
        {
            WriteColor($"     ╔════════════╦═════════════════════════════════════════════════════════════════════╗\n", ConsoleColor.Magenta);        
            WriteColor($"     ║            ║                                                                     ║", ConsoleColor.Magenta);
            WriteColorXY("Размер: ", posX: 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{line.Length,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", posX: 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-57}", textColor: ConsoleColor.Green);
            WriteColor($"\n     ╠════════════╩═════════════════════════════════════════════════════════════════════╣\n", ConsoleColor.Magenta);        
            WriteColor($"     ║                                                                                  ║", ConsoleColor.Magenta);
            WriteColorXY("Инфо: ", posX: 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-74}", textColor: ConsoleColor.Green);
            WriteColor($"\n     ╠══════════════════════════════════════════════════════════════════════════════════╣\n", ConsoleColor.Magenta);        
            WriteColor($"     ║                                                                                  ║", ConsoleColor.Magenta);
            WriteColorXY($"{line,-80}", posX: 7, textColor: ConsoleColor.Green);
            WriteColor($"\n     ╚══════════════════════════════════════════════════════════════════════════════════╝\n", ConsoleColor.Magenta);
        }

        // вывод cтроки 
        public void ShowLine(string line, string name)
        {
            WriteColor($"     ╔════════════╦═════════════════════════════════════════════════════════════════════╗\n", ConsoleColor.Magenta);
            WriteColor($"     ║            ║                                                                     ║", ConsoleColor.Magenta);
            WriteColorXY("Размер: ", posX: 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{line.Length,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", posX: 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-57}", textColor: ConsoleColor.Green);
            WriteColor($"\n     ╠════════════╩═════════════════════════════════════════════════════════════════════╣\n", ConsoleColor.Magenta);            
            WriteColor($"     ║                                                                                  ║", ConsoleColor.Magenta);
            WriteColorXY($"{line,-80}", posX: 7, textColor: ConsoleColor.Green);
            WriteColor($"\n     ╚══════════════════════════════════════════════════════════════════════════════════╝\n", ConsoleColor.Magenta);
        }


        #endregion

        #region Утилиты

        // объект Random для заполнения массивов
        public static Random rand = new Random();

        // получение случайного вещественного числа в диапазоне (min, max]
        public static double GetDouble(int min, int max) => rand.Next(min, max) + rand.NextDouble();

        // вывод сообщения в цвете 
        public static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            // текущий цвет 
            ConsoleColor tempText = Console.ForegroundColor;
            ConsoleColor tempBack = Console.BackgroundColor;

            // установк цвета
            SetColor(textColor, backColor);

            // вывод сообщения 
            Console.Write(msg);

            // возвращение цвета 
            SetColor(tempText, tempBack);
        }

        // вывод сообщения в цвете и позиционированием 
        public static void WriteColorXY(string msg = "", int posX = -1, int posY = -1, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            // позиционирование курсора
            PosXY(posX == -1 ? Console.CursorLeft : posX, posY == -1 ? Console.CursorTop : posY);

            // вывод сообщения в цвете
            WriteColor(msg, textColor, backColor);
        }

        // вывод сообщения о неправильно введённых данных, с указанием позиции
        public static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
        {
            // вывод сообщения 
            WriteColorXY(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

            // задержка по времени
            Thread.Sleep(500);
        }

        // позиционирование курсора
        public static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

        // установка цвета текста 
        public static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

        // установка цвета текста и фона 
        public static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
        } // SetColor

        // вывод сообщения в первой строке консоли
        public static void ShowNavBarMessage(string msg)
        {
            // установка цвета
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // позиционирование курсора
            Console.SetCursorPosition(0, 0);

            // заполенение первой строки цветом 
            Console.WriteLine($"{' ',120}");

            // позиционирование курсора
            Console.SetCursorPosition(2, 0);

            // вывод сообщения 
            Console.WriteLine(msg);

            // позиционирование курсора
            Console.SetCursorPosition(0, 3);

            Console.ResetColor();
        } // ShowNavBarMessage

        #endregion
    }
}
