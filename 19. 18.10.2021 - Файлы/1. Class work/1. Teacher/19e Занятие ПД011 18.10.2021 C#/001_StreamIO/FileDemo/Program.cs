using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args) {
            Console.Title = "Занятие 14.10.2021 - введение в работу с файлами";

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.Clear();
            
            // Получить список файлов из каталога d:\Data, вывести имена файлов
			// и их размер в байтах
            string[] files = Directory.GetFiles(@"d:\Data");
            Console.WriteLine($"{"Имя файла", -30} {"Длина, байт", 12}");
            
            for (int i = 0; i < files.Length; i++) {
                // класс FileInfo - данные по файлам
                FileInfo fi = new FileInfo(files[i]);
                Console.WriteLine($"{fi.Name, -30} {fi.Length, 12:n0}");
				
				// Постраничный вывод данных о найденных файлах
				// Ожидаем нажатия на любую клавишу после вывода Console.WindowHeight - 2
				// строк на экран. 2 строки - для вывода сообщения
                if ((i + 1) % (Console.WindowHeight - 2) == 0) {
                    Console.Write("Нажмите Enter");
                    Console.ReadKey();
                    Console.Clear();
                    Console.WriteLine($"{"Имя файла", -30} {"Длина, байт",12}");
                } // if 
            } // foreach

            Console.WriteLine("\n\n");
            Console.ForegroundColor = ConsoleColor.Black;

            // восстановление цвета консоли
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n");
        } // Main

    } // class Program
}
