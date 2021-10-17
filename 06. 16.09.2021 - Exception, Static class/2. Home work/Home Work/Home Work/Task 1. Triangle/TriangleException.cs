using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит 

// Пространство имён Задание 1. Треугольник
namespace Home_Work.Task_1_Triangle
{
    [Serializable]

    // Класс исключений для работы с треугольниками (класс Triangle)

    public class TriangleException : Exception
    {
        // значения всех сторон треугольника, в котором возникло исключение 
        public (double sideA, double sideB, double sideC) Values { get; set; }

        #region Конструкторы 

        public TriangleException() { }
        public TriangleException(string message) : base(message) { }
        public TriangleException(string message, Exception inner) : base(message, inner) { }
        protected TriangleException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        // инициализирующий конструктор 
        public TriangleException(string message, (double sizeA, double sideB, double sideC) valuesTriangle) : base(message)
        {
            // установка значения сторон треугольника 
            Values = valuesTriangle;
        }

        #endregion

        #region Методы 

        // получить данные (стороны треугольника)
        public (double sideA, double sideB, double sideC) GetValues() => Values;

        // вывод сообщения об ошибке в консоль 
        public void ShowException()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n");
            App.WriteColor("          ╔════════════════════════════════╗\n",    ConsoleColor.Red);
            App.WriteColor("          ║             ОШИБКА             ║\n",    ConsoleColor.Red);
            App.WriteColor("          ╠════════════════════════════════╣\n",    ConsoleColor.Red);

            App.WriteColor("          ║                                ║",      ConsoleColor.Red);
            App.WriteColorXY($"{Message, -30}",         12,    textColor:ConsoleColor.DarkYellow);
            App.WriteColor("\n          ╠═══════════╦════════════════════╣\n",  ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║",      ConsoleColor.Red);
            App.WriteColorXY($"Сторона A", 12,                 textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Values.sideA,18}",      24,        textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╠═══════════╬════════════════════╣\n",  ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║",      ConsoleColor.Red);
            App.WriteColorXY($"Сторона B", 12,                textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Values.sideB,18}",      24,        textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╠═══════════╬════════════════════╣\n",  ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║",      ConsoleColor.Red);
            App.WriteColorXY($"Сторона C", 12,                textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Values.sideC,18}",      24,        textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╚═══════════╩════════════════════╝\n",  ConsoleColor.Red);
        }

        #endregion
    }
}
