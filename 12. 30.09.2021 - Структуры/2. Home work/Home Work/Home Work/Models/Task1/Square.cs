using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work.Interface;  // интерфейс

using static Home_Work.Application.App.Utils;   // для использования утилит

namespace Home_Work.Models.Task1
{
    // Класс Квадратное уравнение
    internal class Square : Root, ISolver
    {
        // название уравнения
        public static string Name => "Квадратное";

        // число c
        private int _c;

        // число x2
        private double? _x2;

        #region Свойства

        // доступ к полю _c
        public int C { get => _c; set => _c = value; }

        // доступ к полю _x2
        public double? X2 { get => _x2; }

        #endregion

        // решение уравнения    Источник: https://skysmart.ru/articles/mathematic/kak-reshat-kvadratnye-uravneniya
        public void Solve()
        {
            // если a == 0
            if (_a == 0) { _x = null; _x2 = null; }

            // значение дискриминанта
            double D = (_b * _b) - 4d * _a * _c;

            // если дискриминант отрицательный - действительных корней нет
            if (D < 0d) { _x = null; _x2 = null; }

            // если дискриминант равен нулю, то корень единственный 
            if (D == 0d) { _x = -_b / 2d * _a; _x2 = null; }

            // если дискриминант положительный, то корня два
            if (D > 0d) 
            { 
                // x1
                _x = (-_b + Math.Sqrt(D)) / (2d * _a); 

                // x2
                _x2 = (-_b - Math.Sqrt(D)) / (2d * _a); 
            }

            // // решение неполных квадратных уравнений
            // 
            // // если b и c == 0     
            // if (_b == _c && _b == 0) _x = 0;
            // 
            // // если b == 0          
            // else if (_b == 0)
            // {
            //     // не имеет корней
            //     if (_c / _a < 0) { _x = null; _x2 = null; }
            // 
            //     // имеет два корня
            //     else { _x = Math.Sqrt(-_c / _a); _x2 = -_x; }
            // }
            // 
            // // если c == 0          ЛЮБОЕ ЗНАЧЕНИЕ
            // else if (_c == 0) { _x = 0; _x2 = -_b / _a; }
        }

        // определение наличия решения
        public bool HasSolver() => (_x != null && _a * (_x * _x) + _b * _x + _c == 0) &&
            (_x2 == null || (_x2 != null && _a * (_x2 * _x2) + _b * _x2 + _c == 0));

        // получение типа уравнения
        public string GetName() => Name;

        // вывод уравнения
        public void Show(int num)
        {
            WriteColorXY("     ║    ║                 ║       ║       ║       ║                      ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num, 2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{Name, -15}", 12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_a, 5:n2}", 30, textColor: ConsoleColor.Green);
            WriteColorXY($"{_b, 5:n2}", 38, textColor: ConsoleColor.Green);
            WriteColorXY($"{_c, 5:n2}", 46, textColor: ConsoleColor.Green);
            WriteColorXY($"  ax2 + bx + c = 0  ", 54, textColor: ConsoleColor.Green);
            ShowResult();
            Console.WriteLine();
            WriteColorXY("     ╠════╬═════════════════╬═══════╬═══════╬═══════╬══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод результата
        public void ShowResult()
        {
            // если нет решенияs
            if (!HasSolver())
                WriteColorXY($"         Нет решения          ", 77, textColor: ConsoleColor.DarkRed);

            // найден один x
            else if (_x != null && _x2 == null)
                WriteColorXY($"x = {_x,5:n5}", 77, textColor: ConsoleColor.Green);

            // если найдено два x
            else WriteColorXY($"x1 = {_x,5:n5}, x2 = {_x2,5:n5}", 77, textColor: ConsoleColor.Green);
        }
    }
}
