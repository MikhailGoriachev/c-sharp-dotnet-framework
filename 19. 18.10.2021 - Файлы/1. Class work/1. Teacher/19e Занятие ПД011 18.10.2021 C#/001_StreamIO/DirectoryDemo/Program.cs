using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Занятие 14.10.2021 - введение в классы для работы с папками/каталогами";
            try {
                
                // Создать объект с данными о заданной папке/заданном каталоге
                DirectoryInfo di = new DirectoryInfo(@"d:\Data\PD011");
                
                // Создание папки
                di.Create();
                Console.WriteLine("Папка создана, нажмите клавишу...");
                Console.ReadKey();

                // Переименование - если полный путь к папке не изменился
                // Перемещение - если полный путь к папке изменился
                di.MoveTo(@"d:\Data\Программисты ПД");   // переименование, т.к. в той же папке
                // di.MoveTo(@"Программисты ПД"); // перемещение в текущую папку (bin/debug)
                Console.WriteLine("Папка переименована, нажмите клавишу...");
                Console.ReadKey();

                // Удаление пустой папки
                di.Delete();
                Console.WriteLine("Папка удалена, нажмите клавишу...");
                Console.ReadKey();
                
                
                // Работа со статическими методами
                // Создание папки
                Console.WriteLine("\nСтатические методы класса Directory:");
                Directory.CreateDirectory(@"d:\Data\PD011");
                Console.WriteLine("Папка создана, нажмите клавишу...");
                Console.ReadKey();

                // Перемещение/переименование папки
                Directory.Move(@"d:\Data\PD011", @"d:\Data\Программисты ПД011");
                Console.WriteLine("Папка переименована, нажмите клавишу...");
                Console.ReadKey();

                // Удаление пустой папки
                Directory.Delete(@"d:\Data\Программисты ПД011");
                Console.WriteLine("Папка удалена, нажмите клавишу...");
                Console.ReadKey();
                

                
                Console.Clear();
                Console.WriteLine("\nСписок подкаталогов/подпапок и файлов в каталоге d:\\Data");
                
                string[] directories = Directory.GetDirectories(@"d:\Data\");
                string[] files = Directory.GetFiles(@"d:\Data\");

                int i = 1;
                foreach (var dir in directories) {
                    Console.Write($"[{dir}]".PadRight(40));
                    if (i++ % 3 == 0) Console.WriteLine();
                } // foreach

                Console.WriteLine();

                i = 1;
                foreach (var file in files) {
                    Console.Write($"{file}".PadRight(40));
                    if (i++ % 3 == 0) Console.WriteLine();
                } // foreach
                Console.WriteLine($"Всего файлов {files.Length}. Нажмите клавишу...");
                Console.ReadKey();
                
                Console.Clear();
                
                
                // Переходы по каталогам

                Console.WriteLine();
                Console.WriteLine(Environment.CurrentDirectory);
                
                // переход на уровень вверх - в родительский каталог
                // фактически - в родительский каталог для текущего (метасимвол ".")
                Environment.CurrentDirectory = Directory.GetParent(".").FullName;
                Console.WriteLine(Environment.CurrentDirectory);
                
                // Лучше переход на уровень вверх выполнять так:
                Environment.CurrentDirectory = ".."; // команда перехода на уровень вверх (метасимвол ..)
                Console.WriteLine(Environment.CurrentDirectory);

                Environment.CurrentDirectory = @"\"; // команда перехода на корневой каталог (метасимвол \)
                Console.WriteLine(Environment.CurrentDirectory);
                
            } catch (Exception ex) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            } // catch

        } // Main
    } // class Program
}
