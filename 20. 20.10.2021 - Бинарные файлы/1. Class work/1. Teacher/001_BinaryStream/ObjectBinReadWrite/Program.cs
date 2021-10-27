
// Описать класс Route для описания велосипедного туристического маршрута,
// содержащий следующие свойства:
//     o название начального пункта маршрута;
//     o название конечного пункта маршрута;
//     o протяженность маршрута, в км;
//     o фамилия и инициалы старшего по маршруту;
//     При помощи меню реализовать следующий функционал:
//         • создание коллекции записей, запись коллекции в бинарный файл
//         • вывод бинарного файла в консоль
//         • сортировка бинарного файла по названиям начального пункта 
//           маршрута методом быстрой сортировки
//         • загрузка файла в коллекцию List<> и вывод этой коллекции
//           в консоль. 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static ObjectBinReadWrite.Utils;

namespace ObjectBinReadWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Занятие 20.10.2021 - чтение объектов из бинарного потока, запись объектов в бинарный поток";
            Console.SetWindowSize(115, 30);

            SetColor(ConsoleColor.White, ConsoleColor.DarkGray);

            string[] menuItems = {
                "\n\n\t   [Меню приложения]",
                "\t────────────────────────────────────────────────────────────────",
                "\t1. Создание и запись коллекции в файл",
                "\t2. Вывод записей из файла в консоль",
                "\t3. Загрузка записей из файла в коллекцию",
                "\t4. Сортировка записей в файле по начальному пункту маршрута",
                "\t────────────────────────────────────────────────────────────────",
                "\t0. Выход, завершение приложения\n"
            };

            App app = new App();

            // главный цикл приложения
            while(true) {
                Console.Clear();

                // вывод меню
                Array.ForEach(menuItems, Console.WriteLine);
                Console.Write("\t>  ");
                ConsoleKeyInfo keyPressed =  Console.ReadKey();
                Console.Clear();

                switch(keyPressed.Key) {

                    // Создание и запись коллекции в файл
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        app.Initialize();
                        app.WriteToBin();
                        app.Show();
                        break;

                    // вывод записей из файла в консоль
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        app.Show();
                        break;  

                    // загрузка записей из файла в коллекцию
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        app.ReadFromBin();
                        app.ShowList($"\n\tМаршруты \"{app.Name}\" загружены из файла {app.FileName}:\n");
                        break;
                    
                    // cортировка записей в файле по начальному пункту
                    case ConsoleKey.D4:
                    case ConsoleKey.NumPad4:
                        app.SortByStartPoint();
                        app.Show($"\n\tМаршруты упорядочены по пункту начала \"{app.Name}\":\n\n");
                        break;

                    // выход из приложения
                    case ConsoleKey.D0:
                    case ConsoleKey.NumPad0:
                    case ConsoleKey.Escape:
                        SetColor(ConsoleColor.White, ConsoleColor.DarkGreen);

                        WritePos(8, 3, "┌──[ Информация ]──────────────────┐");
                        WritePos(8, 4, "│                                  │");
                        WritePos(8, 5, "│    Работа приложения завершена   │");
                        WritePos(8, 6, "│                                  │");
                        WritePos(8, 7, "│       Нажмите любую клавишу      │");
                        WritePos(8, 8, "│                                  │");
                        WritePos(8, 9, "└──────────────────────────────────┘");
                        RestoreColor();
                        Console.Write("\n\n\n\n\n\t");
                        return;

                    default:
                        SetColor(ConsoleColor.White, ConsoleColor.DarkRed);

                        WritePos(8, 3, "┌────[ Ошибка ]────────────────────┐");
                        WritePos(8, 4, "│                                  │");
                        WritePos(8, 5, "│      Нет такой команды меню      │");
                        WritePos(8, 6, "│                                  │");
                        WritePos(8, 7, "│       Нажмите любую клавишу      │");
                        WritePos(8, 8, "│                                  │");
                        WritePos(8, 9, "└──────────────────────────────────┘");

                        RestoreColor();
                        Console.WriteLine("\n\n\n\n\n");
                        break;
                } // switch

                Console.Write("\tНажмите любую клавишу для продолжения. . .");
                Console.ReadKey();
            } // while
        } // Main
    } // class Program
}
