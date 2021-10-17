using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.VisualBasic;   // для работы с классом Interaction

/*
 * Демонстрация методов и свойств класса Math
 */
namespace MathDemo
{
    class Program
    {
        #region Главная программа

        static void Main(string[] args)
        {
            Console.Title = "Заняте 09.09.2021 - демонстрация методов и свойств класса Math";

            string menu = "1. Вариант 7 - сложное выражение\n" +
                          "2. Вариант 15 - сложное выражение\n" +
                          "------------------------------------------------\n" +
                          "0. Выход\n";

            while (true) {
                // вывод меню и получение команды из меню
                string response = Interaction.InputBox(menu, "Меню приложения");

                switch (response) {
                    case "":
                    case "0":
                        Interaction.MsgBox(
                            "Приложение завершено",
                            MsgBoxStyle.OkOnly | MsgBoxStyle.Information,
                            "До свидания");
                        Console.WriteLine();
                        return;
                    case "1":
                        DoVariant7();
                        break;
                    case "2":
                        DoVariant15();
                        break;
                    case "eastern":
                        Interaction.MsgBox(
                            "Скрытая возможность приложения",
                            MsgBoxStyle.Exclamation | MsgBoxStyle.OkOnly,
                            "Пасхалка");
                        break;

                    default:
                        Interaction.MsgBox(
                            $"Нет такой команды ({response}) в меню приложения",
                            MsgBoxStyle.Critical | MsgBoxStyle.OkOnly,
                            "Ошибка");
                        break;
                } // switch
            } // while
        } // Main

        #endregion


        #region Задача Вариант 7
        
        // Вычисления по задаче Вариант 7
        private static void DoVariant7() {
            string prompt, title;
            MsgBoxStyle msgBoxStyle;

            string response = Interaction.InputBox("Аргумент для вычислений:", "Вариант 7");

            // выходной параметр - переменная объявляется в момент вызова
            bool convertResult = double.TryParse(response, out double a);
            if (convertResult) {

                // вычисления по варианту
                double z1 = Math.Pow(Math.Cos(3d * Math.PI / 8d - a / 4d), 2) -
                            Math.Pow(Math.Cos(11d * Math.PI / 8d + a / 4d), 2);
                double z2 = Math.Sqrt(2d) * Math.Sin(a / 2d) / 2d;

                // формирование параметров для окна сообщения 
                title = "Вариант 7 - результат";
                prompt = $"\nВычисления выполнены:\nz1 = {z1:n10}\nz2 = {z2:n10}\n";
                msgBoxStyle = MsgBoxStyle.Information | MsgBoxStyle.OkOnly;
            } else {
                // формирование параметров для окна сообщения 
                title = "Вариант 7 - ошибка";
                prompt = "Введено не число";
                msgBoxStyle = MsgBoxStyle.Critical | MsgBoxStyle.OkOnly;
            } // if

            // вывод результата
            Interaction.MsgBox(prompt, msgBoxStyle, title);
        } // DoVariant7

        #endregion


        #region Задача Вариант 15

        // Вычисления по задаче Вариант 15
        private static void DoVariant15() {
            string prompt, title;
            MsgBoxStyle msgBoxStyle;

            string response = Interaction.InputBox("Аргумент для вычислений:", "Вариант 15");
            bool convertResult = double.TryParse(response, out double b);
            if (convertResult) {
                // вычисления по варианту
                double z1 = Math.Sqrt(2d * b + 2d * Math.Sqrt(b * b - 4d)) /
                     (Math.Sqrt(b * b - 4d) + b + 2d);
                double z2 = 1d / Math.Sqrt(b + 2d);

                // формирование параметров для окна сообщения 
                title = "Вариант 15 - результат";
                prompt = $"Вычисления выполнены:\nz1 = {z1:n10}\nz2 = {z2:n10}\n";
                msgBoxStyle = MsgBoxStyle.Information | MsgBoxStyle.OkOnly;
            } else {
                // формирование параметров для окна сообщения 
                title = "Вариант 15 - ошибка";
                prompt = "Введено не число";
                msgBoxStyle = MsgBoxStyle.Critical | MsgBoxStyle.OkOnly;
            } // if

            // вывод результата
            Interaction.MsgBox(prompt, msgBoxStyle, title);
        } // DoVariant15

        #endregion
    } // class Program
}
