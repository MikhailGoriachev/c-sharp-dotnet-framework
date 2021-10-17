using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application;      // для использования утилит 

// Пространство имен Задание 2. Комната
namespace Home_Work.Task_2_Room
{

    [Serializable]
    // Класс исключений для работы с комнатами (класс Room)
    public class RoomException : Exception
    {
        // значение комнаты 
        public (double area, double height, int window) Value { get; set; }

        #region Конструкторы

        public RoomException() { }
        public RoomException(string message) : base(message) { }
        public RoomException(string message, Exception inner) : base(message, inner) { }
        protected RoomException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }

        // конструктор инициализирующий 
        public RoomException(string message, (double area, double height, int window) value) : base(message) => Value = value;

        #endregion

        #region Методы 

        // получить значение 
        public (double area, double height, int window) GetValue() => Value;

        // вывод сообщения об ошибке в консоль 
        public void ShowException()
        {
            Console.Clear();

            Console.WriteLine("\n\n\n");
            App.WriteColor("          ╔════════════════════════════════╗\n", ConsoleColor.Red);
            App.WriteColor("          ║             ОШИБКА             ║\n", ConsoleColor.Red);
            App.WriteColor("          ╠════════════════════════════════╣\n", ConsoleColor.Red);

            App.WriteColor("          ║                                ║", ConsoleColor.Red);
            App.WriteColorXY($"{Message,-30}", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColor("\n          ╠═══════════╦════════════════════╣\n", ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║", ConsoleColor.Red);
            App.WriteColorXY($" Площадь ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Value.area,18}", 24, textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╠═══════════╬════════════════════╣\n", ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║", ConsoleColor.Red);
            App.WriteColorXY($" Высота  ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Value.height,18}", 24, textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╠═══════════╬════════════════════╣\n", ConsoleColor.Red);

            App.WriteColor("          ║           ║                    ║", ConsoleColor.Red);
            App.WriteColorXY($"  Окна   ", 12, textColor: ConsoleColor.DarkYellow);
            App.WriteColorXY($"{Value.window,18}", 24, textColor: ConsoleColor.Green);
            App.WriteColor("\n          ╚═══════════╩════════════════════╝\n", ConsoleColor.Red);
        }

        #endregion
    }
}
