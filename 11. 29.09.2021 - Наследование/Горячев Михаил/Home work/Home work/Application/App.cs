using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Home_work.Application.App.Utils;       // для использования утилит

/*
 * Задача 1. Создать абстрактный класс Vehicle (транспортное средство). На его 
 * основе реализовать классы Plane (самолет), Саг (автомобиль) и Ship (корабль).
 * Классы должны иметь возможность задавать и получать параметры средств 
 * передвижения (географические координаты, цена, скорость, год выпуска) с 
 * помощью свойств.
 * 
 * Дополнительно для самолета должна быть определена высота, для самолета и 
 * корабля — количество пассажиров, для корабля — порт приписки. 
 * 
 * Создайте массив транспортных средств, состоящий из 2х самолетов, 3х 
 * кораблей и 5и автомобилей. В массиве найти:
 * •	самое старое транспортное средство
 * •	самое быстрое и самое медленное транспортные средства (может быть 
 *      найдено больше 1 транспортного средства) 
 *      
 * Задача 2. Создать иерархию интерфейсов и классов по следующему заданию:
 * •	Интерфейс ПлоскаяФигура с методами для вычисления площади и периметра   
 * •	Интерфейс ОбъемнаяФигура с методами для вычисления площади поверхности
 *      и объема
 * •	Класс Фигура – базовый класс иерархии.
 * •	Треугольник, наследует от Фигура, реализует интерфейс ПлоскаяФигура
 * •	Прямоугольник, наследует от Фигура, реализует интерфейс ПлоскаяФигура
 * •	Цилиндр, наследует от Фигура, реализует интерфейс ОбъемнаяФигура
 * •	Конус, наследует от Фигура, реализует интерфейс ОбъемнаяФигура
 * •	Разместить классы и интерфейсы в отдельных файлах 
 * 
 * Реализовать по два объекта каждого типа в массиве объектов класса Фигура. 
 * 
 * Для массива выполнить:
 * •	Упорядочить массив по убыванию площади
 * •	Выбрать объекты с минимальной и максимальной площадью
*/

namespace Home_work.Application
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
        pointSix
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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Транспортное средство");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Фигура");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out numberTask))
                    continue;

                // обработка ввода 
                switch (numberTask)
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
