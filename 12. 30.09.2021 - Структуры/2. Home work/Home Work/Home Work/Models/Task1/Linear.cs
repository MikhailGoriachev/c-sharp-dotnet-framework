using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work.Interface;  // подключение интерфейса 

using static Home_Work.Application.App.Utils;   // для использования утилит

namespace Home_Work.Models.Task1
{
    // Класс Линейное уравнение
    internal class Linear : Root, ISolver
    {
        #region Свойства

        // название уравнения
        public static string Name => "Линейное";

        #endregion

        #region Методы 

        // решение уравнения    Источник: https://skysmart.ru/articles/mathematic/reshenie-prostyh-linejnyh-uravnenij
        public void Solve()
        {
            // если a и b == 0      НЕТ РЕШЕНИЯ 
            if (_a == _b && _a == 0) _x = Double.PositiveInfinity;                

            // если a != 0          ЕСТЬ РЕШЕНИЕ
            else if (_a != 0) _x = (double)-_b / _a;

            // если a == 0          ЛЮБОЕ ЗНАЧЕНИЕ
            else _x = null;
        }

        // определение наличия решения
        //public bool HasSolver() => _x != null && (_x == Double.PositiveInfinity || Math.Abs((double)(_a * _x + _b)) - 0d >= 1e-10);

        public bool HasSolver() => _x != null;

        // получение типа уравнения
        public string GetName() => Name;

        // вывод уравнения
        public void Show(int num)
        {
            WriteColorXY("     ║    ║                 ║       ║       ║       ║                      ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY($"{num,2}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{Name,-15}", 12, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{_a,5:n2}", 30, textColor: ConsoleColor.Green);
            WriteColorXY($"{_b,5:n2}", 38, textColor: ConsoleColor.Green);
            WriteColorXY($"─────", 46, textColor: ConsoleColor.DarkRed);
            WriteColorXY($"     ax + b = 0     ", 54, textColor: ConsoleColor.Green);
            ShowResult();
            Console.WriteLine();
            WriteColorXY("     ╠════╬═════════════════╬═══════╬═══════╬═══════╬══════════════════════╬════════════════════════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод результата
        public void ShowResult()
        {
            // если нет решения
            if (!HasSolver())
                WriteColorXY($"         Нет решения          ", 77, textColor: ConsoleColor.DarkRed);

            // найден x
            else if (_x != null && _x != Double.PositiveInfinity)
                WriteColorXY($"x = {_x,5:n2}", 77, textColor: ConsoleColor.Green);

            // если найден x, который может быть любым знаачением 
            else WriteColorXY($"x = любое значение", 77, textColor: ConsoleColor.Green);
        }

        #endregion
        }
    }
