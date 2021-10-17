using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home_Work.Models.Task2;                   // для использования классов первого задания

using static Home_Work.Application.App.Utils;   // для использования утилит

namespace Home_Work.Controllers
{
    // Класс Обработка по заданию 2
    internal class Task2
    {
        // коллекция студентов
        Student[] _students = new Student[15];

        #region Методы 

        #region Конструкторы

        // конструктор по умолчанию
        public Task2()
        {
            // установка значений
            Initialization();
        }

        #endregion

        #region Инициализация

        // инициализация
        public void Initialization()
        {
            // инициалы
            string[] initials = new string[5]
            {
                " А.С.",
                " М.К.",
                " Д.Ф.",
                " Я.Р.",
                " П.О."
            };

            // фамилии
            string[] surnames = new string[10]
            {
                "Щербаков",
                "Исаев",
                "Давыдов",
                "Устинов",
                "Ларин",
                "Пирогов",
                "Баранов",
                "Николаев",
                "Марков",
                "Макеев",
            };

            // название групп
            string[] groups = new string[3]
            {
                "Экономическая",
                "Математическая",
                "Информационная"
            };

            // заполнение коллекции студентов
            for (int i = 0; i < _students.Length; i++)
                _students[i] = new Student
                {
                    Name = surnames[rand.Next(0, surnames.Length)] + initials[rand.Next(0, initials.Length)],
                    Group = groups[rand.Next(0, groups.Length)],
                    Marks = FactoryMethodStudent()
                };
        }

        // фабричный метод для создания массива оценок
        private Student.Mark[] FactoryMethodStudent()
        {
            // количество уроков 
            const int countLess = 5;

            // уроки
            string[] lessons = new string[countLess]
            {
                "Алгебра",
                "Геометрия",
                "Английский",
                "Биология",
                "История",
            };

            // массив оценок
            Student.Mark[] marks = new Student.Mark[countLess];

            for (int i = 0; i < countLess; i++)
                marks[i] = new Student.Mark { Name = lessons[i], MarkValue = rand.Next(2, 6) };

            return marks;
        }

        #endregion 

        #region Выборка студентов, у которых есть оценка 2

        // выборка студентов, у которых есть оценка 2
        public Student[] SelectByMarkTwo()
        {
            // массив отобранных студентов
            Student[] select = new Student[_students.Length];

            // предикатор 
            bool Pred(Student s) => IsMark(s, 2);

            // индекс по массиву отобранных 
            int i = 0;

            // поиск студентов
            foreach (var item in _students)
                if (Pred(item)) select[i++] = item;

            // коррекция размера массива
            Array.Resize(ref select, i);

            return select;
        }

        #endregion

        #region Выборка студентов, у которых есть оценки только 4 и 5

        // выборка студентов, у которых есть оценки только 4 и 5
        public Student[] SelectByMarkFourFive()
        {
            // массив отобранных студентов
            Student[] select = new Student[_students.Length];

            // предикатор 
            bool Pred(Student s) => !IsMark(s, 3, 2, 1);

            // индекс по массиву отобранных 
            int i = 0;

            // поиск студентов
            foreach (var item in _students)
                if (Pred(item)) select[i++] = item;

            // коррекция размера массива
            Array.Resize(ref select, i);

            return select;
        }

        #endregion

        #region Сотрировка массива по возрастанию среднего балла

        // сотрировка массива по возрастанию среднего балла
        public void SortAscendByAvgMark()
        {
            // компаратор 
            int Compare(Student s1, Student s2) => s1.Average.CompareTo(s2.Average);

            // сортировка 
            Array.Sort(_students, Compare);
        }

        #endregion

        #region Сотрировка массива по фамилиям и инициалам

        // сотрировка массива по фамилиям и инициалам
        public void SortByName()
        {
            // компаратор 
            int Compare(Student s1, Student s2) => s1.Name.CompareTo(s2.Name);

            // сортировка 
            Array.Sort(_students, Compare);
        }

        #endregion

        #region Перемешивание массива

        // перемешивание массива
        public void ShuffleStudents()
        {
            // перемешивание
            for (int i = 0; i < _students.Length; i++)
            {
                // индекс первого и второго элементов
                int index1 = rand.Next(0, _students.Length);
                int index2 = rand.Next(0, _students.Length);

                (_students[index1], _students[index2]) = (_students[index2], _students[index1]);
            }
                
        }

        #endregion

        #region Вывод студентов

        // вывод студнтов в таблицу
        public void ShowTable(string name = "Студенты", string info = "Исходные данные")
        {
            // вывод шапки таблицы
            ShowHead(_students.Length, name, info);

            // вывод элементов таблицы
            ShowElem(_students);

            // вывод подвала таблицы
            ShowLine();
        }

        // вывод шапки таблицы
        public void ShowHead(int size, string name = "Студенты", string info = "Исходные данные")
        {
            //                      10                            50                                                           79
            WriteColorXY("     ╔════════════╦═════════════════════════════════════════════════════╦═════════════════════════════════════════════════════════════════════════════════╗\n", textColor: ConsoleColor.Magenta);
            WriteColorXY("     ║            ║                                                     ║                                                                                 ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("Размер: ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{size,2}", textColor: ConsoleColor.Green);
            WriteColorXY("Название: ", 20, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{name,-40}", textColor: ConsoleColor.Green);
            WriteColorXY("Инфо: ", 74, textColor: ConsoleColor.DarkYellow);
            WriteColorXY($"{info,-72}", textColor: ConsoleColor.Green);
            Console.WriteLine();

            //                    2          15           5       5       5              20                          30
            WriteColorXY("     ╠════╦═══════╩═════════╦═════════════════╦═════════════════╦═══════╩═════════╦═════════════════╦═════════════════╦═════════════════╦═════════════════╣\n", textColor: ConsoleColor.Magenta);
            //                    2         15                15                 15                 15
            WriteColorXY("     ║    ║                 ║                 ║                 ║                 ║                 ║                 ║                 ║                 ║", textColor: ConsoleColor.Magenta);
            WriteColorXY("N ", 7, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("    Группа     ", 12, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" ФИО студента  ", 30, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("    Алгебра    ", 48, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Геометрия   ", 66, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("  Английский   ", 84, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("   Биология    ", 102, textColor: ConsoleColor.DarkYellow);
            WriteColorXY("    История    ", 120, textColor: ConsoleColor.DarkYellow);
            WriteColorXY(" Средний балл  ", 138, textColor: ConsoleColor.DarkYellow);
            Console.WriteLine();
            WriteColorXY("     ╠════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╬═════════════════╣\n", textColor: ConsoleColor.Magenta);

        }

        // вывод элементов таблицы
        public void ShowElem(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
                students[i].ShowElem(i + 1);
        }

        // вывод подвала таблицы
        public void ShowLine() =>
            WriteColorXY("     ╚════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╩═════════════════╝\n", posY: Console.CursorTop - 1, textColor: ConsoleColor.Magenta);

        #endregion

        #region Общие матоды 

        // поиск на наличие переданных оценок у студента 
        private bool IsMark(Student student, params int[] marks)
        {
            // поиск оценок 
            for (int i = 0; i < student.Lenght; i++)
                if (Pred(student[i].MarkValue)) return true;

            // предикатор для поиска по массиву параметров
            bool Pred(int mark)
            {
                // поиск по коллекции переданных оценок
                foreach (var item in marks)
                    if (item == mark)
                        return true;

                return false;
            }

            return false;
        }

        #endregion 

        #endregion
    }
}
