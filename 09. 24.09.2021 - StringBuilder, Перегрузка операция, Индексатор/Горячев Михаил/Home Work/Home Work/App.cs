using System;
using System.Threading;

// using Home_Work.Task_1_NameTask;     // для подключения классов первого задания
// using Home_Work.Task_2_NameTask;     // для подключения классов второго задания

/*
 * Задача 1. Разработайте класс для хранения одномерного массива из п элементов, 
 * типа int, имя класса IntArray.  В классе реализовать:
 * •	Индексатор с контролем выхода за допустимые пределы (при выходе выбрасывать
 *      исключение)
 * •	Контейнер данных – собственно массив с уровнем доступа private
 * •	свойство Length - размер массива
 * •	метод заполнения случайными числами
 * •	метод вывода в строку
 * В классе Task1 с использованием класса одномерного массива и индексатора реализовать
 * обработки:
 * •	произведение элементов массива с четными номерами, вывести массив с выделением 
 *      цветом элементов с четными номерами 
 * •	сумму элементов массива, расположенных между первым и последним нулевыми 
 *      элементами, вывести диапазон суммирования с выделением цветом: границ и слагаемых
 * •	отрицательным элементам массива поменять знак, сортировать массив по убыванию. 
 *      Метод сортировки – сортировка вставками
 *
 * Задача 2. Разработайте класс Toy для представления игрушки со свойствами – название
 * игрушки (string), возрастная категория (int), стоимость игрушки (int). 
 * Перегрузите операции для класса Toy:
 * •	+: сложения игрушки с целым числом – операция выполняет сложение цены и числа
 * •	–: вычитания целого числа из игрушки – операция выполняет вычитание целого 
 *      числа из цены игрушки
 * •	< и >: сравнение цен двух игрушек
 * •	true: если возрастная категория больше 5
 * •	false: если возрастная категория меньше или равна 5 
 * Продемонстрируйте работу перегруженных операций.
 *
 * Задача 3. Описать класс «товар», содержащий следующие закрытые поля:
 * •	название товара;
 * •	количество товара (в условных единицах);
 * •	стоимость товара в рублях.
 * Предусмотреть свойства для задания и получения состояния объекта.
 * Реализовать перегруженные операции:
 * •	+: сложения товаров с одинаковыми наименованиями, выполняющую сложение их 
 *      стоимостей, т.е. цен, умноженных на количество
 * •	+: сложения товара и целого числа, выполняющего сложение цены и целого числа
 * •	–: вычитание товара и целого числа, выполняющего вычитание целого числа из цены
 * •	сравнение товаров по цене: < >, <= >=, == !=
 * •	операция true: стоимость товара в интервале 1, …, 1000
 * •	операция false: стоимость товара равна 0 или больше 1000
 * Создайте класс Shop (магазин), в котором хранить название магазина, закрытый массив 
 * товаров. Реализуйте в этом классе методы заполнения массива товаров данными, вывод 
 * товаров в консоль, суммирование цен товаров. Разработайте индексатор с контролем 
 * выхода за пределы массива.
 * При помощи индексатора, в классе решения Task3 реализуйте поиск товаров с минимальной
 * ценой, максимальной ценой, сортировку товара по убыванию количества (метод быстрой 
 * сортировки). 
*/

namespace Home_Work
{
    // константы для меню
    internal enum Cmd
    {
        PointExit,
        PointOne,
        PointTwo,
        PointThree,
        PointFour,
        PointFive,
        PointSix,
        PointSeven,
        PointEight,
        PointNine,
        PointTen,
        PointEleven,
        PointTwelve,
        PointThirteen,
        PointFourteen
    }

    public partial class App
    {

        #region Меню заданий 

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
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 1. Одномерный массив");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 2. Игрушка");
                Console.SetCursorPosition(x, y++); Console.WriteLine("Задание 3. Магазин");
                Console.SetCursorPosition(x, ++y); Console.WriteLine("0. Выход");

                y += 4;

                // ввод номера задания
                Console.SetCursorPosition(x, y); Console.Write("Введите номер задания: ");
                if (!int.TryParse(Console.ReadLine(), out int n))
                    continue;

                // обработка ввода 
                switch (n)
                {
                    // выход
                    case (int)Cmd.PointExit:
                        // позициониаровние курсора 
                        Console.SetCursorPosition(2, y + 5);
                        return;

                    // Задание 1. Название задания
                    case (int)Cmd.PointOne:
                        // запуск задания 
                        DemoTask1();
                        break;

                    // Задание 2. Название задания
                    case (int)Cmd.PointTwo:
                        // запуск задания 
                        DemoTask2();
                        break;

                    // Задание 3. Магазин
                    case (int)Cmd.PointThree:
                        // запуск задания 
                        DemoTask3();
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

        #region Утилиты

        // объект Random для заполнения массивов
        public static Random rand = new Random();

        // получение случайного вещественного числа в диапазоне (min, max]
        public static double GetDouble(int min, int max) => rand.Next(min, max) + rand.NextDouble();

        // вывод сообщения в цвете 
        public static void WriteColor(string msg, ConsoleColor textColor, ConsoleColor backColor = ConsoleColor.Black)
        {
            // текущий цвет 
            ConsoleColor tempText = Console.ForegroundColor;
            ConsoleColor tempBack = Console.BackgroundColor;

            // установк цвета
            SetColor(textColor, backColor);

            // вывод сообщения 
            Console.Write(msg);

            // возвращение цвета 
            SetColor(tempText, tempBack);
        }

        // вывод сообщения в цвете и позиционированием 
        public static void WriteColorXY(string msg = "", int posX = -1, int posY = -1, ConsoleColor textColor = ConsoleColor.White, ConsoleColor backColor = ConsoleColor.Black)
        {
            // позиционирование курсора
            PosXY(posX == -1 ? Console.CursorLeft : posX, posY == -1 ? Console.CursorTop : posY);

            // вывод сообщения в цвете
            WriteColor(msg, textColor, backColor);
        }

        // вывод сообщения о неправильно введённых данных, с указанием позиции
        public static void MsgErrorData(int posX = 0, int posY = -1, string msg = "Данные неверны!")
        {
            // вывод сообщения 
            WriteColorXY(msg, posX, posY == -1 ? Console.CursorTop - 1 : posY, ConsoleColor.Black, ConsoleColor.Red);

            // задержка по времени
            Thread.Sleep(500);
        }

        // позиционирование курсора
        public static void PosXY(int posX, int posY) => Console.SetCursorPosition(posX, posY);

        // установка цвета текста 
        public static void SetColor(ConsoleColor color) => Console.ForegroundColor = color; // SetColor

        // установка цвета текста и фона 
        public static void SetColor(ConsoleColor textColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = textColor;
            Console.BackgroundColor = backColor;
        } // SetColor

        // вывод сообщения в первой строке консоли
        public static void ShowNavBarMessage(string msg)
        {
            // установка цвета
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkBlue;

            // позиционирование курсора
            Console.SetCursorPosition(0, 0);

            // заполенение первой строки цветом 
            Console.WriteLine($"{' ',120}");

            // позиционирование курсора
            Console.SetCursorPosition(2, 0);

            // вывод сообщения 
            Console.WriteLine(msg);

            // позиционирование курсора
            Console.SetCursorPosition(0, 3);

            Console.ResetColor();
        } // ShowNavBarMessage

        #endregion
    }
}
