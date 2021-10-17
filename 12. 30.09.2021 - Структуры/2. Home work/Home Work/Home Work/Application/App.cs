using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using static Home_Work.Application.App.Utils;       // для использования утилит

/*
         * Задача 1. Создать иерархию классов и интерфейс для решения линейных и 
         * квадратных уравнений. Линейное уравнение имеет вид: ax + b = 0, 
         * квадратное уравнение имеет вид ax2 + bx + c = 0
         * 
         * Базовый абстрактный класс Root, класс для линейных уравнений Linear, 
         * класс для квадратных уравнений Square. Интерфейс ISolver должен 
         * содержать методы void Solve() для решения уравнения, void  Show()   
         * для   вывода решения в консоль, bool HasSolve() для определения 
         * наличия решения уравнения. 
         * 
         * Создать массив из 20 уравнений, типы и коэффициенты уравнений выбирать
         * случайно. Решить уравнения в массиве, вывести уравнения и решения (или
         * сообщение об отсутствии решения).
         * 
         * Вычислить и вывести следующую статистику:
         *  •	общее количество уравнений
         *      —	сколько из них квадратных
         *      —	сколько из них линейных
         *  •	общее количество решений
         *      —	сколько из них для квадратных уравнений
         *      —	сколько из них для линейных уравнений
         *      
         *             
         * Задача 2. Описать структуру Student, содержащую поля:
         *   •	фамилия и инициалы;
         *   •	название группы;
         *   •	успеваемость (массив из пяти элементов типа Mark – вложенная
         *       структура: название предмета, оценка (short)) 
         *   •	индексатор для массива оценок Mark – вложенная структура: 
         *       название предмета, оценка (short)
         *       
         *   Написать программу, выполняющую обработку массива структур Student:
         *   •	заполнение данными (сгенерированными) массива из десяти структур
         *       типа Student
         *   •	вывод на экран фамилий и названия групп для всех студентов, 
         *       имеющих хотя бы одну оценку 2 (если таких студентов нет, вывести
         *       соответствующее сообщение)
         *   •	вывод на экран фамилий и названий групп для всех студентов,
         *       имеющих оценки только 4 и 5 (если таких студентов нет, вывести
         *       соответствующее сообщение)
         *   •	упорядочивание массива по возрастанию среднего балла
         *   •	упорядочивание массива по фамилиям и инициалам
         *   •	перемешивание массива студентов
*/

namespace Home_Work.Application
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
        pointSix,
        pointSeven
    }

    public partial class App
    {

        #region Меню заданий 

        // номер задания 
        int numberTask = 0;

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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Уравнение");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Студент");
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

    }
}
