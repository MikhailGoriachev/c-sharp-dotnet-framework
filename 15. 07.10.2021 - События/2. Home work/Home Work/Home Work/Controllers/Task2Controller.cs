using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Home_Work.Models.Task2;                       // подключение моделей

using static Home_Work.Application.App.Utils;       // подключение утилит


namespace Home_Work.Controllers
{
    // Класс Обработка по заданию 2
    internal class Task2Controller
    {
        // коллекция персон
        public Person[] Persons { get; set; }

        #region Конструкторы 

        // констурктор по умолчанию
        public Task2Controller()
        {
            // установка занчений
            Initialization();
        }

        #endregion

        #region Методы

        #region Инициализация персон

        // инициализация персон
        public void Initialization(int size = 10)
        {
            // выделение пямяти под массив
            Persons = new Person[size];

            // заполнение массива
            for (int i = 0; i < size; i++)
            {
                Persons[i] = FactoryMethodPerson();
                Persons[i].Id = i + 1;
            }
        }

        // фабричный метод персоны
        public Person FactoryMethodPerson()
        {
            // массив фамилий
            string[] surnames = new string[]
            {
                "Тихонова ",
                "Терентьева ",
                "Тарасов ",
                "Зайцева ",
                "Петров ",
                "Дмитриева ",
                "Корнев ",
                "Севастьянов ",
                "Денисов ",
                "Смирнов "
            };

            // массив инициалов
            string[] init = new string[]
            {
                "С. М.",
                "Е. И.",
                "Д. А.",
                "С. С.",
                "Т. М.",
                "А. Д.",
                "К. Я.",
                "Я. Ф.",
                "М. В.",
                "К. Д."
            };

            // персона 
            return new Person
            {
                Age = rand.Next(21, 41),
                City = GenCity(),
                Name = surnames[rand.Next(0, surnames.Length)] +
                        init[rand.Next(0, init.Length)]
            };
        }

        // получение слуйчайного города
        private string GenCity()
        {
            // массив городов
            string[] city = new string[]
            {
                "Рыбинск",
                "Триест",
                "Малмыж",
                "Сан-Себастьян",
                "Гверу",
                "Луцк",
                "Сува",
                "Габороне",
                "Тимашевск",
                "Харбин"
            };

            return city[rand.Next(0, city.Length)];
        }

        #endregion

        #region Изменение персон

        // изменение персон
        public void Change()
        {
            // выключение курсора 
            Console.CursorVisible = false;

            // текущий заголовок окна
            string tittle = Console.Title;

            // подписка на события
            Subscribe();

            // вывод клавиш для управления
            ShowKey();

            // вывод таблицы с персонами
            ShowTable(info: "Данные для изменения");

            // считанная клавиша
            ConsoleKey key;

            // считывание клавиши
            while (true)
            {
                // клавиша 
                key = Console.ReadKey(true).Key;

                // проверка клавиши
                switch (key)
                {
                    // выход
                    case ConsoleKey.Escape:
                        // включение курсора 
                        Console.CursorVisible = false;
                        // установка заголовка окна (т.к. он может быть изменён при обработке по заданию)
                        Console.Title = tittle;
                        return;

                    // изменение возраста
                    case ConsoleKey.Q:
                        AgeChangeRandomPerson();
                        break;

                    // изменение города проживания
                    case ConsoleKey.W:
                        CityChangeRandomPerson();
                        break;

                    default:
                        continue;
                }
            }
        }

        // вывод клавиш для управления
        private void ShowKey()
        {
            WriteColorXY("     ╔════════════════════════════════╦════════════════════════════════╦════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║                                ║                                ║                                ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Изменение возраста: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Q", textColor: ConsoleColor.Cyan);
            WriteColorXY($"Изменение города: ", 40, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("W", textColor: ConsoleColor.Cyan);
            WriteColorXY("Выход: ", 73, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Esc", textColor: ConsoleColor.Cyan);
            Console.WriteLine();
            WriteColorXY("     ╚════════════════════════════════╩════════════════════════════════╩════════════════════════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        // подписка на события
        private void Subscribe()
        {
            Array.ForEach(Persons, item =>
            {
                // подписка на события Наблюдатель 1
                item.Childhood += LambdaChildhoodEventHandler;

                // подписка на события Наблюдатель 2
                item.Childhood += Observer1.ChildhoodEventHandler;

                // подписка на события Наблюдатель 3
                item.Childhood += ChildhoodEventHandler;

                // подписка на события Наблюдатель 1
                item.Relocate += RelocateEventHandler;

                // подписка на события Наблюдатель 2
                item.Relocate += LambdaRelocateEventHandler;
            });
        }

        // изменение возраста случайной персоны
        private void AgeChangeRandomPerson()
        {
            // индекс персоны
            int index = rand.Next(0, Persons.Length);

            // новые данные возраста 
            int age = rand.Next(15, 25);

            // вывод новых данных
            WriteColorXY($"{Persons[index].Name,-20}", 8, (Persons[index].Id * 2) + 9 , textColor: ConsoleColor.Cyan);
            WriteColorXY($"{age,30}", 31, (Persons[index].Id * 2) + 9, textColor: ConsoleColor.Cyan);

            // изменение данных
            Persons[index].Age = age;
        }

        // изменение города проживания случайной персоны
        private void CityChangeRandomPerson()
        {
            // индекс персоны
            int index = rand.Next(0, Persons.Length);

            // новые данные возраста 
            string city = GenCity();

            // вывод новых данных
            WriteColorXY($"{city,-20}", 64, (Persons[index].Id * 2) + 9, textColor: ConsoleColor.Green);

            // изменение данных
            Persons[index].City = city;
        }

        #endregion

        #region Вывод персон в виде таблицы

        // вывод персон в виде таблицы
        public void ShowTable(string name = "Персоны", string info = "Исходные данные")
        {
            // вывод таблицы (делегирование)
            Person.ShowTable(Persons, name, info);
        }

        #endregion

        #region Обработчик события Childhood

        // обработчик события Childhood
        public void ChildhoodEventHandler(Object sender, ChildhoodEventArgs e)
        {
            /*
             * Подсчитывание общего количества персон с возрастом < 21
             * года, выводить это количество некоторым цветом в консоль,
             * в строку заголовка таблицы
             */

            // количество персон с возрастом < 21
            int count = 0;

            // подсчитывание персон с возрастом < 21
            Array.ForEach(Persons, item => count += item.Age < 21 ? 1 : 0);

            // текущая позиция курсора
            (int x, int y) curPos = (Console.CursorLeft, Console.CursorTop);

            // вывод количества персон с возрастом < 21 в таблицу
            WriteColorXY($"{count,3}", 114, 7, ConsoleColor.Green);

            // установка курсора в исходную позицию 
            Console.SetCursorPosition(curPos.x, curPos.y);
        }

        // обработчик события Childhood лямбда 
        public ChildhoodEvent LambdaChildhoodEventHandler = (sender, e) =>
            {
                // приведение типа 
                Person p = sender as Person;

                WriteColorXY($"{p?.Name,-20}", 8, (p?.Id * 2) + 9 ?? 0, textColor: ConsoleColor.Red);
                WriteColorXY($"{p?.Age,3} Возраст меньше допустимого", 31, (p?.Id * 2) + 9 ?? 0, textColor: ConsoleColor.Red);
                Console.WriteLine();
            };

        #endregion

        #region Обработчик события Relocate

        // обработчик события Relocate лямбда
        public RelocateEvent LambdaRelocateEventHandler = (sender, e) =>
        {
            // приведение типа 
            Person p = sender as Person;

            // заполнение поля пробелами
            WriteColorXY($"  ".PadRight(30), 87, (p?.Id * 2) + 9 ?? 0, textColor: ConsoleColor.Red);

            // вывод данных
            WriteColorXY($"{e.OldSity} --> {e.NewSity}", 87, (p?.Id * 2) + 9 ?? 0, textColor: ConsoleColor.Red);
            Console.WriteLine();
        };

        // обработчик события Relocate
        public void RelocateEventHandler(Object sender, RelocateEventArgs e)
        {
            // города и количество персон в них
            (string city, int count)[] infoCity = new (string city, int count)[Persons.Length];

            int k = 0;

            // подсчитывание 
            for (int i = 0; i < Persons.Length; i++)
            {
                // поиск информации о текущем городе 
                int index = Array.FindIndex(infoCity, item => Persons[i].City == item.city);

                // если текущего города не найдено 
                if (index == -1)
                {
                    // добавление города в массив
                    infoCity[k++] = (Persons[i].City, 1);

                    continue;
                }

                // добавление количества персон в городе
                infoCity[index].count++;
            }

            // форматирование массива 
            Array.Resize(ref infoCity, k);

            // вывод городов и количества жителей
            ShowCityCount(infoCity);
        }

        // вывод городов и количества жителей
        private void ShowCityCount((string city, int count)[] infoCity)
        {
            // текущая позиция курсора
            (int x, int y) curPos = (Console.CursorLeft, Console.CursorTop);

            // позиция по y
            int y = 30;

            Console.CursorTop = y + 2;

            // вывод городов и значений
            ShowHeadCityCount(infoCity.Length);
            ShowFrameCityCount(Persons.Length);
            PosXY(0, Console.CursorTop - (Persons.Length + 1));
            int num = 1; Array.ForEach(infoCity, item => ShowElementCityCount(num++, item));

            // установка курсора в исходную позицию 
            Console.SetCursorPosition(curPos.x, curPos.y);
        }

        // вывод шапки таблицы с городами и количеством жителей
        private void ShowHeadCityCount(int size)
        {
            WriteColorXY("     ╔════════════╦════════════════════════════════╦════════════╗\n", 0, textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                ║            ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("      Название города       ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("Количество", 53, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();

            //                        2             20                   30                            20
            WriteColorXY("     ╠════════════╬════════════════════════════════╬════════════╣\n", textColor: ConsoleColor.Magenta);
        }

        // вывод шапки таблицы с городами и количеством жителей
        private void ShowFrameCityCount(int size)
        {
            for(int i = 0; i < size; i++) 
                WriteColorXY("     ║            ║                                ║            ║\n", textColor: ConsoleColor.Magenta);

            // вывод подвала таблицы
            ShowLineCityCount();
        }

        // вывод элемента таблицы с городами и количеством жителей
        private void ShowElementCityCount(int num, (string city, int count) infoCity)
        {
            WriteColorXY($"{num,10}", 7, textColor: ConsoleColor.DarkGray);
            WriteColorXY($"{infoCity.city, -30}", 20, textColor: ConsoleColor.Cyan);
            WriteColorXY($"{infoCity.count, 10}", 53, textColor: ConsoleColor.Green);
            Console.WriteLine();
        }

        // вывод подвала таблицы с городами и количеством жителей
        private void ShowLineCityCount()
        {
            WriteColorXY("     ╚════════════╩════════════════════════════════╩════════════╝\n", textColor: ConsoleColor.Magenta);
        }

        #endregion

        #endregion

    }
}
