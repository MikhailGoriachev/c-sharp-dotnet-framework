using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsDotNet
{
    class Utils
    {
        /// <summary> Инициализация при старте приложения </summary>
        /// <param name="title"> Заголовок окна </param>
        /// <param name="windowWidth"> Ширина окна </param>
        /// <param name="windowHeight"> Высота окна </param>
        public static void Init(string title, int windowWidth = 80, int windowHeight = 25)
        {
            // Кодировка
            Console.OutputEncoding = Encoding.Unicode;
            // Размер окна
            Console.SetWindowSize(windowWidth, windowHeight);
            // Тайтл
            Console.Title = title;
            // Цвета
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            // Очистить (применить)
            Console.Clear();
        } // Init

        // Вспомогательная переменная
        private static Random random = new Random();

        /// <summary> Возвращает случайное целое число от min до max </summary>
        /// <param name="min">От</param>
        /// <param name="max">До</param>
        /// <returns>Случайное число типа int</returns>
        public static int Random(int min = -10, int max = 10) => random.Next(min, max + 1);
    } // class Utils
}
