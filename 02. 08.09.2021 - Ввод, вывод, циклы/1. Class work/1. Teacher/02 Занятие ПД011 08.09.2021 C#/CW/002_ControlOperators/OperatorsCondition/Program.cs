using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperatorsCondition
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(100, 30);
            Console.Title = "Занятие 08.09.2021 - операторы ветвления, логические операции";

            // Условные операторы рассмотрим на примере решения 
            // простых задач
            // If28();
            // If30();

            // оператора switch
            // Switch();

            // пример на оператор switch
            Case7();

            Console.WriteLine();
        } // Main

        /* 
         * Дан номер года (положительное целое число). Определить количество 
         * дней в этом году, учитывая, что обычный год насчитывает 365 дней, 
         * а високосный — 366 дней. Високосным считается год, делящийся на 4, 
         * за исключением тех годов, которые делятся на 100 и не делятся на 400 
         * (например, годы 300, 1300 и 1900 не являются високосными, а 1200 и 
         * 2000 — являются).
         */
        static void If28()
        {
            int y, d;

            Console.Write("\nIf28: Год? ");
            y = Convert.ToInt32(Console.ReadLine());

            d = 365;

            // Синтаксис if() полностью совпадает с синтаксисом 
            // языка C
            // Те же условные операции < <= != == >= >
            // !
            // && ||   - с кратким способом вычисления 
            // НО!!!!
            // Дополнительно - операторы с длинным способом вычислений
            // & - логическое И с обязательным вычислением операндов
            // | - логияеское ИЛИ с обязательным вычислением операндов
            // И еще одна операция
            // ^ - ИСКЛЮЧАЮЩЕЕ ИЛИ, НЕЭКВИВАЛЕНТНОСТЬ
            // x1      x2      y = x1 ^ x2
            // false   false   false
            // false   true    true
            // true    false   true
            // true    true    false

            if (y % 4 == 0) {
                d++;
                if (y % 100 == 0 && y % 400 != 0) d--;
            } // if

            // форматированный вывод
            Console.WriteLine($"\nIf28: В году {y} дней {d}");

            // еще один вариант вывода с неявным вызовом метода ToString()
            // для нестроковых объектов
            // Console.WriteLine("\nIf28: В году " + y + " дней " + d);
        } // If28


        /*  Дано целое число, лежащее в диапазоне 1–999. Вывести его строку
         *  описание вида «четное двузначное число», «нечетное трехзначное 
         *  число» и т. д.
         */
        static void If30()
        {
            int n;         // исследуемое число
            string desc;   // строка-описание числа 

            // Ввод и валидация данных
            // При помощи класса Environment можно многое узнать о системе
            Console.Write($"\nIf30: Привет, {Environment.UserName}." +
                          $"\n      Введите целое число (1, ..., 999): ");
            n = Convert.ToInt32(Console.ReadLine());
            if (n < 1 || n > 999) {
                ConsoleColor oldColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nЧисло должно быть в диапазоне от 1 до 999\n");
                Console.ForegroundColor = oldColor;
                Environment.Exit(0);
            } // if

            // проверка на четность при помощи битовой операции
            // битовые операции:
            // ~ инверсия
            // & И 
            // | ИЛИ
            // ^ ИСКЛЮЧАЮЩЕЕ ИЛИ
            desc = (n & 1) == 0 ? "четное" : "нечетное";
            // desc = n % 2 == 0 ? "четное" : "нечетное";

            // проверка на количество десятичных разрядов
            if (n < 10)
                desc += " однозначное";
            else if (n < 100)
                desc += " двузначное";
            else
                desc += " трехзначное";

            // завершение описания числа
            desc += " число";

            // вывод результата
            Console.WriteLine($"\nIf30: Вы ввели число {n}, его описание \"{desc}\"");
        } // If30

        // статический объект для формирования случайных чисел
        // статический объект - в ед. экземпляре
        // создание нового объекта - оператор new
        // Класс имяОбъекта = new Класс(параметры);
        static private Random rand = new Random();

        // оператор switch
        static void Switch() {
            string season;         // команда, предполагаем, что это название времени года
            int MinTemp, MaxTemp;  // диапазон температур

            // главный цикл приложения
            while (true) {
                // ввод команды
                Console.Write("\nНазвание времени года (\"числа\" - поток случайных чисел, \"выход\" - для выхода): ");
                season = Console.ReadLine();
                Console.WriteLine();

                // обработка команды
                switch (season.ToLower()) {  // перевести строку в нижний регистр
                    case "зима":
                        MinTemp = rand.Next(-30, 6);
                        MaxTemp = MinTemp + rand.Next(5, 15);
                        Console.WriteLine($"Лежит снег, температура от {MinTemp} до {MaxTemp}");
                        break;
                    case "весна":
                        MinTemp = rand.Next(-5, 15);
                        MaxTemp = MinTemp + rand.Next(5, 15);
                        Console.WriteLine($"Появились подснежники, температура от {MinTemp} до {MaxTemp}");
                        goto default;
                    case "лето":
                        MinTemp = rand.Next(15, 25);
                        MaxTemp = MinTemp + rand.Next(5, 15);
                        Console.WriteLine($"Солнце, ставок и степь, температура от {MinTemp} до {MaxTemp}");
                        goto case "осень";
                    case "осень":
                        Console.WriteLine("Дыни и кукуруза");
                        goto default;
                    default:
                        Console.WriteLine("А иногда идет дождь");
                        break;
                    case "выход":
                        // Завершение работы приложения с кодом 0
                        // Environment.Exit(0);
                        return;
                    case "числа":Randoms();
                        break;
                } // switch
            } // while
        } // Switch


        // Формирование потока целых чисел
        private static void Randoms()
        {
            // демонстрация цикла for()
            for (int i = 0; i < 100; i++) {
                int x = rand.Next(-10, 11); // фактически диапазон: -10, ..., 10
                // вывод переменной x в поле шириной 6 символов
                Console.Write($"{x, 6}");
                if ((i + 1) % 10 == 0) Console.WriteLine();
            } // for i

            Console.WriteLine();
        } // Randoms

        // пример решения задачи Case7
        static void Case7()
        {
            int cod;              // код едиинцы массы
            double massa, kilos;  // введенная масса и масса в килограммах
            string desc;          // строка-описание для названия единицы массы

            while (true) {
                // Ввод кода единицы массы
                Console.Write("\n1 - кг\n2 - мг\n3 - г\n4 - т\n5 - ц\n0 - выход : ");
                int.TryParse(Console.ReadLine(), out cod);
                if (cod == 0) break;

                // Запомнить описание единицы массы 
                switch(cod) {
                    case 1: desc = "кг"; break;
                    case 2: desc = "мг"; break;
                    case 3: desc = "г"; break;
                    case 4: desc = "т"; break;
                    case 5: desc = "ц"; break;
                    default: continue;
                } // switch

                // Ввод массы в выбранных единицах
                Console.Write("\nВведите массу в " + desc + ": ");
                double.TryParse(Console.ReadLine(), out massa);

                // Преобразование введенной массы в кг
                switch (cod) {
                    case 1: kilos = massa; break;
                    case 2: kilos = massa / 1_000_000; break;
                    case 3: kilos = massa / 1000; break;
                    case 4: kilos = massa * 1000; break;
                    case 5: kilos = massa * 100; break;
                    default: continue;
                } // switch

                Console.WriteLine($"\nВы ввели {massa:n} {desc}, в килограммах это составит: {kilos:n}");
            } // while
        } // Case7
    } // class Program
}
